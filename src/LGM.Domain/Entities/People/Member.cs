using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Groups;
using LGM.Domain.Validators.Entities.People;

namespace LGM.Domain.Entities.People
{
    public sealed class Member : Entity
    {
        public string Name { get; private set; }

        public Group Group { get; private set; }

        private Member() { }
        public Member(string name, Group @group)
        {
            CollaboratorValidator.ValidateName(name);
            Name = name;
            Group = @group;
        }
    }
}
