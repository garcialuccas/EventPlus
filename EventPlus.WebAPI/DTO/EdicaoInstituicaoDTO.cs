using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class EdicaoInstituicaoDTO
    {
        [StringLength(100, ErrorMessage = "O Nome Fantasia deve ter no máximo 100 caracteres")]
        public string NomeFantasia { get; set; } = string.Empty;

        [StringLength(14, ErrorMessage = "O CNPJ deve ter no máximo 14 caracteres")]
        public string Cnpj { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O Endereço deve ter no máximo 100 caracteres")]
        public string Endereco { get; set; } = string.Empty;
    }
}
