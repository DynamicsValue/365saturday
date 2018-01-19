using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365Saturday.CodeActivities
{
    public class RetrieveSystemParameter : CodeActivity
    {
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


            throw new NotImplementedException();
        }
    }
}
