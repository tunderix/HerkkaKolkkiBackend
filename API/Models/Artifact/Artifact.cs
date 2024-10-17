using API.Models.Artifact;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Artifacts;

///<summary>
/// Artifact.cs
///</summary>
public class Artifact
{
    [BsonIgnore]
    public string Identifier { get; set; }
    
    [BsonElement("class")]
    public string Class { get; set; }
    
    [BsonElement("cost")]
    public int Cost { get; set; }
    
    [BsonElement("value")]
    public int Value { get; set; }
    
    [BsonElement("guard")]
    public int Guard { get; set; }
    
    [BsonElement("untranslatedName")]
    public string UntranslatedName { get; set; }
    
    [BsonElement("slot")]
    public string Slot { get; set; }
    
    [BsonElement("bmUnit")]
    public string BmUnit { get; set; }
    
    [BsonElement("statBonus")]
    public PrimaryStats PrimaryStats { get; set; }
    
    [BsonElement("calc")]
    public List<string> Calculation { get; set; }
    
    [BsonElement("special")]
    public string Special { get; set; }
    
    [BsonElement("provideSpells")]
    public ProvideSpells ProvideSpells { get; set; }
    
    [BsonElement("tags")]
    public List<string> Tags { get; set; }
    
    [BsonElement("forbidSpells")]
    public ForbidSpells ForbidSpells { get; set; }
    
    [BsonElement("protectSpells")]
    public ProtectSpells ProtectSpells { get; set; }
    
    [BsonElement("townGrowth")]
    public TownGrowth TownGrowth { get; set; }
    
    [BsonElement("noPenalty")]
    public List<string> NoPenalty { get; set; }
    
    [BsonElement("parts")]
    public List<string> Parts { get; set; }
    
    [BsonElement("spellCasts")]
    public List<SpellCast> SpellCasts { get; set; }
}