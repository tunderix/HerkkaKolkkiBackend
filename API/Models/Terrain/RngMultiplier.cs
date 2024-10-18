using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Terrain;

public class RngMultiplier
{
    
    [BsonElement("luckPositive")]
    public string? LuckPositive { get; set; }
    
    [BsonElement("moralePositive")]
    public string? MoralePositive { get; set; }
    
    [BsonElement("luckNegative")]
    public string? LuckNegative { get; set; }
    
    [BsonElement("moraleNegative")]
    public string? MoraleNegative { get; set; }
        
}