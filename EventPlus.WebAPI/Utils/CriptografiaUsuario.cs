using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;

namespace EventPlus.WebAPI.Utils
{
    public class CriptografiaUsuario
    {
        private const int WorkFactor = 12;

        public static string CriptografarSenha(string senhaOriginal)
        {
            if (senhaOriginal.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return BCrypt.Net.BCrypt.HashPassword(senhaOriginal, WorkFactor);
        }

        public static bool VerificarSenha(string senhaOriginal, string senhaCriptografada)
        {
            if (senhaOriginal.IsNullOrEmpty() || senhaOriginal.IsNullOrEmpty())
            {
                return false;
            }

            try
            {
                return BCrypt.Net.BCrypt.Verify(senhaOriginal, senhaCriptografada);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                return false;
            }
        }
    }
}
