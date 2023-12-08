namespace Stockastic.DTO
{
    public class CategoriaDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public CategoriaDTO() { }

        public CategoriaDTO(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
