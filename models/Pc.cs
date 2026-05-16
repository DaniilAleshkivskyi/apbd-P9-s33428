using System.ComponentModel.DataAnnotations;
using WebApplication1.models;

namespace WebApplication1.models;

public class Pc
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public float Weight { get; set; }

    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Stock { get; set; }
    
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}