using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class resendmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Надішліть аудіо ще раз, ви можете використати 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Отправьте аудио еще раз, вы можете использовать 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Send the audio again, you can use 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Envía el audio de nuevo, puedes usar 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Envoyez à nouveau l'audio, vous pouvez utiliser 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "音声をもう一度送信してください。'reply' を使用できます" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "再次发送音频，您可以使用 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Pošlete zvuk znovu, můžete použít 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Send lyden igen, du kan bruge 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "ऑडियो फिर से भेजें, आप 'reply' का उपयोग कर सकते हैं" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Invia di nuovo l'audio, puoi usare 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Skicka ljudet igen, du kan använda 'svara'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Senden Sie das Audio erneut, Sie können 'reply' verwenden" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Wyślij dźwięk ponownie, możesz użyć 'reply'" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.languages.audioResendKey", "Sesi tekrar gönderin, 'reply' kullanabilirsiniz" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Бот не підтримує цей тип контенту" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Бот не поддерживает этот тип контента" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "The bot does not support this type of content" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "El bot no soporta este tipo de contenido." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Le bot ne prend pas en charge ce type de contenu" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "ボットはこのタイプのコンテンツをサポートしていません" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "该机器人不支持此类内容" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Robot tento typ obsahu nepodporuje" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Botten understøtter ikke denne type indhold" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "बॉट इस प्रकार की सामग्री का समर्थन नहीं करता है" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Il bot non supporta questo tipo di contenuto" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Boten stöder inte den här typen av innehåll" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Der Bot unterstützt diese Art von Inhalten nicht" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Bot nie obsługuje tego typu treści" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Bot bu tür içeriği desteklemiyor" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Формат не підтримується. Використовуйте (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Не поддерживаемый формат. Используйте (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Not supported format. Use (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Formato no compatible. Usar (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Format non pris en charge. Utiliser (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "サポートされていない形式です。 使用 (.mp3、.ogg、.flac、.wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "不支持的格式。 使用（.mp3、.ogg、.flac、.wav）" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Nepodporovaný formát. Použít (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Ikke understøttet format. Brug (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "समर्थित प्रारूप नहीं। उपयोग करें (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Formato non supportato. Usa (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Format som inte stöds. Använd (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Nicht unterstütztes Format. Verwendung (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Nieobsługiwany format. Użyj (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Desteklenmeyen biçim. (.mp3, .ogg, .flac, .wav) kullanın" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Не вдається обробити це аудіо, спробуйте інше." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Не удается обработать этот звук, попробуйте другой." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Can't process this audio try another one." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "No se puede procesar este audio, prueba con otro." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Impossible de traiter cet audio, essayez-en un autre." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "この音声を処理できません。別の音声を試してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "无法处理此音频，请尝试另一个。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Tento zvuk nelze zpracovat, zkuste jiný." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Kan ikke behandle denne lyd prøv en anden." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "इस ऑडियो को प्रोसेस नहीं किया जा सकता, एक और ऑडियो आज़माएं." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Impossibile elaborare questo audio, provane un altro." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Det går inte att bearbeta det här ljudet, försök med ett annat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Dieses Audio kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Nie można przetworzyć tego dźwięku, spróbuj innego." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Bu ses işlenemiyor başka bir ses deneyin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Тривалість аудіо не повинна перевищувати 60 секунд" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Продолжительность аудио не должна превышать 60 секунд." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Audio duration must not exceed 60 seconds" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "La duración del audio no debe exceder los 60 segundos." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "La durée audio ne doit pas dépasser 60 secondes" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "音声の長さは 60 秒を超えてはなりません" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "音频时长不得超过 60 秒" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Délka zvuku nesmí přesáhnout 60 sekund" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Lydens varighed må ikke overstige 60 sekunder" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "ऑडियो की अवधि 60 सेकंड से अधिक नहीं होनी चाहिए" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "La durata dell'audio non deve superare i 60 secondi" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Ljudlängden får inte överstiga 60 sekunder" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Die Audiodauer darf 60 Sekunden nicht überschreiten" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Czas trwania dźwięku nie może przekraczać 60 sekund" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Ses süresi 60 saniyeyi geçmemelidir" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Формат не підтримується. Використовуйте (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Не поддерживаемый формат. Использовать (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Not supported format. Use (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Formato no compatible. Usar (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Format non pris en charge. Utiliser (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "サポートされていない形式です。 使用 (.png、.jpeg、.jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "不支持的格式。 使用（.png、.jpeg、.jpg）" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Nepodporovaný formát. Použít (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Ikke understøttet format. Brug (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "समर्थित प्रारूप नहीं। (.पीएनजी, .जेपीईजी, .जेपीजी) का प्रयोग करें" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Formato non supportato. Usa (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Format som inte stöds. Använd (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Nicht unterstütztes Format. Verwenden Sie (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Nieobsługiwany format. Użyj (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Desteklenmeyen biçim. (.png, .jpeg, .jpg) kullanın" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Не вдається обробити цю фотографію, спробуйте іншу." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Не удается обработать это фото. Попробуйте другое." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Can't process this photo try another one." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "No se puede procesar esta foto, prueba con otra." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Impossible de traiter cette photo, essayez-en une autre." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "この写真を処理できません。別の写真を試してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "无法处理这张照片，请尝试另一张。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Tuto fotografii nelze zpracovat, zkuste jinou." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Kan ikke behandle dette billede prøv et andet." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "इस फ़ोटो को प्रोसेस नहीं किया जा सकता, कोई और फ़ोटो आज़माएं." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Impossibile elaborare questa foto, provane un'altra." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Det går inte att bearbeta det här fotot, försök med ett annat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Dieses Foto kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Nie można przetworzyć tego zdjęcia, spróbuj innego." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Bu fotoğraf işlenemiyor başka bir fotoğraf deneyin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Занадто великий файл. Використовуйте фото до 4 Мб" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Слишком большой файл. Используйте фото до 4 МБ" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Too large a file. Use photo up to 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Un archivo demasiado grande. Usar foto de hasta 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Fichier trop volumineux. Utiliser une photo jusqu'à 4 Mo" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "ファイルが大きすぎます。 4 MB までの写真を使用" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "文件太大。 使用最大 4 MB 的照片" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Příliš velký soubor. Použijte fotografii do velikosti 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "For stor fil. Brug foto op til 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "फ़ाइल बहुत बड़ी है. 4 एमबी तक फोटो का प्रयोग करें" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Un file troppo grande. Usa foto fino a 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "För stor fil. Använd foto upp till 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Eine zu große Datei. Verwenden Sie Fotos bis zu 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Zbyt duży plik. Użyj zdjęcia do 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Çok büyük bir dosya. 4 MB'a kadar fotoğraf kullan" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Максимальна довжина тексту одного повідомлення не повинна перевищувати 40 тис. символів." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Максимальная длина текста одного сообщения не должна превышать 40 тыс. символов." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "The maximum text length of one message must not exceed 40k characters." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "La longitud máxima del texto de un mensaje no debe exceder los 40k caracteres." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "La longueur maximale du texte d'un message ne doit pas dépasser 40 000 caractères" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "1 つのメッセージの最大テキスト長は 40,000 文字を超えてはなりません" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "一條消息的最大文本長度不得超過 40k 個字符" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Maximální délka textu jedné zprávy nesmí přesáhnout 40 000 znaků" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Den maksimale tekstlængde på én besked må ikke overstige 40.000 tegn" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "एक संदेश की अधिकतम टेक्स्ट लंबाई 40k वर्णों से अधिक नहीं होनी चाहिए" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "La lunghezza massima del testo di un messaggio non deve superare i 40k caratteri" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Den maximala textlängden för ett meddelande får inte överstiga 40 000 tecken" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Die maximale Textlänge einer Nachricht darf 40.000 Zeichen nicht überschreiten" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Maksymalna długość tekstu jednej wiadomości nie może przekraczać 40 tys. znaków" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Bir mesajın maksimum metin uzunluğu 40k karakteri geçmemelidir" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Не вдалося транскрибувати. Спробуйте вибрати іншу мову транскрибування /audio_language або надішліть інший аудіоформат." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Не удалось расшифровать. Попробуйте выбрать другой язык расшифровки /audio_language или отправьте аудио в другом формате." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Failed to transcribe, please try selecting a different transcribing language /audio_language or send a different audio format." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "No se pudo transcribir, intente seleccionar un idioma de transcripción diferente /audio_language o envíe un formato de audio diferente." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Échec de la transcription, veuillez essayer de sélectionner une autre langue de transcription /audio_language ou envoyer un format audio différent." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "文字起こしに失敗しました。別の文字起こし言語 /audio_language を選択するか、別の音声形式を送信してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "转录失败，请尝试选择不同的转录语言 /audio_language 或发送不同的音频格式。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Přepis se nezdařil, zkuste prosím vybrat jiný jazyk přepisu /audio_language nebo pošlete jiný formát zvuku." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Kunne ikke transskriberes. Prøv at vælge et andet transskriberingssprog /audio_language eller send et andet lydformat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "लिप्यंतरण करने में विफल, कृपया एक भिन्न अनुलेखन भाषा /audio_language का चयन करने का प्रयास करें या एक भिन्न ऑडियो प्रारूप भेजें।" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Impossibile trascrivere, prova a selezionare una lingua di trascrizione diversa /audio_language o invia un formato audio diverso." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Det gick inte att transkribera, försök att välja ett annat transkriberingsspråk /audio_language eller skicka ett annat ljudformat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Transkription fehlgeschlagen, bitte versuchen Sie es mit der Auswahl einer anderen Transkriptionssprache /audio_language oder senden Sie ein anderes Audioformat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Transkrypcja nie powiodła się. Spróbuj wybrać inny język transkrypcji /audio_language lub wyślij inny format audio." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Metne dönüştürülemedi, lütfen farklı bir transkripsiyon dili /audio_language seçmeyi deneyin veya farklı bir ses formatı gönderin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Перевищено ліміт цього місяця надішліть /stats для деталей." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Превышенный предел этого месяца отправьте /stats для деталей." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "This month's limit has been exceeded, send /stats for details." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Se superó el límite de este mes, envíe /stats para obtener más detalles." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "La limite de ce mois a été dépassée, envoyez /stats pour plus de détails." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "今月の制限を超えました。詳細については /stats を送信してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "已超过本月的限制，请发送 /stats 了解详情。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Limit pro tento měsíc byl překročen, pro podrobnosti zašlete /stats ." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Denne måneds grænse er overskredet, send /stats for detaljer." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "इस माह की सीमा पार हो गई है, विवरण के लिए /stats भेजें।" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Il limite di questo mese è stato superato, invia /stats per i dettagli." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Denna månads gräns har överskridits, skicka /stats för mer information." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Das Limit dieses Monats wurde überschritten, senden Sie /stats für Details." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Limit w tym miesiącu został przekroczony, wyślij /stats, aby uzyskać szczegółowe informacje." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Bu ayın limiti aşıldı, detaylar için /stats gönderin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Зображення</b> {1} з {2} використано\n<b>Символов текста для перевода</b> использовано {3} из {4}\n<b>Аудіохвилин</b> використано {5} із {6}\n\nЗалишилося {7} днів підписки\nЗалишилося {8} хвилин підписки\n\nПідписка автоматично оновлюється кожного місяця" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Изображения</b> {1} из {2} использованных\n<b>Символів тексту для перекладу</b> використано {3} з {4}\n<b>Аудио минут</b> использовано {5} из {6}\n\nОсталось {7} дней подписки\nОсталось {8} минут подписки\n\nПодписка автоматически обновляется каждый месяц" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistic</b>\n\nPlan: {0}\n\n<b>Images</b> {1} of {2} used\n<b>Text characters for translation</b> {3} of {4} used\n<b>Audio minutes</b> {5} of {6} used\n\n{7} days of subscription left\n{8} minutes of subscription left\n\nSubscription automatically renews each month" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Estadística</b>\n\nTarifa: {0}\n\n<b>Imágenes</b> {1} de {2} usadas\n<b>Caracteres de texto para traducción</b> {3} de {4} utilizados\n<b>Minutos de audio</b> {5} de {6} utilizados\n\nQuedan {7} días de suscripción\nQuedan {8} minutos de suscripción\n\nMes de skin actualizado automáticamente por suscripción" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistique</b>\n\nTarif : {0}\n\n<b>Images</b> {1} sur {2} utilisées\n<b>Caractères de texte à traduire</b> {3} sur {4} utilisés\n<b>Minutes audio</b> {5} sur {6} utilisées\n\n{7} jours d'abonnement restants\n{8} minutes d'abonnement restantes\n\nAbonnement automatiquement mis à jour skin mois" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>統計</b>\n\n料金: {0}\n\n<b>画像</b> {1}/{2} 使用\n<b>翻訳用テキスト文字</b> {4} 個中 {3} 個使用\n<b>音声時間</b> {6} 中 {5} を使用\n\nサブスクリプションは残り {7} 日\n{8} 分のサブスクリプションが残っています\n\nサブスクリプションは自動的にスキン月を更新します" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>统计</b>\n\n关税：{0}\n\n<b>Images</b> {1} of {2} 使用了\n<b>用于翻译的文本字符</b> 使用了 {3} 个，共 {4} 个\n<b>音频分钟数</b>已使用 {5} 分钟，共 {6} 分钟\n\n订阅还剩 {7} 天\n还剩 {8} 分钟的订阅时间\n\n订阅自动更新皮肤月份" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistika</b>\n\nTarif: {0}\n\n<b>Obrázky</b> použité {1} z {2}\n<b>Textové znaky pro překlad</b> Využito {3} z {4}\n<b>Zvukové minuty</b> Využito {5} z {6}\n\nZbývá {7} dní předplatného\nZbývá {8} minut předplatného\n\nPředplatné automaticky aktualizovalo měsíc vzhledu" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistik</b>\n\nTakst: {0}\n\n<b>Billeder</b> {1} af {2} brugt\n<b>Teksttegn til oversættelse</b> {3} af {4} brugt\n<b>Lydminutter</b> {5} af {6} brugt\n\n{7} dages abonnement tilbage\n{8} minutters abonnement tilbage\n\nAbonnement opdateret automatisk hudmåned" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>आँकड़ा</b>\n\nशुल्क: {0}\n\n<b>इमेज</b> {2} में से {1} इस्तेमाल की गई\n<b>अनुवाद के लिए पाठ वर्ण</b> {4} में से {3} का उपयोग किया गया\n<b>ऑडियो मिनट</b> {6} में से {5} का उपयोग किया गया\n\n{7} दिनों की सदस्‍यता शेष\n{8} मिनट की सदस्यता बाकी है\n\nसदस्यता स्वचालित रूप से अद्यतन त्वचा माह" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistica</b>\n\nTariffa: {0}\n\n<b>Immagini</b> {1} di {2} usate\n<b>Caratteri di testo per la traduzione</b> {3} di {4} utilizzati\n<b>Minuti audio</b> {5} su {6} utilizzati\n\n{7} giorni di abbonamento rimanenti\n{8} minuti di abbonamento rimanenti\n\nAbbonamento aggiornato automaticamente skin mese" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistik</b>\n\nPris: {0}\n\n<b>Bilder</b> {1} av {2} används\n<b>Textecken för översättning</b> {3} av {4} används\n<b>Ljudminuter</b> {5} av {6} används\n\n{7} dagars prenumeration kvar\n{8} minuters prenumeration kvar\n\nAbonnemanget uppdateras automatiskt hudmånad" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistik</b>\n\nTarif: {0}\n\n<b>Bilder</b> {1} von {2} verwendet\n<b>Textzeichen für die Übersetzung</b> {3} von {4} verwendet\n<b>Audiominuten</b> {5} von {6} verbraucht\n\n{7} Tage Abonnement verbleibend\n{8} Minuten Abonnement verbleiben\n\nAbonnement automatisch aktualisiert Skin Monat" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statystyki</b>\n\nTaryfa: {0}\n\n<b>Obrazy</b> użyto {1} z {2}\n<b>Znaki tekstowe do tłumaczenia</b> Użyto {3} z {4}\n<b>Wykorzystano minuty audio</b> {5} z {6}\n\nPozostało {7} dni subskrypcji\nPozostało {8} minut subskrypcji\n\nSubskrypcja automatycznie aktualizuje miesiąc skórki" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 420,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>İstatistik</b>\n\nTarife: {0}\n\n{2} resimden {1} <b>resim</b> kullanıldı\n<b>Çeviri için metin karakterleri</b> {3} / {4} kullanıldı\n<b>Ses dakikaları</b> {5} / {6} kullanıldı\n\n{7} günlük abonelik kaldı\n{8} dakikalık abonelik kaldı\n\nAbonelik otomatik olarak güncellenen cilt ayı" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Взято на обробку, будь ласка, зачекайте хвилинку. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Взято на обработку, пожалуйста, подождите немного. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Taken for processing, please wait a moment. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Tomado para procesar, por favor espere un momento. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Pris pour traitement, veuillez patienter un moment. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "処理に時間がかかっています、しばらくお待ちください。😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "正在处理中，请稍等片刻。😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Převzato ke zpracování, chvíli prosím počkejte. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Optaget til behandling, vent venligst et øjeblik. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 430,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "प्रसंस्करण के लिए लिया गया, कृपया एक क्षण प्रतीक्षा करें। 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Assunto per l'elaborazione, si prega di attendere un momento. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Upptaget för behandling, vänligen vänta ett ögonblick. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Zur Bearbeitung angenommen, bitte warten Sie einen Moment. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Pobrane do przetworzenia, proszę chwilę poczekać. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "İşlem için alındı, lütfen bir dakika bekleyin. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Якщо аудіо транскрипція неправильна, спробуйте вибрати аудіо мову /audio_language і надіслати знову аудіо" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Если аудио транскрипция неверна, попробуйте выбрать аудио язык /audio_language и отправить снова аудио" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "If the audio transcription is incorrect, try to select the audio language /audio_language and send the audio again" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 439,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Si la transcripción del audio es incorrecta, intente seleccionar el idioma del audio /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 440,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Si la transcription audio est incorrecte, essayez de sélectionner la langue audio /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "音声の書き起こしが正しくない場合は、音声言語 /audio_language を選択してみてください" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "如果音频转录不正确，请尝试选择音频语言 /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Pokud je přepis zvuku nesprávný, zkuste vybrat jazyk zvuku /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Hvis lydtransskriptionen er forkert, prøv at vælge lydsproget /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "यदि ऑडियो ट्रांसक्रिप्शन गलत है, तो ऑडियो भाषा /audio_language का चयन करने का प्रयास करें" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "se la trascrizione audio non è corretta, prova a selezionare la lingua audio /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 447,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Om ljudtranskriptionen är felaktig, prova att välja ljudspråket /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 448,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Wenn die Audiotranskription nicht korrekt ist, versuchen Sie, die Audiosprache /audio_language auszuwählen" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 449,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Jeśli transkrypcja dźwięku jest nieprawidłowa, spróbuj wybrać język dźwięku /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 450,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Ses dökümü yanlışsa, ses dilini /audio_language seçmeyi deneyin" });

            migrationBuilder.InsertData(
                schema: "app",
                table: "Translation",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 451, "app.menu.userInfo", 1, "<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}\n\nМова аудіо транскрипції: {2}\n\nМова інтерфейсу: {3}\n\nПоказувати значення англійських слів - {4}" },
                    { 452, "app.menu.userInfo", 2, "<b>Ваши языки</b>\nОсновной язык: {0}\nЦелевой язык: {1}\n\nЯзык аудио транскрипции: {2}\n\nЯзык интерфейса: {3}\n\nПоказывать значение английских слов - {4}" },
                    { 453, "app.menu.userInfo", 3, "<b>Your languages</b>\nMain Language: {0}\nTarget Language: {1}\n\nAudio transcription language: {2}\n\nYour interface language: {3}\n\nShow english words meaning - {4}" },
                    { 454, "app.menu.userInfo", 4, "b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}\n\nIdioma de transcripción de audio: {2}\n\nTu idioma de interfaz: {3}\n\nMostrar el significado de las palabras en inglés - {4}" },
                    { 455, "app.menu.userInfo", 5, "<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}\n\nLangue de transcription audio: {2}\n\nLa langue de votre interface: {3}\n\nAfficher le sens des mots anglais - {4}" },
                    { 456, "app.menu.userInfo", 6, "<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}\n\n音声転写言語: {2}\n\nインターフェース言語: {3}\n\n英単語の意味を表示 - {4}" },
                    { 457, "app.menu.userInfo", 7, "<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}\n\n音频转录语言：{2}\n\n界面语言： {3}\n\n显示英文单词的意思 - {4}" },
                    { 458, "app.menu.userInfo", 8, "<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}\n\nJazyk zvukového přepisu: {2}\n\nVáš jazyk rozhraní: {3}\n\nZobrazit význam anglických slov - {4}" },
                    { 459, "app.menu.userInfo", 9, "<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}\n\nLydtransskriptionssprog: {2}\n\nDit grænsefladesprog: {3}\n\nVis engelske ords betydning - {4}" },
                    { 460, "app.menu.userInfo", 10, "<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}\n\nऑडियो ट्रांसक्रिप्शन भाषा: {2}\n\nअंतरफलक भाषा: {3}\n\nअंग्रेजी शब्दों का अर्थ दिखाएँ - {4}" },
                    { 461, "app.menu.userInfo", 11, "<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}\n\nLingua di trascrizione audio: {2}\n\nLa lingua dell'interfaccia: {3}\n\nMostra il significato delle parole inglesi - {4}" },
                    { 462, "app.menu.userInfo", 12, "<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}\n\nSpråk för ljudtranskription: {2}\n\nDitt gränssnittsspråk: {3}\n\nVisa engelska ords betydelse - {4}" },
                    { 463, "app.menu.userInfo", 13, "<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}\n\nSprache der Audiotranskription: {2}\n\nIhre Oberflächensprache: {3}\n\nVisa engelska ords betydelse - {4}" },
                    { 464, "app.menu.userInfo", 14, "<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}\n\nJęzyk transkrypcji dźwięku: {2}\n\nTwój język interfejsu: {3}\n\nPokaż znaczenie angielskich słów - {4}" },
                    { 465, "app.menu.userInfo", 15, "<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}\n\nSes transkripsiyon dili: {2}\n\nArayüz diliniz: {3}\n\nİngilizce kelimelerin anlamını göster - {4}" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Бот не підтримує цей тип контенту" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Бот не поддерживает этот тип контента" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "The bot does not support this type of content" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "El bot no soporta este tipo de contenido." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Le bot ne prend pas en charge ce type de contenu" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "ボットはこのタイプのコンテンツをサポートしていません" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "该机器人不支持此类内容" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Robot tento typ obsahu nepodporuje" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Botten understøtter ikke denne type indhold" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "बॉट इस प्रकार की सामग्री का समर्थन नहीं करता है" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Il bot non supporta questo tipo di contenuto" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Boten stöder inte den här typen av innehåll" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Der Bot unterstützt diese Art von Inhalten nicht" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Bot nie obsługuje tego typu treści" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.file.noSupportContent", "Bot bu tür içeriği desteklemiyor" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Формат не підтримується. Використовуйте (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Не поддерживаемый формат. Используйте (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Not supported format. Use (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Formato no compatible. Usar (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Format non pris en charge. Utiliser (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "サポートされていない形式です。 使用 (.mp3、.ogg、.flac、.wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "不支持的格式。 使用（.mp3、.ogg、.flac、.wav）" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Nepodporovaný formát. Použít (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Ikke understøttet format. Brug (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "समर्थित प्रारूप नहीं। उपयोग करें (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Formato non supportato. Usa (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Format som inte stöds. Använd (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Nicht unterstütztes Format. Verwendung (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Nieobsługiwany format. Użyj (.mp3, .ogg, .flac, .wav)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noSupportFormat", "Desteklenmeyen biçim. (.mp3, .ogg, .flac, .wav) kullanın" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Не вдається обробити це аудіо, спробуйте інше." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Не удается обработать этот звук, попробуйте другой." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Can't process this audio try another one." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "No se puede procesar este audio, prueba con otro." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Impossible de traiter cet audio, essayez-en un autre." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "この音声を処理できません。別の音声を試してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "无法处理此音频，请尝试另一个。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Tento zvuk nelze zpracovat, zkuste jiný." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Kan ikke behandle denne lyd prøv en anden." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "इस ऑडियो को प्रोसेस नहीं किया जा सकता, एक और ऑडियो आज़माएं." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Impossibile elaborare questo audio, provane un altro." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Det går inte att bearbeta det här ljudet, försök med ett annat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Dieses Audio kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Nie można przetworzyć tego dźwięku, spróbuj innego." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.cantProcess", "Bu ses işlenemiyor başka bir ses deneyin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Тривалість аудіо не повинна перевищувати 60 секунд" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Продолжительность аудио не должна превышать 60 секунд." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Audio duration must not exceed 60 seconds" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "La duración del audio no debe exceder los 60 segundos." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "La durée audio ne doit pas dépasser 60 secondes" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "音声の長さは 60 秒を超えてはなりません" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "音频时长不得超过 60 秒" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Délka zvuku nesmí přesáhnout 60 sekund" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Lydens varighed må ikke overstige 60 sekunder" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "ऑडियो की अवधि 60 सेकंड से अधिक नहीं होनी चाहिए" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "La durata dell'audio non deve superare i 60 secondi" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Ljudlängden får inte överstiga 60 sekunder" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Die Audiodauer darf 60 Sekunden nicht überschreiten" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Czas trwania dźwięku nie może przekraczać 60 sekund" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.noExceedDuration", "Ses süresi 60 saniyeyi geçmemelidir" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Формат не підтримується. Використовуйте (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Не поддерживаемый формат. Использовать (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Not supported format. Use (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Formato no compatible. Usar (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Format non pris en charge. Utiliser (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "サポートされていない形式です。 使用 (.png、.jpeg、.jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "不支持的格式。 使用（.png、.jpeg、.jpg）" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Nepodporovaný formát. Použít (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Ikke understøttet format. Brug (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "समर्थित प्रारूप नहीं। (.पीएनजी, .जेपीईजी, .जेपीजी) का प्रयोग करें" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Formato non supportato. Usa (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Format som inte stöds. Använd (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Nicht unterstütztes Format. Verwenden Sie (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Nieobsługiwany format. Użyj (.png, .jpeg, .jpg)" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.noSupportFormat", "Desteklenmeyen biçim. (.png, .jpeg, .jpg) kullanın" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Не вдається обробити цю фотографію, спробуйте іншу." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Не удается обработать это фото. Попробуйте другое." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Can't process this photo try another one." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "No se puede procesar esta foto, prueba con otra." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Impossible de traiter cette photo, essayez-en une autre." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "この写真を処理できません。別の写真を試してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "无法处理这张照片，请尝试另一张。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Tuto fotografii nelze zpracovat, zkuste jinou." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Kan ikke behandle dette billede prøv et andet." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "इस फ़ोटो को प्रोसेस नहीं किया जा सकता, कोई और फ़ोटो आज़माएं." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Impossibile elaborare questa foto, provane un'altra." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Det går inte att bearbeta det här fotot, försök med ett annat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Dieses Foto kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Nie można przetworzyć tego zdjęcia, spróbuj innego." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.cantProcess", "Bu fotoğraf işlenemiyor başka bir fotoğraf deneyin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Занадто великий файл. Використовуйте фото до 4 Мб" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Слишком большой файл. Используйте фото до 4 МБ" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Too large a file. Use photo up to 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Un archivo demasiado grande. Usar foto de hasta 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Fichier trop volumineux. Utiliser une photo jusqu'à 4 Mo" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "ファイルが大きすぎます。 4 MB までの写真を使用" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "文件太大。 使用最大 4 MB 的照片" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Příliš velký soubor. Použijte fotografii do velikosti 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "For stor fil. Brug foto op til 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "फ़ाइल बहुत बड़ी है. 4 एमबी तक फोटो का प्रयोग करें" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Un file troppo grande. Usa foto fino a 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "För stor fil. Använd foto upp till 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Eine zu große Datei. Verwenden Sie Fotos bis zu 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Zbyt duży plik. Użyj zdjęcia do 4 MB" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.photo.tooLargeFile", "Çok büyük bir dosya. 4 MB'a kadar fotoğraf kullan" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Максимальна довжина тексту одного повідомлення не повинна перевищувати 40 тис. символів." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Максимальная длина текста одного сообщения не должна превышать 40 тыс. символов." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "The maximum text length of one message must not exceed 40k characters." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "La longitud máxima del texto de un mensaje no debe exceder los 40k caracteres." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "La longueur maximale du texte d'un message ne doit pas dépasser 40 000 caractères" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "1 つのメッセージの最大テキスト長は 40,000 文字を超えてはなりません" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "一條消息的最大文本長度不得超過 40k 個字符" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Maximální délka textu jedné zprávy nesmí přesáhnout 40 000 znaků" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Den maksimale tekstlængde på én besked må ikke overstige 40.000 tegn" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "एक संदेश की अधिकतम टेक्स्ट लंबाई 40k वर्णों से अधिक नहीं होनी चाहिए" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "La lunghezza massima del testo di un messaggio non deve superare i 40k caratteri" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Den maximala textlängden för ett meddelande får inte överstiga 40 000 tecken" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Die maximale Textlänge einer Nachricht darf 40.000 Zeichen nicht überschreiten" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Maksymalna długość tekstu jednej wiadomości nie może przekraczać 40 tys. znaków" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.text.maxLength", "Bir mesajın maksimum metin uzunluğu 40k karakteri geçmemelidir" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Не вдалося транскрибувати. Спробуйте вибрати іншу мову транскрибування /audio_language або надішліть інший аудіоформат." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Не удалось расшифровать. Попробуйте выбрать другой язык расшифровки /audio_language или отправьте аудио в другом формате." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Failed to transcribe, please try selecting a different transcribing language /audio_language or send a different audio format." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "No se pudo transcribir, intente seleccionar un idioma de transcripción diferente /audio_language o envíe un formato de audio diferente." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Échec de la transcription, veuillez essayer de sélectionner une autre langue de transcription /audio_language ou envoyer un format audio différent." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "文字起こしに失敗しました。別の文字起こし言語 /audio_language を選択するか、別の音声形式を送信してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "转录失败，请尝试选择不同的转录语言 /audio_language 或发送不同的音频格式。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Přepis se nezdařil, zkuste prosím vybrat jiný jazyk přepisu /audio_language nebo pošlete jiný formát zvuku." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Kunne ikke transskriberes. Prøv at vælge et andet transskriberingssprog /audio_language eller send et andet lydformat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "लिप्यंतरण करने में विफल, कृपया एक भिन्न अनुलेखन भाषा /audio_language का चयन करने का प्रयास करें या एक भिन्न ऑडियो प्रारूप भेजें।" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Impossibile trascrivere, prova a selezionare una lingua di trascrizione diversa /audio_language o invia un formato audio diverso." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Det gick inte att transkribera, försök att välja ett annat transkriberingsspråk /audio_language eller skicka ett annat ljudformat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Transkription fehlgeschlagen, bitte versuchen Sie es mit der Auswahl einer anderen Transkriptionssprache /audio_language oder senden Sie ein anderes Audioformat." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Transkrypcja nie powiodła się. Spróbuj wybrać inny język transkrypcji /audio_language lub wyślij inny format audio." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audio.EmptyResult", "Metne dönüştürülemedi, lütfen farklı bir transkripsiyon dili /audio_language seçmeyi deneyin veya farklı bir ses formatı gönderin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Перевищено ліміт цього місяця надішліть /stats для деталей." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Превышенный предел этого месяца отправьте /stats для деталей." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "This month's limit has been exceeded, send /stats for details." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Se superó el límite de este mes, envíe /stats para obtener más detalles." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "La limite de ce mois a été dépassée, envoyez /stats pour plus de détails." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "今月の制限を超えました。詳細については /stats を送信してください。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "已超过本月的限制，请发送 /stats 了解详情。" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Limit pro tento měsíc byl překročen, pro podrobnosti zašlete /stats ." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Denne måneds grænse er overskredet, send /stats for detaljer." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "इस माह की सीमा पार हो गई है, विवरण के लिए /stats भेजें।" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Il limite di questo mese è stato superato, invia /stats per i dettagli." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Denna månads gräns har överskridits, skicka /stats för mer information." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Das Limit dieses Monats wurde überschritten, senden Sie /stats für Details." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Limit w tym miesiącu został przekroczony, wyślij /stats, aby uzyskać szczegółowe informacje." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "billing.exceedLimit", "Bu ayın limiti aşıldı, detaylar için /stats gönderin." });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Зображення</b> {1} з {2} використано\n<b>Символов текста для перевода</b> использовано {3} из {4}\n<b>Аудіохвилин</b> використано {5} із {6}\n\nЗалишилося {7} днів підписки\nЗалишилося {8} хвилин підписки" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Изображения</b> {1} из {2} использованных\n<b>Символів тексту для перекладу</b> використано {3} з {4}\n<b>Аудио минут</b> использовано {5} из {6}\n\nОсталось {7} дней подписки\nОсталось {8} минут подписки" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistic</b>\n\nPlan: {0}\n\n<b>Images</b> {1} of {2} used\n<b>Text characters for translation</b> {3} of {4} used\n<b>Audio minutes</b> {5} of {6} used\n\n{7} days of subscription left\n{8} minutes of subscription left" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Estadística</b>\n\nTarifa: {0}\n\n<b>Imágenes</b> {1} de {2} usadas\n<b>Caracteres de texto para traducción</b> {3} de {4} utilizados\n<b>Minutos de audio</b> {5} de {6} utilizados\n\nQuedan {7} días de suscripción\nQuedan {8} minutos de suscripción" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistique</b>\n\nTarif : {0}\n\n<b>Images</b> {1} sur {2} utilisées\n<b>Caractères de texte à traduire</b> {3} sur {4} utilisés\n<b>Minutes audio</b> {5} sur {6} utilisées\n\n{7} jours d'abonnement restants\n{8} minutes d'abonnement restantes" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>統計</b>\n\n料金: {0}\n\n<b>画像</b> {1}/{2} 使用\n<b>翻訳用テキスト文字</b> {4} 個中 {3} 個使用\n<b>音声時間</b> {6} 中 {5} を使用\n\nサブスクリプションは残り {7} 日\n{8} 分のサブスクリプションが残っています" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>统计</b>\n\n关税：{0}\n\n<b>Images</b> {1} of {2} 使用了\n<b>用于翻译的文本字符</b> 使用了 {3} 个，共 {4} 个\n<b>音频分钟数</b>已使用 {5} 分钟，共 {6} 分钟\n\n订阅还剩 {7} 天\n还剩 {8} 分钟的订阅时间" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistika</b>\n\nTarif: {0}\n\n<b>Obrázky</b> použité {1} z {2}\n<b>Textové znaky pro překlad</b> Využito {3} z {4}\n<b>Zvukové minuty</b> Využito {5} z {6}\n\nZbývá {7} dní předplatného\nZbývá {8} minut předplatného" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistik</b>\n\nTakst: {0}\n\n<b>Billeder</b> {1} af {2} brugt\n<b>Teksttegn til oversættelse</b> {3} af {4} brugt\n<b>Lydminutter</b> {5} af {6} brugt\n\n{7} dages abonnement tilbage\n{8} minutters abonnement tilbage" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>आँकड़ा</b>\n\nशुल्क: {0}\n\n<b>इमेज</b> {2} में से {1} इस्तेमाल की गई\n<b>अनुवाद के लिए पाठ वर्ण</b> {4} में से {3} का उपयोग किया गया\n<b>ऑडियो मिनट</b> {6} में से {5} का उपयोग किया गया\n\n{7} दिनों की सदस्‍यता शेष\n{8} मिनट की सदस्यता बाकी है" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistica</b>\n\nTariffa: {0}\n\n<b>Immagini</b> {1} di {2} usate\n<b>Caratteri di testo per la traduzione</b> {3} di {4} utilizzati\n<b>Minuti audio</b> {5} su {6} utilizzati\n\n{7} giorni di abbonamento rimanenti\n{8} minuti di abbonamento rimanenti" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistik</b>\n\nPris: {0}\n\n<b>Bilder</b> {1} av {2} används\n<b>Textecken för översättning</b> {3} av {4} används\n<b>Ljudminuter</b> {5} av {6} används\n\n{7} dagars prenumeration kvar\n{8} minuters prenumeration kvar" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statistik</b>\n\nTarif: {0}\n\n<b>Bilder</b> {1} von {2} verwendet\n<b>Textzeichen für die Übersetzung</b> {3} von {4} verwendet\n<b>Audiominuten</b> {5} von {6} verbraucht\n\n{7} Tage Abonnement verbleibend\n{8} Minuten Abonnement verbleiben" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>Statystyki</b>\n\nTaryfa: {0}\n\n<b>Obrazy</b> użyto {1} z {2}\n<b>Znaki tekstowe do tłumaczenia</b> Użyto {3} z {4}\n<b>Wykorzystano minuty audio</b> {5} z {6}\n\nPozostało {7} dni subskrypcji\nPozostało {8} minut subskrypcji" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "stats.message", "<b>İstatistik</b>\n\nTarife: {0}\n\n{2} resimden {1} <b>resim</b> kullanıldı\n<b>Çeviri için metin karakterleri</b> {3} / {4} kullanıldı\n<b>Ses dakikaları</b> {5} / {6} kullanıldı\n\n{7} günlük abonelik kaldı\n{8} dakikalık abonelik kaldı" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Взято на обробку, будь ласка, зачекайте хвилинку. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Взято на обработку, пожалуйста, подождите немного. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Taken for processing, please wait a moment. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Tomado para procesar, por favor espere un momento. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Pris pour traitement, veuillez patienter un moment. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "処理に時間がかかっています、しばらくお待ちください。😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "正在处理中，请稍等片刻。😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Převzato ke zpracování, chvíli prosím počkejte. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Optaget til behandling, vent venligst et øjeblik. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "प्रसंस्करण के लिए लिया गया, कृपया एक क्षण प्रतीक्षा करें। 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Assunto per l'elaborazione, si prega di attendere un momento. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Upptaget för behandling, vänligen vänta ett ögonblick. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Zur Bearbeitung angenommen, bitte warten Sie einen Moment. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "Pobrane do przetworzenia, proszę chwilę poczekać. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 420,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.content.processing", "İşlem için alındı, lütfen bir dakika bekleyin. 😌" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Якщо аудіо транскрипція неправильна, спробуйте вибрати аудіо мову /audio_language і надіслати знову аудіо" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Если аудио транскрипция неверна, попробуйте выбрать аудио язык /audio_language и отправить снова аудио" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "If the audio transcription is incorrect, try to select the audio language /audio_language and send the audio again" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Si la transcripción del audio es incorrecta, intente seleccionar el idioma del audio /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Si la transcription audio est incorrecte, essayez de sélectionner la langue audio /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "音声の書き起こしが正しくない場合は、音声言語 /audio_language を選択してみてください" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "如果音频转录不正确，请尝试选择音频语言 /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Pokud je přepis zvuku nesprávný, zkuste vybrat jazyk zvuku /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Hvis lydtransskriptionen er forkert, prøv at vælge lydsproget /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 430,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "यदि ऑडियो ट्रांसक्रिप्शन गलत है, तो ऑडियो भाषा /audio_language का चयन करने का प्रयास करें" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "se la trascrizione audio non è corretta, prova a selezionare la lingua audio /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Om ljudtranskriptionen är felaktig, prova att välja ljudspråket /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Wenn die Audiotranskription nicht korrekt ist, versuchen Sie, die Audiosprache /audio_language auszuwählen" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Jeśli transkrypcja dźwięku jest nieprawidłowa, spróbuj wybrać język dźwięku /audio_language" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.audios.languageWarning", "Ses dökümü yanlışsa, ses dilini /audio_language seçmeyi deneyin" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}\n\nМова аудіо транскрипції: {2}\n\nМова інтерфейсу: {3}\n\nПоказувати значення англійських слів - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Ваши языки</b>\nОсновной язык: {0}\nЦелевой язык: {1}\n\nЯзык аудио транскрипции: {2}\n\nЯзык интерфейса: {3}\n\nПоказывать значение английских слов - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Your languages</b>\nMain Language: {0}\nTarget Language: {1}\n\nAudio transcription language: {2}\n\nYour interface language: {3}\n\nShow english words meaning - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 439,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}\n\nIdioma de transcripción de audio: {2}\n\nTu idioma de interfaz: {3}\n\nMostrar el significado de las palabras en inglés - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 440,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}\n\nLangue de transcription audio: {2}\n\nLa langue de votre interface: {3}\n\nAfficher le sens des mots anglais - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}\n\n音声転写言語: {2}\n\nインターフェース言語: {3}\n\n英単語の意味を表示 - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}\n\n音频转录语言：{2}\n\n界面语言： {3}\n\n显示英文单词的意思 - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}\n\nJazyk zvukového přepisu: {2}\n\nVáš jazyk rozhraní: {3}\n\nZobrazit význam anglických slov - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}\n\nLydtransskriptionssprog: {2}\n\nDit grænsefladesprog: {3}\n\nVis engelske ords betydning - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}\n\nऑडियो ट्रांसक्रिप्शन भाषा: {2}\n\nअंतरफलक भाषा: {3}\n\nअंग्रेजी शब्दों का अर्थ दिखाएँ - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}\n\nLingua di trascrizione audio: {2}\n\nLa lingua dell'interfaccia: {3}\n\nMostra il significato delle parole inglesi - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 447,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}\n\nSpråk för ljudtranskription: {2}\n\nDitt gränssnittsspråk: {3}\n\nVisa engelska ords betydelse - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 448,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}\n\nSprache der Audiotranskription: {2}\n\nIhre Oberflächensprache: {3}\n\nVisa engelska ords betydelse - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 449,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}\n\nJęzyk transkrypcji dźwięku: {2}\n\nTwój język interfejsu: {3}\n\nPokaż znaczenie angielskich słów - {4}" });

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 450,
                columns: new[] { "Key", "Translate" },
                values: new object[] { "app.menu.userInfo", "<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}\n\nSes transkripsiyon dili: {2}\n\nArayüz diliniz: {3}\n\nİngilizce kelimelerin anlamını göster - {4}" });
        }
    }
}
