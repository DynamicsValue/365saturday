using D365Saturday.Plugins.Commands;
using FakeXrmEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypedEntities;
using Xunit;

namespace D365Saturday.Plugins.Tests.Commands
{
    public class CreateContactCommandTest
    {
        public CreateContactCommandTest()
        {

        }

        [Fact]
        public void Should_create_contact_record()
        {
            Assert.True(false);
        }

        [Fact]
        public void Should_not_create_duplicate_contact_record()
        {
            Assert.True(false); 
        }


        /*   
             //Create
            var ctx = new XrmFakedContext();
            var service = ctx.GetOrganizationService();

            var cmd = new CreateContactCommand() { };
            var result = cmd.Execute(service);

            var contacts = ctx.CreateQuery<Contact>().ToList();
            Assert.Single(contacts);

            
         

            //Existing

            var ctx = new XrmFakedContext();
            var service = ctx.GetOrganizationService();

            //var account
            var contact = new Contact() { Id = Guid.NewGuid(), EMailAddress1 = "jordi.montana@gmail.com" };

            ctx.Initialize(contact);
            var cmd = new CreateContactCommand() { EmailAddress = "jordi.montana@gmail.com" };
            var result = cmd.Execute(service);

            var contacts = ctx.CreateQuery<Contact>().ToList();
            Assert.Single(contacts);
         
         */
    }
}
