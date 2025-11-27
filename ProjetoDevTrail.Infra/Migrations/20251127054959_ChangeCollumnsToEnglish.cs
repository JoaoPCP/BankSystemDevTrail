using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevTrail.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCollumnsToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Accounts",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Accounts",
                newName: "Balance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Accounts",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "Saldo");
        }
    }
}
