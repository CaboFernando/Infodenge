using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infodengue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitanteController : ControllerBase
{
    private readonly ISolicitanteService _service;

    public SolicitanteController(ISolicitanteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] SolicitanteDto dto)
    {
        var result = await _service.CriarOuObterSolicitanteAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var result = await _service.ListarTodosAsync();
        return Ok(result);
    }
}
