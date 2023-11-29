using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.Models;

namespace Stockastic.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly StockasticContext _context;
        public ProdutoController(StockasticContext context)
        {
            _context = context;
        }

        [HttpGet("listaProdutos")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpPost("cadastro")]

        public async Task<IActionResult> CriarProduto([FromBody] Produto produtowModel)
        {

            try
            {
                var produtoExistente = _context.Produtos.FirstOrDefault(u => u.NomeProduto == produtowModel.NomeProduto);

                if (produtoExistente == null)
                {
                    var produto = new Produto
                    {
                        NomeProduto = produtowModel.NomeProduto,
                        PrazoValidade = produtowModel.PrazoValidade,
                        DescricaoProduto = produtowModel.DescricaoProduto,
                        PrecoUnitarioProduto = produtowModel.PrecoUnitarioProduto,
                        QuantidadeMinimaEstoqueProduto = produtowModel.QuantidadeMinimaEstoqueProduto
                    };

                    await _context.SaveChangesAsync();

                    return Ok("Produto cadastrado com sucesso!");
                }
                else
                {
                    throw new InvalidOperationException("Produto já existe para esse usuário cadastrado, incremente-o.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar o produto: " + ex.Message);
            }
        }

        [HttpPost("incrementar")]
        public async Task<IActionResult> IncrementarProduto([FromBody] int quantidade)
        {
            var produtowModel = new Produto();
            var produtoExistente = _context.Produtos.FirstOrDefault(p => p.NomeProduto == produtowModel.NomeProduto);
            if (produtoExistente != null)
                produtoExistente.IncrementarQuantidade(quantidade);

            await _context.SaveChangesAsync();

            return Ok("Quantidade do produto adicionada com sucesso");
        }

        [HttpPost("decrementar")]
        public async Task<IActionResult> DecrementarProduto([FromBody]int quantidade)
        {
            var produtowModel = new Produto();
            var produtoExistente = _context.Produtos.FirstOrDefault(p => p.NomeProduto == produtowModel.NomeProduto);
            if (produtoExistente != null)
                produtoExistente.DecrementarQuantidade(quantidade);

            await _context.SaveChangesAsync();

            return Ok("Quantidade do produto removida com sucesso");
        }
    }
}
