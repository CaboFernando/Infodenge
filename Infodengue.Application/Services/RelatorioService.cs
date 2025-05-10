using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;

namespace Infodengue.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepo;
        private readonly ISolicitanteRepository _solicitanteRepo;

        public RelatorioService(IRelatorioRepository relatorioRepo, ISolicitanteRepository solicitanteRepo)
        {
            _relatorioRepo = relatorioRepo;
            _solicitanteRepo = solicitanteRepo;
        }

        public async Task AdicionarRelatorioAsync(RelatorioDto dto)
        {
            var solicitante = await _solicitanteRepo.ObterPorCpfAsync(dto.CpfSolicitante);

            if (solicitante == null)
                throw new Exception("Solicitante não encontrado");

            var relatorio = new Relatorio{
                Arbovirose = dto.Arbovirose,
                CodigoIbge = dto.CodigoIbge,
                Municipio = dto.Municipio,
                SemanaInicio = dto.SemanaInicio,
                SemanaFim = dto.SemanaFim,
                DataSolicitacao = dto.DataSolicitacao,
                Solicitante = solicitante,
                SolicitanteId = solicitante.Id
            };

            await _relatorioRepo.AdicionarAsync(relatorio);
        }

        public async Task<IEnumerable<RelatorioDto>> ListarTodosAsync()
        {
            var relatorios = await _relatorioRepo.ListarTodosAsync();
            return relatorios.Select(r => new RelatorioDto
            {
                Arbovirose = r.Arbovirose,
                CodigoIbge = r.CodigoIbge,
                Municipio = r.Municipio,
                SemanaInicio = r.SemanaInicio,
                SemanaFim = r.SemanaFim,
                DataSolicitacao = r.DataSolicitacao,
                CpfSolicitante = r.Solicitante?.Cpf
            });
        }

        public async Task<IEnumerable<RelatorioDto>> ListarPorCodigoIbgeAsync(string codigoIbge)
        {
            var relatorios = await _relatorioRepo.ListarPorCodigoIbgeAsync(codigoIbge);
            return relatorios.Select(r => new RelatorioDto
            {
                Arbovirose = r.Arbovirose,
                CodigoIbge = r.CodigoIbge,
                Municipio = r.Municipio,
                SemanaInicio = r.SemanaInicio,
                SemanaFim = r.SemanaFim,
                DataSolicitacao = r.DataSolicitacao,
                CpfSolicitante = r.Solicitante?.Cpf
            });
        }

        public async Task<Dictionary<string, int>> ObterTotaisPorArboviroseAsync()
        {
            var relatorios = await _relatorioRepo.ListarTodosAsync();

            var agrupado = relatorios
                .GroupBy(r => r.Arbovirose)
                .ToDictionary(g => g.Key, g => g.Count());

            return agrupado;
        }

    }
}
