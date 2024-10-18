using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Unit;

public class UnitStats
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    
    public int Attack { get; set; }
    public int Defense { get; set; }
    
    public int MaxHealth { get; set; }
    public int Speed { get; set; }
    public int RangedAmmoCount { get; set; }
}

///<summary>
/// Unit.cs
///</summary>
public class Unit
{
    [BsonIgnore]
    public string Identifier { get; set; }
    
    [BsonElement("0")]
    public string UntranslatedName { get; set; }
    
    [BsonIgnore]
    // [BsonElement("1")] Set this up in deserializer
    public UnitStats UnitStats { get; set; }
    
    [BsonElement("2")]
    public List<string> Traits { get; set; }
    
    [BsonElement("3")]
    public string FactionId { get; set; }
    
    [BsonElement("4")]
    public int Level { get; set; }
    
    [BsonElement("5")]
    public int Growth { get; set; }
    
    [BsonElement("6")]
    public string Cost { get; set; }
    
    [BsonElement("7")]
    public int Value { get; set; }
    
    [BsonElement("8")]
    public int GuardMult1 { get; set; }
    
    [BsonElement("9")]
    public int GuardMult100 { get; set; }
    
    [BsonElement("10")]
    public List<string> Upgrades { get; set; }
    
    [BsonIgnore]
    //[BsonElement("11")] Set this up in deserializer
    public UnitHeroStackSize UnitHeroStackSize { get; set; }
}

public class UnitHeroStackSize
{
    public int Min { get; set; }
    public int Max { get; set; }
}
