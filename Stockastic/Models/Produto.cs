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
        public Categoria? Categoria { get; set; }
        public Usuario Usuario { get; set; }

        public Produto() { }

        public Produto(string nomeProduto, string prazoValidade, string descricaoProduto, decimal precoUnitarioProduto, int quantidadeMinimaEstoqueProduto, Categoria? categoria, Usuario usuario)
        {
            NomeProduto = nomeProduto;
            PrazoValidade = prazoValidade;
            DescricaoProduto = descricaoProduto;
            PrecoUnitarioProduto = precoUnitarioProduto;
            QuantidadeMinimaEstoqueProduto = quantidadeMinimaEstoqueProduto;
            Categoria = categoria;
            Usuario = usuario;
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
                return "A quantidade solicitada do produto é superior a quantidade em estoque.";
            }
        }

        /* Builder */
        public Produto WithNome(string nome)
        {
            NomeProduto = nome;
            return this;
        }


        public Produto WithPrazoValidade(string data)
        {
            PrazoValidade = data;
            return this;
        }

        public Produto WithDescricao(string descricao)
        {
            DescricaoProduto = descricao;
            return this;
        }

        public Produto WithPrecoUnitario(decimal preco)
        {
            PrecoUnitarioProduto = preco;
            return this;
        }

        public Produto WithQuantidadeMinima(int quantidade)
        {
            QuantidadeMinimaEstoqueProduto = quantidade;
            return this;
        }

        public Produto WithQuantidade(int quantidade)
        {
            QuantidadeAtual = quantidade;
            return this;
        }

        public Produto WithCategoria(Categoria categoria)
        {
            Categoria = categoria;
            return this;
        }

        public Produto WithUsuario(Usuario usuario)
        {
            Usuario = usuario;
            return this;
        }
    }
}
