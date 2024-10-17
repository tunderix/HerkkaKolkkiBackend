using System.Text.Json.Serialization;
using API.Models;
using API.Models.Artifacts;
using API.Models.Buildings;
using API.Services;
using DotNetEnv;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

//
// Register custom deserializers for JSON parsing
//
BsonSerializer.RegisterSerializer(typeof(ArtifactWrapper), new ArtifactWrapperDeserializer());
BsonSerializer.RegisterSerializer(typeof(BuildingWrapper), new BuildingWrapperDeserializer());

var builder = WebApplication.CreateBuilder(args);

//
// Load environment variables from .env file
//

// Load environment variables from .env file
Env.Load();

//
// Configure services
//

// Register MongoDB client
var mongoConnectionString = Env.GetString("MONGODB_CONNECTION_STRING");
var settings = MongoClientSettings.FromConnectionString(mongoConnectionString);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(settings));

// Register services
builder.Services.AddSingleton<ArtifactService>();
builder.Services.AddSingleton<BuildingService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Heroes API", Version = "v1" });
    c.SchemaGeneratorOptions.SchemaIdSelector = type => type.FullName;
    // Register schemas automatically
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

//
// Configure the app
//

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Heroes API V1");
    c.RoutePrefix = string.Empty;
});
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
