using EventPlus.WebAPI.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System.Runtime.InteropServices.Marshalling;

namespace EventPlus.WebAPI.Services
{
    public class EnviarEmailService : IEnviarEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EnviarEmailService> _logger;

        public EnviarEmailService(IConfiguration configuration, ILogger<EnviarEmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task EnviarEmailAsync(string destinatario, string assunto, string corpo, CancellationToken ct = default)
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(_configuration["Smtp:RemetenteEmail"]!));
            message.To.Add(MailboxAddress.Parse(destinatario));
            message.Subject = assunto;

            message.Body = new TextPart("html") { Text = corpo };

            using var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(
                    _configuration["Smtp:Host"!],
                    int.Parse(_configuration["Smtp:Port"]!),
                        MailKit.Security.SecureSocketOptions.StartTls,
                        ct);

                await client.AuthenticateAsync(_configuration["Smtp:Usuario"]!, _configuration["Smtp:Senha"]!, ct);

                await client.SendAsync(message, ct);
                await client.DisconnectAsync(true, ct);
                _logger.LogInformation($"Para: {destinatario}\nAssunto: {assunto}\nCorpo: {corpo}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao enviar email\nErro: {ex.Message}");
            }
        }
    }
}
