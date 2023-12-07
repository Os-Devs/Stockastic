using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Stockastic.Models
{
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeUsuarioLogin { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Tipo { get; set; }
        public List<Produto> Produtos { get; set; }

        private void InitLista()
        {
            Produtos = new List<Produto>();
        }

        public Usuario() 
        {
            InitLista();        
        }

        public Usuario(string nomeUsuarioLogin, string nomeUsuario, string email, string senha, TipoUsuario tipoUsuario)
        {
            NomeUsuarioLogin = nomeUsuarioLogin;
            NomeUsuario = nomeUsuario;
            Email = email;
            Senha = senha;
            Tipo = tipoUsuario;
            InitLista();
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public void RemoverProduto(Produto produto)
        {
            Produtos.Remove(produto);
        }
    }

    public enum TipoUsuario
    {

        Empresa,
        Funcionario

    }
}
