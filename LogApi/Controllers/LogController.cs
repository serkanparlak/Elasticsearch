using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;
    private readonly IElasticsearchService _elasticsearchService;

    public LogController(
        ILogger<LogController> logger,
        IElasticsearchService elasticsearchService)
    {
        _logger = logger;
        _elasticsearchService = elasticsearchService;
    }

    public IActionResult Log([FromBody] LogInput logInput)
    {
        _elasticsearchService.Log(logInput);
        return Ok();
    }
}
