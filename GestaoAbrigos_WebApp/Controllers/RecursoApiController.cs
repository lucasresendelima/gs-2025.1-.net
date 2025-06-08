using Microsoft.AspNetCore.Mvc;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Domain.Entities;
using GestaoAbrigos_WebApp.Application.Dtos;

namespace GestaoAbrigos_WebApp.Controllers
{
    [Route("api/recurso")]
    [ApiController]
    public class RecursoApiController : ControllerBase
    {
        private readonly IRecursoApplication _recursoApplication;

        public RecursoApiController(IRecursoApplication recursoApplication)
        {
            _recursoApplication = recursoApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecursoEntity>> GetAll()
        {
            var recursos = _recursoApplication.ObterTodosRecursos();
            return Ok(recursos);
        }

        [HttpGet("{id}")]
        public ActionResult<RecursoEntity> GetById(int id)
        {
            var recurso = _recursoApplication.ObterRecursoPorId(id);
            if (recurso == null)
                return NotFound();
            return Ok(recurso);
        }

        [HttpPost]
        public ActionResult<RecursoEntity> Create([FromBody] RecursoDto recursoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recurso = _recursoApplication.SalvarDadosRecurso(recursoDto);
            if (recurso == null)
                return BadRequest();
                
            return CreatedAtAction(nameof(GetById), new { id = recurso.Id }, recurso);
        }

        [HttpPut("{id}")]
        public ActionResult<RecursoEntity> Update(int id, [FromBody] RecursoDto recursoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recurso = _recursoApplication.EditarDadosRecurso(id, recursoDto);
            if (recurso == null)
                return NotFound();

            return Ok(recurso);
        }

        [HttpDelete("{id}")]
        public ActionResult<RecursoEntity> Delete(int id)
        {
            var recurso = _recursoApplication.DeletarDadosRecurso(id);
            if (recurso == null)
                return NotFound();

            return Ok(recurso);
        }
    }
} 