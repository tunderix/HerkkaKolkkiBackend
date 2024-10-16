using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace API.Models;

///<summary>
/// BaseModelDeserializer.cs
///</summary>
public class BaseModelDeserializer<T, TU> : SerializerBase<List<T>> where T : HeroesDataWrapper<TU>, new()
{
    public override List<T> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var document = BsonDocumentSerializer.Instance.Deserialize(context, args);
        var models = new List<T>();

        foreach (var element in document)
        {
            var model = new T();
            //model.Identifier = element.Name;
            model.Records = BsonSerializer.Deserialize<Dictionary<string, TU>>(element.Value["records"].AsBsonDocument);
            models.Add(model);
        }
        
        return models;
    }
}