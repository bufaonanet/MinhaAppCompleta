using DevIO.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
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

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.ErroCode = id;
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.Mensagem = "Ocorreu um erro. Tente mais tarde ou contate o suporte!";
            }
            else if (id == 404)
            {
                modelErro.ErroCode = id;
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.Mensagem = "A página que você está procurando não existe. <br/> Em caso de dúvidas, entre em contato com o suporte!";
            }
            else if (id == 403)
            {
                modelErro.ErroCode = id;
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.Mensagem = "Você não tem permissão para acessar essa página";
            }
            else
            {
                return StatusCode(500);
            }


            return View(modelErro);
        }
    }
}
