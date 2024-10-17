using API.Models.Faction;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace API.BsonSerialization;

///<summary>
/// FactionWrapperDeserializer.cs
///</summary>
public class FactionWrapperDeserializer : SerializerBase<FactionWrapper>
{
    public override FactionWrapper Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var document = BsonDocumentSerializer.Instance.Deserialize(context, args);
        var wrapper = new FactionWrapper
        {
            Id = document["_id"].AsObjectId,
            Scope = document["scope"].AsString,
            Records = new Dictionary<string, Faction>()
        };
        if (document.Contains("records"))
        {
            var records = document["records"].AsBsonDocument;
            foreach (var element in records.Elements)
            {
                Console.WriteLine("Deserializing Faction: " + element.Name + "/" + element.Value);

                var model = BsonSerializer.Deserialize<Faction>(element.Value.AsBsonDocument);
                //var model = new Faction();
                wrapper.Records.Add(element.Name, model);
            }
        }
        return wrapper;
    }
}