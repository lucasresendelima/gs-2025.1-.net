using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;
using GestaoAbrigos_WebApp.Infrastructure.Data.AppData;

namespace GestaoAbrigos_WebApp.Infrastructure.Data.Repositories
{
    public class RecursoRepository : IRecursoRepository
    {
        private readonly ApplicationContext _context;

        public RecursoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<RecursoEntity>? ObterTodos()
        {
            var recursos = _context.Recursos.ToList();
            return recursos.Any() ? recursos : null;
        }

        public RecursoEntity? ObterPorId(int id)
        {
            return _context.Recursos.Find(id);
        }

        public RecursoEntity? SalvarDados(RecursoEntity entity)
        {
            _context.Recursos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public RecursoEntity? EditarDados(RecursoEntity entity)
        {
            var recurso = _context.Recursos.FirstOrDefault(r => r.Id == entity.Id);

            if (recurso is not null)
            {
                recurso.Nome = entity.Nome;
                recurso.Tipo = entity.Tipo;
                recurso.UnidadeMedida = entity.UnidadeMedida;

                _context.Recursos.Update(recurso);
                _context.SaveChanges();

                return recurso;
            }

            return null;
        }

        public RecursoEntity? DeletarDados(int id)
        {
            var recurso = _context.Recursos.Find(id);

            if (recurso is not null)
            {
                _context.Recursos.Remove(recurso);
                _context.SaveChanges();
                return recurso;
            }

            return null;
        }
    }
}
