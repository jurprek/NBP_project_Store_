using Autofac.Core;
using NBP_project_Store.Service;
using Rhetos;

const string ORIGIN_NAME = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
;

//AddConfigurationsFiles(builder);
ConfigureCorsPolicy(builder);


builder.Services.AddRhetosHost((serviceProvider, rhetosHostBuilder) => rhetosHostBuilder
        .ConfigureRhetosAppDefaults()
        .UseBuilderLogProviderFromHost(serviceProvider)
        .ConfigureConfiguration(cfg => cfg.MapNetCoreConfiguration(builder.Configuration)))
    .AddAspNetCoreIdentityUser()
    .AddHostLogging();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoDBContext>();


var app = builder.Build();

//app.UseRhetosRestApi();

if (app.Environment.IsDevelopment())
{
    app.MapRhetosDashboard();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(ORIGIN_NAME);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddConfigurationsFiles(WebApplicationBuilder builder)
{
    builder!.Host.ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("rhetos-app.local.settings.json");
        config.AddJsonFile("local.settings.json");
    });
}

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
