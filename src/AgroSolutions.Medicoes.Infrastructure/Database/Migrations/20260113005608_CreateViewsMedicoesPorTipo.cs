using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSolutions.Medicoes.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateViewsMedicoesPorTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_temperatura;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_umidade;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_precipitacao;");
        }
    }
}
