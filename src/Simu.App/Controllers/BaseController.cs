using Simu.Business.Interfaces;
using Simu.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace Simu.App.Controllers
{
    public abstract  class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = new Notificador();
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

    }
}