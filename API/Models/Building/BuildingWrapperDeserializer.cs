using API.Models.Artifacts;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace API.Models.Buildings;

///<summary>
/// BuildingWrapperDeserializer.cs
///</summary>
public class BuildingWrapperDeserializer : SerializerBase<BuildingWrapper>
{
    public override BuildingWrapper Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var document = BsonDocumentSerializer.Instance.Deserialize(context, args);
        var wrapper = new BuildingWrapper
        {
            Id = document["_id"].AsObjectId,
            Scope = document["scope"].AsString,
            Records = new Dictionary<string, Building>()
        };

        if (document.Contains("records"))
        {
            var records = document["records"].AsBsonDocument;
            foreach (var element in records.Elements)
            {
                var recordDocument = element.Value.AsBsonArray;
                var model = new Building();
                
                model.Identifier = element.Name;
                model.UntranslatedName = recordDocument[0].AsString;
                model.LegacyId = recordDocument[1].AsInt32;
                model.Order = recordDocument[2].AsBsonArray.Select(x => x.AsInt32).ToArray();
                
                wrapper.Records.Add(element.Name, model);
            }
        }

        return wrapper;
    }
}