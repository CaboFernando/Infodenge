using Infodengue.Application.DTOs;

namespace Infodengue.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task AdicionarRelatorioAsync(RelatorioDto dto);
        Task<IEnumerable<RelatorioDto>> ListarTodosAsync();
        Task<IEnumerable<RelatorioDto>> ListarPorCodigoIbgeAsync(string codigoIbge);
        Task<Dictionary<string, int>> ObterTotaisPorArboviroseAsync();

    }
}
