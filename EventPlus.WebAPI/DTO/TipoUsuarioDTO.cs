using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class TipoUsuarioDTO
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caractéres")]
        public string TituloTipoUsuario { get; set; } = string.Empty;
    }
}
