using System.ComponentModel.DataAnnotations;

namespace Agendamento.App.Models
{
    public class ConsultaDataViewModel
    {
        [Required]
        public string DataHoje { get; set; }
    }
}
