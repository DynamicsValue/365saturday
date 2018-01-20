using FakeXrmEasy;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using TypedEntities;
using Xunit;
using System.Linq;

namespace D365Saturday.CodeActivities.Tests
{
    public class AssignToTeamWithNameTests
    {
        [Fact]
        public void Should_return_error_if_team_name_doesnt_exists()
        {
            var ctx = new XrmFakedContext();

            Dictionary<string, object> inputs = new Dictionary<string, object>()
            {
                { "TeamName", "Non-existing team" }
            };
            var outputs = ctx.ExecuteCodeActivity<AssignToTeamWithName>(inputs);

            Assert.False((bool)outputs["Succeeded"]);
        }

        [Fact]
        public void Should_return_error_if_entity_id_is_not_a_valid_guid()
        {
            var ctx = new XrmFakedContext();

            var team = new Team() { Id = Guid.NewGuid(), Name = "Admin Team" };
            ctx.Initialize(team);

            Dictionary<string, object> inputs = new Dictionary<string, object>()
            {
                { "TeamName", "Admin Team" },
                { "EntityName", "contact" },
                { "EntityId", "asdasdadasd" }
            };
            var outputs = ctx.ExecuteCodeActivity<AssignToTeamWithName>(inputs);

            Assert.False((bool)outputs["Succeeded"]);
        }

        [Fact]
        public void Should_return_error_if_entity_reference_doesnt_exists()
        {
            var ctx = new XrmFakedContext();

            var team = new Team() { Id = Guid.NewGuid(), Name = "Admin Team" };
            ctx.Initialize(team);

            Dictionary<string, object> inputs = new Dictionary<string, object>()
            {
                { "TeamName", "Admin Team" },
                { "EntityName", "contact" },
                { "EntityId", Guid.NewGuid().ToString() }
            };
            var outputs = ctx.ExecuteCodeActivity<AssignToTeamWithName>(inputs);

            Assert.False((bool)outputs["Succeeded"]);
        }

        [Fact]
        public void Should_assign_target_to_specified_existing_team()
        {
            var ctx = new XrmFakedContext();

            var team = new Team() { Id = Guid.NewGuid(), Name = "Admin Team" };
            var contact = new Contact() { Id = Guid.NewGuid(), FirstName = "Leo", LastName = "Messi" };

            ctx.Initialize(new List<Entity>()
            {
                team, contact
            });

            Dictionary<string, object> inputs = new Dictionary<string, object>()
            {
                { "TeamName", "Admin Team" },
                { "EntityName", "contact" },
                { "EntityId", contact.Id.ToString() }
            };
            var outputs = ctx.ExecuteCodeActivity<AssignToTeamWithName>(inputs);

            Assert.True((bool)outputs["Succeeded"]);

            var contactAfter = ctx.CreateQuery<Contact>().FirstOrDefault();
            Assert.Equal(team.Id, contactAfter.OwnerId.Id);
        }

    }
}
