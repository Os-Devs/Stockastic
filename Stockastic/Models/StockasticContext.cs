using Microsoft.EntityFrameworkCore;

namespace Stockastic.Models
{
    public class StockasticContext : DbContext // O contexto do Banco de Dados seguindo o Entity Framework
    {
        public StockasticContext(DbContextOptions<StockasticContext> options) : base(options) // construtor
        {
            //aqui não entendi mt bem, mas tem que criar o construtor herdando as opções do dbcontext para o nosso contexto do banco de dados
        }

        public DbSet<Usuario> Usuarios { get; set; } // Assim cria as tabelas no banco de dados
        //como colocar informações do enum de tipo de usuario aqui pra ele compreender e colocar na tabela ? ou não precisa ?

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        //public DbSet<AssociacaoUsuarioProduto> AssociacaoUsuarioProduto { get; set; }
    }
}
