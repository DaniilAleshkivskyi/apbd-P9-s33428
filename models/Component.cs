
using System.ComponentModel.DataAnnotations;
using WebApplication1.models;

public class Component
{
    [Key]
    [MaxLength(10)]
    public string code { get; set; } = null!;
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    public ComponentType ComponentType { get; set; } = null!;
    
}