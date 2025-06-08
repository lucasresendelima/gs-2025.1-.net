using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Application.Interfaces
{
    public interface IRecursoApplication
    {
        IEnumerable<RecursoEntity>? ObterTodosRecursos();
        RecursoEntity? ObterRecursoPorId(int id);
        RecursoEntity? SalvarDadosRecurso(RecursoDto dto);
        RecursoEntity? EditarDadosRecurso(int id, RecursoDto dto);
        RecursoEntity? DeletarDadosRecurso(int id);
    }
}
