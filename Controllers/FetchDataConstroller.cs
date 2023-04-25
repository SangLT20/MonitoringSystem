using Microsoft.AspNetCore.Mvc;
using log4net;

namespace MonitoringSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class FetchDataController : ControllerBase
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(FetchDataController));
    private readonly IConfiguration _configuration;
    private readonly ILogger<FetchDataController> _logger;

    public FetchDataController(ILogger<FetchDataController> logger, IConfiguration configuration)
    {
        _log.Info($"FetchDataController");
        _logger = logger;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Post([FromForm] string responseData)
    {
        try
        {
            var header = Request.Headers["securityKey"];
            if (header.ToString() == _configuration["SecurityKey"])
            {
                _log.Info($"Post");
                var _coefficient = float.Parse(_configuration["HttpServer:Coefficient"]);
                int valueA1 = responseData == null ? 0 : int.Parse(responseData.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                Console.WriteLine("ValueA1: {0}", valueA1 * _coefficient);
                ShareData.StoredDataFloat = valueA1 * _coefficient;
            }
        }
        catch(Exception ex)
        {
            _log.Error(ex);
        }
        return Ok(new { temperature = ShareData.StoredDataFloat });
    }

    [HttpGet]
    public IActionResult Get()
    {
        _log.Info($"Get");
        return Ok(new { temperature = ShareData.StoredDataFloat });
    }
}
