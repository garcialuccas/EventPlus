using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class EdicaoUsuarioDTO
    {
        [StringLength(256, ErrorMessage = "O Email deve ter no máximo 256 caracteres")]
        public string email { get; set; } = string.Empty;

        [StringLength(60, ErrorMessage = "A Senha deve ter no máximo 60 caracteres")]
        public string senha {  get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string nome { get; set; } = string.Empty; 
    }
}
