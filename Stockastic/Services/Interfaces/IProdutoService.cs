using Stockastic.Models;

namespace Stockastic.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<int> CadastrarProduto(Produto produto);
    }
}
