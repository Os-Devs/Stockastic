using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockastic.Models
{
    public class Notificacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
        public TipoNotificacao TipoNotificao { get; set; }
        public string Mensagem { get; set; }
        public bool Lido { get; set; }

        public Notificacao() { }

        public Notificacao(Usuario usuario, Produto produto, TipoNotificacao tipoNotificao, string mensagem)
        {
            Usuario = usuario;
            Produto = produto;
            TipoNotificao = tipoNotificao;
            Mensagem = mensagem;
        }

        /* Builder */
        public Notificacao WithUsuario(Usuario usuario)
        {
            Usuario = usuario;
            return this;
        }

        public Notificacao WithProduto(Produto produto)
        {
            Produto = produto;
            return this;
        }

        public Notificacao WithTipo(int tipo)
        {
            TipoNotificacao[] valores = (TipoNotificacao[]) Enum.GetValues(typeof(TipoNotificacao));
            TipoNotificao = valores[tipo];
            return this;
        }

        public Notificacao WithMensagem(string mensagem)
        {
            Mensagem = mensagem;
            return this;
        }

        public Notificacao WithLido(bool lido)
        {
            Lido = lido;
            return this;
        }
    }

    public enum TipoNotificacao
    {
        Validade,
        Estoque
    }
}
