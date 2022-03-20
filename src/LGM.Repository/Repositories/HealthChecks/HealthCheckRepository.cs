using LGM.Adapter.Repositories.HealthChecks;
using LGM.Repository.Context;

namespace LGM.Repository.Repositories.HealthChecks;
public sealed class HealthCheckRepository : IHealthCheckRepository
{
    private readonly ApplicationDbContext _context;

    public HealthCheckRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool IsOnline() => _context.Database.CanConnect();
}