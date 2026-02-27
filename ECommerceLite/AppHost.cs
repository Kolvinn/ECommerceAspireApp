using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;


var builder = DistributedApplication.CreateBuilder(args);

// PostgreSQL for products/orders
var postgres = builder.AddPostgres("postgres")
    .WithBindMount("./data", "/var/lib/postgresql/data")
    .WithEnvironment("POSTGRES_PASSWORD", "ecomPW!2024");

// Redis for session state
var redis = builder.AddRedis("redis");

// Microservices
// var catalogApi = builder.AddProject<Projects.ECommerceLite_Api>("catalog-api")
//     .WithReference(postgres);
var api = builder.AddProject<Projects.ECommerceLite_Api>("api")
    .WaitFor(redis)
    .WithReference(redis)
    .WaitFor(postgres);

var cartService = builder.AddProject<Projects.ECommerceLite_CartService>("cart-service")
    .WithReference(redis);

var orderWorker = builder.AddProject<Projects.ECommerceLite_OrderWorker>("order-worker")
    .WithReference(postgres);

// Option B: built-in Vite helper (simpler)
builder.AddViteApp("frontend", "../ECommerceLite.Web")
    .WithReference(api)
    .WithReference(cartService)
    .WithExternalHttpEndpoints().WithNpm();

builder.Build().Run();
