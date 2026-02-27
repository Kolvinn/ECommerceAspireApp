using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceLite.Api;

[Table("Product")]
public class Product
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = default!;
    public string? Desription { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

}