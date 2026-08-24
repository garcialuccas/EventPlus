using System;
using System.Collections.Generic;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.BdContextEvent;

public partial class EventContext : DbContext
{
    public EventContext()
    {
    }

    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentario { get; set; }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<Instituicao> Instituicao { get; set; }

    public virtual DbSet<Presenca> Presenca { get; set; }

    public virtual DbSet<StatusEvento> StatusEvento { get; set; }

    public virtual DbSet<TipoEvento> TipoEvento { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.Property(e => e.IdComentario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Comentario).HasConstraintName("FK_Comentario_Evento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("trgEventoStatusEvento"));

            entity.Property(e => e.IdEvento).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdInstituicaoNavigation).WithMany(p => p.Evento)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Evento_Instituicao");

            entity.HasOne(d => d.IdStatusEventoNavigation).WithMany(p => p.Evento).HasConstraintName("FK_Evento_StatusEvento");

            entity.HasOne(d => d.IdTipoEventoNavigation).WithMany(p => p.Evento)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Evento_TipoEvento");
        });

        modelBuilder.Entity<Instituicao>(entity =>
        {
            entity.Property(e => e.IdInstituicao).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Presenca>(entity =>
        {
            entity.Property(e => e.IdPresenca).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Presenca).HasConstraintName("FK_Presenca_Evento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Presenca)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Presenca_Usuario");
        });

        modelBuilder.Entity<StatusEvento>(entity =>
        {
            entity.Property(e => e.IdStatusEvento).ValueGeneratedNever();
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.Property(e => e.IdTipoEvento).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.Property(e => e.IdTipoUsuario).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Usuario_TipoUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
