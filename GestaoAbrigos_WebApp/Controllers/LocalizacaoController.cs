using GestaoAbrigos_WebApp.Application.Dtos;
using GestaoAbrigos_WebApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAbrigos_WebApp.Controllers
{
    public class LocalizacaoController : Controller
    {
        private readonly ILocalizacaoApplication _localizacaoService;

        public LocalizacaoController(ILocalizacaoApplication localizacaoService)
        {
            _localizacaoService = localizacaoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var localizacoes = _localizacaoService.ObterTodasLocalizacoes();
            return View(localizacoes);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null) return NotFound();

            var localizacao = _localizacaoService.ObterLocalizacaoPorId(id.Value);
            if (localizacao is null) return NotFound();

            return View(localizacao);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LocalizacaoDto model)
        {
            if (ModelState.IsValid)
            {
                _localizacaoService.SalvarDadosLocalizacao(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return NotFound();

            var localizacao = _localizacaoService.ObterLocalizacaoPorId(id.Value);
            if (localizacao is null) return NotFound();

            var model = new LocalizacaoDto
            {
                Id = localizacao.Id,
                Rua = localizacao.Rua,
                Numero = localizacao.Numero,
                Complemento = localizacao.Complemento,
                Cidade = localizacao.Cidade,
                Estado = localizacao.Estado,
                Cep = localizacao.Cep
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LocalizacaoDto model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _localizacaoService.EditarDadosLocalizacao(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();

            var localizacao = _localizacaoService.ObterLocalizacaoPorId(id.Value);
            if (localizacao is null) return NotFound();

            return View(localizacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _localizacaoService.DeletarDadosLocalizacao(id);
            if (deleted is null) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
