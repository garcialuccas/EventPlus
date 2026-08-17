using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class PresencaDTO
    {
        [Required]
        public Guid idUsuario { get; set; } = Guid.Empty;

        [Required]
        public Guid idEvento { get; set; } = Guid.Empty;
    }
}
