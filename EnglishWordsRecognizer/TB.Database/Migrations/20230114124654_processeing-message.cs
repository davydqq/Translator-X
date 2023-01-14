using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class processeingmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 181,
                column: "Translate",
                value: "<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\n\n<b>Надішліть фотографії та отримайте </b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- аудіо транскрипцію");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 182,
                column: "Translate",
                value: "<b>Возможности бота</b>\n\nОтправьте текст для автоматического перевода на выбранный язык.\n\nОтправьте /meaning_english, чтобы показывать английское значение и синоними.\n\n<b>Отправьте фотографии и получите </b>\n- Текст с фото\n- Все объекты с фото с переводом\n- Краткое описание фото, если возможно\n\n<b>Отправьте аудио и получите</b>\n- аудио транскрипцию");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 183,
                column: "Translate",
                value: "<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nUse /meaning_english to enable show English meaning and synonyms for the words.\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audio");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 184,
                column: "Translate",
                value: "<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\n\n<b>Envíe fotos y obtenga </b> \n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- la transcripción del audio");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 185,
                column: "Translate",
                value: "<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\n\n<b>Soumettez des photos et obtenez </b> \n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 186,
                column: "Translate",
                value: "<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\n\n<b>写真を送信して </b> を入手してください> \n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 187,
                column: "Translate",
                value: "<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n\n<b>提交照片并获取 </b> \n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 188,
                column: "Translate",
                value: "<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\n\n<b>Odešlete fotografie a získejte</b> \n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- zvukový přepis");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 189,
                column: "Translate",
                value: "<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\n\n<b>Indsend billeder og få </b> \n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- lydtransskription");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 190,
                column: "Translate",
                value: "<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें </b> \n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 191,
                column: "Translate",
                value: "<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\n\n<b>Invia foto e ottieni </b> \n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- trascrizione audio");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 192,
                column: "Translate",
                value: "<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\n\n<b>Skicka in foton och få </b> \n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- ljudtranskription");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 193,
                column: "Translate",
                value: "<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\n\n<b>Senden Sie Fotos und erhalten Sie </b> \n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 194,
                column: "Translate",
                value: "<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\n\n<b>Prześlij zdjęcia i uzyskaj </b> \n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- transkrypcję dźwięku");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 195,
                column: "Translate",
                value: "<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\n\n<b>Fotoğraf gönderin ve </b> \n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- sesli transkripsiyonu alın");

            migrationBuilder.InsertData(
                schema: "app",
                table: "Translation",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 406, "app.content.processing", 1, "Взято на обробку, будь ласка, зачекайте хвилинку. 😌" },
                    { 407, "app.content.processing", 2, "Взято на обработку, пожалуйста, подождите немного. 😌" },
                    { 408, "app.content.processing", 3, "Taken for processing, please wait a moment. 😌" },
                    { 409, "app.content.processing", 4, "Tomado para procesar, por favor espere un momento. 😌" },
                    { 410, "app.content.processing", 5, "Pris pour traitement, veuillez patienter un moment. 😌" },
                    { 411, "app.content.processing", 6, "処理に時間がかかっています、しばらくお待ちください。😌" },
                    { 412, "app.content.processing", 7, "正在处理中，请稍等片刻。😌" },
                    { 413, "app.content.processing", 8, "Převzato ke zpracování, chvíli prosím počkejte. 😌" },
                    { 414, "app.content.processing", 9, "Optaget til behandling, vent venligst et øjeblik. 😌" },
                    { 415, "app.content.processing", 10, "प्रसंस्करण के लिए लिया गया, कृपया एक क्षण प्रतीक्षा करें। 😌" },
                    { 416, "app.content.processing", 11, "Assunto per l'elaborazione, si prega di attendere un momento. 😌" },
                    { 417, "app.content.processing", 12, "Upptaget för behandling, vänligen vänta ett ögonblick. 😌" },
                    { 418, "app.content.processing", 13, "Zur Bearbeitung angenommen, bitte warten Sie einen Moment. 😌" },
                    { 419, "app.content.processing", 14, "Pobrane do przetworzenia, proszę chwilę poczekać. 😌" },
                    { 420, "app.content.processing", 15, "İşlem için alındı, lütfen bir dakika bekleyin. 😌" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 181,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 182,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 183,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 184,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 185,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 186,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 187,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 188,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 189,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 190,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 191,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 192,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 193,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 194,
                column: "Translate",
                value: "Info");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 195,
                column: "Translate",
                value: "Info");
        }
    }
}
