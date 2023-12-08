using Stockastic.DTO;
using Stockastic.Models;

namespace Stockastic.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>> ListarProdutos(int usuario);
        Task<int> CadastrarProduto(ProdutoDTO produtoDTO);
        Task<int> IncrementarProduto(AlterQuantidadeDTO quantidadeDTO);
        Task<int> DecrementarProduto(AlterQuantidadeDTO quantidadeDTO);
        Task<int> RemoverProduto(RemoverProdutoDTO removerDTO);
        Task<int> EditarProduto(EditarProdutoDTO produtoDTO);
    }
}
