using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;

namespace GestaoAbrigos_WebApp.Application.Services
{
    public class AbrigoApplication : IAbrigoApplication
    {
        private readonly IAbrigoRepository _abrigoRepository;

        public AbrigoApplication(IAbrigoRepository abrigoRepository)
        {
            _abrigoRepository = abrigoRepository;
        }

        public AbrigoEntity? SalvarDadosAbrigo(AbrigoDto dto)
        {
            var abrigo = new AbrigoEntity
            {
                Nome = dto.Nome,
                Capacidade = dto.Capacidade,
                Status = dto.Status,
                LocalizacaoId = dto.LocalizacaoId
            };

            return _abrigoRepository.SalvarDados(abrigo);
        }

        public AbrigoEntity? EditarDadosAbrigo(int id, AbrigoDto dto)
        {
            var abrigo = new AbrigoEntity
            {
                Id = id,
                Nome = dto.Nome,
                Capacidade = dto.Capacidade,
                Status = dto.Status,
                LocalizacaoId = dto.LocalizacaoId
            };

            return _abrigoRepository.EditarDados(abrigo);
        }

        public AbrigoEntity? DeletarDadosAbrigo(int id)
        {
            return _abrigoRepository.DeletarDados(id);
        }

        public AbrigoEntity? ObterAbrigoPorId(int id)
        {
            return _abrigoRepository.ObterPorId(id);
        }

        public IEnumerable<AbrigoEntity>? ObterTodosAbrigos()
        {
            return _abrigoRepository.ObterTodos() ?? Enumerable.Empty<AbrigoEntity>();
        }
    }
}
