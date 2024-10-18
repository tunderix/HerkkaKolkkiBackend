using API.Models.Unit;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

///<summary>
/// UnitService.cs
///</summary>
public class UnitService
{
    private readonly IMongoCollection<UnitWrapper> _unitCollection;
    
    public UnitService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("Heroes3");
        _unitCollection = database.GetCollection<UnitWrapper>("Units");
    }
    
    
    public async Task<List<Unit>> GetAllUnitsAsync()
    {
        var unitWrappers = await _unitCollection.Find(new BsonDocument()).ToListAsync();
        var units = new List<Unit>();

        foreach (var wrapper in unitWrappers)
        {
            units.AddRange(wrapper.Records.Select(record => record.Value));
        }

        return units;
    }
}