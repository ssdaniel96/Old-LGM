namespace LGM.DTOS.Groups;
public sealed class GroupDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public GroupIdentityDto GroupIdentityDto { get; set; }
}
