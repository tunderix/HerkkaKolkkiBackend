using MongoDB.Bson;

namespace API.Models.Unit;

///<summary>
/// UnitWrapper.cs
///</summary>
public class UnitWrapper : HeroesDataWrapper<Unit>
{
    public UnitWrapper(BsonDocument document)
    {
        Id = document["_id"].AsObjectId;
        Scope = document["scope"].AsString;
        Records = new Dictionary<string, Unit>();
    }
}