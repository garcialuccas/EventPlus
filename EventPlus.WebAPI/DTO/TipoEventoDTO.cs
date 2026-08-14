using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class TipoEventoDTO
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caractéres")]
        public string TituloTipoEvento { get; set; } = string.Empty;
    }
}
