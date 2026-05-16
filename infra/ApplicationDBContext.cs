using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    
    public DbSet<Pc> PCs { get; set; } = null!;
    public DbSet<PCComponent> PCComponents { get; set; } = null!;
    public DbSet<ComponentType> ComponentTypes { get; set; } = null!;
    public DbSet<Component> Components { get; set; } = null!;
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //PC
        modelBuilder.Entity<Pc>()
            .HasKey(pc => pc.Id);
        //Component
        modelBuilder.Entity<Component>()
            .HasKey(p => p.code);
        modelBuilder.Entity<ComponentType>()
            .HasKey(pt => pt.Id);
        modelBuilder.Entity<ComponentManufacturer>()
            .HasKey(mp => mp.Id);

        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new { pc.PcId, pc.ComponentCode });
        
        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.Pc)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pc => pc.PcId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.Component)
            .WithMany()
            .HasForeignKey(pc => pc.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);
    }
}