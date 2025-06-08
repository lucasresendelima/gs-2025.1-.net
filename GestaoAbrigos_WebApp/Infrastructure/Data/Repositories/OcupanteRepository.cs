using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;
using GestaoAbrigos_WebApp.Infrastructure.Data.AppData;

namespace GestaoAbrigos_WebApp.Infrastructure.Data.Repositories
{
    public class OcupanteRepository : IOcupanteRepository
    {
        private readonly ApplicationContext _context;

        public OcupanteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<OcupanteEntity>? ObterTodos()
        {
            var ocupantes = _context.Ocupantes.ToList();
            return ocupantes.Any() ? ocupantes : null;
        }

        public OcupanteEntity? ObterPorId(int id)
        {
            return _context.Ocupantes.Find(id);
        }

        public OcupanteEntity? SalvarDados(OcupanteEntity entity)
        {
            _context.Ocupantes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public OcupanteEntity? EditarDados(OcupanteEntity entity)
        {
            var ocupante = _context.Ocupantes.FirstOrDefault(o => o.Id == entity.Id);

            if (ocupante is not null)
            {
                ocupante.Nome = entity.Nome;
                ocupante.Idade = entity.Idade;
                ocupante.Genero = entity.Genero;
                ocupante.AbrigoId = entity.AbrigoId;

                _context.Ocupantes.Update(ocupante);
                _context.SaveChanges();

                return ocupante;
            }

            return null;
        }

        public OcupanteEntity? DeletarDados(int id)
        {
            var ocupante = _context.Ocupantes.Find(id);

            if (ocupante is not null)
            {
                _context.Ocupantes.Remove(ocupante);
                _context.SaveChanges();
                return ocupante;
            }

            return null;
        }
    }
}
