using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly INotificador _notificador;

        protected ControllerBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return ! _notificador.TemNotificacao();
        }
    }
}
