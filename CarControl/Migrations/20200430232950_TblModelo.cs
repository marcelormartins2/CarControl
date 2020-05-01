using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarControl.Migrations
{
    public partial class TblModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Fabricante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FabricanteId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelo_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnoModeloId = table.Column<int>(nullable: false),
                    Placa = table.Column<string>(nullable: true),
                    Chassis = table.Column<string>(nullable: true),
                    Hodometro = table.Column<int>(nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    AnoFab = table.Column<DateTime>(nullable: false),
                    Origem = table.Column<string>(nullable: true),
                    Renavam = table.Column<int>(nullable: false),
                    ValorPago = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false),
                    FabricanteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnoModelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeiculoId1 = table.Column<Guid>(nullable: true),
                    VeiculoId = table.Column<int>(nullable: false),
                    ModeloId = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnoModelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnoModelo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnoModelo_Veiculo_VeiculoId1",
                        column: x => x.VeiculoId1,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnoModelo_ModeloId",
                table: "AnoModelo",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_AnoModelo_VeiculoId1",
                table: "AnoModelo",
                column: "VeiculoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_FabricanteId",
                table: "Modelo",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_FabricanteId",
                table: "Veiculo",
                column: "FabricanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnoModelo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Fabricante");
        }
    }
}
