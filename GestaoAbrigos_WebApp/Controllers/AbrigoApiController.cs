using Microsoft.AspNetCore.Mvc;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Application.Dtos;

namespace GestaoAbrigos_WebApp.Controllers
{
    [Route("api/abrigo")]
    [ApiController]
    public class AbrigoApiController : ControllerBase
    {
        private readonly IAbrigoApplication _abrigoApplication;

        public AbrigoApiController(IAbrigoApplication abrigoApplication)
        {
            _abrigoApplication = abrigoApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AbrigoEntity>> GetAll()
        {
            var abrigos = _abrigoApplication.ObterTodosAbrigos();
            return Ok(abrigos);
        }

        [HttpGet("{id}")]
        public ActionResult<AbrigoEntity> GetById(int id)
        {
            var abrigo = _abrigoApplication.ObterAbrigoPorId(id);
            if (abrigo == null)
                return NotFound();
            return Ok(abrigo);
        }

        [HttpPost]
        public ActionResult<AbrigoEntity> Create([FromBody] AbrigoDto abrigoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var abrigo = _abrigoApplication.SalvarDadosAbrigo(abrigoDto);
            if (abrigo == null)
                return BadRequest();
                
            return CreatedAtAction(nameof(GetById), new { id = abrigo.Id }, abrigo);
        }

        [HttpPut("{id}")]
        public ActionResult<AbrigoEntity> Update(int id, [FromBody] AbrigoDto abrigoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var abrigo = _abrigoApplication.EditarDadosAbrigo(id, abrigoDto);
            if (abrigo == null)
                return NotFound();

            return Ok(abrigo);
        }

        [HttpDelete("{id}")]
        public ActionResult<AbrigoEntity> Delete(int id)
        {
            var abrigo = _abrigoApplication.DeletarDadosAbrigo(id);
            if (abrigo == null)
                return NotFound();

            return Ok(abrigo);
        }
    }
} 