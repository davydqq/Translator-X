using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class movetoscheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TextRequestTypes",
                newName: "TextRequestTypes",
                newSchema: "requests");

            migrationBuilder.RenameTable(
                name: "ImageRequestTypes",
                newName: "ImageRequestTypes",
                newSchema: "requests");

            migrationBuilder.RenameTable(
                name: "AudioRequestTypes",
                newName: "AudioRequestTypes",
                newSchema: "requests");

            migrationBuilder.RenameTable(
                name: "ApiTypes",
                newName: "ApiTypes",
                newSchema: "requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TextRequestTypes",
                schema: "requests",
                newName: "TextRequestTypes");

            migrationBuilder.RenameTable(
                name: "ImageRequestTypes",
                schema: "requests",
                newName: "ImageRequestTypes");

            migrationBuilder.RenameTable(
                name: "AudioRequestTypes",
                schema: "requests",
                newName: "AudioRequestTypes");

            migrationBuilder.RenameTable(
                name: "ApiTypes",
                schema: "requests",
                newName: "ApiTypes");
        }
    }
}
