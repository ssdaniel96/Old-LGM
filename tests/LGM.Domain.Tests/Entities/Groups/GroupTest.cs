using FluentAssertions;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Entities.People;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Enums.Groups;
using LGM.Domain.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace LGM.Domain.Tests.Entities.People;

public class GroupTest
{

    private GroupIdentity GetValidGroupIdentty()
    {
        return new(11231233, SourceTypeEnum.Telegram);
    }


    [Fact]
    public void Create_Valid_NoExceptions()
    {
        Action createGroup = () => _ = new Group("Descrição válida", GetValidGroupIdentty());
        createGroup.Should().NotThrow<Exception>();
    }

    [Fact]
    public void Create_Valid_Expected()
    {
        var expected = new
        {
            Description = "Descrição válida",
            Members = new List<Member>().AsReadOnly(),
            ReadingPlans = new List<ReadingPlan>().AsReadOnly(),
            GroupIdentity = new
            {
                Id = 0,
                SourceId = 11231233,
                SourceTypeEnum = SourceTypeEnum.Telegram
            }

        };

        var group = new Group("Descrição válida", GetValidGroupIdentty());

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
        Action createGroup = () => _ = new Group(invalidDescription, GetValidGroupIdentty());
        createGroup.Should().Throw<Exceptions.Validations.ValidationException>();
    }
}

