namespace EventPlus.WebAPI.Interfaces
{
    public interface IEnviarEmailService
    {
        Task EnviarEmailAsync(string destinatario, string assunto, string corpo, CancellationToken ct = default);
    }
}
