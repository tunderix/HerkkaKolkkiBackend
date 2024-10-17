using API.Models.Faction;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

///<summary>
/// FactionService.cs
///</summary>
public class FactionService
{
    private readonly IMongoCollection<FactionWrapper> _factionCollection;
    
    public FactionService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("Heroes3");
        _factionCollection = database.GetCollection<FactionWrapper>("Factions");
    }
    
    /// <summary>
    /// Get all buildings.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Faction>> GetAllFactionsAsync()
    {
        var factionWrappers = await _factionCollection.Find(new BsonDocument()).ToListAsync();
        var factions = new List<Faction>();

        foreach (var wrapper in factionWrappers)
        {
            factions.AddRange(wrapper.Records.Select(record => record.Value));
        }

        return factions;
    }
}