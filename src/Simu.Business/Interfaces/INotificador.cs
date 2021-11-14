using System.Collections.Generic;
using Simu.Business.Notificacoes;

namespace Simu.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
