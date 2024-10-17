using API.Models.Artifacts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

///<summary>
/// ArtifactService.cs
///</summary>
public class ArtifactService
{
    private readonly IMongoCollection<ArtifactWrapper> _artifactCollection;

    /// <summary>
    /// ArtifactService constructor.
    /// </summary>
    public ArtifactService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("Heroes3");
        _artifactCollection = database.GetCollection<ArtifactWrapper>("Artifacts");
    }

    /// <summary>
    /// Get all artifacts.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Artifact>> GetAllArtifactsAsync()
    {
        var artifactWrappers = await _artifactCollection.Find(new BsonDocument()).ToListAsync();
        var artifacts = new List<Artifact>();

        foreach (var wrapper in artifactWrappers)
        {
            artifacts.AddRange(wrapper.Records.Select(record => record.Value));
        }

        return artifacts;
    }

    /// <summary>
    /// Get artifact by name.
    /// </summary>
    /// <param name="nameToFind"></param>
    /// <returns></returns>
    public async Task<Artifact?> GetArtifactByNameAsync(string nameToFind)
    {
        var artifactWrappers = await _artifactCollection.Find(new BsonDocument()).ToListAsync();

        foreach (var wrapper in artifactWrappers)
        {
            foreach (var record in wrapper.Records)
            {
                if (record.Value.UntranslatedName.Contains(nameToFind))
                {
                    return record.Value;
                }
            }
        }

        return null;
    }
}
