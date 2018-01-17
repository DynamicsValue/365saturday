using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365Saturday.Plugins
{
    public class PhoneCallCreatePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            #region Boilerplate
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service reference.
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            #endregion

            throw new NotImplementedException();
        }
    }
}
