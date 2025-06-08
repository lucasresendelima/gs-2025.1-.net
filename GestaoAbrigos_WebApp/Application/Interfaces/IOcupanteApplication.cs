using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Application.Interfaces
{
    public interface IOcupanteApplication
    {
        IEnumerable<OcupanteEntity>? ObterTodosOcupantes();
        OcupanteEntity? ObterOcupantePorId(int id);
        OcupanteEntity? SalvarDadosOcupante(OcupanteDto dto);
        OcupanteEntity? EditarDadosOcupante(int id, OcupanteDto dto);
        OcupanteEntity? DeletarDadosOcupante(int id);
    }
}
