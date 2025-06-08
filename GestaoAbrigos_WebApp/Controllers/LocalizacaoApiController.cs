using Microsoft.AspNetCore.Mvc;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Application.Dtos;

namespace GestaoAbrigos_WebApp.Controllers
{
    [Route("api/localizacao")]
    [ApiController]
    public class LocalizacaoApiController : ControllerBase
    {
        private readonly ILocalizacaoApplication _localizacaoApplication;

        public LocalizacaoApiController(ILocalizacaoApplication localizacaoApplication)
        {
            _localizacaoApplication = localizacaoApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocalizacaoEntity>> GetAll()
        {
            var localizacoes = _localizacaoApplication.ObterTodasLocalizacoes();
            return Ok(localizacoes);
        }

        [HttpGet("{id}")]
        public ActionResult<LocalizacaoEntity> GetById(int id)
        {
            var localizacao = _localizacaoApplication.ObterLocalizacaoPorId(id);
            if (localizacao == null)
                return NotFound();
            return Ok(localizacao);
        }

        [HttpPost]
        public ActionResult<LocalizacaoEntity> Create([FromBody] LocalizacaoDto localizacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var localizacao = _localizacaoApplication.SalvarDadosLocalizacao(localizacaoDto);
            if (localizacao == null)
                return BadRequest();
                
            return CreatedAtAction(nameof(GetById), new { id = localizacao.Id }, localizacao);
        }

        [HttpPut("{id}")]
        public ActionResult<LocalizacaoEntity> Update(int id, [FromBody] LocalizacaoDto localizacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var localizacao = _localizacaoApplication.EditarDadosLocalizacao(id, localizacaoDto);
            if (localizacao == null)
                return NotFound();

            return Ok(localizacao);
        }

        [HttpDelete("{id}")]
        public ActionResult<LocalizacaoEntity> Delete(int id)
        {
            var localizacao = _localizacaoApplication.DeletarDadosLocalizacao(id);
            if (localizacao == null)
                return NotFound();

            return Ok(localizacao);
        }
    }
} 