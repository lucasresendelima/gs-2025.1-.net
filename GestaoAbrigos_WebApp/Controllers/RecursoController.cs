using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAbrigos_WebApp.Controllers
{
    public class RecursoController : Controller
    {
        private readonly IRecursoApplication _recursoApplication;

        public RecursoController(IRecursoApplication recursoApplication)
        {
            _recursoApplication = recursoApplication;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var recursos = _recursoApplication.ObterTodosRecursos();
            return View(recursos);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();

            var recurso = _recursoApplication.ObterRecursoPorId(id.Value);
            if (recurso is null) return NotFound();

            return View(recurso);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecursoDto model)
        {
            if (ModelState.IsValid)
            {
                _recursoApplication.SalvarDadosRecurso(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return NotFound();

            var recurso = _recursoApplication.ObterRecursoPorId(id.Value);
            if (recurso is null) return NotFound();

            var model = new RecursoDto
            {
                Id = recurso.Id,
                Nome = recurso.Nome,
                Tipo = recurso.Tipo,
                UnidadeMedida = recurso.UnidadeMedida
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RecursoDto model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _recursoApplication.EditarDadosRecurso(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();

            var recurso = _recursoApplication.ObterRecursoPorId(id.Value);
            if (recurso is null) return NotFound();

            return View(recurso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _recursoApplication.DeletarDadosRecurso(id);
            if (deleted is null) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
