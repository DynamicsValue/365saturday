using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypedEntities;

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

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                var target = context.InputParameters["Target"] as Entity;
                var phoneCall = target.ToEntity<PhoneCall>();

                var contact = phoneCall.RegardingObjectId;
                var phoneNumber = phoneCall.PhoneNumber;

                //query to create a phone history only if the pair [phonenumber, contact] doesn't exist
                using (var ctx = new XrmServiceContext(service))
                {
                    var exists = (from ph in ctx.CreateQuery<ultra_phonecallhistory>()
                                  where ph.ultra_contactid.Id == contact.Id
                                  where ph.ultra_phonenumber == phoneNumber
                                  select ph).FirstOrDefault() != null;

                    if(!exists)
                    {
                        //Create phone history record
                        var phoneHistory = new ultra_phonecallhistory()
                        {
                            ultra_contactid = contact,
                            ultra_phonenumber = phoneNumber,
                            ultra_lastcalldate = DateTime.Now
                        };
                        phoneHistory.Id = service.Create(phoneHistory);

                        //Phonecall then assigned to the created phonecall history
                        phoneCall.ultra_phonecallhistoryid = phoneHistory.ToEntityReference();

                    }
                    
                }
                    
            }
        }
    }
}
