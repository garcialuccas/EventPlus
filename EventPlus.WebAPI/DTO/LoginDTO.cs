using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        [StringLength(256, ErrorMessage = "O Email deve ter no máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 60 caracteres")]
        public string senha { get; set; } = string.Empty;
    }
}
