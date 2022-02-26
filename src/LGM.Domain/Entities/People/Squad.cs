using LGM.Domain.Entities.Base;
using LGM.Domain.Validators.Entities.People;

namespace LGM.Domain.Entities.People
{
    public sealed class Squad : Entity
    {
        public string Name { get; private set; }

        public IReadOnlyCollection<Collaborator> Collaborators { get; private set; } = new List<Collaborator>();

        public Squad(string name)
        {
            SquadValidator.IsValidName(name);
            Name = name;
        }

    }
}
