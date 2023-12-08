using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

namespace Stockastic.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly StockasticContext _dbContext;

        public CategoriaService(StockasticContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CadastroCategoria(CategoriaDTO categoriaDTO)
        {
            var categoriaExistente = _dbContext.Categorias.FirstOrDefault(c => c.NomeCategoria.ToUpper().Equals(categoriaDTO.Nome.ToUpper()));

            if(categoriaExistente == null)
            {
                var categoria = new Categoria();

                categoria.WithNome(categoriaDTO.Nome)
                         .WithDescricao(categoriaDTO.Descricao);

                _dbContext.Categorias.Add(categoria);
                return _dbContext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }

        public Task<List<Categoria>> ListarCategorias()
        {
            return _dbContext.Categorias.ToListAsync();
        }
    }
}
