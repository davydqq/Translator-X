using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class audioerrortranscriptionmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 421, "app.audio.EmptyResult", 1, "Не вдалося транскрибувати. Спробуйте вибрати іншу мову транскрибування /audio_language або надішліть інший аудіоформат." },
                    { 422, "app.audio.EmptyResult", 2, "Не удалось расшифровать. Попробуйте выбрать другой язык расшифровки /audio_language или отправьте аудио в другом формате." },
                    { 423, "app.audio.EmptyResult", 3, "Failed to transcribe, please try selecting a different transcribing language /audio_language or send a different audio format." },
                    { 424, "app.audio.EmptyResult", 4, "No se pudo transcribir, intente seleccionar un idioma de transcripción diferente /audio_language o envíe un formato de audio diferente." },
                    { 425, "app.audio.EmptyResult", 5, "Échec de la transcription, veuillez essayer de sélectionner une autre langue de transcription /audio_language ou envoyer un format audio différent." },
                    { 426, "app.audio.EmptyResult", 6, "文字起こしに失敗しました。別の文字起こし言語 /audio_language を選択するか、別の音声形式を送信してください。" },
                    { 427, "app.audio.EmptyResult", 7, "转录失败，请尝试选择不同的转录语言 /audio_language 或发送不同的音频格式。" },
                    { 428, "app.audio.EmptyResult", 8, "Přepis se nezdařil, zkuste prosím vybrat jiný jazyk přepisu /audio_language nebo pošlete jiný formát zvuku." },
                    { 429, "app.audio.EmptyResult", 9, "Kunne ikke transskriberes. Prøv at vælge et andet transskriberingssprog /audio_language eller send et andet lydformat." },
                    { 430, "app.audio.EmptyResult", 10, "लिप्यंतरण करने में विफल, कृपया एक भिन्न अनुलेखन भाषा /audio_language का चयन करने का प्रयास करें या एक भिन्न ऑडियो प्रारूप भेजें।" },
                    { 431, "app.audio.EmptyResult", 11, "Impossibile trascrivere, prova a selezionare una lingua di trascrizione diversa /audio_language o invia un formato audio diverso." },
                    { 432, "app.audio.EmptyResult", 12, "Det gick inte att transkribera, försök att välja ett annat transkriberingsspråk /audio_language eller skicka ett annat ljudformat." },
                    { 433, "app.audio.EmptyResult", 13, "Transkription fehlgeschlagen, bitte versuchen Sie es mit der Auswahl einer anderen Transkriptionssprache /audio_language oder senden Sie ein anderes Audioformat." },
                    { 434, "app.audio.EmptyResult", 14, "Transkrypcja nie powiodła się. Spróbuj wybrać inny język transkrypcji /audio_language lub wyślij inny format audio." },
                    { 435, "app.audio.EmptyResult", 15, "Metne dönüştürülemedi, lütfen farklı bir transkripsiyon dili /audio_language seçmeyi deneyin veya farklı bir ses formatı gönderin." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 435);
        }
    }
}
