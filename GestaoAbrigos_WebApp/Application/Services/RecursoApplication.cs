using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;

namespace GestaoAbrigos_WebApp.Application.Services
{
    public class RecursoApplication : IRecursoApplication
    {
        private readonly IRecursoRepository _recursoRepository;

        public RecursoApplication(IRecursoRepository recursoRepository)
        {
            _recursoRepository = recursoRepository;
        }

        public RecursoEntity? SalvarDadosRecurso(RecursoDto dto)
        {
            var recurso = new RecursoEntity
            {
                Nome = dto.Nome,
                Tipo = dto.Tipo,
                UnidadeMedida = dto.UnidadeMedida
            };

            return _recursoRepository.SalvarDados(recurso);
        }

        public RecursoEntity? EditarDadosRecurso(int id, RecursoDto dto)
        {
            var recurso = new RecursoEntity
            {
                Id = id,
                Nome = dto.Nome,
                Tipo = dto.Tipo,
                UnidadeMedida = dto.UnidadeMedida
            };

            return _recursoRepository.EditarDados(recurso);
        }

        public RecursoEntity? DeletarDadosRecurso(int id)
        {
            return _recursoRepository.DeletarDados(id);
        }

        public RecursoEntity? ObterRecursoPorId(int id)
        {
            return _recursoRepository.ObterPorId(id);
        }

        public IEnumerable<RecursoEntity>? ObterTodosRecursos()
        {
            return _recursoRepository.ObterTodos() ?? Enumerable.Empty<RecursoEntity>();
        }
    }
}
