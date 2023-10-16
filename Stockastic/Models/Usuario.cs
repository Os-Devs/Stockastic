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

        public string Senha { get; set; }


        public TipoUsuario Tipo { get; set; }

        public Usuario()
        {
           
        }

        public Usuario(string nomeUsuario, string senha, string nomeUsuarioLogin)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            NomeUsuarioLogin = nomeUsuarioLogin;
        } 
    }

    public enum TipoUsuario
    {
        Empresa,
        Funcionario
    }
}
