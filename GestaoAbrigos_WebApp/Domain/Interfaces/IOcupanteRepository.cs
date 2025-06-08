using GestaoAbrigos_WebApp.Domain.Entities;

namespace GestaoAbrigos_WebApp.Domain.Interfaces
{
    public interface IOcupanteRepository
    {
        IEnumerable<OcupanteEntity>? ObterTodos();
        OcupanteEntity? ObterPorId(int id);
        OcupanteEntity? SalvarDados(OcupanteEntity entity);
        OcupanteEntity? EditarDados(OcupanteEntity entity);
        OcupanteEntity? DeletarDados(int id);
    }
}
