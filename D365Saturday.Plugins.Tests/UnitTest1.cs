using FakeXrmEasy;
using System;
using TypedEntities;
using Xunit;
using System.Linq;

namespace D365Saturday.Plugins.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_create_phone_call_history_on_create_of_a_phonecall()
        {
            var ctx = new XrmFakedContext();
            var plugCtx = ctx.GetDefaultPluginContext();

            ctx.ExecutePluginWith<PhoneCallCreatePlugin>(plugCtx);

            var historyRecords = ctx.CreateQuery<ultra_phonecallhistory>().ToList();
            Assert.Equal(1, historyRecords.Count);
        }
    }
}
