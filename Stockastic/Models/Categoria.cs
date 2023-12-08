using System.ComponentModel.DataAnnotations;

namespace Stockastic.Models
{
    public class Categoria
    {

        [Key]
        public string NomeCategoria { get; set; }
        public string DescricaoCategoria { get; set; }

        public Categoria() { }

        public Categoria(string nomeCategoria, string descricaoCategoria)
        {
            NomeCategoria = nomeCategoria;
            DescricaoCategoria = descricaoCategoria;
        }

        public Categoria WithNome(string nome)
        {
            NomeCategoria = nome;
            return this;
        }

        public Categoria WithDescricao(string descricao)
        {
            DescricaoCategoria = descricao;
            return this;
        }
    }
}
