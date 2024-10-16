using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class StatBonus
{
    [BsonElement("ad")]
    public AttackDefense Ad { get; set; }
    
    [BsonElement("magic")]
    public Magic Magic { get; set; }
}