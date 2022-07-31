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
            
            return View();
        }



        [HttpPost]
        public IActionResult ConsultarData(ConsultaDataViewModel data)
        {
            var datas = _repository.ObterPorData(data.DataHoje);
            if (datas == null)
            {
                var horaTemp = new List<string>() { "10:00", "13:00", "14:00" };
                ViewBag.horas = horaTemp;
                ViewBag.data = data.DataHoje;
                return View();
            }

            var horasCandidatas = new List<string>() { "10:00", "13:00", "14:00" };
            var horaPode = new List<string>();
            var horaNaoPode = new List<string>();
            foreach (var x in datas)
            {
                if(x.Hora == "10:00" || x.Hora == "13:00" || x.Hora == "14:00")
                {
                    horaNaoPode.Add(x.Hora);
                }
            }

            foreach(var hora in horasCandidatas) 
            {
                if (!horaNaoPode.Contains(hora))
                {
                    horaPode.Add(hora);
                }
            }

            ViewBag.horas = horaPode;
            ViewBag.data = data.DataHoje;
            return View();
                
        }

        [HttpPost]
        public IActionResult Agendar(DataModelViewModel form)
        {
            if (ModelState.IsValid)
            {
                _repository.Adicionar(_Map.Map<DataModel>(form));
                ViewData["resultado"] = "Agendado com Sucesso!";
                return RedirectToAction("Index");
            }

            ViewData["resultado"] = "Não foi possivel agendar, tentar mais tarde!";
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