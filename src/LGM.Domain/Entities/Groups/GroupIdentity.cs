using LGM.Domain.Entities.Base;
using LGM.Domain.Enums.Groups;

namespace LGM.Domain.Entities.Groups
{
    public sealed class GroupIdentity : Entity
    {
        public GroupIdentity(string sourceId, SourceTypeEnum sourceTypeEnum)
        {
            SourceId = sourceId;
            SourceTypeEnum = sourceTypeEnum;
        }

        public string SourceId { get; private set; } // Id do grupo do telegram, discord etc.
        public SourceTypeEnum SourceTypeEnum { get; private set; }


    }
}
