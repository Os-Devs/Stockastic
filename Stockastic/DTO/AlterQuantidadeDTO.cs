namespace Stockastic.DTO
{
    public class AlterQuantidadeDTO
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public AlterQuantidadeDTO() { }

        public AlterQuantidadeDTO(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
