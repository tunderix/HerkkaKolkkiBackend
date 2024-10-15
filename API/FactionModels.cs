using System.ComponentModel.DataAnnotations;

namespace API;

/// <summary>
/// Represents a Faction in the game.
/// </summary>
public class Faction
{
    /// <summary>
    /// The scope of the faction.
    /// </summary>
    [Required]
    public string Scope { get; set; }
    
    /// <summary>
    /// The records of the faction.
    /// </summary>
    [Required]
    public Dictionary<string, Record> Records { get; set; }
}

/// <summary>
/// Represents a record within a Faction.
/// </summary>
public class Record
{
    /// <summary>
    /// The untranslated name of the record.
    /// </summary>
    [Required]
    public string UntranslatedName { get; set; }
    
    /// <summary>
    /// The alignment of the faction.
    /// </summary>
    [Required]
    public string Alignment { get; set; }
    
    /// <summary>
    /// The native terrain of the faction.
    /// </summary>
    [Required]
    public string NativeTerrain { get; set; }
    
    /// <summary>
    /// The warrior class details.
    /// </summary>
    public WarriorClass WarriorClass { get; set; }
    
    /// <summary>
    /// The mage class details.
    /// </summary>
    public MageClass MageClass { get; set; }
}

/// <summary>
/// Represents the warrior class details.
/// </summary>
public class WarriorClass
{
    /// <summary>
    /// The ID of the warrior class.
    /// </summary>
    [Required]
    public string Id { get; set; }
    
    /// <summary>
    /// The untranslated name of the warrior class.
    /// </summary>
    [Required]
    public string UntranslatedName { get; set; }
    
    /// <summary>
    /// The starting parameters of the warrior class.
    /// </summary>
    public StartParams StartParams { get; set; }
    
    /// <summary>
    /// The low level increase stats.
    /// </summary>
    public Increase LowLevelIncrease { get; set; }
    
    /// <summary>
    /// The high level increase stats.
    /// </summary>
    public Increase HighLevelIncrease { get; set; }
    
    /// <summary>
    /// The skills of the warrior class.
    /// </summary>
    public Dictionary<string, int> Skills { get; set; }
}

/// <summary>
/// Represents the mage class details.
/// </summary>
public class MageClass
{
    /// <summary>
    /// The ID of the mage class.
    /// </summary>
    [Required]
    public string Id { get; set; }
    
    /// <summary>
    /// The untranslated name of the mage class.
    /// </summary>
    [Required]
    public string UntranslatedName { get; set; }
    
    /// <summary>
    /// The starting parameters of the mage class.
    /// </summary>
    public StartParams StartParams { get; set; }
    
    /// <summary>
    /// The low level increase stats.
    /// </summary>
    public Increase LowLevelIncrease { get; set; }
    
    /// <summary>
    /// The high level increase stats.
    /// </summary>
    public Increase HighLevelIncrease { get; set; }
    
    /// <summary>
    /// The skills of the mage class.
    /// </summary>
    public Dictionary<string, int> Skills { get; set; }
}

/// <summary>
/// Represents the starting parameters for attack and defense.
/// </summary>
public class StartParams
{
    /// <summary>
    /// The attack and defense parameters.
    /// </summary>
    [Required]
    public AttackDefense Ad { get; set; }
    
    /// <summary>
    /// The magic parameters.
    /// </summary>
    [Required]
    public Magic Magic { get; set; }
}

/// <summary>
/// Represents the attack and defense parameters.
/// </summary>
public class AttackDefense
{
    /// <summary>
    /// The attack value.
    /// </summary>
    [Required]
    public int Attack { get; set; }
    
    /// <summary>
    /// The defense value.
    /// </summary>
    [Required]
    public int Defense { get; set; }
}

/// <summary>
/// Represents the magic parameters.
/// </summary>
public class Magic
{
    /// <summary>
    /// The spell power.
    /// </summary>
    [Required]
    public int Sp { get; set; }
    
    /// <summary>
    /// The intelligence.
    /// </summary>
    [Required]
    public int Int { get; set; }
}

/// <summary>
/// Represents the increase stats for levels.
/// </summary>
public class Increase
{
    /// <summary>
    /// The attack increase value.
    /// </summary>
    [Required]
    public int Attack { get; set; }
    
    /// <summary>
    /// The defense increase value.
    /// </summary>
    [Required]
    public int Defense { get; set; }
    
    /// <summary>
    /// The spell power increase value.
    /// </summary>
    [Required]
    public int Sp { get; set; }
    
    /// <summary>
    /// The intelligence increase value.
    /// </summary>
    [Required]
    public int Int { get; set; }
}