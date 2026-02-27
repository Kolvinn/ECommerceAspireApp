using ECommerceLite.Api;
using ECommerceLite.Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public static class DataEndpoints
{

    public static void MapDbEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/Products");

        //GetAllProducts
        group.MapGet("/", async Task<Results<Ok<List<Product>>, NotFound>> (DataDbContext db) =>
        {
            var list = await db.Products.ToListAsync();
            return list.Count > 0 ? TypedResults.Ok(list) : TypedResults.NotFound();// == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("GetAllProducts");


        //UpdateProduct
        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, Product todo, DataDbContext db) =>
        {
            var affected = await db.Products
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Title, todo.Title)
            );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProduct");


        //GetProduct
        group.MapGet("/{id}", async Task<Results<Ok<Product>, NotFound>> (Guid id, DataDbContext db) =>
        {
            return await db.Products.AsNoTracking() //asnotracking disables telemetry and change tracking in order to reduce overhead (for read only operations)
                .FirstOrDefaultAsync(model => model.Id == id)
                is Product model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProduct");

        string createProduct = "CreateProduct";
        // group.MapPost("/{id}", async Task<Results<Ok, NotFound>> (Product product, DataDbContext db) =>
        // {
        //     var affected = await db.Products
        //         .Where(model => model.Id == id)
        //         .ExecuteUpdateAsync(setters => setters
        //         .SetProperty(m => m.Title, todo.Title)
        //         .SetProperty(m => m.IsComplete, todo.IsComplete)
        //         .SetProperty(m => m.Position, todo.Position)
        // ))
        

        group.MapPost("/", async (Product product, DataDbContext db) =>
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/Todo/{product.Id}",product);
        })
        .WithName(createProduct);
    
    }
}