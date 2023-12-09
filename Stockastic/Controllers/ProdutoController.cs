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
        private readonly INotificaoProduto _notificacao;
        private readonly IProdutoService _produtoService;

        public ProdutoController(INotificaoProduto context, IProdutoService produtoService)
        {
            _notificacao = context;
            _produtoService = produtoService;
        }

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

        [HttpPost("notificacoes")]
        public async Task<ActionResult<List<Notificacao>>> Notificacoes([FromBody] EditarProdutoDTO produtoDTO, [FromQuery] int page)
        {
            try
            {
                int init = (page - 1) * 5;
                var editar = await _notificacao.ConsultarNotificoes(produtoDTO.UsuarioId);
                return Ok(editar.Skip(init).Take(5).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um ao listar as notificações: " + ex.Message);
            }
        }
    }
}
