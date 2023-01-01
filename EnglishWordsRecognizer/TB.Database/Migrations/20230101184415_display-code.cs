using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class displaycode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Languages",
                newName: "DisplayCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayCode",
                table: "Languages",
                newName: "DisplayName");
        }
    }
}
