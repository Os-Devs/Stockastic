namespace Stockastic.DTO
{
    public class CadastroUsuarioDTO
    {
        public string NomeLogin { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
    }
}
