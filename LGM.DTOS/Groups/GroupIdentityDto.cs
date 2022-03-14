using LGM.Domain.Enums.Groups;

namespace LGM.DTOS.Groups;
public sealed class GroupIdentityDto
{
    public string SourceId { get; set; }
    public SourceTypeEnum SourceTypeEnum { get; set; }
}