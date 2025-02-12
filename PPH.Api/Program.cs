using Dapper;
using Npgsql;
using PPH.Api.Endpoints;
using PPH.DataAccess.Repositories;
using PPH.DataAccess.Repositories.Implementations;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add the PostgreSQL connection to the service container
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
    return new NpgsqlConnection(connectionString);
});

builder.Services.AddScoped<IMapsRepository, MapsRepository>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<IMetadataRepository, MetadataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

GetEventsEndpoint.Map(app);
GetMapsEndpoint.Map(app);
AddMapEndpoint.Map(app);
MetadataEndpoints.Map(app);

/*
 * Dapper config
 */

SqlMapper.AddTypeHandler(new DateTimeHandler());
DefaultTypeMap.MatchNamesWithUnderscores = true;

app.Run();

