using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewtonServices.Migrations
{
    /// <inheritdoc />
    public partial class AddedCodeToGenrePlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Platforms",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Genres",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Genres");
        }
    }
}
