using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;

namespace GestaoAbrigos_WebApp.Application.Services
{
    public class OcupanteApplication : IOcupanteApplication
    {
        private readonly IOcupanteRepository _ocupanteRepository;

        public OcupanteApplication(IOcupanteRepository ocupanteRepository)
        {
            _ocupanteRepository = ocupanteRepository;
        }

        public OcupanteEntity? SalvarDadosOcupante(OcupanteDto dto)
        {
            var ocupante = new OcupanteEntity
            {
                Nome = dto.Nome,
                Idade = dto.Idade,
                Genero = dto.Genero,
                AbrigoId = dto.AbrigoId
            };

            return _ocupanteRepository.SalvarDados(ocupante);
        }

        public OcupanteEntity? EditarDadosOcupante(int id, OcupanteDto dto)
        {
            var ocupante = new OcupanteEntity
            {
                Id = id,
                Nome = dto.Nome,
                Idade = dto.Idade,
                Genero = dto.Genero,
                AbrigoId = dto.AbrigoId
            };

            return _ocupanteRepository.EditarDados(ocupante);
        }

        public OcupanteEntity? DeletarDadosOcupante(int id)
        {
            return _ocupanteRepository.DeletarDados(id);
        }

        public OcupanteEntity? ObterOcupantePorId(int id)
        {
            return _ocupanteRepository.ObterPorId(id);
        }

        public IEnumerable<OcupanteEntity>? ObterTodosOcupantes()
        {
            return _ocupanteRepository.ObterTodos() ?? Enumerable.Empty<OcupanteEntity>();
        }
    }
}
