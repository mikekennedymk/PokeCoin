﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokéCoin.Context;

#nullable disable

namespace PokéCoin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

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

                    b.Property<DateTime?>("RemovidoEm")
                        .HasColumnType("datetime2");

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
                            CriadoEm = new DateTime(2024, 7, 7, 0, 17, 57, 948, DateTimeKind.Utc).AddTicks(3508),
                            DataNascimento = new DateTime(2024, 7, 6, 21, 17, 57, 948, DateTimeKind.Local).AddTicks(3516),
                            Email = "email@email.com",
                            Nome = "Primeiro Usuário",
                            Senha = "senha123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
