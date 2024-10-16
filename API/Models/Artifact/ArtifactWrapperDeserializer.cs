using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Collections.Generic;
using API.Models.Artifacts;

namespace API.Models;

///<summary>
/// ArtifactWrapperDeserializer.cs
///</summary>
public class ArtifactWrapperDeserializer : SerializerBase<ArtifactWrapper>
{
    public override ArtifactWrapper Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var document = BsonDocumentSerializer.Instance.Deserialize(context, args);
        var wrapper = new ArtifactWrapper
        {
            Id = document["_id"].AsObjectId,
            Scope = document["scope"].AsString,
            Records = new Dictionary<string, Artifact>()
        };

        if (document.Contains("records"))
        {
            var records = document["records"].AsBsonDocument;
            foreach (var element in records.Elements)
            {
                var recordDocument = element.Value.AsBsonDocument;
                var model = BsonSerializer.Deserialize<Artifact>(recordDocument);
                model.Identifier = element.Name;
                wrapper.Records.Add(element.Name, model);
            }
        }

        return wrapper;
    }
}