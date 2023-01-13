using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixestablishedmessage4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 16,
                column: "Translate",
                value: "Мови були встановлені.\n\n<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\n\n<b>Надішліть фотографії та отримайте </b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- аудіо транскрипцію\n\n<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 19,
                column: "Translate",
                value: "Se han establecido las lenguas.\n\n<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\n\n<b>Envíe fotos y obtenga </b> \n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- la transcripción del audio\n\n<b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 20,
                column: "Translate",
                value: "Les langues ont été définies.\n\n<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\n\n<b>Soumettez des photos et obtenez </b> \n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio\n\n<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 21,
                column: "Translate",
                value: "言語が設定されました。\n\n<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\n\n<b>写真を送信して </b> を入手してください> \n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし\n\n<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 22,
                column: "Translate",
                value: "设置了语言。\n\n<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n\n<b>提交照片并获取 </b> \n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录\n\n<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 23,
                column: "Translate",
                value: "Jazyky byly nastaveny.\n\n<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\n\n<b>Odešlete fotografie a získejte</b> \n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- zvukový přepis\n\n<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 24,
                column: "Translate",
                value: "Sprog blev sat.\n\n<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\n\n<b>Indsend billeder og få </b> \n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- lydtransskription\n\n<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 25,
                column: "Translate",
                value: "भाषाएँ निर्धारित की गईं।\n\n<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें </b> \n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन\n\n<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 26,
                column: "Translate",
                value: "Le lingue sono state impostate.\n\n<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\n\n<b>Invia foto e ottieni </b> \n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- trascrizione audio\n\n<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 27,
                column: "Translate",
                value: "Språk sattes.\n\n<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\n\n<b>Skicka in foton och få </b> \n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- ljudtranskription\n\n<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 28,
                column: "Translate",
                value: "Sprachen wurden eingestellt.\n\n<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\n\n<b>Senden Sie Fotos und erhalten Sie </b> \n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten\n\n<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 29,
                column: "Translate",
                value: "Ustawiono języki.\n\n<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\n\n<b>Prześlij zdjęcia i uzyskaj </b> \n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- transkrypcję dźwięku\n\n<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 30,
                column: "Translate",
                value: "Diller ayarlandı.\n\n<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\n\n<b>Fotoğraf gönderin ve </b> \n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- sesli transkripsiyonu alın\n\n<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 16,
                column: "Translate",
                value: "Мови були встановлені.\n\n<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\n\n<b>Надішліть фотографії та отримайте </ b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- аудіо транскрипцію\n\n<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 19,
                column: "Translate",
                value: "Se han establecido las lenguas.\n\n<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\n\n<b>Envíe fotos y obtenga </b > \n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- la transcripción del audio\n\n<b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 20,
                column: "Translate",
                value: "Les langues ont été définies.\n\n<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\n\n<b>Soumettez des photos et obtenez </b > \n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio\n\n<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 21,
                column: "Translate",
                value: "言語が設定されました。\n\n<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\n\n<b>写真を送信して </b を入手してください> \n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし\n\n<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 22,
                column: "Translate",
                value: "设置了语言。\n\n<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n\n<b>提交照片并获取 </b > \n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录\n\n<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 23,
                column: "Translate",
                value: "Jazyky byly nastaveny.\n\n<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\n\n<b>Odešlete fotografie a získejte </b > \n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- zvukový přepis\n\n<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 24,
                column: "Translate",
                value: "Sprog blev sat.\n\n<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\n\n<b>Indsend billeder og få </b > \n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- lydtransskription\n\n<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 25,
                column: "Translate",
                value: "भाषाएँ निर्धारित की गईं।\n\n<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें </b > \n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन\n\n<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 26,
                column: "Translate",
                value: "Le lingue sono state impostate.\n\n<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\n\n<b>Invia foto e ottieni </b > \n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- trascrizione audio\n\n<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 27,
                column: "Translate",
                value: "Språk sattes.\n\n<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\n\n<b>Skicka in foton och få </b > \n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- ljudtranskription\n\n<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 28,
                column: "Translate",
                value: "Sprachen wurden eingestellt.\n\n<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\n\n<b>Senden Sie Fotos und erhalten Sie </b > \n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten\n\n<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 29,
                column: "Translate",
                value: "Ustawiono języki.\n\n<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\n\n<b>Prześlij zdjęcia i uzyskaj </b > \n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- transkrypcję dźwięku\n\n<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 30,
                column: "Translate",
                value: "Diller ayarlandı.\n\n<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\n\n<b>Fotoğraf gönderin ve </b > \n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- sesli transkripsiyonu alın\n\n<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}");
        }
    }
}
