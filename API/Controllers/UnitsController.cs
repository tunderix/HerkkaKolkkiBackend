using API.Models.Unit;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

///<summary>
/// UnitsController.cs
///</summary>
public class UnitsController: ControllerBase
{
    private UnitService _unitService;

    public UnitsController(UnitService unitService)
    {
        _unitService = unitService;
    }
    
    /// <summary>
    /// Get all Units
    /// </summary>
    /// <returns></returns>
    [HttpGet("allUnits")]
    public async Task<ActionResult<List<Unit>>> GetAllUnits()
    {
        var units = await _unitService.GetAllUnitsAsync();
        return Ok(units);
    }
}