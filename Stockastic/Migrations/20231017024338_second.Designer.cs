﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stockastic.Models;

#nullable disable

namespace Stockastic.Migrations
{
    [DbContext(typeof(StockasticContext))]
    [Migration("20231017024338_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Stockastic.Models.Categoria", b =>
                {
                    b.Property<string>("nomeCategoria")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("descricaoCategoria")
                        .HasColumnType("longtext");

                    b.HasKey("nomeCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Stockastic.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("PrazoValidade")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("PrecoUnitarioProduto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("QuantidadeAtual")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeMinimaEstoqueProduto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Stockastic.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUsuarioLogin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}