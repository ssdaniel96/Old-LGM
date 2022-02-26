// ReSharper disable CollectionNeverUpdated.Local
using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Lectures;

namespace LGM.Domain.Entities.People
{
    public sealed class Group : Entity
    {
        public string Description { get; private set; }
        public IReadOnlyCollection<Collaborator> Collaborators => _collaborators.AsReadOnly();
        private readonly List<Collaborator> _collaborators = new();

        public IReadOnlyCollection<LecturePlan> LecturePlans => _lecturePlans.AsReadOnly();
        private readonly List<LecturePlan> _lecturePlans = new();

        public Group(string description)
        {
            Description = description;
        }
    }
}