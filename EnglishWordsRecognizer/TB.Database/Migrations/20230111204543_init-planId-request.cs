using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class initplanIdrequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPlanId",
                schema: "requests",
                table: "BaseRequest",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequest_UserPlanId",
                schema: "requests",
                table: "BaseRequest",
                column: "UserPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseRequest_UserPlans_UserPlanId",
                schema: "requests",
                table: "BaseRequest",
                column: "UserPlanId",
                principalSchema: "app",
                principalTable: "UserPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseRequest_UserPlans_UserPlanId",
                schema: "requests",
                table: "BaseRequest");

            migrationBuilder.DropIndex(
                name: "IX_BaseRequest_UserPlanId",
                schema: "requests",
                table: "BaseRequest");

            migrationBuilder.DropColumn(
                name: "UserPlanId",
                schema: "requests",
                table: "BaseRequest");
        }
    }
}
