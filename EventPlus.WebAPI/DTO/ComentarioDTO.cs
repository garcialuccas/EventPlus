using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class ComentarioDTO
    {
        [Required]
        public Guid idUsuario { get; set; }

        [Required]
        public Guid idEvento { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O comentário deve ter no máximo 200 caracteres")]
        public string descricao { get; set; }

        public bool exibe = true;

        public DateTime DataComentario { get; set; } = DateTime.Now;
    }
}
