using FluentAssertions;
using LGM.Domain.Entities.Books;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Enums.Groups;
using LGM.Domain.Exceptions.Validations;
using LGM.Domain.Tests.Helpers;
using System;
using Xunit;

namespace LGM.Domain.Tests.Entities.Books
{
    public class BookTest
    {
        private static GroupIdentity GetValidGroupIdentity()
        {
            return new(11231233, SourceTypeEnum.Telegram);
        }

        private static Group GetValidGroup()
        {
            return new("Descrição válida", GetValidGroupIdentity());
        }


        [Fact]
        public void Create_Valid_NoExceptions()
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações",
                uri = "http://centrowhite.org.br/files/ebooks/egw/O%20Desejado%20de%20Todas%20as%20Na%C3%A7%C3%B5es.pdf";
            int totalPages = 400,
                totalChapters = 40;

            Action createBook = () => _ = new Book(author, title, totalPages, totalChapters, uri, GetValidGroup());
            createBook.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Create_ValidWithUriNull_NoExceptions()
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações";
            string? uri = null;
            int totalPages = 400,
                totalChapters = 40;

            Action createBook = () => _ = new Book(author, title, totalPages, totalChapters, uri, GetValidGroup());
            createBook.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Create_Valid_ReturnsExpected()
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações",
                uri = "http://centrowhite.org.br/files/ebooks/egw/O%20Desejado%20de%20Todas%20as%20Na%C3%A7%C3%B5es.pdf";
            int totalPages = 400,
                totalChapters = 40;

            var expectedBook = new
            {
                Id = 0,
                Author = author,
                Title = title,
                TotalPages = totalPages,
                TotalChapters = totalChapters,
                Uri = new Uri(uri)
            };

            Book book = new(author, title, totalPages, totalChapters, uri, GetValidGroup());

            book.Should().BeEquivalentTo(expectedBook);
        }

        [Fact]
        public void Create_ValidWithUriNull_ReturnsExpected()
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações";
            string? uri = null;
            int totalPages = 400,
                totalChapters = 40;

            var expectedBook = new
            {
                Id = 0,
                Author = author,
                Title = title,
                TotalPages = totalPages,
                TotalChapters = totalChapters,
                Uri = (Uri?)null
            };

            Book book = new(author, title, totalPages, totalChapters, uri, GetValidGroup());

            book.Should().BeEquivalentTo(expectedBook);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("ab")]
        [InlineData(StringHelper._51Length)]
        public void Create_InvalidAuthor_ThrowException(string invalidAuthor)
        {
            string title = "Desejado de Todas as Nações",
                uri = "http://centrowhite.org.br/files/ebooks/egw/O%20Desejado%20de%20Todas%20as%20Na%C3%A7%C3%B5es.pdf";
            int totalPages = 400,
                totalChapters = 40;

            Action createBook = () => _ = new Book(invalidAuthor, title, totalPages, totalChapters, uri, GetValidGroup());
            createBook.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("ab")]
        [InlineData(StringHelper._101Length)]
        public void Create_InvalidTitle_ThrowException(string invalidTitle)
        {
            string author = "Ellen G. White",
                uri = "http://centrowhite.org.br/files/ebooks/egw/O%20Desejado%20de%20Todas%20as%20Na%C3%A7%C3%B5es.pdf";
            int totalPages = 400,
                totalChapters = 40;

            Action createBook = () => _ = new Book(author, invalidTitle, totalPages, totalChapters, uri, GetValidGroup());
            createBook.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_InvalidTotalPages_ThrowException(int invalidTotalPages)
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações",
                uri = "http://centrowhite.org.br/files/ebooks/egw/O%20Desejado%20de%20Todas%20as%20Na%C3%A7%C3%B5es.pdf";
            int totalChapters = 40;

            Action createBook = () => _ = new Book(author, title, invalidTotalPages, totalChapters, uri, GetValidGroup());
            createBook.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_InvalidTotalChapters_ThrowException(int invalidTotalChapters)
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações",
                uri = "http://centrowhite.org.br/files/ebooks/egw/O%20Desejado%20de%20Todas%20as%20Na%C3%A7%C3%B5es.pdf";
            int totalPages = 400;

            Action createBook = () => _ = new Book(author, title, totalPages, invalidTotalChapters, uri, GetValidGroup());
            createBook.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("    ")]
        [InlineData("ab")]
        [InlineData("dwdwdw.r")]
        public void Create_InvalidUri_ThrowException(string invalidUri)
        {
            string author = "Ellen G. White",
                title = "Desejado de Todas as Nações";
            int totalPages = 400,
                totalChapters = 40;

            Action createBook = () => _ = new Book(author, title, totalPages, totalChapters, invalidUri, GetValidGroup());
            createBook.Should().Throw<ValidationException>();
        }

    }
}
