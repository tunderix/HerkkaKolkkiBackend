using System.Text.Json.Serialization;
using API;
using API.Models;
using API.Models.Artifacts;
using API.Models.Buildings;
using API.Services;
using API.Settings;
using DotNetEnv;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

BsonSerializer.RegisterSerializer(typeof(ArtifactWrapper), new ArtifactWrapperDeserializer());
BsonSerializer.RegisterSerializer(typeof(BuildingWrapper), new BuildingWrapperDeserializer());

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000); // Configure the HTTP port
});

Env.TraversePath().Load();
/*
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

*/
/*
var connectionUri = builder.Configuration.GetConnectionString("MongoConnection");
if (string.IsNullOrEmpty(connectionUri))
{
    throw new InvalidOperationException("MongoDB connection URI is not set in configuration.");
}
*/

var mongoConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");

var settings = MongoClientSettings.FromConnectionString(mongoConnectionString);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(settings));
builder.Services.AddScoped<HeroesJsonParser>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Heroes API V1");
        c.RoutePrefix = string.Empty;
    });
    
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
