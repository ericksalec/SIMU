using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simu.App.ViewModels;
using Simu.Business.Interfaces;
using Simu.Business.Models;
using Simu.App.Constantes;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace Simu.App.Controllers
{
    [Authorize]
    public class TarefasController : BaseController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;
        //private readonly IQuestaoRepository _questaoRepository;
        //private readonly IQuestaoService _questaoService;
        private readonly IMapper _mapper;

        public TarefasController(ITarefaRepository tarefaRepository,
                                 IMapper mapper,
                                 ITarefaService tarefaService,
                                 //IQuestaoRepository questaoRepository,
                                 //IQuestaoService questaoService,
                                 INotificador notificador) : base(notificador)
        {
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
            //_questaoRepository = questaoRepository;
            //_questaoService = questaoService;
            _mapper = mapper;
        }
       
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTarefaUsuario(userId)));
        }

        public async Task<IActionResult> TarefasFeitas()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTarefaUsuarioDone(userId)));
        }

        public async Task<IActionResult> QuestoesProva(string prova)
        {
            prova = "";
            return View(_mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterProva(prova)));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaViewModel = await ObterTarefasUsuario(id);

            if (tarefaViewModel == null)
            {
                return NotFound();
            }

            return View(tarefaViewModel);
        }

        //public async Task<IActionResult> Questoes()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Dados()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid) return View(tarefaViewModel);

            var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            tarefa.UsuarioId = userId;
            await _tarefaService.Adicionar(tarefa);

            if (!OperacaoValida()) return View(tarefaViewModel);
            TempData["Sucesso"] = "Tarefa adicionada com sucesso!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var tarefaViewModel = await ObterTarefa(id);

            if (tarefaViewModel == null)
            {
                return NotFound();
            }

            return View(tarefaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TarefaViewModel tarefaViewModel)
        {
            if (id != tarefaViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return PartialView("_EditarTarefa", new TarefaViewModel { Titulo = tarefaViewModel.Titulo, Descricao = tarefaViewModel.Descricao });


            var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
            await _tarefaService.Atualizar(tarefa);


            if (!OperacaoValida()) return View(tarefaViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ConcluirTarefa(Guid id)
        {

            var tarefaViewModel = await ObterTarefa(id);

            if (tarefaViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_ConcluirTarefa", new TarefaViewModel { Titulo = tarefaViewModel.Titulo, Descricao = tarefaViewModel.Descricao, UsuarioId = tarefaViewModel.UsuarioId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConcluirTarefa(Guid id, TarefaViewModel tarefaViewModel)
        {
            if (id != tarefaViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return NotFound();
            tarefaViewModel.Ativo = true;

            var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
            await _tarefaRepository.Atualizar(tarefa);

            var url = Url.Action("ObterTarefas", "Tarefas", new { id = tarefa.Id });

            return Json(new { success = true, url });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarTarefa(Guid id, TarefaViewModel tarefaViewModel)
        {
            if (id != tarefaViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return PartialView("_EditarTarefa", new TarefaViewModel { Titulo = tarefaViewModel.Titulo, Descricao = tarefaViewModel.Descricao });


            var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
            await _tarefaService.Atualizar(tarefa);

            var url = Url.Action("ObterTarefas", "Tarefas", new { id = tarefa.Id });

            return Json(new { success = true, url });
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var tarefaViewModel = await ObterTarefa(id);

            if (tarefaViewModel == null)
            {
                return NotFound();
            }

            return PartialView("_ExcluirTarefa", new TarefaViewModel { Titulo = tarefaViewModel.Titulo, Descricao = tarefaViewModel.Descricao});
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tarefaViewModel = await ObterTarefa(id);

            if (tarefaViewModel == null) return NotFound();

            await _tarefaService.Remover(id);

            var url = Url.Action("ObterTarefas", "Tarefas", new { id = id });

            return Json(new { success = true, url });
        }

        public async Task<IActionResult> ObterTarefas(string id)
        {

            var tarefas = _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTarefaUsuario(id));

            if (tarefas == null)
            {
                return NotFound();
            }

            return PartialView("_ListarTarefas", tarefas);
        }

        public async Task<IActionResult> ObterProva(string prova)
        {

            var tarefas = _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterProva(prova));

            if (tarefas == null)
            {
                return NotFound();
            }

            return PartialView("_ListarTarefas", tarefas);
        }


        public async Task<IActionResult> ObterTarefaExcluir(Guid id)
        {

            var tarefa = await ObterTarefa(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return PartialView("_ExcluirTarefa", tarefa);
        }

        private async Task<TarefaViewModel> ObterTarefa(Guid id)
        {
            return _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterTarefa(id));

        }

        private async Task<TarefaViewModel> ObterTarefasUsuario(string usuarioId)
        {
            return _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterTarefaUsuario(usuarioId));

        }

        private async Task<TarefaViewModel> ObterProvas(string prova)
        {
            return _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterProva(prova));

        }

        public async Task<IActionResult> Provas()
        {
            var prova = "1";
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterProva(prova)));
        }

    }
}
