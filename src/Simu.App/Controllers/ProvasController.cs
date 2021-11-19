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
            return View(_mapper.Map<IList<QuestaoViewModel>>(await _questaoRepository.ObterQuestoes()));

        }

        public async Task<IActionResult> QuestoesPorProva(string prova)
        {
            prova = "2019";
            return View(_mapper.Map<IList<QuestaoViewModel>>(await _questaoRepository.ObterQuestoesProva(prova)));

        }

        public  IActionResult QuestoesRespondidas(IList<QuestaoViewModel> questaoViewModel)
        {
            return View(questaoViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> VerificarRespostas(IList<QuestaoViewModel> questaoViewModel)
        {
            var listModel = questaoViewModel;
            foreach (var item in listModel)
            {
                var resposta = VerificarAlternativa(item);
                var questao = await _questaoRepository.ObterQuestao(item.Id);

                if (questao.Resposta == resposta)
                    item.Correta = true;
                else
                    item.Correta = false;
                
            }
            return View(listModel);
        }
        public string VerificarAlternativa(QuestaoViewModel model)
        {
            var resposta = "";
            switch (model.Marcada)
            {
                case "A":
                    resposta = model.A;
                    break;
                case "B":
                    resposta = model.B;
                    break;
                case "C":
                    resposta = model.C;
                    break;
                case "D":
                    resposta = model.D;
                    break;
                case "E":
                    resposta = model.E;
                    break;
            }
            return resposta;
        }

    }
}
