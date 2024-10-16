using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models;
///<summary>
/// HeroesDataWrapper.cs
///</summary>
public class HeroesDataWrapper<T>
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    
    [BsonElement("scope")]
    public string Scope { get; set; }
    
    [BsonElement("records")]
    public Dictionary<string, T> Records { get; set; }
}