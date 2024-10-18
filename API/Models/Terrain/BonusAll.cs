using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Terrain;

public class BonusAll
{
    [BsonElement("rngMult")]
    public RngMultiplier? RngMultiplier { get; set; }
}