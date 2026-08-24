namespace EventPlus.WebAPI.Interfaces
{
    public interface IModerationService
    {
        // true se o texto for reprovado
        Task<bool> ModerarTexto(string texto);
    }
}
