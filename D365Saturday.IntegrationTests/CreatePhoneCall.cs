using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Microsoft.Xrm.Tooling.Connector;
using TypedEntities;
using System.Linq;

namespace D365Saturday.IntegrationTests
{
    [TestClass]
    public class CreatePhoneCall
    {
        [TestMethod]
        public void CheckPhoneCallHistory()
        {
            string crmCon = ConfigurationManager.ConnectionStrings["crm"].ConnectionString;

            using (CrmServiceClient svc = new CrmServiceClient(crmCon))
            {
                Contact c = new Contact();
                c.FirstName = "Wael";
                c.LastName = Guid.NewGuid().ToString();
                c.MobilePhone = new Random().Next(100000000, 200000000).ToString();

                c.Id = svc.Create(c);

                PhoneCall p = new PhoneCall();
                p.RegardingObjectId = c.ToEntityReference();
                p.PhoneNumber = c.MobilePhone;

                p.Id = svc.Create(p);

                using (var ctx = new XrmServiceContext(svc))
                {

                    var exists = (from ph in ctx.CreateQuery<ultra_phonecallhistory>()
                                  where ph.ultra_contactid.Id == c.Id
                                  where ph.ultra_phonenumber == c.MobilePhone
                                  select ph).FirstOrDefault() != null;

                    Assert.IsTrue(exists);
                }
            }
        }
    }
}
