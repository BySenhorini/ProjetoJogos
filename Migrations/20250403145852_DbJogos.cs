using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class DbJogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    JogoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoJogo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Plataforma = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.JogoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Nickname = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    JogoFavorito = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Jogos_JogoFavorito",
                        column: x => x.JogoFavorito,
                        principalTable: "Jogos",
                        principalColumn: "JogoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_NomeDoJogo",
                table: "Jogos",
                column: "NomeDoJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_JogoFavorito",
                table: "Usuarios",
                column: "JogoFavorito");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Nickname",
                table: "Usuarios",
                column: "Nickname",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
