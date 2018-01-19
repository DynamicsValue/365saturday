using FakeXrmEasy;
using System;
using TypedEntities;
using Xunit;
using System.Linq;

namespace D365Saturday.Plugins.Tests
{
    public class PhoneCallCreatePluginTests
    {
        [Fact]
        public void Should_create_phone_call_history_on_create_of_a_phonecall_with_its_details()
        {
            var ctx = new XrmFakedContext();

            var contact = new Contact() { Id = Guid.NewGuid() };

            var phoneCall = new PhoneCall()
            {
                Id = Guid.NewGuid(),
                RegardingObjectId = contact.ToEntityReference(),
                PhoneNumber = "+34666666666" 
            };

            ctx.ExecutePluginWithTarget<PhoneCallCreatePlugin>(phoneCall);

            var historyRecords = ctx.CreateQuery<ultra_phonecallhistory>().ToList();
            Assert.Equal(1, historyRecords.Count);

            var historyRecord = historyRecords.First();
            Assert.Equal(phoneCall.PhoneNumber, historyRecord.ultra_phonenumber);
            Assert.Equal(phoneCall.RegardingObjectId.Id, historyRecord.ultra_contactid.Id);
        }

        [Fact]
        public void Shouldnt_create_a_duplicate_phone_call_history_record()
        {
            var ctx = new XrmFakedContext();

            var contact = new Contact() { Id = Guid.NewGuid() };
            
            var phoneCall = new PhoneCall()
            {
                Id = Guid.NewGuid(),
                RegardingObjectId = contact.ToEntityReference(),
                PhoneNumber = "+34666666666"
            };

            var existingPhoneCallHistory = new ultra_phonecallhistory()
            {
                Id = Guid.NewGuid(),
                ultra_contactid = contact.ToEntityReference(),
                ultra_phonenumber = phoneCall.PhoneNumber
            };
            ctx.Initialize(existingPhoneCallHistory);

            ctx.ExecutePluginWithTarget<PhoneCallCreatePlugin>(phoneCall);

            var historyRecords = ctx.CreateQuery<ultra_phonecallhistory>().ToList();
            Assert.Equal(1, historyRecords.Count);

            var historyRecord = historyRecords.First();
            Assert.Equal(phoneCall.PhoneNumber, historyRecord.ultra_phonenumber);
            Assert.Equal(phoneCall.RegardingObjectId.Id, historyRecord.ultra_contactid.Id);
        }
    }
}
