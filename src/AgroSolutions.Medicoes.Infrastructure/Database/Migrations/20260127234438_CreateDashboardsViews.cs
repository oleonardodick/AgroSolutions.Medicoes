using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSolutions.Medicoes.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateDashboardsViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_base AS
                    SELECT
                        m.id,
                        m.data_medicao,
                        m.tipo,
                        CASE m.tipo
                            WHEN 0 THEN 'Temperatura'
                            WHEN 1 THEN 'Umidade'
                            WHEN 2 THEN 'Precipitacao'
                        END AS tipo_descricao,
                        m.valor,
                        t.id AS id_talhao,
                        t.nome AS talhao,
                        p.id AS id_propriedade,
                        p.nome AS propriedade
                    FROM medicoes m
                    JOIN talhoes t ON t.id = m.id_talhao
                    JOIN propriedades p ON p.id = t.id_propriedade;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_media_hora AS
                    SELECT
                        date_trunc('hour', data_medicao) AS hora,
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao,
                        tipo,
                        tipo_descricao,
                        AVG(valor) AS valor_medio
                    FROM vw_medicoes_base
                    GROUP BY
                        hora,
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao,
                        tipo,
                        tipo_descricao;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_ultima AS
                    SELECT DISTINCT ON (id_talhao, tipo)
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao,
                        tipo,
                        tipo_descricao,
                        valor,
                        data_medicao
                    FROM vw_medicoes_base
                    ORDER BY id_talhao, tipo, data_medicao DESC;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_precipitacao_diaria AS
                    SELECT
                        date_trunc('day', data_medicao) AS dia,
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao,
                        SUM(valor) AS precipitacao_total
                    FROM vw_medicoes_base
                    WHERE tipo = 2
                    GROUP BY
                        dia,
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_medicoes_indicadores_dia AS
                    SELECT
                        date_trunc('day', data_medicao) AS dia,
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao,
                        tipo,
                        tipo_descricao,
                        MIN(valor) AS valor_min,
                        MAX(valor) AS valor_max,
                        AVG(valor) AS valor_medio
                    FROM vw_medicoes_base
                    GROUP BY
                        dia,
                        id_propriedade,
                        propriedade,
                        id_talhao,
                        talhao,
                        tipo,
                        tipo_descricao;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE VIEW vw_alertas_base AS
                    SELECT
                        a.id,
                        a.data_alerta,
                        a.tipo,
                        CASE a.tipo
                            WHEN 0 THEN 'Alta temperatura'
                            WHEN 1 THEN 'Baixa temperatura'
                            WHEN 2 THEN 'Alta Umidade'
                            WHEN 3 THEN 'Baixa Umidade'
                            WHEN 4 THEN 'Chuva excessiva'
                            WHEN 5 THEN 'Alerta de Seca'
                        END AS tipo_descricao,
                        t.id AS id_talhao,
                        t.nome AS talhao,
                        p.id AS id_propriedade,
                        p.nome AS propriedade
                    FROM alertas a
                    JOIN talhoes t ON t.id = a.id_talhao
                    JOIN propriedades p ON p.id = t.id_propriedade;
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_media_hora;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_ultima;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_precipitacao_diaria;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_indicadores_dia;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_alertas_base;");
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_medicoes_base;");
        }
    }
}
