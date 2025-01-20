using Npgsql;
using PPH.Api.Endpoints;
using PPH.Api.Endpoints.Events;
using PPH.DataAccess.Repositories;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

GetEventsEndpoint.Map(app);
GetMapsEndpoint.Map(app);

app.Run();
