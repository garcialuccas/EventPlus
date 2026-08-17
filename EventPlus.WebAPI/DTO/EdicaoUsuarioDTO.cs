using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class EdicaoUsuarioDTO
    {
        [StringLength(256, ErrorMessage = "O Email deve ter no máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string email { get; set; } = string.Empty;

        [StringLength(60, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 60 caracteres")]
        public string senha {  get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string nome { get; set; } = string.Empty; 
    }
}
