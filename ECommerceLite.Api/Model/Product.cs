
using System.ComponentModel.DataAnnotations;
namespace ECommerceLite.Api;

//[Table("Product")]
//[JsonSerializable(typeof(Product))] 
public class Product
{
    [Required]
    public int Id { get; set; }

    public string Title { get; set; } = default!;
    public string? Desription { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

}