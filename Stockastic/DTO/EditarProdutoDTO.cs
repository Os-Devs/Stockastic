using Stockastic.Models;

namespace Stockastic.DTO
{
    public class EditarProdutoDTO : ProdutoDTO
    {
        public int ProdutoId { get; set; }

        public EditarProdutoDTO() { }

        public EditarProdutoDTO(int produtoId, int usuarioId, string nome, string prazoValidade, string descricao, decimal precoUnitario, int quantidadeMinima, int quantidade, string? categoria) 
            : base(usuarioId, nome, prazoValidade, descricao, precoUnitario, quantidadeMinima, quantidade, categoria)
        {
            ProdutoId = produtoId;
        }
    }
}
