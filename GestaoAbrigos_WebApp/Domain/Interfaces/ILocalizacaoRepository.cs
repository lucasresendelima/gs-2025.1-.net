using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Domain.Interfaces
{
    public interface ILocalizacaoRepository
    {
        IEnumerable<LocalizacaoEntity>? ObterTodos();
        LocalizacaoEntity? ObterPorId(int id);
        LocalizacaoEntity? SalvarDados(LocalizacaoEntity entity);
        LocalizacaoEntity? EditarDados(LocalizacaoEntity entity);
        LocalizacaoEntity? DeletarDados(int id);
    }
}
