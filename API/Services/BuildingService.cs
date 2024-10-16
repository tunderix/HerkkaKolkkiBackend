﻿using API.Models.Buildings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

///<summary>
/// BuildingService.cs
///</summary>
public class BuildingService
{
    private readonly IMongoCollection<BuildingWrapper> _buildingCollection;

    public BuildingService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("Heroes3");
        _buildingCollection = database.GetCollection<BuildingWrapper>("Buildings");
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