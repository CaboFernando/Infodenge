using Infodengue.Domain.Entities;

namespace Infodengue.Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<Relatorio>> ListarTodosAsync();
        Task AdicionarAsync(Relatorio relatorio);
        Task<IEnumerable<Relatorio>> ListarPorCodigoIbgeAsync(string codigoIbge);
    }
}
