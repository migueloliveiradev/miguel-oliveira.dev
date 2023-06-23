using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database
{
    /// <inheritdoc />
    public partial class modify_projects_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tecnologias_Projetos_ProjetoId",
                table: "Tecnologias");

            migrationBuilder.DropIndex(
                name: "IX_Tecnologias_ProjetoId",
                table: "Tecnologias");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Tecnologias");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Projetos",
                newName: "Working");

            migrationBuilder.CreateTable(
                name: "ProjetoTecnologia",
                columns: table => new
                {
                    ProjetosId = table.Column<int>(type: "int", nullable: false),
                    TecnologiasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoTecnologia", x => new { x.ProjetosId, x.TecnologiasId });
                    table.ForeignKey(
                        name: "FK_ProjetoTecnologia_Projetos_ProjetosId",
                        column: x => x.ProjetosId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoTecnologia_Tecnologias_TecnologiasId",
                        column: x => x.TecnologiasId,
                        principalTable: "Tecnologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoTecnologia_TecnologiasId",
                table: "ProjetoTecnologia",
                column: "TecnologiasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoTecnologia");

            migrationBuilder.RenameColumn(
                name: "Working",
                table: "Projetos",
                newName: "Active");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Tecnologias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tecnologias_ProjetoId",
                table: "Tecnologias",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tecnologias_Projetos_ProjetoId",
                table: "Tecnologias",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id");
        }
    }
}
