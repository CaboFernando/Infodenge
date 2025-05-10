using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infodengue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatorioService _service;

    public RelatorioController(IRelatorioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Solicitar([FromBody] RelatorioDto dto)
    {
        await _service.AdicionarRelatorioAsync(dto);
        return Ok("Relatório salvo com sucesso.");
    }

    [HttpGet("todos")]
    public async Task<IActionResult> ObterTodos()
    {
        var relatorios = await _service.ListarTodosAsync();
        return Ok(relatorios);
    }

    [HttpGet("por-codigo-ibge/{codigo}")]
    public async Task<IActionResult> PorCodigoIbge(string codigo)
    {
        var relatorios = await _service.ListarPorCodigoIbgeAsync(codigo);
        return Ok(relatorios);
    }

    [HttpGet("totais-por-arbovirose")]
    public async Task<IActionResult> TotaisPorArbovirose()
    {
        var resultado = await _service.ObterTotaisPorArboviroseAsync();
        return Ok(resultado);
    }
}
