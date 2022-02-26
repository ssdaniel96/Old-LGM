using FluentAssertions;
using LGM.Domain.Entities.People;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace LGM.Domain.Tests.Entities.People;

public class GroupTest
{
    [Fact]
    public void Create_Valid_NoExceptions()
    {
        Action createGroup = () => _ = new Group("Descrição válida");
        createGroup.Should().NotThrow<Exception>();
    }

    [Fact]
    public void Create_Valid_Expected()
    {
        var expected = new
        {
            Description = "Descrição válida",
            Collaborators = new List<Collaborator>().AsReadOnly(),
            ReadingPlans = new List<ReadingPlan>().AsReadOnly()
        };

        var group = new Group("Descrição válida");

        group.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("ab")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("        ")]
    [InlineData(StringHelper._101Length)]
    public void Create_InvalidDescription_Exception(string invalidDescription)
    {
        Action createGroup = () => _ = new Group(invalidDescription);
        createGroup.Should().Throw<Exceptions.Validations.ValidationException>();
    }
}

