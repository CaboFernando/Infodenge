using Infodengue.Domain.Entities;

namespace Infodengue.Domain.Interfaces
{
    public interface ISolicitanteRepository
    {
        Task<Solicitante> ObterPorCpfAsync(string cpf);
        Task AdicionarAsync(Solicitante solicitante);
        Task<IEnumerable<Solicitante>> ObterTodosAsync();
    }
}
