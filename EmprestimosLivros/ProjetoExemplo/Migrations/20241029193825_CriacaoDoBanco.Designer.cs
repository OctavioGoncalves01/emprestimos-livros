﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoExemplo.Data;

#nullable disable

namespace ProjetoExemplo.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20241029193825_CriacaoDoBanco")]
    partial class CriacaoDoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoExemplo.Models.EmprestimosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LivroEmprestado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Receber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataUltimaAtualiacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Emprestimos");
                });
#pragma warning restore 612, 618
        }
    }
}
