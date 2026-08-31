using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace EventPlus.WebAPI.Utils
{
    public class SightengineModerationService : IModerationService
    {
        private readonly HttpClient _http;
        private readonly string _apiUser;
        private readonly string _apiSecret;
        private const double limiar = 0.5;
        public SightengineModerationService(HttpClient http, IOptions<SightengineSettings> options)
        {
            _http = http;
            _apiUser = options.Value.ApiUser;
            _apiSecret = options.Value.ApiSecret;
        }
        public async Task<bool> ModerarTexto(string texto)
        {
            var form = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["text"] = texto,
                ["lang"] = "pt",
                ["mode"] = "ml",
                ["api_user"] = _apiUser,
                ["api_secret"] = _apiSecret
            });

            var resposta = await _http.PostAsync("text/check.json", form);

            resposta.EnsureSuccessStatusCode();

            using var doc = JsonDocument.Parse(await resposta.Content.ReadAsStringAsync());

            var root = doc.RootElement;

            if (root.GetProperty("status").GetString() != "sucess")
            {
                var msg = root.TryGetProperty("error", out var err) && err.TryGetProperty("message", out var m) ? m.GetString() : "erro desconhecido";

                throw new Exception($"Sightengine: {msg}");
            }

            var classes = root.GetProperty("moderatoin_classes");

            foreach (var prop in classes.EnumerateObject())
            {
                if (prop.Name == "available") continue;

                if (prop.Value.ValueKind == JsonValueKind.Number && prop.Value.GetDouble() >= limiar) return true; // reprovado
            }

            return false; // aprovado
        }
    }
}
