using Agendamento.App.Models;
using AutoMapper;
using Bussines.Interface;
using Bussines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace Agendamento.App.Controllers
{
    public class HomeController : Controller
    {
        private IConsultaDataRepository _repository;
        private IMapper _Map;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConsultaDataRepository repository, IMapper map)
        {
            _logger = logger;
            _repository = repository;
            _Map = map;
        }

        public IActionResult Index()
        {
            ViewBag.TipoSolicitacao = new List<string>() { "Adesão ao PrevMais", "Requerimento de Benefícios", "Outros - Indicar" };

            if (TempData["resultado"] != null)
            {
                var result = TempData["resultado"] as string;
                ViewBag.result = result;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Agendar(DataModelViewModel form)
        {
            if(form.TipoSolicitacao == "Outros - Indicar" && form.SolicitacaoPersonalizada == null)
            {
                TempData["resultado"] = "Digite a sua solicitação!";
                return RedirectToAction("Index");
            }
            var text = "Nada Selecionado";
            if (form.Hora == text || form.TipoSolicitacao == text)
            {
                TempData["resultado"] = "Preencha os campos!";
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Adicionar(_Map.Map<DataModel>(form));
                    TempData["resultado"] = "Agendado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    var exception = ex.ToString();
                    TempData["resultado"] = exception;
                    return RedirectToAction("Index");
                }
            }
            TempData["resultado"] = "Formulário inválido";
            return RedirectToAction("Index");


        }

        public IActionResult ObterTodos()
        {
            var todos = _Map.Map<List<DataModelViewModel>>(_repository.ObterTodos()); 
            return View(todos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}