using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevIO.App.Extensions
{
    public class SymmaryViewComponent : ViewComponent
    {
        private readonly INotificador _inotificador;

        public SymmaryViewComponent(INotificador inotificador)
        {
            _inotificador = inotificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_inotificador.ObterNotificacao());

            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Mensagem));

            return View();
        }

    }
}
