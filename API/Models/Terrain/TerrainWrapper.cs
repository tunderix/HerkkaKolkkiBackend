using MongoDB.Bson;

namespace API.Models.Terrain;

///<summary>
/// TerrainWrapper.cs
///</summary>
public class TerrainWrapper : HeroesDataWrapper<Terrain>
{
    public TerrainWrapper(BsonDocument document)
    {
        Id = document["_id"].AsObjectId;
        Scope = document["scope"].AsString;
        Records = new Dictionary<string, Terrain>();
    }
}