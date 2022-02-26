using FluentAssertions;
using LGM.Domain.Entities.People;
using LGM.Domain.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace LGM.Domain.Tests.Entities.People
{
    public class CollaboratorTest
    {
        [Fact]
        public void Create_Valid_NoExceptions()
        {
            Action createCollaborator = () => _ = new Collaborator("Daniel Cajazeiro");
            createCollaborator.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Create_Valid_Expected()
        {
            var expected = new
            {
                Name = "Daniel Cajazeiro",
                Squads = new List<Squad>().AsReadOnly()
            };

            var collaborator = new Collaborator("Daniel Cajazeiro");

            collaborator.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("Al")]
        [InlineData(StringHelper._51Length)]
        public void Create_InvalidName_ThrowException(string invalidName)
        {
            Action createCollaborator = () => _ = new Collaborator(invalidName);
            createCollaborator.Should().Throw<Exceptions.Validations.ValidationException>();
        }

    }
}
