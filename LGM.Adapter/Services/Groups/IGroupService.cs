using LGM.DTOS.Groups;

namespace LGM.Adapter.Services.Groups;

public interface IGroupService
{
    Task InsertAsync(InsertGroupDto insertGroupDto, InsertGroupIdentityDto insertGroupIdentityDto);
}
