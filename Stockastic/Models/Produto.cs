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
        public int QuantidadeAtual { get; set; } // preciso criar um método para atribuir valores a essa propriedade, eu deixo setar?

        public Produto()
        {
        }

        public Produto(string nomeProduto, string prazoValidade, string descricaoProduto, decimal precoUnitarioProduto, int quantidadeMinimaEstoqueProduto)
        {
            NomeProduto = nomeProduto;
            PrazoValidade = prazoValidade;
            DescricaoProduto = descricaoProduto;
            PrecoUnitarioProduto = precoUnitarioProduto;
            QuantidadeMinimaEstoqueProduto = quantidadeMinimaEstoqueProduto;
        }

    }
}
