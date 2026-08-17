using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

public partial class EdicaoEventoDTO
{
    [StringLength(100)]
    public string NomeEvento { get; set; } = string.Empty;

    public DateTime DataEvento { get; set; }

    public string Descricao { get; set; } = string.Empty;

    [StringLength(200)]
    public string? ImagemUrl { get; set; }

    public Guid? IdTipoEvento { get; set; }

    public Guid? IdInstituicao { get; set; }
}
