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
    public class RetrieveSystemParameter : CodeActivity
    {
        [Input("Parameter Name")]
        public InArgument<string> ParameterName { get; set; }

        [Output("Parameter Value")]
        public OutArgument<string> ParameterValue { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            #region Bolierplate
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory =
                executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service =
                serviceFactory.CreateOrganizationService(context.UserId);

            var tracing = executionContext.GetExtension<ITracingService>();
            #endregion

            var parameterName = ParameterName.Get(executionContext);
            using(var ctx = new XrmServiceContext(service))
            {
                var parameter = (from p in ctx.CreateQuery<ultra_systemparameter>()
                                 where p.ultra_name == parameterName
                                 select p.ultra_parametervalue)
                                    .FirstOrDefault();

                if(parameter != null)
                {
                    ParameterValue.Set(executionContext, parameter);
                }
                
            }
        }
    }
}
