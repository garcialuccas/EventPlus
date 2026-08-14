using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EventPlus.WebAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "O nome fantasia é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome fantasia deve ter no máximo 100 caracteres")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, ErrorMessage = "O CNPJ deve ter no máximo 14 caracteres")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(100, ErrorMessage = "O endereço deve ter no máximo 100 caracteres")]
        public string Endereco { get; set;  } = string.Empty;
    }
}
