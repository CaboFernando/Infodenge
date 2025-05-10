using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;
using Infodengue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infodengue.Infrastructure.Repositories
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly AppDbContext _context;

        public SolicitanteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Solicitante> ObterPorCpfAsync(string cpf)
        {
            return await _context.Solicitantes.FirstOrDefaultAsync(s => s.Cpf == cpf);
        }

        public async Task AdicionarAsync(Solicitante solicitante)
        {
            _context.Solicitantes.Add(solicitante);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Solicitante>> ObterTodosAsync()
        {
            return await _context.Solicitantes.ToListAsync();
        }
    }
}
