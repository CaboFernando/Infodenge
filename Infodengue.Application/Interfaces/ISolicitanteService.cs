using Infodengue.Application.DTOs;

namespace Infodengue.Application.Interfaces
{
    public interface ISolicitanteService
    {
        Task<SolicitanteDto> CriarOuObterSolicitanteAsync(SolicitanteDto dto);
        Task<IEnumerable<SolicitanteDto>> ListarTodosAsync();
    }
}
