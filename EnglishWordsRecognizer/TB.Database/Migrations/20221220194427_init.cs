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
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Translate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 1, "app.languages.interfaceLanguage", 1, "Мова інтерфейсу:" },
                    { 2, "app.languages.interfaceLanguage", 2, "Язык интерфейса:" },
                    { 3, "app.languages.interfaceLanguage", 3, "Your interface language:" },
                    { 4, "app.languages.interfaceLanguage", 4, "Tu idioma de interfaz:" },
                    { 5, "app.languages.interfaceLanguage", 5, "La langue de votre interface :" },
                    { 6, "app.languages.interfaceLanguage", 6, "" },
                    { 7, "app.languages.interfaceLanguage", 7, "" },
                    { 8, "app.languages.interfaceLanguage", 8, "Váš jazyk rozhraní:" },
                    { 9, "app.languages.interfaceLanguage", 9, "Dit grænsefladesprog:" },
                    { 10, "app.languages.interfaceLanguage", 10, "" },
                    { 11, "app.languages.interfaceLanguage", 11, "La lingua dell'interfaccia:" },
                    { 12, "app.languages.interfaceLanguage", 12, "Ditt gränssnittsspråk:" },
                    { 13, "app.languages.interfaceLanguage", 13, "Ihre Oberflächensprache:" },
                    { 14, "app.languages.interfaceLanguage", 14, "Twój język interfejsu:" },
                    { 15, "app.languages.interfaceLanguage", 15, "Arayüz diliniz:" },
                    { 16, "app.languages.established", 1, "" },
                    { 17, "app.languages.established", 2, "" },
                    { 18, "app.languages.established", 3, "The languages were established." },
                    { 19, "app.languages.established", 4, "" },
                    { 20, "app.languages.established", 5, "" },
                    { 21, "app.languages.established", 6, "1" },
                    { 22, "app.languages.established", 7, "1" },
                    { 23, "app.languages.established", 8, "" },
                    { 24, "app.languages.established", 9, "" },
                    { 25, "app.languages.established", 10, "1" },
                    { 26, "app.languages.established", 11, "" },
                    { 27, "app.languages.established", 12, "" },
                    { 28, "app.languages.established", 13, "" },
                    { 29, "app.languages.established", 14, "" },
                    { 30, "app.languages.established", 15, "" },
                    { 31, "app.languages.nativeL", 1, "" },
                    { 32, "app.languages.nativeL", 2, "" },
                    { 33, "app.languages.nativeL", 3, "Native Language:" },
                    { 34, "app.languages.nativeL", 4, "" },
                    { 35, "app.languages.nativeL", 5, "" },
                    { 36, "app.languages.nativeL", 6, "1" },
                    { 37, "app.languages.nativeL", 7, "1" },
                    { 38, "app.languages.nativeL", 8, "" },
                    { 39, "app.languages.nativeL", 9, "" },
                    { 40, "app.languages.nativeL", 10, "1" },
                    { 41, "app.languages.nativeL", 11, "" },
                    { 42, "app.languages.nativeL", 12, "" },
                    { 43, "app.languages.nativeL", 13, "" },
                    { 44, "app.languages.nativeL", 14, "" },
                    { 45, "app.languages.nativeL", 15, "" },
                    { 46, "app.languages.targetL", 1, "" },
                    { 47, "app.languages.targetL", 2, "" },
                    { 48, "app.languages.targetL", 3, "Target Language:" },
                    { 49, "app.languages.targetL", 4, "" },
                    { 50, "app.languages.targetL", 5, "" },
                    { 51, "app.languages.targetL", 6, "1" },
                    { 52, "app.languages.targetL", 7, "1" },
                    { 53, "app.languages.targetL", 8, "" },
                    { 54, "app.languages.targetL", 9, "" },
                    { 55, "app.languages.targetL", 10, "1" },
                    { 56, "app.languages.targetL", 11, "" },
                    { 57, "app.languages.targetL", 12, "" },
                    { 58, "app.languages.targetL", 13, "" },
                    { 59, "app.languages.targetL", 14, "" },
                    { 60, "app.languages.targetL", 15, "" },
                    { 61, "app.languages.yourLanguages", 1, "" },
                    { 62, "app.languages.yourLanguages", 2, "" },
                    { 63, "app.languages.yourLanguages", 3, "Your languages" },
                    { 64, "app.languages.yourLanguages", 4, "" },
                    { 65, "app.languages.yourLanguages", 5, "" },
                    { 66, "app.languages.yourLanguages", 6, "1" },
                    { 67, "app.languages.yourLanguages", 7, "1" },
                    { 68, "app.languages.yourLanguages", 8, "" },
                    { 69, "app.languages.yourLanguages", 9, "" },
                    { 70, "app.languages.yourLanguages", 10, "1" },
                    { 71, "app.languages.yourLanguages", 11, "" },
                    { 72, "app.languages.yourLanguages", 12, "" },
                    { 73, "app.languages.yourLanguages", 13, "" },
                    { 74, "app.languages.yourLanguages", 14, "" },
                    { 75, "app.languages.yourLanguages", 15, "" },
                    { 76, "app.languages.canSend", 1, "" },
                    { 77, "app.languages.canSend", 2, "" },
                    { 78, "app.languages.canSend", 3, "Send text, photo, audio for translating." },
                    { 79, "app.languages.canSend", 4, "" },
                    { 80, "app.languages.canSend", 5, "" },
                    { 81, "app.languages.canSend", 6, "1" },
                    { 82, "app.languages.canSend", 7, "1" },
                    { 83, "app.languages.canSend", 8, "" },
                    { 84, "app.languages.canSend", 9, "" },
                    { 85, "app.languages.canSend", 10, "1" },
                    { 86, "app.languages.canSend", 11, "" },
                    { 87, "app.languages.canSend", 12, "" },
                    { 88, "app.languages.canSend", 13, "" },
                    { 89, "app.languages.canSend", 14, "" },
                    { 90, "app.languages.canSend", 15, "" },
                    { 91, "app.images.text", 1, "" },
                    { 92, "app.images.text", 2, "" },
                    { 93, "app.images.text", 3, "<b>Text on photo</b>" },
                    { 94, "app.images.text", 4, "" },
                    { 95, "app.images.text", 5, "" },
                    { 96, "app.images.text", 6, "1" },
                    { 97, "app.images.text", 7, "1" },
                    { 98, "app.images.text", 8, "" },
                    { 99, "app.images.text", 9, "" },
                    { 100, "app.images.text", 10, "1" },
                    { 101, "app.images.text", 11, "" },
                    { 102, "app.images.text", 12, "" },
                    { 103, "app.images.text", 13, "" },
                    { 104, "app.images.text", 14, "" },
                    { 105, "app.images.text", 15, "" },
                    { 106, "app.images.objects", 1, "" },
                    { 107, "app.images.objects", 2, "" },
                    { 108, "app.images.objects", 3, "<b>Image objects</b>" },
                    { 109, "app.images.objects", 4, "" },
                    { 110, "app.images.objects", 5, "" },
                    { 111, "app.images.objects", 6, "1" },
                    { 112, "app.images.objects", 7, "1" },
                    { 113, "app.images.objects", 8, "" },
                    { 114, "app.images.objects", 9, "" },
                    { 115, "app.images.objects", 10, "1" },
                    { 116, "app.images.objects", 11, "" },
                    { 117, "app.images.objects", 12, "" },
                    { 118, "app.images.objects", 13, "" },
                    { 119, "app.images.objects", 14, "" },
                    { 120, "app.images.objects", 15, "" },
                    { 121, "app.images.description", 1, "" },
                    { 122, "app.images.description", 2, "" },
                    { 123, "app.images.description", 3, "<b>Image description</b>" },
                    { 124, "app.images.description", 4, "" },
                    { 125, "app.images.description", 5, "" },
                    { 126, "app.images.description", 6, "1" },
                    { 127, "app.images.description", 7, "1" },
                    { 128, "app.images.description", 8, "" },
                    { 129, "app.images.description", 9, "" },
                    { 130, "app.images.description", 10, "1" },
                    { 131, "app.images.description", 11, "" },
                    { 132, "app.images.description", 12, "" },
                    { 133, "app.images.description", 13, "" },
                    { 134, "app.images.description", 14, "" },
                    { 135, "app.images.description", 15, "" },
                    { 136, "app.texts.maybeMean", 1, "" },
                    { 137, "app.texts.maybeMean", 2, "" },
                    { 138, "app.texts.maybeMean", 3, "<b>Maybe you mean</b>" },
                    { 139, "app.texts.maybeMean", 4, "" },
                    { 140, "app.texts.maybeMean", 5, "" },
                    { 141, "app.texts.maybeMean", 6, "1" },
                    { 142, "app.texts.maybeMean", 7, "1" },
                    { 143, "app.texts.maybeMean", 8, "" },
                    { 144, "app.texts.maybeMean", 9, "" },
                    { 145, "app.texts.maybeMean", 10, "1" },
                    { 146, "app.texts.maybeMean", 11, "" },
                    { 147, "app.texts.maybeMean", 12, "" },
                    { 148, "app.texts.maybeMean", 13, "" },
                    { 149, "app.texts.maybeMean", 14, "" },
                    { 150, "app.texts.maybeMean", 15, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageId",
                table: "Translations",
                column: "LanguageId");

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
                name: "Translations");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
