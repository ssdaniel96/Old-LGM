using LGM.DTOS.Groups;

namespace LGM.Adapter.Services.Groups;

public interface IGroupService
{
    Task<GroupDto> InsertAsync(InsertGroupDto insertGroupDto);
}
