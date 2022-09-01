using EstudosEFCore.Models.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Infrastructure.Contexts
{
    public class ControleFrotaContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<MotoristaVeiculo> MotoristasVeiculos { get; set; }

        public ControleFrotaContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntities(modelBuilder);
            InitializeData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            ConfigureEntityMotoristaVeiculo(modelBuilder);
            ConfigureEntityMotorista(modelBuilder);
        }

        private void InitializeData(ModelBuilder modelBuilder)
        {
            string motoristaId = "";
            string veiculoId = "";

            Motorista motorista1 = new Motorista()
            {
                MotoristaId = BaseEntity.GenerateId(),
                Nome = "Joao Marcos",
                CNH = "45698765498",
                ValidadeCNH = new DateTime(2023,2,23),
                Ativo = true
            };

            Veiculo veiculo1 = new Veiculo()
            {
                VeiculoId = BaseEntity.GenerateId(),
                Modelo = "Volvo FH 5540",
                Ano = 2019,
                Placa = "HDT3B58"
            };

            motoristaId = motorista1.MotoristaId;
            veiculoId = veiculo1.VeiculoId;

            MotoristaVeiculo motoristaVeiculo1 = new MotoristaVeiculo
            {
                MotoristaId = motoristaId,
                VeiculoId = veiculoId
            };

            modelBuilder.Entity<Motorista>().HasData(motorista1);
            modelBuilder.Entity<Veiculo>().HasData(veiculo1);
            modelBuilder.Entity<MotoristaVeiculo>().HasData(motoristaVeiculo1);

            Motorista motorista2 = new Motorista()
            {
                MotoristaId = BaseEntity.GenerateId(),
                Nome = "Francisco Fernando",
                CNH = "6987589365",
                ValidadeCNH = new DateTime(2024, 7, 14),
                Ativo = true
            };

            Veiculo veiculo2 = new Veiculo()
            {
                VeiculoId = BaseEntity.GenerateId(),
                Modelo = "Scania R450",
                Ano = 2018,
                Placa = "DRG7T34"
            };

            motoristaId = motorista2.MotoristaId;
            veiculoId = veiculo2.VeiculoId;

            MotoristaVeiculo motoristaVeiculo2 = new MotoristaVeiculo
            {
                MotoristaId = motoristaId,
                VeiculoId = veiculoId
            };

            modelBuilder.Entity<Motorista>().HasData(motorista2);
            modelBuilder.Entity<Veiculo>().HasData(veiculo2);
            modelBuilder.Entity<MotoristaVeiculo>().HasData(motoristaVeiculo2);
        }

        private void ConfigureEntityMotorista(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorista>()
                .ToTable("tbl_motor")
                .HasKey(m => m.MotoristaId);

            modelBuilder.Entity<Motorista>()
                .Property(m => m.MotoristaId)
                .HasColumnName("motor_id")
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Motorista>()
                .Property(m => m.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Motorista>()
                .Property(m => m.CNH)
                .HasColumnName("cnh")
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Motorista>()
                .Property(m => m.ValidadeCNH)
                .HasColumnName("validadeCNH")
                .HasColumnType("datetime")
                .IsRequired();

            modelBuilder.Entity<Motorista>()
                .Property(m => m.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("tinyint")
                .HasDefaultValue(true);
        }

        private void ConfigureEntityMotoristaVeiculo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoristaVeiculo>()
                .ToTable("tbl_motr_veicl")
                .HasKey(mv => new { mv.VeiculoId, mv.MotoristaId });

            modelBuilder.Entity<MotoristaVeiculo>()
                .Property(mv => mv.VeiculoId)
                .HasColumnName("veicl_id")
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<MotoristaVeiculo>()
                .Property(mv => mv.MotoristaId)
                .HasColumnName("motor_id")
                .HasColumnType("varchar(50)");
        }


    }
}
