using Stockastic.DTO;
using Stockastic.Models;

namespace Stockastic.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<int> CadastroCategoria(CategoriaDTO categoriaDTO);
        Task<List<Categoria>> ListarCategorias();
    }
}
