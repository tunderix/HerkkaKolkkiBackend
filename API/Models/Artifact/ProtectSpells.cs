using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class ProtectSpells
{
    [BsonElement("onlySpells")]
    public List<string> OnlySpells { get; set; }
    
    [BsonElement("tags")]
    public List<string> Tags { get; set; }
    
    [BsonElement("levels")]
    public List<int> Levels { get; set; }
}