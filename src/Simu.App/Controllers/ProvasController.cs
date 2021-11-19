using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simu.App.ViewModels;
using Simu.Business.Interfaces;
using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ceTe.DynamicPDF;

namespace Simu.App.Controllers
{
    [Authorize]
    public class ProvasController : BaseController
    {

        private readonly IQuestaoRepository _questaoRepository;
        private readonly IQuestaoService _questaoService;
        private readonly IDadoRepository _dadoRepository;
        private readonly IDadoService _dadoService;
        private readonly IMapper _mapper;

        public ProvasController(IMapper mapper,
                                 IQuestaoRepository questaoRepository,
                                 IQuestaoService questaoService,
                                 IDadoRepository dadoRepository,
                                 IDadoService dadoService,
                                 INotificador notificador) : base(notificador)
        {

            _questaoRepository = questaoRepository;
            _questaoService = questaoService;
            _dadoRepository = dadoRepository;
            _dadoService = dadoService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Questoes()
        {
            return View(_mapper.Map<IList<QuestaoViewModel>>(await _questaoRepository.ObterQuestoes()));

        }
        public async Task<IActionResult> Dados()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = Guid.Parse(userId);
            var dado = _mapper.Map<Dado>(await _dadoRepository.ObterDadosUsuario(id));

            var dadoViewModel = new DadoViewModel 
            {
                Acertos = dado.Acertos,
                Erros = dado.Erros,
                Respondidas = dado.Respondidas,
            };

            return View(dadoViewModel);
        }

        public async Task<DadoViewModel> ObterDadosPorAno(int anoProva)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = Guid.Parse(userId);

            var dado = _mapper.Map<Dado>(await _dadoRepository.ObterDadosUsuarioPorAno(id, anoProva));

            var dadoViewModel = new DadoViewModel
            {
                Acertos = dado.Acertos,
                Erros = dado.Erros,
                Respondidas = dado.Respondidas,
                AnoProva = dado.AnoProva,
            };

            return dadoViewModel;
        }

        public async Task<IActionResult> QuestoesPorProva(string prova)
        {
            ViewData["Prova"] = prova;
            return View(_mapper.Map<IList<QuestaoViewModel>>(await _questaoRepository.ObterQuestoesProva(prova)));

        }

        public async Task<IActionResult> ObterDadosUsuario()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = Guid.Parse(userId);
            return View(_mapper.Map<Dado>(await _dadoRepository.ObterDadosUsuario(id)));

        }

        public IActionResult QuestoesRespondidas(IList<QuestaoViewModel> questaoViewModel)
        {
            return View(questaoViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> VerificarRespostas(IList<QuestaoViewModel> questaoViewModel)
        {
            var dados = new Dado();

            dados.Acertos = 0;
            dados.Erros = 0;
            dados.Respondidas = 0;
            var listModel = questaoViewModel;
            foreach (var item in listModel)
            {
                var resposta = VerificarAlternativa(item);
                var questao = await _questaoRepository.ObterQuestao(item.Id);
                dados.Respondidas = dados.Respondidas + 1;

                if (questao.Resposta == resposta)
                {
                    item.Correta = true;
                    dados.Acertos = dados.Acertos + 1;
                }
                else
                {
                    item.Correta = false;
                    dados.Erros = dados.Erros + 1;
                }
            }

            TempData["Acertos"] = dados.Acertos;
            TempData["Erros"] = dados.Erros;
            TempData["Respondidas"] = dados.Respondidas;

            AdicionarDados(dados);
            return View(listModel);
        }
        private string VerificarAlternativa(QuestaoViewModel model)
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

        public bool AdicionarDados(Dado dado)
        {
            dado.Id = new Guid();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dado.UserId = Guid.Parse(userId);
            _dadoService.Adicionar(dado);

            return true;
        }
    }
}
