using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.DTOs.Client;
using API.Helpers;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return ApiResultMapper.ToActionResult(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return ApiResultMapper.ToActionResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClientRequest dto)
    {
        var result = await _service.CreateAsync(dto);
        return ApiResultMapper.ToActionResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClientRequest dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return ApiResultMapper.ToActionResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return ApiResultMapper.ToActionResult(result);
    }
}

