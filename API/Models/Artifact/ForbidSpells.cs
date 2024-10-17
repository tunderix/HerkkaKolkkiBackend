using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifact;

public class ForbidSpells
{
    [BsonElement("levels")]
    public List<int> Levels { get; set; }

    [BsonElement("teachableOnly")]
    public bool TeachableOnly { get; set; }

    [BsonElement("all")]
    public bool All { get; set; }
    
    [BsonElement("onlySpells")]
    public List<string> OnlySpells { get; set; }
}