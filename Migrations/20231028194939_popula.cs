using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokéCoin.Migrations
{
    /// <inheritdoc />
    public partial class popula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "DataNascimento", "Email", "Nome", "Senha" },
                values: new object[] { 1, new DateTime(2023, 10, 28, 16, 49, 39, 68, DateTimeKind.Local).AddTicks(3009), "email@email.com", "Primeiro Usuário", "senha123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
