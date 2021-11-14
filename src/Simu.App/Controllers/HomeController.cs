
using Simu.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Simu.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500  || id == 404)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde.";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
