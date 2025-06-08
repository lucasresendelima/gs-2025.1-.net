using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Domain.Interfaces
{
    public interface IAbrigoRepository
    {
        IEnumerable<AbrigoEntity>? ObterTodos();
        AbrigoEntity? ObterPorId(int id);
        AbrigoEntity? SalvarDados(AbrigoEntity entity);
        AbrigoEntity? EditarDados(AbrigoEntity entity);
        AbrigoEntity? DeletarDados(int id);
    }
}
