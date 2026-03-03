using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ECommerceLite.Api.Data;

public class DataDbContext(DbContextOptions<DataDbContext> options) : DbContext(options)
{

    // Define your DbSets (tables) here
   // public DbSet<Employee> Employees { get; set; }

    public DbSet<ECommerceLite.Api.Product> Products {get;set;} = default!;


    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Product>().Property(e => e.Id)
    //         .HasValueGenerator<UUIDv7Generator>()
    //         .ValueGeneratedOnAdd();
    // }
}

// public class UUIDv7Generator : ValueGenerator<Guid>
// {
//     public override bool GeneratesTemporaryValues => false;

//     public override Guid Next(EntityEntry entry)
//     {
//         // Uses DateTimeOffset.UtcNow internally, so we don't need to pass it explicitly
//         return Guid.CreateVersion7();
//     }


// }