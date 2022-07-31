using System.ComponentModel.DataAnnotations;

namespace Bussines.Models
{
    public class DataModel: Entity
    {
        [Required]
        public string Data { get; set; }
        [Required]
        public string Hora { get; set; }
        [Required]


        public PessoaModel Pessoa { get; set; }
    }
}
