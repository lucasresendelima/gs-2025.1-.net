using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Application.Interfaces
{
    public interface IAbrigoApplication
    {
        IEnumerable<AbrigoEntity>? ObterTodosAbrigos();
        AbrigoEntity? ObterAbrigoPorId(int id);
        AbrigoEntity? SalvarDadosAbrigo(AbrigoDto entity);
        AbrigoEntity? EditarDadosAbrigo(int id, AbrigoDto entity);
        AbrigoEntity? DeletarDadosAbrigo(int id);

    }
}
