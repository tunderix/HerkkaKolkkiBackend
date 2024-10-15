using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Controller for Heroes related operations.
/// </summary>
[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly HeroesJsonParser _parser;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parser"></param>
    public HeroesController(HeroesJsonParser parser)
    {
        _parser = parser;
    }

    /// <summary>
    /// Get all factions from the JSON files.
    /// </summary>
    /// <returns>List of factions.</returns>
    [HttpGet("factions")]
    public IActionResult GetFactions()
    {
        var factions = _parser.ParseFactions();
        return Ok(factions);
    }
}