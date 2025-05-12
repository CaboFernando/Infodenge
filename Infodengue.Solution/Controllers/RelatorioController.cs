using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Infodengue.Application.Services;
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

    [HttpGet("dados")]
    public async Task<IActionResult> ObterDados([FromServices] InfodengueApiService apiService, [FromQuery] string arbovirose, [FromQuery] int codigoIbge, [FromQuery] string inicio, [FromQuery] string fim)
    {
        var dados = await apiService.ObterDadosAsync(arbovirose, codigoIbge, inicio, fim);
        return Ok(dados);
    }

    [HttpGet("municipios")]
    public IActionResult ListarMunicipios()
    {
        var municipios = new List<object>
        {
            new { Codigo = 3304557, Nome = "Rio de Janeiro" },
            new { Codigo = 3550308, Nome = "São Paulo" },
            // outros...
        };
        return Ok(municipios);
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

    [HttpGet("totais-por-municipio")]
    public async Task<IActionResult> TotaisPorMunicipio()
    {
        var totais = await _service.ObterTotaisPorMunicipioAsync();
        return Ok(totais);
    }

    [HttpGet("por-municipios")]
    public async Task<IActionResult> PorMunicipios([FromQuery] string[] nomes)
    {
        var relatorios = await _service.ObterPorMunicipiosAsync(nomes);
        return Ok(relatorios);
    }

    [HttpGet("solicitantes")]
    public async Task<IActionResult> ObterSolicitantes()
    {
        var solicitantes = await _service.ObterSolicitantesAsync();
        return Ok(solicitantes);
    }

    [HttpGet("filtrar")]
    public async Task<IActionResult> Filtrar([FromQuery] int codigoIbge, [FromQuery] int semanaInicio, [FromQuery] int semanaFim, [FromQuery] string arbovirose)
    {
        var resultado = await _service.FiltrarRelatoriosAsync(codigoIbge, semanaInicio, semanaFim, arbovirose);
        return Ok(resultado);
    }
}
