using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Validators.Entities.Books;

namespace LGM.Domain.Entities.Books
{
    public sealed class Book : Entity
    {
        public string Author { get; private set; }
        public string Title { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalChapters { get; private set; }
        public Uri? Uri { get; private set; }
        public Group Group { get; private set; }

        private Book() { }
        public Book(string author, string title, int totalPages, int totalChapters, string? uri, Group @group)
        {
            BookValidator.Validate(author, title, totalPages, totalChapters, uri);
            Author = author;
            Title = title;
            TotalPages = totalPages;
            TotalChapters = totalChapters;
            Group = @group;
            Uri = uri == null ? null : new(uri);
        }
    }
}
