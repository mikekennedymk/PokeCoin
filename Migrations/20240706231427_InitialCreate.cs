using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokéCoin.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DataNascimento",
                value: new DateTime(2024, 7, 6, 20, 14, 27, 573, DateTimeKind.Local).AddTicks(2915));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DataNascimento",
                value: new DateTime(2023, 10, 29, 1, 24, 3, 380, DateTimeKind.Local).AddTicks(2471));
        }
    }
}
