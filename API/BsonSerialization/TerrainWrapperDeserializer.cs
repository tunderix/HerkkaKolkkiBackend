using API.Models.Terrain;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace API.BsonSerialization;

///<summary>
/// Provides custom deserialization logic for the <see cref="TerrainWrapper"/> class.
/// </summary>
public class TerrainWrapperDeserializer : SerializerBase<TerrainWrapper>
{
    ///<summary>
    /// Deserializes a <see cref="TerrainWrapper"/> object from BSON.
    ///</summary>
    ///<param name="context">The deserialization context.</param>
    ///<param name="args">The deserialization arguments.</param>
    ///<returns>A deserialized <see cref="TerrainWrapper"/> object.</returns>
    public override TerrainWrapper Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        // Deserialize the BSON document
        var document = BsonDocumentSerializer.Instance.Deserialize(context, args);
        var wrapper = new TerrainWrapper(document);

        // Check if the document contains the "records" element
        if (!document.Contains("records")) return wrapper;
        
        // Deserialize the "records" element
        var records = document["records"].AsBsonDocument;
        
        foreach (var element in records.Elements)
        {
            // Deserialize each record as a Terrain object
            var model = BsonSerializer.Deserialize<Terrain>(element.Value.AsBsonDocument);

            // Set the Identifier property of the Terrain object
            model.Identifier = element.Name;
                
            // Log the deserialization process
            Console.WriteLine("Deserializing Terrain: " + element.Name + "/" + model);
            
            // Add the deserialized Terrain object to the wrapper's Records dictionary
            wrapper.Records.Add(element.Name, model);
        }

        return wrapper;
    }
}