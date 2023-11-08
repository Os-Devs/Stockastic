using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockastic.Models
{
    public class Produto
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NomeProduto { get; set; }
        public string PrazoValidade { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal PrecoUnitarioProduto { get; set; }
        public int QuantidadeMinimaEstoqueProduto { get; set; }
        public int QuantidadeAtual { get; set; }
        public Usuario UsuarioAssociado { get; set; }

        public Produto()
        {
        }

        public Produto(string nomeProduto, string prazoValidade, string descricaoProduto, decimal precoUnitarioProduto, int quantidadeMinimaEstoqueProduto, Usuario usuarioAssociado)
        {
            NomeProduto = nomeProduto;
            PrazoValidade = prazoValidade;
            DescricaoProduto = descricaoProduto;
            PrecoUnitarioProduto = precoUnitarioProduto;
            QuantidadeMinimaEstoqueProduto = quantidadeMinimaEstoqueProduto;
            UsuarioAssociado = usuarioAssociado;

        }

        public string IncrementarQuantidade(int quantidade)
        {
            QuantidadeAtual += quantidade;
            return "Quantidade do produto adicionada com sucesso";
        }

        public string DecrementarQuantidade(int quantidade)
        {
            if (QuantidadeAtual >= quantidade)
            {
                QuantidadeAtual -= quantidade;
                return "Quantidade do produto diminuída com sucesso";
            }
            else
            {
                throw new Exception("A quantidade solicitada do produto é superior a quantidade em estoque.");
            }
        }

    }
}
