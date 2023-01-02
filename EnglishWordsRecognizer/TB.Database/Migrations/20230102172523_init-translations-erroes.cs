using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class inittranslationserroes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 301, "app.file.noSupportContent", 1, "Бот не підтримує цей тип контенту" },
                    { 302, "app.file.noSupportContent", 2, "Бот не поддерживает этот тип контента" },
                    { 303, "app.file.noSupportContent", 3, "The bot does not support this type of content" },
                    { 304, "app.file.noSupportContent", 4, "El bot no soporta este tipo de contenido." },
                    { 305, "app.file.noSupportContent", 5, "Le bot ne prend pas en charge ce type de contenu" },
                    { 306, "app.file.noSupportContent", 6, "ボットはこのタイプのコンテンツをサポートしていません" },
                    { 307, "app.file.noSupportContent", 7, "该机器人不支持此类内容" },
                    { 308, "app.file.noSupportContent", 8, "Robot tento typ obsahu nepodporuje" },
                    { 309, "app.file.noSupportContent", 9, "Botten understøtter ikke denne type indhold" },
                    { 310, "app.file.noSupportContent", 10, "बॉट इस प्रकार की सामग्री का समर्थन नहीं करता है" },
                    { 311, "app.file.noSupportContent", 11, "Il bot non supporta questo tipo di contenuto" },
                    { 312, "app.file.noSupportContent", 12, "Boten stöder inte den här typen av innehåll" },
                    { 313, "app.file.noSupportContent", 13, "Der Bot unterstützt diese Art von Inhalten nicht" },
                    { 314, "app.file.noSupportContent", 14, "Bot nie obsługuje tego typu treści" },
                    { 315, "app.file.noSupportContent", 15, "Bot bu tür içeriği desteklemiyor" },
                    { 316, "app.audio.noSupportFormat", 1, "Формат не підтримується. Використовуйте (.mp3, .ogg, .flac, .wav)" },
                    { 317, "app.audio.noSupportFormat", 2, "Не поддерживаемый формат. Используйте (.mp3, .ogg, .flac, .wav)" },
                    { 318, "app.audio.noSupportFormat", 3, "Not supported format. Use (.mp3, .ogg, .flac, .wav)" },
                    { 319, "app.audio.noSupportFormat", 4, "Formato no compatible. Usar (.mp3, .ogg, .flac, .wav)" },
                    { 320, "app.audio.noSupportFormat", 5, "Format non pris en charge. Utiliser (.mp3, .ogg, .flac, .wav)" },
                    { 321, "app.audio.noSupportFormat", 6, "サポートされていない形式です。 使用 (.mp3、.ogg、.flac、.wav)" },
                    { 322, "app.audio.noSupportFormat", 7, "不支持的格式。 使用（.mp3、.ogg、.flac、.wav）" },
                    { 323, "app.audio.noSupportFormat", 8, "Nepodporovaný formát. Použít (.mp3, .ogg, .flac, .wav)" },
                    { 324, "app.audio.noSupportFormat", 9, "Ikke understøttet format. Brug (.mp3, .ogg, .flac, .wav)" },
                    { 325, "app.audio.noSupportFormat", 10, "समर्थित प्रारूप नहीं। उपयोग करें (.mp3, .ogg, .flac, .wav)" },
                    { 326, "app.audio.noSupportFormat", 11, "Formato non supportato. Usa (.mp3, .ogg, .flac, .wav)" },
                    { 327, "app.audio.noSupportFormat", 12, "Format som inte stöds. Använd (.mp3, .ogg, .flac, .wav)" },
                    { 328, "app.audio.noSupportFormat", 13, "Nicht unterstütztes Format. Verwendung (.mp3, .ogg, .flac, .wav)" },
                    { 329, "app.audio.noSupportFormat", 14, "Nieobsługiwany format. Użyj (.mp3, .ogg, .flac, .wav)" },
                    { 330, "app.audio.noSupportFormat", 15, "Desteklenmeyen biçim. (.mp3, .ogg, .flac, .wav) kullanın" },
                    { 331, "app.audio.cantProcess", 1, "Не вдається обробити це аудіо, спробуйте інше." },
                    { 332, "app.audio.cantProcess", 2, "Не удается обработать этот звук, попробуйте другой." },
                    { 333, "app.audio.cantProcess", 3, "Can't process this audio try another one." },
                    { 334, "app.audio.cantProcess", 4, "No se puede procesar este audio, prueba con otro." },
                    { 335, "app.audio.cantProcess", 5, "Impossible de traiter cet audio, essayez-en un autre." },
                    { 336, "app.audio.cantProcess", 6, "この音声を処理できません。別の音声を試してください。" },
                    { 337, "app.audio.cantProcess", 7, "无法处理此音频，请尝试另一个。" },
                    { 338, "app.audio.cantProcess", 8, "Tento zvuk nelze zpracovat, zkuste jiný." },
                    { 339, "app.audio.cantProcess", 9, "Kan ikke behandle denne lyd prøv en anden." },
                    { 340, "app.audio.cantProcess", 10, "इस ऑडियो को प्रोसेस नहीं किया जा सकता, एक और ऑडियो आज़माएं." },
                    { 341, "app.audio.cantProcess", 11, "Impossibile elaborare questo audio, provane un altro." },
                    { 342, "app.audio.cantProcess", 12, "Det går inte att bearbeta det här ljudet, försök med ett annat." },
                    { 343, "app.audio.cantProcess", 13, "Dieses Audio kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." },
                    { 344, "app.audio.cantProcess", 14, "Nie można przetworzyć tego dźwięku, spróbuj innego." },
                    { 345, "app.audio.cantProcess", 15, "Bu ses işlenemiyor başka bir ses deneyin." },
                    { 346, "app.audio.noExceedDuration", 1, "Тривалість аудіо не повинна перевищувати 60 секунд" },
                    { 347, "app.audio.noExceedDuration", 2, "Продолжительность аудио не должна превышать 60 секунд." },
                    { 348, "app.audio.noExceedDuration", 3, "Audio duration must not exceed 60 seconds" },
                    { 349, "app.audio.noExceedDuration", 4, "La duración del audio no debe exceder los 60 segundos." },
                    { 350, "app.audio.noExceedDuration", 5, "La durée audio ne doit pas dépasser 60 secondes" },
                    { 351, "app.audio.noExceedDuration", 6, "音声の長さは 60 秒を超えてはなりません" },
                    { 352, "app.audio.noExceedDuration", 7, "音频时长不得超过 60 秒" },
                    { 353, "app.audio.noExceedDuration", 8, "Délka zvuku nesmí přesáhnout 60 sekund" },
                    { 354, "app.audio.noExceedDuration", 9, "Lydens varighed må ikke overstige 60 sekunder" },
                    { 355, "app.audio.noExceedDuration", 10, "ऑडियो की अवधि 60 सेकंड से अधिक नहीं होनी चाहिए" },
                    { 356, "app.audio.noExceedDuration", 11, "La durata dell'audio non deve superare i 60 secondi" },
                    { 357, "app.audio.noExceedDuration", 12, "Ljudlängden får inte överstiga 60 sekunder" },
                    { 358, "app.audio.noExceedDuration", 13, "Die Audiodauer darf 60 Sekunden nicht überschreiten" },
                    { 359, "app.audio.noExceedDuration", 14, "Czas trwania dźwięku nie może przekraczać 60 sekund" },
                    { 360, "app.audio.noExceedDuration", 15, "Ses süresi 60 saniyeyi geçmemelidir" },
                    { 361, "app.photo.noSupportFormat", 1, "Формат не підтримується. Використовуйте (.png, .jpeg, .jpg)" },
                    { 362, "app.photo.noSupportFormat", 2, "Не поддерживаемый формат. Использовать (.png, .jpeg, .jpg)" },
                    { 363, "app.photo.noSupportFormat", 3, "Not supported format. Use (.png, .jpeg, .jpg)" },
                    { 364, "app.photo.noSupportFormat", 4, "Formato no compatible. Usar (.png, .jpeg, .jpg)" },
                    { 365, "app.photo.noSupportFormat", 5, "Format non pris en charge. Utiliser (.png, .jpeg, .jpg)" },
                    { 366, "app.photo.noSupportFormat", 6, "サポートされていない形式です。 使用 (.png、.jpeg、.jpg)" },
                    { 367, "app.photo.noSupportFormat", 7, "不支持的格式。 使用（.png、.jpeg、.jpg）" },
                    { 368, "app.photo.noSupportFormat", 8, "Nepodporovaný formát. Použít (.png, .jpeg, .jpg)" },
                    { 369, "app.photo.noSupportFormat", 9, "Ikke understøttet format. Brug (.png, .jpeg, .jpg)" },
                    { 370, "app.photo.noSupportFormat", 10, "समर्थित प्रारूप नहीं। (.पीएनजी, .जेपीईजी, .जेपीजी) का प्रयोग करें" },
                    { 371, "app.photo.noSupportFormat", 11, "Formato non supportato. Usa (.png, .jpeg, .jpg)" },
                    { 372, "app.photo.noSupportFormat", 12, "Format som inte stöds. Använd (.png, .jpeg, .jpg)" },
                    { 373, "app.photo.noSupportFormat", 13, "Nicht unterstütztes Format. Verwenden Sie (.png, .jpeg, .jpg)" },
                    { 374, "app.photo.noSupportFormat", 14, "Nieobsługiwany format. Użyj (.png, .jpeg, .jpg)" },
                    { 375, "app.photo.noSupportFormat", 15, "Desteklenmeyen biçim. (.png, .jpeg, .jpg) kullanın" },
                    { 376, "app.photo.cantProcess", 1, "Не вдається обробити цю фотографію, спробуйте іншу." },
                    { 377, "app.photo.cantProcess", 2, "Не удается обработать это фото. Попробуйте другое." },
                    { 378, "app.photo.cantProcess", 3, "Can't process this photo try another one." },
                    { 379, "app.photo.cantProcess", 4, "No se puede procesar esta foto, prueba con otra." },
                    { 380, "app.photo.cantProcess", 5, "Impossible de traiter cette photo, essayez-en une autre." },
                    { 381, "app.photo.cantProcess", 6, "この写真を処理できません。別の写真を試してください。" },
                    { 382, "app.photo.cantProcess", 7, "无法处理这张照片，请尝试另一张。" },
                    { 383, "app.photo.cantProcess", 8, "Tuto fotografii nelze zpracovat, zkuste jinou." },
                    { 384, "app.photo.cantProcess", 9, "Kan ikke behandle dette billede prøv et andet." },
                    { 385, "app.photo.cantProcess", 10, "इस फ़ोटो को प्रोसेस नहीं किया जा सकता, कोई और फ़ोटो आज़माएं." },
                    { 386, "app.photo.cantProcess", 11, "Impossibile elaborare questa foto, provane un'altra." },
                    { 387, "app.photo.cantProcess", 12, "Det går inte att bearbeta det här fotot, försök med ett annat." },
                    { 388, "app.photo.cantProcess", 13, "Dieses Foto kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." },
                    { 389, "app.photo.cantProcess", 14, "Nie można przetworzyć tego zdjęcia, spróbuj innego." },
                    { 390, "app.photo.cantProcess", 15, "Bu fotoğraf işlenemiyor başka bir fotoğraf deneyin." },
                    { 391, "app.photo.tooLargeFile", 1, "Занадто великий файл. Використовуйте фото до 4 Мб" },
                    { 392, "app.photo.tooLargeFile", 2, "Слишком большой файл. Используйте фото до 4 МБ" },
                    { 393, "app.photo.tooLargeFile", 3, "Too large a file. Use photo up to 4 MB" },
                    { 394, "app.photo.tooLargeFile", 4, "Un archivo demasiado grande. Usar foto de hasta 4 MB" },
                    { 395, "app.photo.tooLargeFile", 5, "Fichier trop volumineux. Utiliser une photo jusqu'à 4 Mo" },
                    { 396, "app.photo.tooLargeFile", 6, "ファイルが大きすぎます。 4 MB までの写真を使用" },
                    { 397, "app.photo.tooLargeFile", 7, "文件太大。 使用最大 4 MB 的照片" },
                    { 398, "app.photo.tooLargeFile", 8, "Příliš velký soubor. Použijte fotografii do velikosti 4 MB" },
                    { 399, "app.photo.tooLargeFile", 9, "For stor fil. Brug foto op til 4 MB" },
                    { 400, "app.photo.tooLargeFile", 10, "फ़ाइल बहुत बड़ी है. 4 एमबी तक फोटो का प्रयोग करें" },
                    { 401, "app.photo.tooLargeFile", 11, "Un file troppo grande. Usa foto fino a 4 MB" },
                    { 402, "app.photo.tooLargeFile", 12, "För stor fil. Använd foto upp till 4 MB" },
                    { 403, "app.photo.tooLargeFile", 13, "Eine zu große Datei. Verwenden Sie Fotos bis zu 4 MB" },
                    { 404, "app.photo.tooLargeFile", 14, "Zbyt duży plik. Użyj zdjęcia do 4 MB" },
                    { 405, "app.photo.tooLargeFile", 15, "Çok büyük bir dosya. 4 MB'a kadar fotoğraf kullan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 405);
        }
    }
}
