using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class audiotranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 256, "app.audios.audioText", 1, "Аудіо-транскрипція" },
                    { 257, "app.audios.audioText", 2, "Транскрипция аудио" },
                    { 258, "app.audios.audioText", 3, "Audio transcription" },
                    { 259, "app.audios.audioText", 4, "Transcripción de audio" },
                    { 260, "app.audios.audioText", 5, "Transcription audio" },
                    { 261, "app.audios.audioText", 6, "音声トランスクリプション" },
                    { 262, "app.audios.audioText", 7, "音频转录" },
                    { 263, "app.audios.audioText", 8, "Přepis zvuku" },
                    { 264, "app.audios.audioText", 9, "Lydtransskription" },
                    { 265, "app.audios.audioText", 10, "ऑडियो ट्रांसक्रिप्शन" },
                    { 266, "app.audios.audioText", 11, "Trascrizione audio" },
                    { 267, "app.audios.audioText", 12, "Ljudtranskription" },
                    { 268, "app.audios.audioText", 13, "Audiotranskription" },
                    { 269, "app.audios.audioText", 14, "Transkrypcja dźwięku" },
                    { 270, "app.audios.audioText", 15, "Ses transkripsiyonu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 270);
        }
    }
}
