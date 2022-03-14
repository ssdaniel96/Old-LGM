using LGM.Domain.Enums.Groups;

namespace LGM.Domain.ValueObjects.Groups;

public sealed class GroupIdentity
{
    public GroupIdentity(string sourceId, SourceTypeEnum sourceTypeEnum)
    {
        SourceId = sourceId;
        SourceTypeEnum = sourceTypeEnum;
    }

    public string SourceId { get; private set; } // Id do grupo do telegram, discord etc.
    public SourceTypeEnum SourceTypeEnum { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is GroupIdentity @other)
        {
            return SourceId == other.SourceId
                   && SourceTypeEnum == other.SourceTypeEnum;
        }

        return false;
    }

    public override int GetHashCode() => SourceId.GetHashCode() ^ SourceTypeEnum.GetHashCode();
}