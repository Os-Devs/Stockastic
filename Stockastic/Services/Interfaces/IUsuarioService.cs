using Stockastic.Models;

namespace Stockastic.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CadastroUsuario();
        Task<Usuario> LoginUsuario();
        Task<IEnumerable<Usuario>> ListarUsuarios();
    }
}
