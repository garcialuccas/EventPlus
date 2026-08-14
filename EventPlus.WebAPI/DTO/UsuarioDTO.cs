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
        [StringLength(256, ErrorMessage = "O email deve ter no máximo 256 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(60, ErrorMessage = "A senha deve ter no máximo 60 caracteres")]
        public string Senha {  get; set; } = string.Empty;

        public Guid? idTipoUsuatio { get; set; }
    }
}
