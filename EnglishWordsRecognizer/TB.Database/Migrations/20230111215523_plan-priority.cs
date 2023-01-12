using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class planpriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "billing",
                table: "Plan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1,
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2,
                column: "Priority",
                value: 1000);

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3,
                column: "Priority",
                value: 999);

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 4,
                column: "Priority",
                value: 998);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "billing",
                table: "Plan");
        }
    }
}
