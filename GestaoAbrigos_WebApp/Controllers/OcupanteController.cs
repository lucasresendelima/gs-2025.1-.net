using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAbrigos_WebApp.Controllers
{
    public class OcupanteController : Controller
    {
        private readonly IOcupanteApplication _ocupanteApplication;

        public OcupanteController(IOcupanteApplication ocupanteApplication)
        {
            _ocupanteApplication = ocupanteApplication;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ocupantes = _ocupanteApplication.ObterTodosOcupantes();
            return View(ocupantes);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return NotFound();

            var ocupante = _ocupanteApplication.ObterOcupantePorId(id.Value);
            if (ocupante is null)
                return NotFound();

            return View(ocupante);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OcupanteDto model)
        {
            if (ModelState.IsValid)
            {
                _ocupanteApplication.SalvarDadosOcupante(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return NotFound();

            var ocupante = _ocupanteApplication.ObterOcupantePorId(id.Value);
            if (ocupante is null)
                return NotFound();

            var model = new OcupanteDto
            {
                Id = ocupante.Id,
                Nome = ocupante.Nome,
                Idade = ocupante.Idade,
                Genero = ocupante.Genero,
                AbrigoId = ocupante.AbrigoId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OcupanteDto model)
        {
            if (id != model.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _ocupanteApplication.EditarDadosOcupante(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var ocupante = _ocupanteApplication.ObterOcupantePorId(id.Value);
            if (ocupante is null)
                return NotFound();

            return View(ocupante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _ocupanteApplication.DeletarDadosOcupante(id);

            if (deleted is null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
