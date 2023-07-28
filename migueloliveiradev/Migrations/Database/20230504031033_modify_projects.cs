using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database;

/// <inheritdoc />
public partial class modify_projects : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Nome",
            table: "Projetos",
            newName: "Titulo");

        migrationBuilder.AddColumn<string>(
            name: "SubTitulo",
            table: "Projetos",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "SubTitulo",
            table: "Projetos");

        migrationBuilder.RenameColumn(
            name: "Titulo",
            table: "Projetos",
            newName: "Nome");
    }
}
