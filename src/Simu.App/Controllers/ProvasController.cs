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

    }
}
