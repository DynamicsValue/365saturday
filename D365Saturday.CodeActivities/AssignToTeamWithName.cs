using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypedEntities;

namespace D365Saturday.CodeActivities
{
    public class AssignToTeamWithName : CodeActivity
    {
        [Input("Team Name")]
        public InArgument<string> TeamName { get; set; }

        [Input("Entity Name")]
        public InArgument<string> EntityName { get; set; }

        [Input("Entity Id")]
        public InArgument<string> EntityId { get; set; }

        [Output("Succeeded")]
        public OutArgument<bool> Succeeded { get; set; }

        [Output("Error Message")]
        public OutArgument<string> ErrorMessage { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            #region Boilerplate
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory =
                executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service =
                serviceFactory.CreateOrganizationService(context.UserId);

            var tracing = executionContext.GetExtension<ITracingService>();
            #endregion

            var entityIdString = EntityId.Get(executionContext);
            Guid entityId = Guid.Empty;

            if(!Guid.TryParse(entityIdString, out entityId))
            {
                Succeeded.Set(executionContext, false);
                ErrorMessage.Set(executionContext, $"Guid {entityIdString} is not a valid GUID.");
                return;
            }

            var teamName = TeamName.Get(executionContext);
            using(var ctx = new XrmServiceContext(service))
            {
                var team = (from t in ctx.CreateQuery<Team>()
                                 where t.Name == teamName
                                 select t).FirstOrDefault();

                if(team == null)
                {
                    Succeeded.Set(executionContext, false);
                    ErrorMessage.Set(executionContext, $"Team {teamName} not found.");
                    return;
                }

                var logicalName = EntityName.Get(executionContext);
                var reference = (from r in ctx.CreateQuery(logicalName)
                            where (Guid) r[$"{logicalName}id"] == entityId
                            select r).FirstOrDefault();

                if (reference == null)
                {
                    Succeeded.Set(executionContext, false);
                    ErrorMessage.Set(executionContext, $"Entity Reference with logical name {logicalName} and id {entityIdString} wasn't found.");
                    return;
                }

                //Assign otherwise
                var assignRequest = new AssignRequest()
                {
                    Assignee = team.ToEntityReference(),
                    Target = reference.ToEntityReference()
                };
                service.Execute(assignRequest);
            }


            Succeeded.Set(executionContext, true);
        }
    }
}
