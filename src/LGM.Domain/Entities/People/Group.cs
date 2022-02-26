// ReSharper disable CollectionNeverUpdated.Local
using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Readings;

namespace LGM.Domain.Entities.People
{
    public sealed class Group : Entity
    {
        public string Description { get; private set; }
        public IReadOnlyCollection<Collaborator> Collaborators => _collaborators.AsReadOnly();
        private readonly List<Collaborator> _collaborators = new();

        public IReadOnlyCollection<ReadingPlan> ReadingPlans => _readingPlans.AsReadOnly();
        private readonly List<ReadingPlan> _readingPlans = new();

        public Group(string description)
        {
            Description = description;
        }
    }
}