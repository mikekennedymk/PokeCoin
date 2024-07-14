using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokéCoin.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RemovidoEm",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DataNascimento", "RemovidoEm" },
                values: new object[] { new DateTime(2024, 7, 6, 21, 4, 3, 522, DateTimeKind.Local).AddTicks(4544), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemovidoEm",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DataNascimento",
                value: new DateTime(2024, 7, 6, 21, 0, 4, 522, DateTimeKind.Local).AddTicks(1162));
        }
    }
}
