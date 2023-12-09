using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;

namespace Stockastic.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly StockasticContext _dbcontext;

        public UsuarioService(StockasticContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<int> CadastroUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            var usuarioExistente = _dbcontext.Usuarios.FirstOrDefaultAsync(u => u.Email.ToUpper().Equals(usuarioDTO.Email.ToUpper()));

            if(usuarioExistente.Result == null)
            {
                var cadastroUsuario = new Usuario();

                cadastroUsuario.WithNomeLogin(usuarioDTO.NomeLogin)
                               .WithNomeUsuario(usuarioDTO.NomeUsuario)
                               .WithEmail(usuarioDTO.Email)
                               .WithSenha(usuarioDTO.Senha)
                               .WithTipoUsuario(usuarioDTO.TipoUsuario);

                _dbcontext.Usuarios.AddAsync(cadastroUsuario);
                return _dbcontext.SaveChangesAsync();
            }
            else
            {
                var task = new TaskCompletionSource<int>();
                Task.Delay(1000).ContinueWith(_ => { task.TrySetResult(0); });

                return task.Task;
            }
        }

        public Task<List<Usuario>> ListarUsuarios()
        {
            return _dbcontext.Usuarios.ToListAsync();
        }

        public Task<Usuario?> LoginUsuario(LoginDTO loginDTO)
        {
            var usuarioExistente = _dbcontext.Usuarios.FirstOrDefaultAsync(u => u.NomeUsuarioLogin.ToUpper().Equals(loginDTO.NomeUsuario) && u.Senha.Equals(loginDTO.Senha));
            return usuarioExistente;
        }
    }
}
