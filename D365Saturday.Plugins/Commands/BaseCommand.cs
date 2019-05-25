using D365Saturday.Plugins.Models;
using Microsoft.Xrm.Sdk;
using System;

namespace D365Saturday.Plugins.Commands
{
    public class BaseCommand
    {
        public GenericResult Execute(IOrganizationService service)
        {
            try
            {
                return ConcreteExecute(service);
            }
            catch(Exception ex)
            {
                return GenericResult.Error(ex.ToString());
            }
        }

        

        protected virtual GenericResult ConcreteExecute(IOrganizationService service)
        {
            throw new Exception("Must be overriden");
        }
    }
}
