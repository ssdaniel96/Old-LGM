using LGM.Domain.Entities.Groups;
using LGM.Domain.ValueObjects.Groups;

namespace LGM.Adapter.Repositories.Groups;
public interface IGroupRepository
{
    Task<Group?> GetBySourceAsync(GroupIdentity groupIdentity);

    Task<Group> InsertAsync(Group @group);
}