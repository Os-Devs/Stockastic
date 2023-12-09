using Microsoft.EntityFrameworkCore;
using Stockastic.DTO;
using Stockastic.Models;
using Stockastic.Services.Interfaces;
using System.Globalization;
using System.Net;
using System.Net.Mail;

namespace Stockastic.Services
{
    public class NotificacaoService : INotificaoProduto
    {
        private readonly StockasticContext _dbcontext;

        public NotificacaoService(StockasticContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        private void CriarNotificoes(int usuario)
        {
            var produtosUsuario = _dbcontext.Produtos.Where(p => p.Usuario.Id == usuario).Include(p => p.Usuario).ToListAsync();

            if(produtosUsuario.Result.Count > 0)
            {
                foreach(var produto in produtosUsuario.Result)
                {
                    DateTime hoje = DateTime.Now;
                    DateTime validadeProduto = DateTime.ParseExact(produto.PrazoValidade, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if(produto.QuantidadeAtual <= produto.QuantidadeMinimaEstoqueProduto)
                    {
                        var notificacaoExistente = _dbcontext.Notificacoes.FirstOrDefault(n => n.Usuario.Id == produto.Usuario.Id && n.Produto.Id == produto.Id && n.TipoNotificao == TipoNotificacao.Estoque);

                        if (notificacaoExistente == null)
                        {
                            var notificacao = new Notificacao();

                            notificacao.WithUsuario(produto.Usuario)
                                        .WithProduto(produto)
                                        .WithTipo(1)
                                        .WithMensagem($"O produto {produto.NomeProduto} está com quantidade mínima no estoque")
                                        .WithLido(false);

                            _dbcontext.Notificacoes.Add(notificacao);
                            _dbcontext.SaveChanges();
                        }
                    }

                    if(validadeProduto.AddDays(-7) <= hoje)
                    {
                        var notificacaoExistente = _dbcontext.Notificacoes.FirstOrDefault(n => n.Usuario.Id == produto.Usuario.Id && n.Produto.Id == produto.Id && n.TipoNotificao == TipoNotificacao.Validade);

                        if (notificacaoExistente == null)
                        {
                            var notificacao = new Notificacao();

                            notificacao.WithUsuario(produto.Usuario)
                                       .WithProduto(produto)
                                       .WithTipo(0)
                                       .WithMensagem($"O produto {produto.NomeProduto} está próximo do seu vencimento")
                                       .WithLido(false);

                            _dbcontext.Notificacoes.Add(notificacao);
                            _dbcontext.SaveChanges();
                        }
                    }
                }
            }
        }

        public Task<List<Notificacao>> ConsultarNotificoes(int usuario)
        {
            CriarNotificoes(usuario);

            var notificacoesSistema = _dbcontext.Notificacoes.Where(n => n.Usuario.Id == usuario && n.Lido == false);

            return notificacoesSistema.ToListAsync();
        }

        public void EnviarEmail(EmailDTO email)
        {
            string servidorSmtp = "smtp.gmail.com";
            int portaSmtp = 587;

            string from = "enviadorafakao@gmail.com";
            string senha = "ifpb1234";

            var mensagem = new MailMessage(from, email.Destinatarios, email.Titulo, email.Assunto);

            var clienteSmtp = new SmtpClient(servidorSmtp)
            {
                Port = portaSmtp,
                Credentials = new NetworkCredential(from, senha),
                EnableSsl = true
            };

            try
            {
                clienteSmtp.Send(mensagem);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao enviar o e-mail: {ex.Message}");
            }
        }

    }
}
