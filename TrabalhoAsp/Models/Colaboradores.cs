using System.ComponentModel.DataAnnotations;

namespace TrabalhoAsp.Models
{
    public class Colaboradores
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo Nome é Obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo sobrenome é Obrigatório!")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo Titulo é Obrigatório!")]
        public string Titulo { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}