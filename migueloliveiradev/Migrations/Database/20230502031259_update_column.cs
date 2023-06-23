using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations.Database
{
    /// <inheritdoc />
    public partial class update_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassFontAwesome",
                table: "Skills",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "ClassFontAwesome",
                table: "RedeSociais",
                newName: "Icon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Skills",
                newName: "ClassFontAwesome");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "RedeSociais",
                newName: "ClassFontAwesome");
        }
    }
}
