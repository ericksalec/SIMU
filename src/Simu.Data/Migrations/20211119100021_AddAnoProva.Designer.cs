﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Simu.Data.Context;

namespace Simu.Data.Migrations
{
    [DbContext(typeof(SimuDbContext))]
    [Migration("20211119100021_AddAnoProva")]
    partial class AddAnoProva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Simu.Business.Models.Assunto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Assunto");
                });

            modelBuilder.Entity("Simu.Business.Models.Dado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Acertos")
                        .HasColumnType("int");

                    b.Property<int>("AnoProva")
                        .HasColumnType("int");

                    b.Property<int>("Erros")
                        .HasColumnType("int");

                    b.Property<int>("Respondidas")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Dado");
                });

            modelBuilder.Entity("Simu.Business.Models.Prova", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("QuestaoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

                    b.ToTable("Prova");
                });

            modelBuilder.Entity("Simu.Business.Models.Questao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("A")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("AnoProva")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("B")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("C")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("D")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("E")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Prova")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("TarefaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoAssunto")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Questao");
                });

            modelBuilder.Entity("Simu.Business.Models.QuestaoRespondida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("A")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("Acerto")
                        .HasColumnType("bit");

                    b.Property<string>("AnoProva")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("B")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("C")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("D")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Prova")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespostaMarcada")
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("TarefaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoAssunto")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("QuestaoRespondida");
                });

            modelBuilder.Entity("Simu.Business.Models.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Prova")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TarefaId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UploadImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Simu.Business.Models.Prova", b =>
                {
                    b.HasOne("Simu.Business.Models.Questao", "Questao")
                        .WithMany()
                        .HasForeignKey("QuestaoId");

                    b.Navigation("Questao");
                });
#pragma warning restore 612, 618
        }
    }
}
