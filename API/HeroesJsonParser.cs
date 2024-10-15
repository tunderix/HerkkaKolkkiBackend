using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API;

///<summary>
/// HeroesJsonParser.cs
///</summary>
public class HeroesJsonParser
{
    
    public List<Faction> ParseFactions()
    {
        string filePath = "../Data/gameResources/hota_base.fhmod/factions.fhdb.json";
        string factoryFilePath = "../Data/gameResources/hota_factory.fhmod/hota_factory.fhdb.json";
        
        var baseFactionsJson = File.ReadAllText(filePath);
        var factoryJson = File.ReadAllText(factoryFilePath);
        
        var extensionObjects = JArray.Parse(factoryJson);
        var firstObject = extensionObjects.First.ToObject<Faction>();
        
        var factions = JsonConvert.DeserializeObject<List<Faction>>(baseFactionsJson);
        
        // merge firstObject.Records into factions.Records
        factions[0].Records.Add(firstObject.Records.First().Key, firstObject.Records.First().Value);
        
        
        return factions;
    }
}