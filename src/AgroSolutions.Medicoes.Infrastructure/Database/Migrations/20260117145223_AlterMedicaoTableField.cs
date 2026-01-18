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
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS vw_medicoes_temperatura;
            ");

            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS vw_medicoes_umidade;
            ");

            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS vw_medicoes_precipitacao;
            ");

            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "medicoes",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_temperatura AS
                SELECT
                    id_talhao,
                    data_medicao,
                    valor
                FROM medicoes
                WHERE
                    tipo = 0;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_umidade AS
                SELECT
                    id_talhao,
                    data_medicao,
                    valor
                FROM medicoes
                WHERE
                    tipo = 1;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_precipitacao AS
                SELECT
                    id_talhao,
                    data_medicao,
                    valor
                FROM medicoes
                WHERE
                    tipo = 2;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS vw_medicoes_temperatura;
            ");

            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS vw_medicoes_umidade;
            ");

            migrationBuilder.Sql(@"
                DROP VIEW IF EXISTS vw_medicoes_precipitacao;
            ");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "medicoes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_temperatura AS
                SELECT
                    id_talhao,
                    data_medicao,
                    valor
                FROM medicoes
                WHERE
                    tipo = 0;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_umidade AS
                SELECT
                    id_talhao,
                    data_medicao,
                    valor
                FROM medicoes
                WHERE
                    tipo = 1;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_precipitacao AS
                SELECT
                    id_talhao,
                    data_medicao,
                    valor
                FROM medicoes
                WHERE
                    tipo = 2;
            ");
        }
    }
}
