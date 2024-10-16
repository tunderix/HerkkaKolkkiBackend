using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class ProvideSpells
{
    [BsonElement("schools")]
    public List<string> Schools { get; set; }
    
    [BsonElement("teachableOnly")]
    public bool TeachableOnly { get; set; }
    
    [BsonElement("levels")]
    public List<int> Levels { get; set; }
    
    [BsonElement("onlySpells")]
    public List<string> OnlySpells { get; set; }
}