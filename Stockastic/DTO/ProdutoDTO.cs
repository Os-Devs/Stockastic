using System.Globalization;

namespace Stockastic.DTO
{
    public class ProdutoDTO
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string PrazoValidade { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeMinima { get; set; }
        public int Quantidade { get; set; }
        public string? Categoria { get; set; }

        public ProdutoDTO() { }

        public ProdutoDTO(int usuarioId, string nome, string prazoValidade, string descricao, decimal precoUnitario, int quantidadeMinima, int quantidade, string? categoria)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            PrazoValidade = prazoValidade;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            QuantidadeMinima = quantidadeMinima;
            Quantidade = quantidade;
            Categoria = categoria;
        }
    }
}
