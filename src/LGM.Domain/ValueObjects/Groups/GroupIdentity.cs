using LGM.Domain.Enums.Groups;

namespace LGM.Domain.ValueObjects.Groups;

public sealed class GroupIdentity
{
    private GroupIdentity() { }

    public GroupIdentity(string sourceId, SourceTypeEnum sourceTypeId)
    {
        SourceId = sourceId;
        SourceTypeId = sourceTypeId;
    }

    public string SourceId { get; private set; } // Id do grupo do telegram, discord etc.
    public SourceTypeEnum SourceTypeId { get; private set; }


    public override bool Equals(object? obj)
    {
        if (obj is GroupIdentity @other)
        {
            return SourceId == other.SourceId
                   && SourceTypeId == other.SourceTypeId;
        }

        return false;
    }

    public override int GetHashCode() => SourceId.GetHashCode() ^ SourceTypeId.GetHashCode();
}