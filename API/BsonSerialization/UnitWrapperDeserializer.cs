using API.Models.Terrain;
using API.Models.Unit;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace API.BsonSerialization;

///<summary>
/// UnitWrapperDeserializer.cs
///</summary>
public class UnitWrapperDeserializer : SerializerBase<UnitWrapper>
{
    ///<summary>
    /// Deserializes a <see cref="TerrainWrapper"/> object from BSON.
    ///</summary>
    ///<param name="context">The deserialization context.</param>
    ///<param name="args">The deserialization arguments.</param>
    ///<returns>A deserialized <see cref="TerrainWrapper"/> object.</returns>
    public override UnitWrapper Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        // Deserialize the BSON document
        var document = BsonDocumentSerializer.Instance.Deserialize(context, args);
        var wrapper = new UnitWrapper(document);

        // Check if the document contains the "records" element
        if (!document.Contains("records")) return wrapper;
        
        // Deserialize the "records" element
        var records = document["records"].AsBsonDocument;
        
        foreach (var element in records.Elements)
        {
            var property = element.Value.AsBsonArray;

            var unit = new Unit();
            unit.Identifier = element.Name;
            
            
            unit.UntranslatedName = property[0].AsString;
            unit.UnitStats = new UnitStats
            {
                MinDamage = property[1][0][0].AsInt32,
                MaxDamage = property[1][0][1].AsInt32,
                Attack = property[1][1][0].AsInt32,
                Defense = property[1][1][1].AsInt32,
                MaxHealth = property[1][2].AsInt32,
                Speed = property[1][3].AsInt32,
            };
            
            //if(property[1][4] != null) unit.UnitStats.RangedAmmoCount = property[1][4].AsInt32;
            unit.Traits = property[2].AsBsonArray.Select(x => x.AsString).ToList();
            unit.FactionId = property[3].AsString;
            unit.Level = property[4].AsInt32;
            unit.Growth = property[5].AsInt32;
            unit.Cost = property[6].AsString;
            unit.Value = property[7].AsInt32;
                
            unit.GuardMult1 = property[8].AsInt32;
            unit.GuardMult100 = property[9].AsInt32;
            //unit.Upgrades = property[10].AsBsonArray.Select(x => x.AsString).ToList();
                
            unit.UnitHeroStackSize = new UnitHeroStackSize{ Min = property[11][0].AsInt32, Max = property[11][1].AsInt32 };
                
            wrapper.Records.Add(unit.Identifier, unit);
            
                
            // Log the deserialization process
            Console.WriteLine("Deserializing Unit: " + element.Name + "/" + unit);
            
            // Add the deserialized Terrain object to the wrapper's Records dictionary
            if (!wrapper.Records.ContainsKey(element.Name))
            {
                wrapper.Records.Add(element.Name, unit);
            }
        }

        return wrapper;
    }
}