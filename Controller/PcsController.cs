using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pcService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await _pcService.GetComponentsAsync(id);
        if (result == null) return NotFound($"PC with id {id} not found");
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcCreateUpdateDto dto)
    {
        var result = await _pcService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcCreateUpdateDto dto)
    {
        var success = await _pcService.UpdateAsync(id, dto);
        if (!success) return NotFound($"PC with id {id} not found");
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _pcService.DeleteAsync(id);
        if (!success) return NotFound($"PC with id {id} not found");
        return NoContent();
    }
}