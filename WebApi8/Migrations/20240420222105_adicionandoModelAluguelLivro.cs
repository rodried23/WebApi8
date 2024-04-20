using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi8.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoModelAluguelLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AluguelLivroModelId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AluguelLivro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AluguelLivro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AluguelLivro_Pessoa_IdPessoaId",
                        column: x => x.IdPessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AluguelLivroModelId",
                table: "Livros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_AluguelLivro_IdPessoaId",
                table: "AluguelLivro",
                column: "IdPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_AluguelLivro_AluguelLivroModelId",
                table: "Livros",
                column: "AluguelLivroModelId",
                principalTable: "AluguelLivro",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_AluguelLivro_AluguelLivroModelId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "AluguelLivro");

            migrationBuilder.DropIndex(
                name: "IX_Livros_AluguelLivroModelId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "AluguelLivroModelId",
                table: "Livros");
        }
    }
}
