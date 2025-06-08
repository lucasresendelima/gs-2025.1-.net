using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Domain.Interfaces
{
    public interface IRecursoRepository
    {
        IEnumerable<RecursoEntity>? ObterTodos();
        RecursoEntity? ObterPorId(int id);
        RecursoEntity? SalvarDados(RecursoEntity entity);
        RecursoEntity? EditarDados(RecursoEntity entity);
        RecursoEntity? DeletarDados(int id);
    }
}
