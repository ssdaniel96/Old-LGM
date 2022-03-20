using LGM.Adapter.Services.HealthChecks;
using LGM.DTOS.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LGM.Api.Controllers.HealthChecks;
[Route("_healthCheck")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private readonly ApiVersionOptionDto _versionOptionDto;
    private readonly IHealthCheckService _healthCheckService;
    public HealthCheckController(IOptions<ApiVersionOptionDto> versionOptionDto,
        IHealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
        _versionOptionDto = versionOptionDto.Value;
    }

    [HttpGet, Route("version")]
    public ActionResult<string> GetVersion() => Ok(_versionOptionDto.Version);


    [HttpGet, Route("datetime")]
    public ActionResult<DateTime> GetDateTime() => Ok(DateTime.Now);

    [HttpGet, Route("status")]
    public ActionResult<string> GetStatus() => _healthCheckService.IsOnline() ? "online" : "offline";
}
