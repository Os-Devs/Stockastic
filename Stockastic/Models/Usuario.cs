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

        public Usuario() { }

        public Usuario(string nomeUsuarioLogin, string nomeUsuario, string email, string senha, TipoUsuario tipoUsuario)
        {
            NomeUsuarioLogin = nomeUsuarioLogin;
            NomeUsuario = nomeUsuario;
            Email = email;
            Senha = senha;
            Tipo = tipoUsuario;
        }

        /* Builder */
        public Usuario WithNomeLogin(string nome)
        {
            NomeUsuarioLogin = nome;
            return this;
        }

        public Usuario WithNomeUsuario(string nome)
        {
            NomeUsuario = nome;
            return this;
        }

        public Usuario WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public Usuario WithSenha(string senha)
        {
            Senha = senha;
            return this;
        }

        public Usuario WithTipoUsuario(int tipo)
        {
            TipoUsuario[] valores = (TipoUsuario[]) Enum.GetValues(typeof(TipoUsuario));
            Tipo = valores[tipo];
            return this;
        }
    }

    public enum TipoUsuario
    {
        Empresa,
        Funcionario
    }
}
