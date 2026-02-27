using ECommerceLite.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.AddNpgsqlDbContext<DataDbContext>("UserDatabase");



builder.Services.AddOpenApi();
// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
//builder.Services.defa
//builder.Services.AddDbContext<UserDb>(options => options.UseSqlite("TodoList"));
//builder.Services.AddNpgsqlDataSource();
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
await dbContext.Database.MigrateAsync();
