using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

[Route("api/usuarios")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService service)
    {
        _usuarioService = service;
    }

    [HttpGet("listaUsuarios")]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _usuarioService.ListarUsuarios();
    }

    [HttpPost("login")]
    public async Task<ActionResult<Usuario>> Login([FromBody] LoginDTO login)
    {
        var usuario = await _usuarioService.LoginUsuario(login);

        if (usuario == null)
        {
            return Unauthorized();
        }

        return Ok(usuario);
    }

    [HttpPost("cadastro")]
    public async Task<ActionResult<Usuario>> Cadastro([FromBody] CadastroUsuarioDTO model)
    {
        try
        {
            var cadastro = await _usuarioService.CadastroUsuario(model);

            if(cadastro > 0)
            {
                return Ok("Usuário cadastrado com sucesso!");
            }
            else
            {
                return StatusCode(400, "Ocorreu um erro ao criar o usuário: Já existe um usuário registrado com os dados informados" );
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao criar o usuário: " + ex.Message);
        }
    }
}
