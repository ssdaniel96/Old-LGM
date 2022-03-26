using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.People;
using LGM.Domain.Validators.Entities.Lectures;

namespace LGM.Domain.Entities.Readings
{
    public sealed class Reminder : Entity
    {
        public Member KickOf { get; private set; }
        public Member Responsible { get; private set; }
        public Member Prayer { get; private set; }
        public int Chapter { get; private set; }
        public int PageNumber { get; private set; }
        public int Paragraph { get; private set; }

        private Reminder() { }
        public Reminder(
            Member kickOf,
            Member responsible,
            Member prayer,
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
