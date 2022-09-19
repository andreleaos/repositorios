using System;
using GestaoServicosApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestaoServicosApi.Models.Contexts
{
    public partial class GestaoServicoContext : DbContext
    {
        public GestaoServicoContext()
        {
        }

        public GestaoServicoContext(DbContextOptions<GestaoServicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnalistaSuporte> AnalistaSuporte { get; set; }
        public virtual DbSet<OrdemTrabalho> OrdemTrabalho { get; set; }
        public virtual DbSet<Requisicao> Requisicao { get; set; }
        public virtual DbSet<StatusOrdemTrabalho> StatusOrdemTrabalho { get; set; }
        public virtual DbSet<StatusRequisicao> StatusRequisicao { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=ANDRE-NOTE\\SQLEXPRESS;Database=servicosdb;Trusted_Connection=yes;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalistaSuporte>(entity =>
            {
                entity.ToTable("analistaSuporte");

                entity.Property(e => e.AnalistaSuporteId).HasColumnName("analistaSuporteId");

                entity.Property(e => e.AnalistaAtivo).HasColumnName("analistaAtivo");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ramal)
                    .HasColumnName("ramal")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdemTrabalho>(entity =>
            {
                entity.HasKey(e => new { e.RequisicaoId, e.OrdemTrabalhoId });

                entity.ToTable("ordemTrabalho");

                entity.Property(e => e.RequisicaoId).HasColumnName("requisicaoId");

                entity.Property(e => e.OrdemTrabalhoId)
                    .HasColumnName("ordemTrabalhoId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AnalistaSuporteId).HasColumnName("analistaSuporteId");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnName("dataAtualizacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOrdemTrabalhoId).HasColumnName("statusOrdemTrabalhoId");

                entity.HasOne(d => d.AnalistaSuporte)
                    .WithMany(p => p.OrdemTrabalho)
                    .HasForeignKey(d => d.AnalistaSuporteId)
                    .HasConstraintName("FK_ordemTrabalho_analistaSuporte");

                entity.HasOne(d => d.StatusOrdemTrabalho)
                    .WithMany(p => p.OrdemTrabalho)
                    .HasForeignKey(d => d.StatusOrdemTrabalhoId)
                    .HasConstraintName("FK_ordemTrabalho_statusOrdemTrabalho");
            });

            modelBuilder.Entity<Requisicao>(entity =>
            {
                entity.ToTable("requisicao");

                entity.Property(e => e.RequisicaoId).HasColumnName("requisicaoId");

                entity.Property(e => e.DataAbertura)
                    .HasColumnName("dataAbertura")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataFechamento)
                    .HasColumnName("dataFechamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAtualizacao)
                    .HasColumnName("dataUltimaAtualizacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Requisicao)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_requisicao_statusRequisicao");
            });

            modelBuilder.Entity<StatusOrdemTrabalho>(entity =>
            {
                entity.ToTable("statusOrdemTrabalho");

                entity.Property(e => e.StatusOrdemTrabalhoId).HasColumnName("statusOrdemTrabalhoId");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusRequisicao>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("statusRequisicao");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
