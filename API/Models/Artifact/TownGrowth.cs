using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

public class TownGrowth
{
    [BsonElement("level")]
    public int Level { get; set; }

    [BsonElement("size")]
    public int Size { get; set; }
}