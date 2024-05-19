using MongoDB.Driver;
using NBP_project_Store.Service;
using Rhetos;

const string ORIGIN_NAME = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Dodajte Cors politiku
ConfigureCorsPolicy(builder);

// Konfigurirajte Rhetos
builder.Services.AddRhetosHost((serviceProvider, rhetosHostBuilder) => rhetosHostBuilder
        .ConfigureRhetosAppDefaults()
        .UseBuilderLogProviderFromHost(serviceProvider)
        .ConfigureConfiguration(cfg => cfg.MapNetCoreConfiguration(builder.Configuration)))
    .AddAspNetCoreIdentityUser()
    .AddHostLogging();

// Dodajte MongoDB kao servis
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    // Postavite MongoDB konekciju
    var mongoConnectionString = "mongodb://localhost:27017"; // Postavite svoj connection string
    return new MongoClient(mongoConnectionString);
});

// Registrirajte IMongoDatabase kao servis
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();
    var databaseName = "NBP_Project_Store_MongoDB"; // Postavite ime vaše baze podataka
    return mongoClient.GetDatabase(databaseName);
});

// Registrirajte MongoDBContext kao servis
builder.Services.AddSingleton<MongoDBContext>();

// Registrirajte PredmetManager
builder.Services.AddSingleton<IPredmetManager, PredmetManager>();

// Dodajte ostale servise ako ih imate
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapRhetosDashboard();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(ORIGIN_NAME);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureCorsPolicy(WebApplicationBuilder appbuilder)
{
    var origin = appbuilder.Configuration["FrontendApp"] ?? "http://localhost:4200";

    appbuilder.Services.AddCors(options =>
    {
        options.AddPolicy(name: ORIGIN_NAME,
            builder =>
            {
                builder.WithOrigins(origin).SetIsOriginAllowed(origin => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithExposedHeaders("Content-Disposition");
            });
    });
}
