using System.ComponentModel.DataAnnotations;

namespace Carros.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do carro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Informe a cor")]
        public string Cor { get; set; }

    }
}