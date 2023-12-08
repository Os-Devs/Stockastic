using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockastic.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descricaoCategoria",
                table: "Categorias",
                newName: "DescricaoCategoria");

            migrationBuilder.RenameColumn(
                name: "nomeCategoria",
                table: "Categorias",
                newName: "NomeCategoria");

            migrationBuilder.AddColumn<string>(
                name: "CategoriaNomeCategoria",
                table: "Produtos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "DescricaoCategoria",
                keyValue: null,
                column: "DescricaoCategoria",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoCategoria",
                table: "Categorias",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaNomeCategoria",
                table: "Produtos",
                column: "CategoriaNomeCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produtos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaNomeCategoria",
                table: "Produtos",
                column: "CategoriaNomeCategoria",
                principalTable: "Categorias",
                principalColumn: "NomeCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioId",
                table: "Produtos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaNomeCategoria",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriaNomeCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoriaNomeCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "DescricaoCategoria",
                table: "Categorias",
                newName: "descricaoCategoria");

            migrationBuilder.RenameColumn(
                name: "NomeCategoria",
                table: "Categorias",
                newName: "nomeCategoria");

            migrationBuilder.AlterColumn<string>(
                name: "descricaoCategoria",
                table: "Categorias",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
