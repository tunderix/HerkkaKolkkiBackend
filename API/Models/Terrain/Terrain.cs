using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Terrain;

///<summary>
/// Terrain.cs
///</summary>
public class Terrain
{
    [BsonIgnore]
    public string Identifier { get; set; }
    
    [BsonElement("untranslatedName")]
    public string UntranslatedName { get; set; }
    
    [BsonElement("moveCost")]
    public int? MoveCost { get; set; }
    
    [BsonElement("extraLayer")]
    public bool? ExtraLayer { get; set; }
    
    [BsonElement("tileBase")]
    public string? TileBase { get; set; }
    
    [BsonElement("isObstacle")]
    public bool? IsObstacle { get; set; }
    
    [BsonElement("nonUnderground")]
    public string? NonUnderground { get; set; }
    
    [BsonElement("bonusAll")]
    public BonusAll? BonusAll { get; set; }
}