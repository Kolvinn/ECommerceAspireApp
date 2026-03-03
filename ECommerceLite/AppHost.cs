using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;


var builder = DistributedApplication.CreateBuilder(args);

// PostgreSQL for products/orders
var postgres = builder.AddPostgres("postgres").WithPgWeb();
    //.WithBindMount("./data", "/var/lib/postgresql/data")
    //.WithEnvironment("POSTGRES_PASSWORD", "ecomPW!2024");
var db = postgres.AddDatabase("postgresdb");
// Redis for session state
var redis = builder.AddRedis("redis");

var username = builder.AddParameter("username");
var password = builder.AddParameter("password", secret: true);
var keycloak = builder.AddKeycloak("keycloak",8080, username, password)
    .WithDataVolume();

// Microservices
// var catalogApi = builder.AddProject<Projects.ECommerceLite_Api>("catalog-api")
//     .WithReference(postgres);
var api = builder.AddProject<Projects.ECommerceLite_Api>("api")
    .WaitFor(redis)
    .WithReference(redis)
    .WaitFor(db)
    .WithReference(db)
    .WithReference(keycloak)
    .WaitFor(keycloak);

// var cartService = builder.AddProject<Projects.ECommerceLite_CartService>("cart-service")
//     .WithReference(redis);

// var orderWorker = builder.AddProject<Projects.ECommerceLite_OrderWorker>("order-worker")
//     .WithReference(postgres);

// Option B: built-in Vite helper (simpler)
builder.AddViteApp("frontend", "../ECommerceLite.Web")
    .WithReference(api)
    .WaitFor(api)
    //.WithReference(cartService)
    .WithReference(keycloak)
    .WithExternalHttpEndpoints()
    .WithNpm();


builder.Build().Run();
