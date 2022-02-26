using LGM.Domain.Entities.Base;
using LGM.Domain.Validators.Entities.People;

namespace LGM.Domain.Entities.People
{
    public sealed class Collaborator : Entity
    {
        public string Name { get; private set; }

        public IReadOnlyCollection<Squad> Squads => _squads.AsReadOnly();
        private readonly List<Squad> _squads = new();

        public Collaborator(string name)
        {
            CollaboratorValidator.ValidateName(name);
            Name = name;
        }
    }
}
