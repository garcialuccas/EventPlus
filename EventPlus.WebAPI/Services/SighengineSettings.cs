using EventPlus.WebAPI.Interfaces;

namespace EventPlus.WebAPI.Services
{
    public class SighengineSettings : IModerationService
    {
        public string ApiUser { get; set; }
        public string ApiSecret { get; set; }

        public Task<bool> ModerarTexto(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
