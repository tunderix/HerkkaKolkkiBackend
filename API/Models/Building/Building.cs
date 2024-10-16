using MongoDB.Bson.Serialization.Attributes;

namespace API.Models.Buildings;

///<summary>
/// Building.cs
///</summary>
public class Building
{
    [BsonIgnore]
    public string Identifier { get; set; }
    
    public string UntranslatedName { get; set; }
    
    public int LegacyId { get; set; }
    
    public int[] Order { get; set; }
}

