using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifact;

public class SpellCast
{
    [BsonElement("spell")]
    public string Spell { get; set; }

    [BsonElement("sp")]
    public int SpellPoints { get; set; }

    [BsonElement("level")]
    public int Level { get; set; }
}