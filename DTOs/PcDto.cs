namespace WebApplication1.DTOs;

public class PcGetAllDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}

public class PcComponentsDto
{
    public string ComponentCode { get; set; } = null!;
    public string ComponentName { get; set; } = null!;
    public string? Description { get; set; }
    public int Amount { get; set; }
}

public class PcCreateUpdateDto
{
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}