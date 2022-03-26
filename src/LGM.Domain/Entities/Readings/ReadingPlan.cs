// ReSharper disable CollectionNeverUpdated.Local

using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Books;
using LGM.Domain.Entities.Groups;

namespace LGM.Domain.Entities.Readings
{
    public sealed class ReadingPlan : Entity
    {
        public Group Group { get; private set; }
        public Book Book { get; private set; }
        public Progression Progression { get; private set; }
        public int ProgressionId { get; private set; }
        public IReadOnlyCollection<Reminder> Reminders => _reminders.AsReadOnly();
        private readonly List<Reminder> _reminders = new();

        private ReadingPlan() { }
        public ReadingPlan(Group @group, Book book, Progression progression)
        {
            Group = @group;
            Book = book;
            Progression = progression;
            ProgressionId = progression.Id;
        }
    }
}
