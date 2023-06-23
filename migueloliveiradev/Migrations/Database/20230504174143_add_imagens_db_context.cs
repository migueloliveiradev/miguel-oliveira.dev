using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database
{
    /// <inheritdoc />
    public partial class add_imagens_db_context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Projetos_ProjetoId",
                table: "Imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Tecnologias_Imagem_LogoId",
                table: "Tecnologias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem");

            migrationBuilder.RenameTable(
                name: "Imagem",
                newName: "Imagens");

            migrationBuilder.RenameIndex(
                name: "IX_Imagem_ProjetoId",
                table: "Imagens",
                newName: "IX_Imagens_ProjetoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Projetos_ProjetoId",
                table: "Imagens",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnologias_Imagens_LogoId",
                table: "Tecnologias",
                column: "LogoId",
                principalTable: "Imagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Projetos_ProjetoId",
                table: "Imagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tecnologias_Imagens_LogoId",
                table: "Tecnologias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens");

            migrationBuilder.RenameTable(
                name: "Imagens",
                newName: "Imagem");

            migrationBuilder.RenameIndex(
                name: "IX_Imagens_ProjetoId",
                table: "Imagem",
                newName: "IX_Imagem_ProjetoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Projetos_ProjetoId",
                table: "Imagem",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnologias_Imagem_LogoId",
                table: "Tecnologias",
                column: "LogoId",
                principalTable: "Imagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
