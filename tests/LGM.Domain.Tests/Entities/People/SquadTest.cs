using FluentAssertions;
using LGM.Domain.Entities.People;
using LGM.Domain.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace LGM.Domain.Tests.Entities.People;

public class SquadTest
{
    [Fact]
    public void Create_Valid_NoExceptions()
    {
        Action createSquad = () => _ = new Squad("Descrição válida");
        createSquad.Should().NotThrow<Exception>();
    }

    [Fact]
    public void Create_Valid_Expected()
    {
        var expected = new
        {
            Name = "Nome válido",
            Collaborators = new List<Collaborator>().AsReadOnly()
        };

        var squad = new Squad("Nome válido");

        squad.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("ab")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("        ")]
    [InlineData(StringHelper._51Length)]
    public void Create_InvalidName_Exception(string invalidName)
    {
        Action createSquad = () => _ = new Squad(invalidName);
        createSquad.Should().Throw<Exceptions.Validations.ValidationException>();
    }
}

