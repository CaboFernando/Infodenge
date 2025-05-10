using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;
using Infodengue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infodengue.Infrastructure.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Relatorio>> ListarTodosAsync()
        {
            return await _context.Relatorios.Include(r => r.Solicitante).ToListAsync();
        }

        public async Task AdicionarAsync(Relatorio relatorio)
        {
            _context.Relatorios.Add(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Relatorio>> ListarPorCodigoIbgeAsync(string codigoIbge)
        {
            return await _context.Relatorios
                .Include(r => r.Solicitante)
                .Where(r => r.CodigoIbge.ToString() == codigoIbge)
                .ToListAsync();
        }
    }
}
