using Stockastic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Stockastic.Models
{
    public class AssociacaoUsuarioProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProdutoIdd { get; set; }
        public Produto Produto { get; set; }

        public string UsuarioIdd { get; set; }
        public Usuario Usuario { get; set; }

    }
}
