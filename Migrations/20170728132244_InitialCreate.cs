using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurante.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_restaurante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Endereco = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_restaurante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_prato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    RestauranteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_prato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_prato_tb_restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "tb_restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_prato_RestauranteId",
                table: "tb_prato",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_prato");

            migrationBuilder.DropTable(
                name: "tb_restaurante");
        }
    }
}
