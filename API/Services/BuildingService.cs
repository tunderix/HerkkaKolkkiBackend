using API.Models.Buildings;
using API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

///<summary>
/// BuildingService.cs
///</summary>
public class BuildingService
{
    private readonly IMongoCollection<BuildingWrapper> _buildingCollection;

    public BuildingService(IMongoClient mongoClient, IOptions<MongoSettings> mongoSettings)
    {
        var settings = mongoSettings.Value;
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _buildingCollection = database.GetCollection<BuildingWrapper>(settings.BuildingCollection);
    }

    /// <summary>
    /// Get all buildings.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Building>> GetAllBuildingsAsync()
    {
        var buildingWrappers = await _buildingCollection.Find(new BsonDocument()).ToListAsync();
        var buildings = new List<Building>();

        foreach (var wrapper in buildingWrappers)
        {
            buildings.AddRange(wrapper.Records.Select(record => record.Value));
        }

        return buildings;
    }
}