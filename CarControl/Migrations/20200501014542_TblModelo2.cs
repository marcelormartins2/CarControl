using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarControl.Migrations
{
    public partial class TblModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnoModelo");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnoFab = table.Column<DateTime>(nullable: false),
                    AnoModeloId = table.Column<int>(nullable: false),
                    Chassis = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    FabricanteId = table.Column<int>(nullable: true),
                    Hodometro = table.Column<int>(nullable: false),
                    Origem = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Renavam = table.Column<int>(nullable: false),
                    ValorPago = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false)
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
                    Ano = table.Column<int>(nullable: false),
                    ModeloId = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false),
                    VeiculoId1 = table.Column<Guid>(nullable: true)
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
                name: "IX_Veiculo_FabricanteId",
                table: "Veiculo",
                column: "FabricanteId");
        }
    }
}
