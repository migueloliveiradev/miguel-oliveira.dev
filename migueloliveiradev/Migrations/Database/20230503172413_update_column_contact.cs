using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database;

/// <inheritdoc />
public partial class update_column_contact : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_Contact",
            table: "Contact");

        migrationBuilder.RenameTable(
            name: "Contact",
            newName: "Contacts");

        migrationBuilder.AddColumn<int>(
            name: "Status",
            table: "Contacts",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddPrimaryKey(
            name: "PK_Contacts",
            table: "Contacts",
            column: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_Contacts",
            table: "Contacts");

        migrationBuilder.DropColumn(
            name: "Status",
            table: "Contacts");

        migrationBuilder.RenameTable(
            name: "Contacts",
            newName: "Contact");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Contact",
            table: "Contact",
            column: "Id");
    }
}
