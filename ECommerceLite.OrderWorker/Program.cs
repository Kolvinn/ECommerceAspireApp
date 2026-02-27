using ECommerceLite.OrderWorker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<OrderWorker>();

var host = builder.Build();
host.Run();
