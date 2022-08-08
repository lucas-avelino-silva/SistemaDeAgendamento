using Agendamento.App.Models;
using AutoMapper;
using Bussines.Interface;
using Bussines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace Agendamento.App.Controllers
{
    [ApiController]
    [Route("Api")]
    public class ApiAgendamento : Controller
    {
        private IConsultaDataRepository _repository;
        private IMapper _Map;
        private readonly ILogger<HomeController> _logger;

        public ApiAgendamento(ILogger<HomeController> logger, IConsultaDataRepository repository, IMapper map)
        {
            _logger = logger;
            _repository = repository;
            _Map = map;
        }

        [HttpPost]
        [Route("Consultar")]
        public IActionResult ConsultarData([FromBody] ConsultaDataViewModel data)
        {
            if (!ModelState.IsValid)
            {
                var result = "Não foi possivel consultar a data, tentar mais tarde!";
                return Ok(result);
            }
            var datas = _repository.ObterPorData(data.DataHoje);
            if (datas == null)
            {
                var horas = new List<string>() { "10:00", "13:00", "14:00" };
                return View(horas);
            }

            var horasCandidatas = new List<string>() { "10:00", "13:00", "14:00" };
            var horaPode = new List<string>();
            var horaNaoPode = new List<string>();
            foreach (var x in datas)
            {
                if (x.Hora == "10:00" || x.Hora == "13:00" || x.Hora == "14:00")
                {
                    horaNaoPode.Add(x.Hora);
                }
            }

            foreach (var hora in horasCandidatas)
            {
                if (!horaNaoPode.Contains(hora))
                {
                    horaPode.Add(hora);
                }
            }

            return Ok(horaPode);

        }

    }
}