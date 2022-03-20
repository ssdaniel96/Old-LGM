using LGM.Adapter.Repositories.HealthChecks;

namespace LGM.Application.Services.HealthChecks;
public sealed class HealthCheckService : IHealthCheckRepository
{
    private readonly IHealthCheckRepository _healthCheckRepository;

    public HealthCheckService(IHealthCheckRepository healthCheckRepository)
    {
        _healthCheckRepository = healthCheckRepository;
    }

    public bool IsOnline() => _healthCheckRepository.IsOnline();
}

