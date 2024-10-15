using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

///<summary>
/// ArtifactsController.cs
///</summary>
public class ArtifactsController: ControllerBase
{
    private readonly ArtifactService _artifactService;

    public ArtifactsController(ArtifactService artifactService)
    {
        _artifactService = artifactService;
    }

    /// <summary>
    /// Get all artifacts.
    /// </summary>
    /// <returns>List of all artifacts.</returns>
    [HttpGet("all")]
    public async Task<ActionResult<List<Artifact>>> GetAllArtifacts()
    {
        var artifacts = await _artifactService.GetAllArtifactsAsync();
        return Ok(artifacts);
    }

    /// <summary>
    /// Get artifact by name.
    /// </summary>
    /// <param name="name">Name of the artifact.</param>
    /// <returns>Artifact details.</returns>
    [HttpGet("{name}")]
    public async Task<ActionResult<Artifact>> GetArtifactByName(string name)
    {
        var artifact = await _artifactService.GetArtifactByNameAsync(name);

        if (artifact == null)
        {
            return NotFound();
        }

        return Ok(artifact);
    }
}