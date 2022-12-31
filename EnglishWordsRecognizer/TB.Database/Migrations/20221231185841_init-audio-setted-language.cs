using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class initaudiosettedlanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 286, "app.languages.audioLanguageKey", 1, "Мова аудіо транскрипції:" },
                    { 287, "app.languages.audioLanguageKey", 2, "Язык аудио транскрипции:" },
                    { 288, "app.languages.audioLanguageKey", 3, "Audio transcription language:" },
                    { 289, "app.languages.audioLanguageKey", 4, "Idioma de transcripción de audio:" },
                    { 290, "app.languages.audioLanguageKey", 5, "Langue de transcription audio :" },
                    { 291, "app.languages.audioLanguageKey", 6, "音声転写言語:" },
                    { 292, "app.languages.audioLanguageKey", 7, "音频转录语言：" },
                    { 293, "app.languages.audioLanguageKey", 8, "Jazyk zvukového přepisu:" },
                    { 294, "app.languages.audioLanguageKey", 9, "Lydtransskriptionssprog:" },
                    { 295, "app.languages.audioLanguageKey", 10, "ऑडियो ट्रांसक्रिप्शन भाषा:" },
                    { 296, "app.languages.audioLanguageKey", 11, "Lingua di trascrizione audio:" },
                    { 297, "app.languages.audioLanguageKey", 12, "Språk för ljudtranskription:" },
                    { 298, "app.languages.audioLanguageKey", 13, "Sprache der Audiotranskription:" },
                    { 299, "app.languages.audioLanguageKey", 14, "Język transkrypcji dźwięku:" },
                    { 300, "app.languages.audioLanguageKey", 15, "Ses transkripsiyon dili:" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 300);
        }
    }
}
