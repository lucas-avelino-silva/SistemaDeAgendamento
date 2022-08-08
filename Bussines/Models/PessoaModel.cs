using System.ComponentModel.DataAnnotations;

namespace Bussines.Models
{
    public class PessoaModel: Entity
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string telefone { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]

        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
