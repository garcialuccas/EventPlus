using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

public partial class EventoDTO
{
    [Required(ErrorMessage = "O Nome do evento é obrigatório")]
    [StringLength(100)]
    public string NomeEvento { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data é obrigatória")]
    public DateTime DataEvento { get; set; }

    [Required(ErrorMessage = "A Descrição do evento é obrigatória")]
    public string Descricao { get; set; } = string.Empty;

    public IFormFile? ImagemUrl { get; set; }

    public Guid? IdTipoEvento { get; set; }

    public Guid? IdInstituicao { get; set; }}
