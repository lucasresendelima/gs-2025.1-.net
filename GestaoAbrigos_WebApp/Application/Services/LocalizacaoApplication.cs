using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Domain.Interfaces;

namespace GestaoAbrigos_WebApp.Application.Services

{
    public class LocalizacaoApplication : ILocalizacaoApplication
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;

        public LocalizacaoApplication(ILocalizacaoRepository localizacaoRepository)
        {
            _localizacaoRepository = localizacaoRepository;
        }

        public IEnumerable<LocalizacaoEntity> ObterTodasLocalizacoes()
        {
            return _localizacaoRepository.ObterTodos() ?? new List<LocalizacaoEntity>();
        }

        public LocalizacaoEntity? ObterLocalizacaoPorId(int id)
        {
            return _localizacaoRepository.ObterPorId(id);
        }

        public LocalizacaoEntity? SalvarDadosLocalizacao(LocalizacaoDto dto)
        {
            var localizacao = new LocalizacaoEntity
            {
                Rua = dto.Rua,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                Cep = dto.Cep
            };

            return _localizacaoRepository.SalvarDados(localizacao);
        }

        public LocalizacaoEntity? EditarDadosLocalizacao(int id, LocalizacaoDto dto)
        {
            var localizacao = new LocalizacaoEntity
            {
                Id = id,
                Rua = dto.Rua,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                Cep = dto.Cep
            };

            return _localizacaoRepository.EditarDados(localizacao);
        }

        public LocalizacaoEntity? DeletarDadosLocalizacao(int id)
        {
            return _localizacaoRepository.DeletarDados(id);
        }
    }
}
