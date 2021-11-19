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

namespace Simu.App.Controllers
{
    [Authorize]
    public class DadosController : BaseController
    {


        private readonly IDadoRepository _dadoRepository;
        private readonly IDadoService _dadoService;
        private readonly IMapper _mapper;

        public DadosController(IMapper mapper,
                                 IDadoRepository dadoRepository,
                                 IDadoService dadoService,
                                 INotificador notificador) : base(notificador)
        {

            _dadoRepository = dadoRepository;
            _dadoService = dadoService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public bool AdicionarDados()
        {
            //int acertos, int erros, int respondidas
            if (TempData["Respondidas"] != null)

            {
                // Necessário TypeCasting para tipos complexos.


            }
            var acertos = TempData["Acertos"];
            var erros = TempData["Erros"];
            var respondidas = TempData["Respondidas"];

            var dadoViewModel = new DadoViewModel
            {
                //Acertos = acertos,
                //Erros = erros,
                //Respondidas = respondidas,
            };

            var dado = _mapper.Map<Dado>(dadoViewModel);
            dado.Id = new Guid();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dado.UserId = Guid.Parse(userId);
            _dadoService.Adicionar(dado);

            return true;
        }

    }
}
