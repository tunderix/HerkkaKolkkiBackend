using API.Models.Terrain;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

///<summary>
/// TerrainsController.cs
///</summary>
public class TerrainsController: ControllerBase
{
    private TerrainService _terrainService;

    public TerrainsController(TerrainService terrainService)
    {
        _terrainService = terrainService;
    }
    
    /// <summary>
    /// Get all Terrains
    /// </summary>
    /// <returns></returns>
    [HttpGet("allTerrains")]
    public async Task<ActionResult<List<Terrain>>> GetAllTerrains()
    {
        var factions = await _terrainService.GetAllTerrainsAsync();
        return Ok(factions);
    }
}