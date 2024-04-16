using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi8.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColunaTabelaAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Autores");
        }
    }
}
