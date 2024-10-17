using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

///<summary>
/// PrimaryStatsFlat.cs
///</summary>
public class PrimaryStatsFlat
{
    [BsonElement("attack")]
    public int Attack { get; set; }
    
    [BsonElement("defense")]
    public int Defense { get; set; }
    
    [BsonElement("sp")]
    public int SpellPower { get; set; }
    
    [BsonElement("int")]
    public int Knowledge { get; set; }
}