using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database;

/// <inheritdoc />
public partial class update_column_project : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "Active",
            table: "Projetos",
            type: "tinyint(1)",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "DateEnd",
            table: "Projetos",
            type: "datetime(6)",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DateStart",
            table: "Projetos",
            type: "datetime(6)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "UrlLinkedin",
            table: "Projetos",
            type: "longtext",
            nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Active",
            table: "Projetos");

        migrationBuilder.DropColumn(
            name: "DateEnd",
            table: "Projetos");

        migrationBuilder.DropColumn(
            name: "DateStart",
            table: "Projetos");

        migrationBuilder.DropColumn(
            name: "UrlLinkedin",
            table: "Projetos");
    }
}
