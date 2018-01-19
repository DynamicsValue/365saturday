using FakeXrmEasy;
using System;
using System.Collections.Generic;
using TypedEntities;
using Xunit;

namespace D365Saturday.CodeActivities.Tests
{
    public class RetrieveSystemParameterTests
    {
        [Fact]
        public void Should_retrieve_the_parameter_value_given_a_parameter_exists()
        {
            var ctx = new XrmFakedContext();

            var parameter = new ultra_systemparameter()
            {
                Id = Guid.NewGuid(),
                ultra_name = "Dummy Parameter Name",
                ultra_parametervalue = "Dummy value"
            };
            ctx.Initialize(parameter);

            Dictionary<string, object> inputs = new Dictionary<string, object>()
            {
                { "ParameterName", "Dummy Parameter Name" }
            };
            var outputs = ctx.ExecuteCodeActivity<RetrieveSystemParameter>(inputs);

            Assert.Equal("Dummy value", outputs["ParameterValue"]);

        }
    }
}
