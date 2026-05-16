using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Infrastructure;
using WebApplication1.models;

namespace WebApplication1.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllDto>> GetAllAsync();
    Task<IEnumerable<PcComponentsDto>> GetComponentsAsync(int id);
    Task<PcGetAllDto> CreateAsync(PcCreateUpdateDto dto);
    Task<bool> UpdateAsync(int id, PcCreateUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}

public class PcService : IPcService
{
    private readonly ApplicationDbContext _context;

    public PcService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PcGetAllDto>> GetAllAsync()
    {
        return await _context.PCs.Select(pc => new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        }).ToListAsync();
    }

    public async Task<IEnumerable<PcComponentsDto>> GetComponentsAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return null!;

        return await _context.PCComponents
            .Where(pc => pc.PcId == id)
            .Select(pc => new PcComponentsDto
            {
                ComponentCode = pc.ComponentCode,
                ComponentName = pc.Component.name,
                Description = pc.Component.description,
                Amount = pc.Amount
            }).ToListAsync();
    }

    public async Task<PcGetAllDto> CreateAsync(PcCreateUpdateDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, PcCreateUpdateDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}