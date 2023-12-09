using Microsoft.EntityFrameworkCore;

namespace Stockastic.Models
{
    public class StockasticContext : DbContext
    {
        public StockasticContext(DbContextOptions<StockasticContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Notificacao> Notificacoes { get; set; }
    }
}
