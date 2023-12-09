namespace Stockastic.DTO
{
    public class EmailDTO
    {
        public string Destinatarios { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }

        public EmailDTO() { }

        public EmailDTO(string destinatarios, string titulo, string assunto)
        {
            Destinatarios = destinatarios;
            Titulo = titulo;
            Assunto = assunto;
        }
    }
}
