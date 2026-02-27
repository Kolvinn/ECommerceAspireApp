
using System;
using System.Collections.Generic;

namespace ECommerceLite.OrderWorker;

public class OrderWorker(ILogger<OrderWorker> logger) : BackgroundService()
{
    // private readonly DataDbContext? _db;
    // private readonly ILogger<OrderWorker> _logger = logger;

    // public OrderWorker(DataDbContext db, ILogger<OrderWorker> logger) : this(logger)
    // {
    
    //     _db = default!;
    //     _logger = logger;
    // }
        
    

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // while (!stoppingToken.IsCancellationRequested)
        // {
        //     // Process unfulfilled orders
        //     var pendingOrders = await _db.Orders
        //         .Where(o => o.Status == OrderStatus.Pending)
        //         .ToListAsync(stoppingToken);

        //     foreach (var order in pendingOrders)
        //     {
        //         // Simulate fulfillment
        //         order.Status = OrderStatus.Fulfilled;
        //         _logger.LogInformation("Order {OrderId} fulfilled.", order.Id);
        //     }
        //     await _db.SaveChangesAsync(stoppingToken);

        //     await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        //}
    }
    // protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    // {
    //     while (!stoppingToken.IsCancellationRequested)
    //     {
    //         if (logger.IsEnabled(LogLevel.Information))
    //         {
    //             logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    //         }
    //         await Task.Delay(1000, stoppingToken);
    //     }
    // }
}
