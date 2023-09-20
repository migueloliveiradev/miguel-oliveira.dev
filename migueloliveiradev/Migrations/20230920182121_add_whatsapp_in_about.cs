using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migueloliveiradev.Migrations
{
    /// <inheritdoc />
    public partial class add_whatsapp_in_about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "number_whatsapp",
                table: "about",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "text_message_whatsapp",
                table: "about",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number_whatsapp",
                table: "about");

            migrationBuilder.DropColumn(
                name: "text_message_whatsapp",
                table: "about");
        }
    }
}
