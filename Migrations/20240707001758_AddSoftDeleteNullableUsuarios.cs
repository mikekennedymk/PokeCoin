using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokéCoin.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteNullableUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovidoEm",
                table: "Usuarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CriadoEm", "DataNascimento", "RemovidoEm" },
                values: new object[] { new DateTime(2024, 7, 7, 0, 17, 57, 948, DateTimeKind.Utc).AddTicks(3508), new DateTime(2024, 7, 6, 21, 17, 57, 948, DateTimeKind.Local).AddTicks(3516), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovidoEm",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CriadoEm", "DataNascimento", "RemovidoEm" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 6, 21, 4, 3, 522, DateTimeKind.Local).AddTicks(4544), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
