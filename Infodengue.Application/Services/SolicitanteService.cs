using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;

namespace Infodengue.Application.Services
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _repository;

        public SolicitanteService(ISolicitanteRepository repository)
        {
            _repository = repository;
        }

        public async Task<SolicitanteDto> CriarOuObterSolicitanteAsync(SolicitanteDto dto)
        {
            var existente = await _repository.ObterPorCpfAsync(dto.Cpf);

            if (existente != null)
            {
                return new SolicitanteDto { Nome = existente.Nome, Cpf = existente.Cpf };
            }

            var novo = new Solicitante{
                Nome = dto.Nome, 
                Cpf = dto.Cpf
            };
            await _repository.AdicionarAsync(novo);

            return dto;
        }

        public async Task<IEnumerable<SolicitanteDto>> ListarTodosAsync()
        {
            var lista = await _repository.ObterTodosAsync(); // Se você quiser listar todos
            return lista.Select(s => new SolicitanteDto { Nome = s.Nome, Cpf = s.Cpf });
        }
    }
}
