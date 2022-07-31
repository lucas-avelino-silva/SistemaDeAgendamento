using System.ComponentModel.DataAnnotations;

namespace Agendamento.App.Models
{
    public class DataModelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Hora { get; set; }



        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public PessoaViewModel Pessoa { get; set; }

    }
}
