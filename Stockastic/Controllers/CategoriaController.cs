using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.Models;

namespace Stockastic.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly StockasticContext _context;

        public CategoriaController(StockasticContext context)
        {
            _context = context;
        }

        [HttpPost("cadastro")]

        public async Task<ActionResult<Categoria>> Cadastro([FromBody] Categoria model)
        {
            try
            {
                var produtoExistente = _context.Categorias.FirstOrDefault(c => c.NomeCategoria == model.NomeCategoria);

                if (produtoExistente == null)
                {
                    var categoria = new Categoria
                    {
                        NomeCategoria = model.NomeCategoria,
                        DescricaoCategoria = model.DescricaoCategoria,
                    };

                    _context.Categorias.Add(categoria);
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
