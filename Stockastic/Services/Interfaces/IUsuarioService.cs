using Stockastic.DTO;
using Stockastic.Models;

namespace Stockastic.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CadastroUsuario(CadastroUsuarioDTO usuarioDTO);
        Task<Usuario?> LoginUsuario(LoginDTO loginDTO);
        Task<List<Usuario>> ListarUsuarios();
    }
}
