using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsSupportInteface = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportTargetLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportNativeLanguage = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    TelegramUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsBot = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    LanguageCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.TelegramUserId);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NativeLanguageId = table.Column<int>(type: "integer", nullable: true),
                    TargetLanguageId = table.Column<int>(type: "integer", nullable: true),
                    InterfaceLanguageId = table.Column<int>(type: "integer", nullable: false),
                    RecognizeEnglishMeaning = table.Column<bool>(type: "boolean", nullable: false),
                    TelegramUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Languages_InterfaceLanguageId",
                        column: x => x.InterfaceLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_Languages_NativeLanguageId",
                        column: x => x.NativeLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_Languages_TargetLanguageId",
                        column: x => x.TargetLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_TelegramUserId",
                        column: x => x.TelegramUserId,
                        principalTable: "Users",
                        principalColumn: "TelegramUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsSupportInteface", "IsSupportNativeLanguage", "IsSupportTargetLanguage", "Name" },
                values: new object[,]
                {
                    { 1, "uk", true, true, true, "Ukrainian 🇺🇦" },
                    { 2, "ru", true, true, true, "Russian 🇷🇺" },
                    { 3, "en", true, true, true, "English 🇺🇸" },
                    { 4, "es", true, true, true, "Spanish 🇪🇸" },
                    { 5, "fr", true, true, true, "French 🇫🇷" },
                    { 6, "ja", true, true, true, "Japanese 🇯🇵" },
                    { 7, "zh-Hans", true, true, true, "Chinese 🇨🇳" },
                    { 8, "cs", true, true, true, "Czech 🇨🇿" },
                    { 9, "da", true, true, true, "Danish 🇩🇰" },
                    { 10, "hi", true, true, true, "Hindi 🇮🇳" },
                    { 11, "it", true, true, true, "Italian 🇮🇹" },
                    { 12, "sv", true, true, true, "Swedish 🇸🇪" },
                    { 13, "de", true, true, true, "German 🇩🇪" },
                    { 14, "pl", true, true, true, "Polish 🇵🇱" },
                    { 15, "tr", true, true, true, "Turkish 🇹🇷" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_InterfaceLanguageId",
                table: "UserSettings",
                column: "InterfaceLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_NativeLanguageId",
                table: "UserSettings",
                column: "NativeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_TargetLanguageId",
                table: "UserSettings",
                column: "TargetLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_TelegramUserId",
                table: "UserSettings",
                column: "TelegramUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
