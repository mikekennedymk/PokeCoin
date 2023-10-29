﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokéCoin.Context;

#nullable disable

namespace PokéCoin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231029042403_Key-Usuario")]
    partial class KeyUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokéCoin.Models.Usuarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DataNascimento = new DateTime(2023, 10, 29, 1, 24, 3, 380, DateTimeKind.Local).AddTicks(2471),
                            Email = "email@email.com",
                            Nome = "Primeiro Usuário",
                            Senha = "senha123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
