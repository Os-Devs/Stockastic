using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

namespace Stockastic.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly StockasticContext _context;
        private readonly IProdutoService _produtoService;

        public ProdutoController(StockasticContext context, IProdutoService produtoService)
        {
            _context = context;
            _produtoService = produtoService;
        }

        /*[HttpGet("listaProdutos")]
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
        */

        //Usando Service

        [HttpGet("listaProdutos/{usuario}")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarProdutos(int usuario)
        {
            return await _produtoService.ListarProdutos(usuario);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO produtoModel)
        {

            try
            {
                var cadastro = await _produtoService.CadastrarProduto(produtoModel);

                if (cadastro > 0)
                {
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
        public async Task<IActionResult> IncrementarProduto([FromBody] AlterQuantidadeDTO quantidadeDTO)
        {
            try
            {
                var incrementar = await _produtoService.IncrementarProduto(quantidadeDTO);

                if (incrementar > 0)
                {
                    return Ok("Quantidade do produto adicionada com sucesso");
                }
                else
                {
                    return StatusCode(500, "Ocorreu um erro ao incrementar o produto");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao incrementar o produto: " + ex.Message);
            }
        }

        [HttpPost("decrementar")]
        public async Task<IActionResult> DecrementarProduto([FromBody] AlterQuantidadeDTO quantidadeDTO)
        {
            try
            {
                var decrementar = await _produtoService.DecrementarProduto(quantidadeDTO);

                if (decrementar > 0)
                {
                    return Ok("Quantidade do produto decrementada com sucesso");
                }
                else
                {
                    return StatusCode(500, "Ocorreu um erro ao decrementar o produto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao decrementar o produto: " + ex.Message);
            }
        }

        [HttpDelete("remover")]
        public async Task<IActionResult> RemoverProduto([FromBody] RemoverProdutoDTO quantidadeDTO)
        {
            try
            {
                var decrementar = await _produtoService.RemoverProduto(quantidadeDTO);

                if (decrementar > 0)
                {
                    return Ok("Produto removido com sucesso");
                }
                else
                {
                    return StatusCode(500, "Ocorreu um erro ao remover o produto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao remover o produto: " + ex.Message);
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EditarProduto([FromBody] EditarProdutoDTO produtoDTO)
        {
            try
            {
                var editar = await _produtoService.EditarProduto(produtoDTO);

                if (editar > 0)
                {
                    return Ok("Produto editado com sucesso");
                }
                else
                {
                    return StatusCode(500, "Ocorreu um erro ao editar o produto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao editar o produto: " + ex.Message);
            }
        }

    }
}
