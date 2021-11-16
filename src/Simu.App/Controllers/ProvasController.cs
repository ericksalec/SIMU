using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simu.App.ViewModels;
using Simu.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Simu.App.Controllers
{
    [Authorize]
    public class ProvasController : BaseController
    {

        private readonly IQuestaoRepository _questaoRepository;
        private readonly IQuestaoService _questaoService;
        private readonly IMapper _mapper;

        public ProvasController(IMapper mapper,
                                 IQuestaoRepository questaoRepository,
                                 IQuestaoService questaoService,
                                 INotificador notificador) : base(notificador)
        {

            _questaoRepository = questaoRepository;
            _questaoService = questaoService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> Questoes()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Questoes()
        {
            return View(_mapper.Map<IEnumerable<QuestaoViewModel>>(await _questaoRepository.ObterQuestoes()));

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SalvarResposta(Guid id, QuestaoViewModel questaoViewModel)
        //{
        //    if (id != tarefaViewModel.Id) return NotFound();


        //    if (!ModelState.IsValid) return PartialView("_EditarTarefa", new TarefaViewModel { Titulo = tarefaViewModel.Titulo, Descricao = tarefaViewModel.Descricao });


        //    var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
        //    await _tarefaService.Atualizar(tarefa);

        //    var url = Url.Action("ObterTarefas", "Tarefas", new { id = tarefa.Id });

        //    return Json(new { success = true, url });
        //}


    }
}
