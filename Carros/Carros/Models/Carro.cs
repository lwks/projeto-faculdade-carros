using System.ComponentModel.DataAnnotations;

namespace Carros.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do carro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a categoria")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Informe a cor")]
        public Cor Cor { get; set; }

    }

    public enum Categoria
    {
        Sedã,
        Hatch,
        Perua,
        Coupé,
        Picape,
        Van
    }

    public enum Cor
    {
        Preto,
        Branco,
        Vermelho,
        Verde, 
        Vinho
    }
}