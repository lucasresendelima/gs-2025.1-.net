using Microsoft.AspNetCore.Mvc;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Application.Dtos;

namespace GestaoAbrigos_WebApp.Controllers
{
    [Route("api/ocupante")]
    [ApiController]
    public class OcupanteApiController : ControllerBase
    {
        private readonly IOcupanteApplication _ocupanteApplication;

        public OcupanteApiController(IOcupanteApplication ocupanteApplication)
        {
            _ocupanteApplication = ocupanteApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OcupanteEntity>> GetAll()
        {
            var ocupantes = _ocupanteApplication.ObterTodosOcupantes();
            return Ok(ocupantes);
        }

        [HttpGet("{id}")]
        public ActionResult<OcupanteEntity> GetById(int id)
        {
            var ocupante = _ocupanteApplication.ObterOcupantePorId(id);
            if (ocupante == null)
                return NotFound();
            return Ok(ocupante);
        }

        [HttpPost]
        public ActionResult<OcupanteEntity> Create([FromBody] OcupanteDto ocupanteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ocupante = _ocupanteApplication.SalvarDadosOcupante(ocupanteDto);
            if (ocupante == null)
                return BadRequest();
                
            return CreatedAtAction(nameof(GetById), new { id = ocupante.Id }, ocupante);
        }

        [HttpPut("{id}")]
        public ActionResult<OcupanteEntity> Update(int id, [FromBody] OcupanteDto ocupanteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ocupante = _ocupanteApplication.EditarDadosOcupante(id, ocupanteDto);
            if (ocupante == null)
                return NotFound();

            return Ok(ocupante);
        }

        [HttpDelete("{id}")]
        public ActionResult<OcupanteEntity> Delete(int id)
        {
            var ocupante = _ocupanteApplication.DeletarDadosOcupante(id);
            if (ocupante == null)
                return NotFound();

            return Ok(ocupante);
        }
    }
} 