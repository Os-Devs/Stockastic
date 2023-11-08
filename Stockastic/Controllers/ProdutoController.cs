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
        private readonly UserManager<Usuario> _userManager;

        public ProdutoController(StockasticContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("cadastro")]

        public async Task<IActionResult> CriarProduto([FromBody] Produto produtowModel, Usuario usuarioId)
        {
            try
            {
                var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuarioId.NomeUsuario);

                if (usuarioExistente != null)
                {
                    var produto = new Produto

                    {
                        NomeProduto = produtowModel.NomeProduto,
                        PrazoValidade = produtowModel.PrazoValidade,
                        DescricaoProduto = produtowModel.DescricaoProduto,
                        PrecoUnitarioProduto = produtowModel.PrecoUnitarioProduto,
                        QuantidadeMinimaEstoqueProduto = produtowModel.QuantidadeMinimaEstoqueProduto
                    };

                    var associacaoUsuarioProduto = new AssociacaoUsuarioProduto
                    {
                        Produto = produto,

                        Usuario = usuarioExistente
                    };

                    _context.AssociacaoUsuarioProduto.Add(associacaoUsuarioProduto);
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

    }
}
