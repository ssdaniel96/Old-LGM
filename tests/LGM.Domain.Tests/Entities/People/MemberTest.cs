using FluentAssertions;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Entities.People;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Enums.Groups;
using LGM.Domain.Tests.Helpers;
using LGM.Domain.ValueObjects.Groups;
using System;
using System.Collections.Generic;
using Xunit;

namespace LGM.Domain.Tests.Entities.People;

public class MemberTest
{

    private static GroupIdentity GetValidGroupIdentity() => new("11231233", SourceTypeEnum.Telegram);

    private static Group GetValidGroup() => new("Descrição válida", GetValidGroupIdentity());

    [Fact]
    public void Create_Valid_NoExceptions()
    {
        Action createCollaborator = () => _ = new Member("Daniel Cajazeiro", GetValidGroup());
        createCollaborator.Should().NotThrow<Exception>();
    }

    [Fact]
    public void Create_Valid_Expected()
    {
        var expected = new
        {
            Name = "Daniel Cajazeiro",
            Group = new
            {
                Description = "Descrição válida",
                Members = new List<Member>().AsReadOnly(),
                ReadingPlans = new List<ReadingPlan>().AsReadOnly(),
                GroupIdentity = new
                {
                    SourceId = "11231233",
                    SourceTypeEnum = SourceTypeEnum.Telegram
                }
            }
        };

        var collaborator = new Member("Daniel Cajazeiro", GetValidGroup());

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
        Action createCollaborator = () => _ = new Member(invalidName, GetValidGroup());
        createCollaborator.Should().Throw<Exceptions.Validations.ValidationException>();
    }

}