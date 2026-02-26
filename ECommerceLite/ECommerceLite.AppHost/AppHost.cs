var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithEnvironment("POSTGRES_PASSWORD", "ecomPW!2024");


var cache = builder.AddRedis("redis-cart");

var server = builder.AddProject<Projects.ECommerceLite_Server>("server")
    .WithReference(cache)
    .WaitFor(cache)
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();


var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);



server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run(); 

/**
// Microservices
var catalogApi = builder.AddProject<Projects.ECommerceLite_CatalogApi>("catalog-api")
    .WithReference(postgres);

var cartService = builder.AddProject<Projects.ECommerceLite_CartService>("cart-service")
    .WithReference(redis);

var orderWorker = builder.AddProject<Projects.ECommerceLite_OrderWorker>("order-worker")
    .WithReference(postgres);

// Frontend (Blazor)
var web = builder.AddProject<Projects.ECommerceLite_Web>("web")
    .WithReference(catalogApi)
    .WithReference(cartService);

builder.Build().Run();
*/
