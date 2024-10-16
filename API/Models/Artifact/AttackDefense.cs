using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class AttackDefense
{
    [BsonElement("attack")]
    public int? Attack { get; set; }
    
    [BsonElement("defense")]
    public int? Defense { get; set; }
}