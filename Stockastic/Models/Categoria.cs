using System.ComponentModel.DataAnnotations;

namespace Stockastic.Models
{
    public class Categoria
    {
        [Key]
        public string? nomeCategoria { get; set; }

        public string? descricaoCategoria { get; set;}
    }
}
