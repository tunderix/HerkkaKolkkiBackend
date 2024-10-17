using API.Models.Artifacts;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Faction;

///<summary>
/// Faction.cs
///</summary>
public class Faction
{
    [BsonIgnore]
    [BsonElement("id")]
    public string Identifier { get; set; }
    
    [BsonElement("untranslatedName")]
    public string UntranslatedName { get; set; }
    
    [BsonElement("alignment")]
    public string Alignment { get; set; }
    
    [BsonElement("nativeTerrain")]
    public string? NativeTerrain { get; set; }
    
    [BsonElement("warriorClass")]
    public HeroClass? WarriorClass { get; set; }
    
    [BsonElement("mageClass")]
    public HeroClass? MageClass { get; set; }
}

public class HeroClass
{
    [BsonElement("id")]
    public string? Identifier { get; set; }
    
    [BsonElement("untranslatedName")]
    public string UntranslatedName { get; set; }
    
    [BsonElement("startParams")]
    public PrimaryStats PrimaryStats { get; set; }
    
    [BsonElement("lowLevelIncrease")]
    public PrimaryStatsFlat LowLevelIncrease { get; set; }
    
    [BsonElement("highLevelIncrease")]
    public PrimaryStatsFlat HighLevelIncrease { get; set; }
    
    [BsonElement("skills")]
    public Dictionary<string, int> SkillProbabilities { get; set; }
}