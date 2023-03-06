using Microsoft.AspNetCore.Mvc;
using log4net;

namespace MonitoringSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class FetchDataController : ControllerBase
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(FetchDataController));
    private readonly ILogger<FetchDataController> _logger;

    public FetchDataController(ILogger<FetchDataController> logger)
    {
        _log.Info($"FetchDataController");
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post([FromForm] int temperature)
    {
        ShareData.Temperature = temperature;
        return Ok(new { temperature = ShareData.Temperature });
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new{ temperature = ShareData.Temperature});
    }
}
