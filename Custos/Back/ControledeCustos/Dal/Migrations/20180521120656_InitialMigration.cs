using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dal.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioDepartamentos",
                columns: table => new
                {
                    CodigoFuncionario = table.Column<int>(nullable: false),
                    CodigoDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioDepartamentos", x => new { x.CodigoFuncionario, x.CodigoDepartamento });
                    table.ForeignKey(
                        name: "FK_FuncionarioDepartamentos_Departamento_CodigoDepartamento",
                        column: x => x.CodigoDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioDepartamentos_Funcionario_CodigoFuncionario",
                        column: x => x.CodigoFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoDepartamento = table.Column<int>(nullable: false),
                    CodigoFuncionario = table.Column<int>(nullable: false),
                    DataMovimentacao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Departamento_CodigoDepartamento",
                        column: x => x.CodigoDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Funcionario_CodigoFuncionario",
                        column: x => x.CodigoFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioDepartamentos_CodigoDepartamento",
                table: "FuncionarioDepartamentos",
                column: "CodigoDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_CodigoDepartamento",
                table: "Movimentacao",
                column: "CodigoDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_CodigoFuncionario",
                table: "Movimentacao",
                column: "CodigoFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioDepartamentos");

            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
