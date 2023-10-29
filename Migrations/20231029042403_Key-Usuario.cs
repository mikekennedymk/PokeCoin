using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokéCoin.Migrations
{
    /// <inheritdoc />
    public partial class KeyUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DataNascimento",
                value: new DateTime(2023, 10, 29, 1, 24, 3, 380, DateTimeKind.Local).AddTicks(2471));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DataNascimento",
                value: new DateTime(2023, 10, 28, 16, 49, 39, 68, DateTimeKind.Local).AddTicks(3009));
        }
    }
}
