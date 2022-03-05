using LGM.Domain.Entities.Base;
using LGM.Domain.Enums.Groups;

namespace LGM.Domain.Entities.Groups
{
    public class GroupIdentity : Entity
    {
        public GroupIdentity(int sourceId, SourceTypeEnum sourceTypeEnum)
        {
            SourceId = sourceId;
            SourceTypeEnum = sourceTypeEnum;
        }

        public int SourceId { get; private set; } // Id do grupo do telegram, discord etc.
        public SourceTypeEnum SourceTypeEnum { get; private set; }


    }
}
