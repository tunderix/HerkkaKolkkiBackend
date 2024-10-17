using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class PrimaryMagic
{
    [BsonElement("int")]
    public int? Knowledge { get; set; }
    
    [BsonElement("sp")]
    public int? SpellPower { get; set; }
}