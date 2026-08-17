using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        [StringLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(60, MinimumLength = 8,ErrorMessage = "A senha deve ter entre 8 e 60 caracteres")]
        public string Senha {  get; set; } = string.Empty;

        public Guid? idTipoUsuario { get; set; }
    }
}
