using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;

namespace GestaoAbrigos_WebApp.Presentation.Controllers
{
    public class AbrigoController : Controller
    {
        private readonly IAbrigoApplication _abrigoApplicationService;
        private readonly ILocalizacaoApplication _localizacaoApplicationService;

        public AbrigoController(
            IAbrigoApplication abrigoApplicationService,
            ILocalizacaoApplication localizacaoApplicationService)
        {
            _abrigoApplicationService = abrigoApplicationService;
            _localizacaoApplicationService = localizacaoApplicationService;
        }

        private void CarregarLocalizacoes()
        {
            var localizacoes = _localizacaoApplicationService.ObterTodasLocalizacoes();
            ViewBag.Localizacoes = new SelectList(localizacoes, "Id", "Nome");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var abrigos = _abrigoApplicationService.ObterTodosAbrigos();
            return View(abrigos);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();

            var abrigo = _abrigoApplicationService.ObterAbrigoPorId(id.Value);
            if (abrigo is null) return NotFound();

            return View(abrigo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregarLocalizacoes();
            return View(new AbrigoDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AbrigoDto model)
        {
            if (ModelState.IsValid)
            {
                _abrigoApplicationService.SalvarDadosAbrigo(model);
                return RedirectToAction(nameof(Index));
            }

            CarregarLocalizacoes();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return NotFound();

            var abrigo = _abrigoApplicationService.ObterAbrigoPorId(id.Value);
            if (abrigo is null) return NotFound();

            var model = new AbrigoDto
            {
                Id = abrigo.Id,
                Nome = abrigo.Nome,
                Capacidade = abrigo.Capacidade,
                Status = abrigo.Status,
                LocalizacaoId = abrigo.LocalizacaoId
            };

            CarregarLocalizacoes();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AbrigoDto model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _abrigoApplicationService.EditarDadosAbrigo(id, model);
                return RedirectToAction(nameof(Index));
            }

            CarregarLocalizacoes();
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();

            var abrigo = _abrigoApplicationService.ObterAbrigoPorId(id.Value);
            if (abrigo is null) return NotFound();

            return View(abrigo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _abrigoApplicationService.DeletarDadosAbrigo(id);

            if (deleted is null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
