using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Application.Interfaces
{
    public interface ILocalizacaoApplication
    {
        IEnumerable<LocalizacaoEntity>? ObterTodasLocalizacoes();
        LocalizacaoEntity? ObterLocalizacaoPorId(int id);
        LocalizacaoEntity? SalvarDadosLocalizacao(LocalizacaoDto dto);
        LocalizacaoEntity? EditarDadosLocalizacao(int id, LocalizacaoDto dto);
        LocalizacaoEntity? DeletarDadosLocalizacao(int id);
    }
}
