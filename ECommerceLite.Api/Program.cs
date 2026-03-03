using ECommerceLite.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.AddNpgsqlDbContext<DataDbContext>("postgresdb");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();
builder.Services.AddAuthentication()
                .AddKeycloakJwtBearer
                (
                    serviceName: "keycloak",
                    realm: "master",
                    options =>
                    {
                        options.Audience = "api-audience";

                        // For development only - disable HTTPS metadata validation
                        // In production, use explicit Authority configuration instead
                        if (builder.Environment.IsDevelopment())
                        {
                            options.RequireHttpsMetadata = false;
                        }
                    });
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();

app.MapDbEndpoints();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<DataDbContext>();
app.Run();
//await dbContext.Database.MigrateAsync();
