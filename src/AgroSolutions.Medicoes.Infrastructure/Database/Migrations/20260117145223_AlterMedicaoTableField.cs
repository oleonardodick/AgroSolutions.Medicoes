using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSolutions.Medicoes.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterMedicaoTableField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "medicoes",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "medicoes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
