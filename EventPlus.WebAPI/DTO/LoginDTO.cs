using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        [StringLength(256, ErrorMessage = "O Email deve ter no máximo 256 caracteres")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [StringLength(60, ErrorMessage = "A Senha deve ter no máximo 60 caracteres")]
        public string senha { get; set; } = string.Empty;
    }
}
