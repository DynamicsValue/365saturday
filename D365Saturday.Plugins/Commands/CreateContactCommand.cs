using D365Saturday.Plugins.Models;
using Microsoft.Xrm.Sdk;
using TypedEntities;
using System.Linq;

namespace D365Saturday.Plugins.Commands
{
    public class CreateContactCommand: BaseCommand
    {
        public string EmailAddress { get; set; }
        protected override GenericResult ConcreteExecute(IOrganizationService service)
        {
            var contact = new Contact() { EMailAddress1 = EmailAddress };

            using(var ctx = new XrmServiceContext(service))
            {
                var contactsExists = (from c in ctx.CreateQuery<Contact>()
                                      where c.EMailAddress1 == EmailAddress
                                      select c).FirstOrDefault() != null;

                if(!contactsExists)
                {
                    service.Create(contact);
                }
            }
            

            return new  GenericResult();
        }
    }
}
