using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;
using GestaoAbrigos_WebApp.Infrastructure.Data.AppData;

namespace GestaoAbrigos_WebApp.Infrastructure.Data.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly ApplicationContext _context;

        public LocalizacaoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<LocalizacaoEntity>? ObterTodos()
        {
            return _context.Localizacoes.ToList();
        }

        public LocalizacaoEntity? ObterPorId(int id)
        {
            return _context.Localizacoes.Find(id);
        }

        public LocalizacaoEntity? SalvarDados(LocalizacaoEntity entity)
        {
            _context.Localizacoes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public LocalizacaoEntity? EditarDados(LocalizacaoEntity entity)
        {
            var localizacao = _context.Localizacoes.FirstOrDefault(x => x.Id == entity.Id);
            if (localizacao is not null)
            {
                localizacao.Rua = entity.Rua;
                localizacao.Numero = entity.Numero;
                localizacao.Complemento = entity.Complemento;
                localizacao.Cidade = entity.Cidade;
                localizacao.Estado = entity.Estado;
                localizacao.Cep = entity.Cep;

                _context.Localizacoes.Update(localizacao);
                _context.SaveChanges();

                return localizacao;
            }

            return null;
        }

        public LocalizacaoEntity? DeletarDados(int id)
        {
            var localizacao = _context.Localizacoes.Find(id);
            if (localizacao is not null)
            {
                _context.Localizacoes.Remove(localizacao);
                _context.SaveChanges();
                return localizacao;
            }

            return null;
        }
    }
}
