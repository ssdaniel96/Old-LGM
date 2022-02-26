// ReSharper disable CollectionNeverUpdated.Local
using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Books;
using LGM.Domain.Entities.People;

namespace LGM.Domain.Entities.Lectures
{
    public sealed class LecturePlan : Entity
    {
        public Group Group { get; private set; }
        public Book Book { get; private set; }
        public Progression Progression { get; private set; }
        public IReadOnlyCollection<Reminder> Reminders => _reminders.AsReadOnly();
        private readonly List<Reminder> _reminders = new();

        public LecturePlan(Group @group, Book book, Progression progression)
        {
            Group = @group;
            Book = book;
            Progression = progression;
        }
    }
}
