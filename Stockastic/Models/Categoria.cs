using System.ComponentModel.DataAnnotations;

namespace Stockastic.Models
{
    public class Categoria
    {
        [Key]
        public string? NomeCategoria { get; set; }

        public string? DescricaoCategoria { get; set;}
    }
}
