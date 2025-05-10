using Infodengue.Application.DTOs;
using Infodengue.Domain.Entities;

namespace Infodengue.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task AdicionarRelatorioAsync(RelatorioDto dto);
        Task<IEnumerable<RelatorioDto>> ListarTodosAsync();
        Task<IEnumerable<RelatorioDto>> ListarPorCodigoIbgeAsync(string codigoIbge);
        Task<Dictionary<string, int>> ObterTotaisPorArboviroseAsync();
        Task<IEnumerable<object>> ObterTotaisPorMunicipioAsync();
        Task<IEnumerable<Relatorio>> ObterPorMunicipiosAsync(List<string> nomes);
        Task<IEnumerable<Solicitante>> ObterSolicitantesAsync();
        Task<IEnumerable<Relatorio>> FiltrarRelatoriosAsync(int codigoIbge, int semanaInicio, int semanaFim, string arbovirose);

    }
}
