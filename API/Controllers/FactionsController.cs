using API.Models.Faction;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

///<summary>
/// FactionsController.cs
///</summary>
public class FactionsController: ControllerBase
{
    private FactionService _factionService;
    
    public FactionsController(FactionService factionService)
    {
        _factionService = factionService;
    }
    
    /// <summary>
    /// Get all factions
    /// </summary>
    /// <returns></returns>
    [HttpGet("allFactions")]
    public async Task<ActionResult<List<Faction>>> GetAllFactions()
    {
        var factions = await _factionService.GetAllFactionsAsync();
        return Ok(factions);
    }
}