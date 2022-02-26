using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.People;
using LGM.Domain.Validators.Entities.Lectures;

namespace LGM.Domain.Entities.Lectures
{
    public sealed class Reminder : Entity
    {
        public Collaborator KickOf { get; private set; }
        public Collaborator Responsible { get; private set; }
        public Collaborator Prayer { get; private set; }
        public int Chapter { get; private set; }
        public int PageNumber { get; private set; }
        public int Paragraph { get; private set; }

        public Reminder(
            Collaborator kickOf,
            Collaborator responsible,
            Collaborator prayer,
            int chapter,
            int pageNumber,
            int paragraph)
        {
            ReminderValidator.Validate(pageNumber, chapter, paragraph);
            KickOf = kickOf;
            Responsible = responsible;
            Prayer = prayer;
            Chapter = chapter;
            PageNumber = pageNumber;
            Paragraph = paragraph;
        }
    }
}
