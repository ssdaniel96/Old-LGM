using FluentAssertions;
using LGM.Domain.Entities.Books;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Entities.People;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Enums.Groups;
using LGM.Domain.ValueObjects.Groups;
using System;
using System.Collections.Generic;
using Xunit;

namespace LGM.Domain.Tests.Entities.Readings;

public class ReadingPlanTest
{
    private static GroupIdentity GetValidGroupIdentity()
    {
        return new("11231233", SourceTypeEnum.Telegram);
    }

    private static Group GetValidGroup() => new("Espartanos", GetValidGroupIdentity());

    private static Book GetValidBook() => new(
        "Ellen G. White",
        "O Grande Conflito",
        700,
        50,
        "http://www.google.com",
        GetValidGroup());

    private static Progression GetValidProgression() => new(1, 1, 1);

    [Fact]
    public void Create_Valid_NoExceptions()
    {
        Action createReadingPlan =
            () => _ = new ReadingPlan(
                GetValidGroup(),
                GetValidBook(),
                GetValidProgression());

        createReadingPlan.Should().NotThrow<Exception>();
    }

    [Fact]
    public void Create_Valid_Expected()
    {
        var group = GetValidGroup();
        var book = GetValidBook();
        var progression = GetValidProgression();

        var expected = new
        {
            Id = 0,
            Group = new
            {
                Id = 0,
                Description = group.Description,
                Members = new List<Member>().AsReadOnly(),
                ReadingPlans = new List<ReadingPlan>().AsReadOnly(),
                GroupIdentity = new
                {
                    SourceId = "11231233",
                    SourceTypeEnum = SourceTypeEnum.Telegram
                }
            },
            Book = new
            {
                Id = 0,
                Author = book.Author,
                Title = book.Title,
                TotalPages = book.TotalPages,
                TotalChapters = book.TotalChapters,
                Uri = book.Uri
            },
            Progression = new
            {
                Chapter = progression.Chapter,
                PageNumber = progression.PageNumber,
                Paragraph = progression.Paragraph
            },
            Reminders = new List<Reminder>().AsReadOnly()
        };

        var readingPlan = new ReadingPlan(group, book, progression);

        readingPlan.Should().BeEquivalentTo(expected);
    }
}
