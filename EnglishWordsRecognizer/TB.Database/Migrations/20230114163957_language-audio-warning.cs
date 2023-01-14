using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class languageaudiowarning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "app",
                table: "Translation",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 421, "app.audios.languageWarning", 1, "Якщо аудіо транскрипція неправильна, спробуйте вибрати аудіо мову /audio_language і надіслати знову аудіо" },
                    { 422, "app.audios.languageWarning", 2, "Если аудио транскрипция неверна, попробуйте выбрать аудио язык /audio_language и отправить снова аудио" },
                    { 423, "app.audios.languageWarning", 3, "If the audio transcription is incorrect, try to select the audio language /audio_language and send the audio again" },
                    { 424, "app.audios.languageWarning", 4, "Si la transcripción del audio es incorrecta, intente seleccionar el idioma del audio /audio_language" },
                    { 425, "app.audios.languageWarning", 5, "Si la transcription audio est incorrecte, essayez de sélectionner la langue audio /audio_language" },
                    { 426, "app.audios.languageWarning", 6, "音声の書き起こしが正しくない場合は、音声言語 /audio_language を選択してみてください" },
                    { 427, "app.audios.languageWarning", 7, "如果音频转录不正确，请尝试选择音频语言 /audio_language" },
                    { 428, "app.audios.languageWarning", 8, "Pokud je přepis zvuku nesprávný, zkuste vybrat jazyk zvuku /audio_language" },
                    { 429, "app.audios.languageWarning", 9, "Hvis lydtransskriptionen er forkert, prøv at vælge lydsproget /audio_language" },
                    { 430, "app.audios.languageWarning", 10, "यदि ऑडियो ट्रांसक्रिप्शन गलत है, तो ऑडियो भाषा /audio_language का चयन करने का प्रयास करें" },
                    { 431, "app.audios.languageWarning", 11, "se la trascrizione audio non è corretta, prova a selezionare la lingua audio /audio_language" },
                    { 432, "app.audios.languageWarning", 12, "Om ljudtranskriptionen är felaktig, prova att välja ljudspråket /audio_language" },
                    { 433, "app.audios.languageWarning", 13, "Wenn die Audiotranskription nicht korrekt ist, versuchen Sie, die Audiosprache /audio_language auszuwählen" },
                    { 434, "app.audios.languageWarning", 14, "Jeśli transkrypcja dźwięku jest nieprawidłowa, spróbuj wybrać język dźwięku /audio_language" },
                    { 435, "app.audios.languageWarning", 15, "Ses dökümü yanlışsa, ses dilini /audio_language seçmeyi deneyin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 435);
        }
    }
}
