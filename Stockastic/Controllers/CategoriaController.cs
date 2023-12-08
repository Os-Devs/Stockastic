using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

namespace Stockastic.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoria;

        public CategoriaController(ICategoriaService categoria)
        {
            _categoria = categoria;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult> Cadastro([FromBody] CategoriaDTO categoria)
        {
            try
            {
                var cadastro = await _categoria.CadastroCategoria(categoria);

                if(cadastro > 0)
                {
                    return Ok("Categoria cadastrada com sucesso!");
                }
                else
                {
                    throw new InvalidOperationException("Produto já existe em estoque");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar a categoria: " + ex.Message);
            }
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Categoria>>> ListarCategorias()
        {
            return await _categoria.ListarCategorias();
        }
    }
}
