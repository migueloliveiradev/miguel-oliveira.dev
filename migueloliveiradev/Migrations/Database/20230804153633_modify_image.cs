using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database;

/// <inheritdoc />
public partial class modify_image : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Url",
            table: "Images",
            newName: "NameWebp");

        migrationBuilder.RenameColumn(
            name: "Descricao",
            table: "Images",
            newName: "Name");

        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Images",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Description",
            table: "Images");

        migrationBuilder.RenameColumn(
            name: "NameWebp",
            table: "Images",
            newName: "Url");

        migrationBuilder.RenameColumn(
            name: "Name",
            table: "Images",
            newName: "Descricao");
    }
}
