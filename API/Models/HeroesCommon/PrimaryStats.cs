using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class PrimaryStats
{
    [BsonElement("ad")]
    public PrimaryPhysical PrimaryPhysical { get; set; }
    
    [BsonElement("magic")]
    public PrimaryMagic PrimaryMagic { get; set; }
}