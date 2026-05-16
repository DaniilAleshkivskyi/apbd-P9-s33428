using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.models;

public class PCComponent
{
    public int PcId { get; set; }
    [ForeignKey(nameof(PcId))]
    public Pc Pc { get; set; } = null!;
    [MaxLength(10)]
    public string ComponentCode { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;
    public int Amount { get; set; }
}