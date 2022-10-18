﻿// <auto-generated />
using System;
using CDP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDP.Migrations
{
    [DbContext(typeof(CDPContext))]
    [Migration("20221018013119_AllModels")]
    partial class AllModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CDP_Project.Models.Cargo", b =>
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

            modelBuilder.Entity("CDP_Project.Models.Fazenda", b =>
                {
                    b.Property<int>("IdFazenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdFazenda");

                    b.ToTable("Fazenda");
                });

            modelBuilder.Entity("CDP_Project.Models.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<int?>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("DataNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("SafraIdSafra")
                        .HasColumnType("int");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("CargoId");

                    b.HasIndex("SafraIdSafra");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CDP_Project.Models.Plantio", b =>
                {
                    b.Property<int>("IdPlantio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adubacao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Chuva")
                        .HasColumnType("int");

                    b.Property<string>("Cultura")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("DataPlantio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DistSementes")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("IdSemente")
                        .HasColumnType("int");

                    b.Property<string>("QtdSementes")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("SementesIdSemente")
                        .HasColumnType("int");

                    b.Property<string>("TempoPlantio")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("TipoPlantio")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("UmidadePlantio")
                        .HasColumnType("int");

                    b.HasKey("IdPlantio");

                    b.HasIndex("SementesIdSemente");

                    b.ToTable("Plantio");
                });

            modelBuilder.Entity("CDP_Project.Models.Safra", b =>
                {
                    b.Property<int>("IdSafra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdTalhao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("IdSafra");

                    b.ToTable("Safras");
                });

            modelBuilder.Entity("CDP_Project.Models.Semente", b =>
                {
                    b.Property<int>("IdSemente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdSemente");

                    b.ToTable("Sementes");
                });

            modelBuilder.Entity("CDP_Project.Models.Talhoes", b =>
                {
                    b.Property<int>("IdTalhao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("CultivarAnterior")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("FazendaIdFazenda")
                        .HasColumnType("int");

                    b.Property<int>("IdFazenda")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("SafraIdSafra")
                        .HasColumnType("int");

                    b.Property<string>("TipoSolo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("IdTalhao");

                    b.HasIndex("FazendaIdFazenda");

                    b.HasIndex("SafraIdSafra");

                    b.ToTable("Talhoes");
                });

            modelBuilder.Entity("CDP_Project.Models.Usuario", b =>
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
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

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
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CargosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CDP_Project.Models.Funcionario", b =>
                {
                    b.HasOne("CDP_Project.Models.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId");

                    b.HasOne("CDP_Project.Models.Safra", null)
                        .WithMany("Funcionarios")
                        .HasForeignKey("SafraIdSafra");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("CDP_Project.Models.Plantio", b =>
                {
                    b.HasOne("CDP_Project.Models.Semente", "Sementes")
                        .WithMany()
                        .HasForeignKey("SementesIdSemente");

                    b.Navigation("Sementes");
                });

            modelBuilder.Entity("CDP_Project.Models.Talhoes", b =>
                {
                    b.HasOne("CDP_Project.Models.Fazenda", "Fazenda")
                        .WithMany()
                        .HasForeignKey("FazendaIdFazenda");

                    b.HasOne("CDP_Project.Models.Safra", null)
                        .WithMany("Talhoes")
                        .HasForeignKey("SafraIdSafra");

                    b.Navigation("Fazenda");
                });

            modelBuilder.Entity("CDP_Project.Models.Usuario", b =>
                {
                    b.HasOne("CDP_Project.Models.Cargo", "Cargos")
                        .WithMany("Usuarios")
                        .HasForeignKey("CargosId");

                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("CDP_Project.Models.Cargo", b =>
                {
                    b.Navigation("Funcionarios");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CDP_Project.Models.Safra", b =>
                {
                    b.Navigation("Funcionarios");

                    b.Navigation("Talhoes");
                });
#pragma warning restore 612, 618
        }
    }
}
