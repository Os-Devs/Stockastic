using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

namespace Stockastic.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly StockasticContext _dbContext;

        public ProdutoService(StockasticContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Produto>> ListarProdutos(int usuario)
        {
            return _dbContext.Produtos.Where(p => p.Usuario.Id == usuario).Include(p => p.Categoria).ToListAsync();
        }

        public Task<int> CadastrarProduto(ProdutoDTO produtoDTO)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.NomeProduto.ToUpper().Equals(produtoDTO.Nome.ToUpper()) && p.Usuario.Id == produtoDTO.UsuarioId);
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Id == produtoDTO.UsuarioId);
            var categoria = _dbContext.Categorias.FirstOrDefault(c => c.NomeCategoria.ToUpper().Equals(produtoDTO.Categoria.ToUpper()));

            if (produtoExistente == null && usuario != null)
            {
                var produto = new Produto();

                produto.WithNome(produtoDTO.Nome)
                       .WithPrazoValidade(produtoDTO.PrazoValidade)
                       .WithDescricao(produtoDTO.Descricao)
                       .WithPrecoUnitario(produtoDTO.PrecoUnitario)
                       .WithQuantidadeMinima(produtoDTO.QuantidadeMinima)
                       .WithQuantidade(produtoDTO.Quantidade)
                       .WithCategoria(categoria)
                       .WithUsuario(usuario);

                _dbContext.Produtos.Add(produto);
                return _dbContext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }

        public Task<int> IncrementarProduto(AlterQuantidadeDTO quantidadeDTO)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.Id == quantidadeDTO.ProdutoId);

            if(produtoExistente != null)
            {
                produtoExistente.IncrementarQuantidade(quantidadeDTO.Quantidade > 0 ? quantidadeDTO.Quantidade : 0);
                return _dbContext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }

        public Task<int> DecrementarProduto(AlterQuantidadeDTO quantidadeDTO)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.Id == quantidadeDTO.ProdutoId);

            if (produtoExistente != null)
            {
                produtoExistente.DecrementarQuantidade(quantidadeDTO.Quantidade > 0 ? quantidadeDTO.Quantidade : 0);
                return _dbContext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }

        public Task<int> RemoverProduto(RemoverProdutoDTO removerDTO)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.Id == removerDTO.ProdutoId);
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Id == removerDTO.UsuarioId);

            if (produtoExistente != null && (usuario != null && usuario.Tipo == TipoUsuario.Empresa))
            {
                _dbContext.Produtos.Remove(produtoExistente);
                return _dbContext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }

        public Task<int> EditarProduto(EditarProdutoDTO produtoDTO)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.Id == produtoDTO.ProdutoId);
            var categoria = _dbContext.Categorias.FirstOrDefault(c => c.NomeCategoria.ToUpper().Equals(produtoDTO.Categoria.ToUpper()));

            if(produtoExistente != null)
            {
                produtoExistente.WithDescricao(produtoDTO.Descricao)
                                .WithPrecoUnitario(produtoDTO.PrecoUnitario)
                                .WithCategoria(categoria);

                return _dbContext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }
    }
}
