using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class Magic
{
    [BsonElement("int")]
    public int? Knowledge { get; set; }
    
    [BsonElement("sp")]
    public int? SpellPower { get; set; }
}