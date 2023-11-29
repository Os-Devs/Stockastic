using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockastic.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioAssociadoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioAssociadoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioAssociadoId",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioAssociadoId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioAssociadoId",
                table: "Produtos",
                column: "UsuarioAssociadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioAssociadoId",
                table: "Produtos",
                column: "UsuarioAssociadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
