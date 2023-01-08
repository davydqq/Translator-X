using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class requestuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "requests",
                table: "BaseRequest",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequest_UserId",
                schema: "requests",
                table: "BaseRequest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseRequest_TelegramUser_UserId",
                schema: "requests",
                table: "BaseRequest",
                column: "UserId",
                principalSchema: "app",
                principalTable: "TelegramUser",
                principalColumn: "TelegramUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseRequest_TelegramUser_UserId",
                schema: "requests",
                table: "BaseRequest");

            migrationBuilder.DropIndex(
                name: "IX_BaseRequest_UserId",
                schema: "requests",
                table: "BaseRequest");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "requests",
                table: "BaseRequest");
        }
    }
}
