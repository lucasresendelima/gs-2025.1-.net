using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;
using GestaoAbrigos_WebApp.Infrastructure.Data.AppData;

namespace GestaoAbrigos_WebApp.Infrastructure.Data.Repositories
{
    public class AbrigoRepository : IAbrigoRepository
    {
        private readonly ApplicationContext _context;
        public AbrigoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<AbrigoEntity>? ObterTodos()
        {
            var abrigos =  _context.Abrigos.ToList();

            if (abrigos.Any())
                return abrigos;

            return null;
        }

        public AbrigoEntity? ObterPorId(int id)
        {
            var abrigo = _context.Abrigos.Find(id);

            if (abrigo is not null)
                return abrigo;

            return null;
        }

        public AbrigoEntity? SalvarDados(AbrigoEntity entity)
        {
            _context.Abrigos.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public AbrigoEntity? EditarDados(AbrigoEntity entity)
        {
            var abrigo = _context.Abrigos.FirstOrDefault(campo => campo.Id == entity.Id);

            if (abrigo is not null)
            {
                entity.Nome = abrigo.Nome;
                entity.Capacidade = abrigo.Capacidade;
                entity.Status = abrigo.Status;

                _context.Abrigos.Update(abrigo);
                _context.SaveChanges();

                return abrigo;
            }

            return null;
        }

        public AbrigoEntity? DeletarDados(int id)
        {
            var abrigo = _context.Abrigos.Find(id);

            if (abrigo is not null)
            {
                _context.Abrigos.Remove(abrigo);
                _context.SaveChanges();

                return abrigo;
            }

            return null;
        }
    }
}
