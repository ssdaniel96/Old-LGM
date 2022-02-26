using FluentAssertions;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Exceptions.Validations;
using System;
using Xunit;

namespace LGM.Domain.Tests.Entities.Readings
{
    public class ProgressionTest
    {

        [Fact]
        public void Create_Valid_NoExceptions()
        {
            int chapter = 1, pageNumber = 1, paragraph = 1;

            Action createProgression = () => _ = new Progression(chapter, pageNumber, paragraph);
            createProgression.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Create_Valid_Excepted()
        {
            int chapter = 1, pageNumber = 1, paragraph = 1;

            var expected = new
            {
                Id = 0,
                Chapter = 1,
                PageNumber = 1,
                Paragraph = 1
            };

            var progression = new Progression(chapter, pageNumber, paragraph);
            progression.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidChapter_Exception(int invalidChapter)
        {
            int pageNumber = 1, paragraph = 1;

            Action createProgression = () => _ = new Progression(invalidChapter, pageNumber, paragraph);
            createProgression.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidPageNumber_Exception(int invalidPageNumber)
        {
            int chapter = 1, paragraph = 1;

            Action createProgression = () => _ = new Progression(chapter, invalidPageNumber, paragraph);
            createProgression.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithInvalidParagraph_Exception(int invalidParagraph)
        {
            int chapter = 1, pageNumber = 1;

            Action createProgression = () => _ = new Progression(chapter, pageNumber, invalidParagraph);
            createProgression.Should().Throw<ValidationException>();
        }
    }
}
