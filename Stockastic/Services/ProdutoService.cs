using Microsoft.EntityFrameworkCore;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

namespace Stockastic.Services
{
    public class ProdutoService : IProdutoService
    {
        readonly Usuario usuario = new Usuario();
        readonly Produto produto = new Produto();

        private readonly StockasticContext _dbContext;

        public ProdutoService(StockasticContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (usuario.Tipo == TipoUsuario.Empresa)
            {
                _dbContext.Produtos.Add(produto);
                _dbContext.SaveChanges();
            }
        }

        public void RemoverProduto(Produto produto)
        {
            if (usuario.Tipo == TipoUsuario.Empresa)
            {
                _dbContext.Produtos.Remove(produto);
                _dbContext.SaveChanges();
            }
        }

        /* Usando Service */

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public Task<int> CadastrarProduto(Produto produto)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.NomeProduto.ToUpper().Equals(produto.NomeProduto.ToUpper()) /* && p.Usuario.Equals(produto.Usuario) */);

            if(produtoExistente == null)
            {
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



        //public void EditarProduto(Produto produto)
        //{
        //    var descricao = produto.DescricaoProduto;
        //    var precoUnitario = produto.PrecoUnitarioProduto;
        //    if (usuario.Tipo == TipoUsuario.Empresa)
        //    {
        //        _dbContext.Produtos.Update(descricao);
        //        _dbContext.Produtos.Update(precoUnitario);
        //    }
        //}

        // id especificado, eu preciso editar usando linq e depois dar update no produto em si.

        // criar repositório pra isolar ainda mais a lógica

        //Injeção de dependência

        // como fazer um método que permita editar informações de produto? no caso, eu só queria permitir a edição da descrição do produto e seu preço unitário

        // acho que é tranquilo fazer um update ou uma consulta usando linq, sei lá, deve funcionar
    }
}
