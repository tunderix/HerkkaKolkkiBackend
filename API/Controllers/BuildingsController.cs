using API.Models.Buildings;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

///<summary>
/// BuildingsController.cs
///</summary>
public class BuildingsController: ControllerBase
{
    private readonly BuildingService BuildingService;
    
    public BuildingsController(BuildingService buildingService)
    {
        BuildingService = buildingService;
    }
    /// <summary>
    /// Get all buildings
    /// </summary>
    /// <returns></returns>
    [HttpGet("allBuildings")]
    public async Task<ActionResult<List<Building>>> GetAllBuildings()
    {
        var buildings = await BuildingService.GetAllBuildingsAsync();
        return Ok(buildings);
    }
}