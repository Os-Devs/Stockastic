using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpPost("cadastro")]

        public async Task<ActionResult<Produto>> Cadastro([FromBody] Produto model)
        {
            try
            {
                var produtoExistente = _context.Produtos.FirstOrDefault(p => p.NomeProduto == model.NomeProduto);

                if (produtoExistente == null)
                {
                    var produto = new Produto
                    {
                        NomeProduto = model.NomeProduto,
                        PrazoValidade = model.PrazoValidade,
                        DescricaoProduto = model.DescricaoProduto,
                        PrecoUnitarioProduto = model.PrecoUnitarioProduto,
                        QuantidadeMinimaEstoqueProduto = model.QuantidadeMinimaEstoqueProduto
                    };

                    _context.Produtos.Add(produto);
                    await _context.SaveChangesAsync();

                    return Ok("Produto cadastrado com sucesso!");
                }
                else
                {
                    throw new InvalidOperationException("Produto já existe em estoque");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar o produto: " + ex.Message);
            }
        }


    }
}
