using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.Models;

[Route("api/usuarios")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly StockasticContext _context;

    public UsuarioController(StockasticContext context)
    {
        _context = context;
    }

    [HttpGet("listaUsuarios")]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    [HttpGet("tipo")]
    public ActionResult<IEnumerable<string>> GetTiposUsuario()
    {
        var tipo = Enum.GetNames(typeof(TipoUsuario));
        return Ok(tipo);
    }

    [HttpGet("login")]
    public async Task<ActionResult<Usuario>> Login([FromQuery] string nomeUsuarioLogin, [FromQuery] string senha)
    {
        var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.NomeUsuarioLogin == nomeUsuarioLogin);

        if (usuario == null)
        {
            return NotFound();
        }

        if (usuario.Senha != senha)
        {
            return Unauthorized();
        }
        return Ok();
    }

    [HttpPost("cadastro")]
    public async Task<ActionResult<Usuario>> Cadastro([FromBody] Usuario model)
    {
        var usuario = new Usuario();
        try
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.NomeUsuario == usuario.NomeUsuario);

            if (usuarioExistente == null)
            {
                usuario.NomeUsuarioLogin = model.NomeUsuarioLogin;
                usuario.NomeUsuario = model.NomeUsuario;
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
                return Ok("Usuário cadastrado com sucesso!");
            }
            else
            {
                throw new InvalidOperationException("Nome de usuário já existe");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao criar o usuário: " + ex.Message);
        }
    }
}
