using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models;

public class ArtifactWrapper
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    
    [BsonElement("scope")]
    public string Scope { get; set; }

    [BsonElement("records")]
    public Dictionary<string, Artifact> Records { get; set; }
}

///<summary>
/// Artifact.cs
///</summary>
public class Artifact
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnore]
    public string Id { get; set; }
    
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
    public StatBonus StatBonus { get; set; }
    
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

public class StatBonus
{
    [BsonElement("ad")]
    public AttackDefense Ad { get; set; }
    
    [BsonElement("magic")]
    public Magic Magic { get; set; }
}

public class AttackDefense
{
    [BsonElement("attack")]
    public int? Attack { get; set; }
    
    [BsonElement("defense")]
    public int? Defense { get; set; }
}

public class Magic
{
    [BsonElement("int")]
    public int? Knowledge { get; set; }
    
    [BsonElement("sp")]
    public int? SpellPower { get; set; }
}

public class ProvideSpells
{
    [BsonElement("schools")]
    public List<string> Schools { get; set; }
    
    [BsonElement("teachableOnly")]
    public bool TeachableOnly { get; set; }
    
    [BsonElement("levels")]
    public List<int> Levels { get; set; }
    
    [BsonElement("onlySpells")]
    public List<string> OnlySpells { get; set; }
}

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

public class ProtectSpells
{
    [BsonElement("onlySpells")]
    public List<string> OnlySpells { get; set; }
    
    [BsonElement("tags")]
    public List<string> Tags { get; set; }
    
    [BsonElement("levels")]
    public List<int> Levels { get; set; }
}

public class TownGrowth
{
    [BsonElement("level")]
    public int Level { get; set; }

    [BsonElement("size")]
    public int Size { get; set; }
}

public class SpellCast
{
    [BsonElement("spell")]
    public string Spell { get; set; }

    [BsonElement("sp")]
    public int SpellPoints { get; set; }

    [BsonElement("level")]
    public int Level { get; set; }
}