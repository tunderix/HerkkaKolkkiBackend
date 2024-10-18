using API.Models.Terrain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

///<summary>
/// TerrainService.cs
///</summary>
public class TerrainService
{
    private readonly IMongoCollection<TerrainWrapper> _terrainCollection;

    public TerrainService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("Heroes3");
        _terrainCollection = database.GetCollection<TerrainWrapper>("Terrains");
    }
    
    public async Task<List<Terrain>> GetAllTerrainsAsync()
    {
        var terrainWrappers = await _terrainCollection.Find(new BsonDocument()).ToListAsync();
        var terrains = new List<Terrain>();

        foreach (var wrapper in terrainWrappers)
        {
            terrains.AddRange(wrapper.Records.Select(record => record.Value));
        }

        return terrains;
    }
}