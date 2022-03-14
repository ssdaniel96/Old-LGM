using LGM.Adapter.Repositories.Groups;
using LGM.Domain.Entities.Groups;
using LGM.Domain.ValueObjects.Groups;
using LGM.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LGM.Repository.Repositories.Groups;
public sealed class GroupRepository : IGroupRepository
{
    private readonly ApplicationDbContext _context;
    public GroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Group?> GetBySourceAsync(GroupIdentity groupIdentity)
    {
        return await _context.Groups.SingleOrDefaultAsync(p => p.GroupIdentity.Equals(groupIdentity));
    }

    public async Task<Group> InsertAsync(Group @group)
    {
        await _context.Groups.AddAsync(@group);
        await _context.SaveChangesAsync();
        return @group;
    }
}

