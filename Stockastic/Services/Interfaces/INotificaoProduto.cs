using Stockastic.DTO;
using Stockastic.Models;

namespace Stockastic.Services.Interfaces
{
    public interface INotificaoProduto
    {
        Task<List<Notificacao>> ConsultarNotificoes(int usuario);
        void EnviarEmail(EmailDTO email);
    }
}
