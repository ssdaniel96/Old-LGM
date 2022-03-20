// ReSharper disable CollectionNeverUpdated.Local

using LGM.Domain.Entities.Base;
using LGM.Domain.Entities.Books;
using LGM.Domain.Entities.People;
using LGM.Domain.Entities.Readings;
using LGM.Domain.Validators.Entities.People;
using LGM.Domain.ValueObjects.Groups;

namespace LGM.Domain.Entities.Groups;

public sealed class Group : Entity
{
    public GroupIdentity GroupIdentity { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<Member> Members => _members.AsReadOnly();
    private readonly List<Member> _members = new();

    public IReadOnlyCollection<ReadingPlan> ReadingPlans => _readingPlans.AsReadOnly();
    private readonly List<ReadingPlan> _readingPlans = new();

    public IReadOnlyCollection<Book> Books = new List<Book>();

    public Group(string description, GroupIdentity groupIdentity)
    {
        GroupValidator.Validate(description);
        Description = description;
        GroupIdentity = groupIdentity;
    }
}
