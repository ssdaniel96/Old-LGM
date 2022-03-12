using LGM.Domain.Enums.Groups;

namespace LGM.DTOS.Groups
{
    public class InsertGroupIdentityDto
    {
        public string ForeignId { get; set; }
        public SourceTypeEnum SourceTypeEnum { get; set; }
    }
}
