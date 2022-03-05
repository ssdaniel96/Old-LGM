using Bogus;
using FluentAssertions;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Entities.People;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Enums.Groups;
using System;
using Xunit;

namespace LGM.Domain.Tests.Entities.Readings
{
    public class ReminderTest
    {

        private static GroupIdentity GetValidGroupIdentity()
        {
            return new(11231233, SourceTypeEnum.Telegram);
        }

        private static Group GetValidGroup()
        {
            return new("Descrição válida", GetValidGroupIdentity());
        }

        private static Member GetValidCollaborator() => new(new Faker().Person.FullName, GetValidGroup());

        [Fact]
        public void Create_Valid_NoExceptions()
        {
            Action createReminder = () => _ = new Reminder(
                GetValidCollaborator(),
                GetValidCollaborator(),
                GetValidCollaborator(),
                1,
                1,
                1);

            createReminder.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Create_Valid_ReturnExpected()
        {
            string collaboratorName1 = new Faker().Person.FullName,
                collaboratorName2 = new Faker().Person.FullName,
                collaboratorName3 = new Faker().Person.FullName;

            Member collaborator1 = new(collaboratorName1, GetValidGroup()),
                collaborator2 = new(collaboratorName2, GetValidGroup()),
                collaborator3 = new(collaboratorName3, GetValidGroup());

            var expected = new
            {
                KickOf = new
                {
                    Id = 0,
                    Name = collaboratorName1
                },
                Responsible = new
                {
                    Id = 0,
                    Name = collaboratorName2
                },
                Prayer = new
                {
                    Id = 0,
                    Name = collaboratorName3
                },
                Chapter = 1,
                PageNumber = 1,
                Paragraph = 1
            };


            var reminder = new Reminder(
                collaborator1,
                collaborator2,
                collaborator3,
                1,
                1,
                1);

            reminder.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidChapter_ThrowsException(int invalidChapter)
        {
            Action createReminder = () => _ = new Reminder(
                GetValidCollaborator(),
                GetValidCollaborator(),
                GetValidCollaborator(),
                invalidChapter,
                1,
                1);

            createReminder.Should().Throw<Exceptions.Validations.ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidPage_ThrowsException(int invalidPage)
        {
            Action createReminder = () => _ = new Reminder(
                GetValidCollaborator(),
                GetValidCollaborator(),
                GetValidCollaborator(),
                1,
                invalidPage,
                1);

            createReminder.Should().Throw<Exceptions.Validations.ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidParagraph_ThrowsException(int invalidParagraph)
        {
            Action createReminder = () => _ = new Reminder(
                GetValidCollaborator(),
                GetValidCollaborator(),
                GetValidCollaborator(),
                1,
                1,
                invalidParagraph);

            createReminder.Should().Throw<Exceptions.Validations.ValidationException>();
        }
    }
}
