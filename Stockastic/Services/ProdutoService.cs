using Stockastic.Models;

namespace Stockastic.Services
{
    public class ProdutoService
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
