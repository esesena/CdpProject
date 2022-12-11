﻿// <auto-generated />
using System;
using CDP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDP.Migrations
{
    [DbContext(typeof(CDPContext))]
    partial class CDPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CDP.Models.Aviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aviso");
                });

            modelBuilder.Entity("CDP.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("CDP.Models.Fazenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Area")
                        .HasColumnType("double");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fazenda");
                });

            modelBuilder.Entity("CDP.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CDP.Models.Plantio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adubacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Chuva")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Cultura")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPlantio")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("DistSementes")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("QtdSementes")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Safra")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SementeId")
                        .HasColumnType("int");

                    b.Property<string>("TempoPlantio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoPlantio")
                        .HasColumnType("int");

                    b.Property<decimal>("UmidadePlantio")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("SementeId");

                    b.ToTable("Plantio");
                });

            modelBuilder.Entity("CDP.Models.PlantioTalhoes", b =>
                {
                    b.Property<int>("PlantioId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("TalhoesId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("PlantioId", "TalhoesId");

                    b.HasIndex("TalhoesId");

                    b.ToTable("PlantioTalhoes");
                });

            modelBuilder.Entity("CDP.Models.Semente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ConsumoSementes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Cultura")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Floracao")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("GrupoMaturacao")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("HabitoCrescimento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Resistencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sementes");
                });

            modelBuilder.Entity("CDP.Models.Talhoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Area")
                        .HasColumnType("double");

                    b.Property<int>("FazendaId")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoSolo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FazendaId");

                    b.ToTable("Talhoes");
                });

            modelBuilder.Entity("CDP.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("CargosId")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CargosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CDP.Models.Funcionario", b =>
                {
                    b.HasOne("CDP.Models.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("CDP.Models.Plantio", b =>
                {
                    b.HasOne("CDP.Models.Semente", "Sementes")
                        .WithMany()
                        .HasForeignKey("SementeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sementes");
                });

            modelBuilder.Entity("CDP.Models.PlantioTalhoes", b =>
                {
                    b.HasOne("CDP.Models.Plantio", "Plantio")
                        .WithMany("PlantioTalhoes")
                        .HasForeignKey("PlantioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDP.Models.Talhoes", "Talhoes")
                        .WithMany("PlantioTalhoes")
                        .HasForeignKey("TalhoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plantio");

                    b.Navigation("Talhoes");
                });

            modelBuilder.Entity("CDP.Models.Talhoes", b =>
                {
                    b.HasOne("CDP.Models.Fazenda", "Fazenda")
                        .WithMany("Talhoes")
                        .HasForeignKey("FazendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fazenda");
                });

            modelBuilder.Entity("CDP.Models.Usuario", b =>
                {
                    b.HasOne("CDP.Models.Cargo", "Cargos")
                        .WithMany("Usuarios")
                        .HasForeignKey("CargosId");

                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("CDP.Models.Cargo", b =>
                {
                    b.Navigation("Funcionarios");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CDP.Models.Fazenda", b =>
                {
                    b.Navigation("Talhoes");
                });

            modelBuilder.Entity("CDP.Models.Plantio", b =>
                {
                    b.Navigation("PlantioTalhoes");
                });

            modelBuilder.Entity("CDP.Models.Talhoes", b =>
                {
                    b.Navigation("PlantioTalhoes");
                });
#pragma warning restore 612, 618
        }
    }
}
