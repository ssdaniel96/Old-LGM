using LGM.Adapter.Repositories.HealthChecks;
using LGM.Adapter.Services.HealthChecks;

namespace LGM.Application.Services.HealthChecks;
public sealed class HealthCheckService : IHealthCheckService
{
    private readonly IHealthCheckRepository _healthCheckRepository;

    public HealthCheckService(IHealthCheckRepository healthCheckRepository)
    {
        _healthCheckRepository = healthCheckRepository;
    }

    public bool IsOnline() => _healthCheckRepository.IsOnline();
}

