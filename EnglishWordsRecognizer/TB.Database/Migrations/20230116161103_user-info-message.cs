using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class userinfomessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 5,
                column: "Translate",
                value: "La langue de votre interface:");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 16,
                column: "Translate",
                value: "Мови були встановлені.\n\n<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\nНадішліть /interface_language, щоб змінити мову інтерфейсу\n\n<b>Надішліть фотографії та отримайте </b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- Аудіо транскрипцію\n\n<b>Бот підтримує «відповіді» та «пересилання» повідомлень.</b>\n\n<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 17,
                column: "Translate",
                value: "Языки были установлены.\n\n<b>Возможности бота</b>\n\nОтправьте текст для автоматического перевода на выбранный язык.\n\nОтправьте /meaning_english, чтобы показывать английское значение и синоними.\nОтправьте /interface_language, чтобы изменить язык интерфейса\n\n<b>Отправьте фотографии и получите </b>\n- Текст с фото\n- Все объекты с фото с переводом\n- Краткое описание фото, если возможно\n\n<b>Отправьте аудио и получите</b>\n- Аудио транскрипцию\n\n<b>Бот поддерживает 'ответы' и 'пересылки' сообщений.</b>\n\n<b>Ваши языки</b>\nОсновной язык: {0}\nЦелевой язык: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 18,
                column: "Translate",
                value: "The languages were established.\n\n<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nSend /meaning_english to enable show English meaning and synonyms for the words.\nSend /interface_language to change the interface language\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audio\n\n<b>Bot support 'replies' and 'forwards' messages.</b>\n\n<b>Your languages</b>\nMain Language: {0}\nTarget Language: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 19,
                column: "Translate",
                value: "Se han establecido las lenguas.\n\n<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\nEnvía /interface_language para cambiar el idioma de la interfaz\n\n<b>Envíe fotos y obtenga </b>\n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- La transcripción del audio\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>\n\nb>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 20,
                column: "Translate",
                value: "Les langues ont été définies.\n\n<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\nEnvoyez /interface_language pour changer la langue de l'interface\n\n<b>Soumettez des photos et obtenez </b>\n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio\n\n<b>Le bot prend en charge les messages 'répondre' et 'transférer'.</b>\n\n<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 21,
                column: "Translate",
                value: "言語が設定されました。\n\n<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\nインターフェイス言語を変更するには、/interface_language を送信します\n\n<b>写真を送信して </b> を入手してください\n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし\n\n<b>ボットはメッセージの「返信」と「転送」をサポートします。</b>\n\n<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 22,
                column: "Translate",
                value: "设置了语言。\n\n<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n发送 /interface_language 更改界面语言\n\n<b>提交照片并获取</b>\n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录\n\n<b>Bot 支持“回复”和“转发”消息。</b>\n\n<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 23,
                column: "Translate",
                value: "Jazyky byly nastaveny.\n\n<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\nPro změnu jazyka rozhraní odešlete /interface_language\n\n<b>Odešlete fotografie a získejte</b>\n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- Zvukový přepis\n\n<b>Bot podporuje „odpovědi“ a „přeposílání“ zpráv.</b>\n\n<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 24,
                column: "Translate",
                value: "Sprog blev sat.\n\n<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\nSend /interface_language for at ændre grænsefladesproget\n\n<b>Indsend billeder og få </b>\n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- Lydtransskription\n\n<b>Bot understøtter 'svar' og 'videresendelser'-meddelelser.</b>\n\n<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 25,
                column: "Translate",
                value: "भाषाएँ निर्धारित की गईं।\n\n<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\nइंटरफ़ेस भाषा बदलने के लिए /interface_language भेजें\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें</b>\n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन\n\n<b>बॉट 'जवाब' और 'फॉरवर्ड' संदेशों का समर्थन करता है।</b>\n\n<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 26,
                column: "Translate",
                value: "Le lingue sono state impostate.\n\n<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\nInvia /interface_language per cambiare la lingua dell'interfaccia\n\n<b>Invia foto e ottieni </b>\n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- Trascrizione audio\n\n<b>Il bot supporta i messaggi di 'risposta' e 'inoltro'.</b>\n\n<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 27,
                column: "Translate",
                value: "Språk sattes.\n\n<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\nSkicka /interface_language för att ändra gränssnittsspråket\n\n<b>Skicka in foton och få </b>\n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- Ljudtranskription\n\n<b>Bot stöder 'svar' och 'vidarebefordrar' meddelanden.</b>\n\n<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 28,
                column: "Translate",
                value: "Sprachen wurden eingestellt.\n\n<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\nSenden Sie /interface_language, um die Sprache der Benutzeroberfläche zu ändern\n\n<b>Senden Sie Fotos und erhalten Sie</b>\n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten\n\n<b>Bot unterstützt 'Antworten' und 'Weiterleiten' von Nachrichten.</b>\n\n<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 29,
                column: "Translate",
                value: "Ustawiono języki.\n\n<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\nWyślij /interface_language, aby zmienić język interfejsu\n\n<b>Prześlij zdjęcia i uzyskaj </b>\n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- Transkrypcję dźwięku\n\n<b>Bot obsługuje 'odpowiedzi' i 'przekazuje dalej' wiadomości.</b>\n\n<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 30,
                column: "Translate",
                value: "Diller ayarlandı.\n\n<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\nArayüz dilini değiştirmek için /interface_language gönderin\n\n<b>Fotoğraf gönderin ve </b>\n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- Sesli transkripsiyonu alın\n\n<b>Bot desteği 'yanıtlar' ve 'iletilen' mesajlar.</b>\n\n<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 181,
                column: "Translate",
                value: "<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\nНадішліть /interface_language, щоб змінити мову інтерфейсу\n\n<b>Надішліть фотографії та отримайте </b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- Аудіо транскрипцію\n\n<b>Бот підтримує «відповіді» та «пересилання» повідомлень.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 182,
                column: "Translate",
                value: "<b>Возможности бота</b>\n\nОтправьте текст для автоматического перевода на выбранный язык.\n\nОтправьте /meaning_english, чтобы показывать английское значение и синоними.\nОтправьте /interface_language, чтобы изменить язык интерфейса\n\n<b>Отправьте фотографии и получите </b>\n- Текст с фото\n- Все объекты с фото с переводом\n- Краткое описание фото, если возможно\n\n<b>Отправьте аудио и получите</b>\n- Аудио транскрипцию\n\n<b>Бот поддерживает 'ответы' и 'пересылки' сообщений.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 183,
                column: "Translate",
                value: "<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nSend /meaning_english to enable show English meaning and synonyms for the words.\nSend /interface_language to change the interface language\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audio\n\n<b>Bot support 'replies' and 'forwards' messages.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 184,
                column: "Translate",
                value: "<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\nEnvía /interface_language para cambiar el idioma de la interfaz\n\n<b>Envíe fotos y obtenga </b>\n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- La transcripción del audio\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 185,
                column: "Translate",
                value: "<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\nEnvoyez /interface_language pour changer la langue de l'interface\n\n<b>Soumettez des photos et obtenez </b>\n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio\n\n<b>Le bot prend en charge les messages 'répondre' et 'transférer'.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 186,
                column: "Translate",
                value: "<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\nインターフェイス言語を変更するには、/interface_language を送信します\n\n<b>写真を送信して </b> を入手してください\n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし\n\n<b>ボットはメッセージの「返信」と「転送」をサポートします。</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 187,
                column: "Translate",
                value: "<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n发送 /interface_language 更改界面语言\n\n<b>提交照片并获取</b>\n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录\n\n<b>Bot 支持“回复”和“转发”消息。</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 188,
                column: "Translate",
                value: "<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\nPro změnu jazyka rozhraní odešlete /interface_language\n\n<b>Odešlete fotografie a získejte</b>\n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- Zvukový přepis\n\n<b>Bot podporuje „odpovědi“ a „přeposílání“ zpráv.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 189,
                column: "Translate",
                value: "<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\nSend /interface_language for at ændre grænsefladesproget\n\n<b>Indsend billeder og få </b>\n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- Lydtransskription\n\n<b>Bot understøtter 'svar' og 'videresendelser'-meddelelser.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 190,
                column: "Translate",
                value: "<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\nइंटरफ़ेस भाषा बदलने के लिए /interface_language भेजें\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें</b>\n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन\n\n<b>बॉट 'जवाब' और 'फॉरवर्ड' संदेशों का समर्थन करता है।</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 191,
                column: "Translate",
                value: "<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\nInvia /interface_language per cambiare la lingua dell'interfaccia\n\n<b>Invia foto e ottieni </b>\n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- Trascrizione audio\n\n<b>Il bot supporta i messaggi di 'risposta' e 'inoltro'.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 192,
                column: "Translate",
                value: "<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\nSkicka /interface_language för att ändra gränssnittsspråket\n\n<b>Skicka in foton och få </b>\n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- Ljudtranskription\n\n<b>Bot stöder 'svar' och 'vidarebefordrar' meddelanden.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 193,
                column: "Translate",
                value: "<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\nSenden Sie /interface_language, um die Sprache der Benutzeroberfläche zu ändern\n\n<b>Senden Sie Fotos und erhalten Sie</b>\n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten\n\n<b>Bot unterstützt 'Antworten' und 'Weiterleiten' von Nachrichten.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 194,
                column: "Translate",
                value: "<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\nWyślij /interface_language, aby zmienić język interfejsu\n\n<b>Prześlij zdjęcia i uzyskaj </b>\n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- Transkrypcję dźwięku\n\n<b>Bot obsługuje 'odpowiedzi' i 'przekazuje dalej' wiadomości.</b>");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 195,
                column: "Translate",
                value: "<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\nArayüz dilini değiştirmek için /interface_language gönderin\n\n<b>Fotoğraf gönderin ve </b>\n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- Sesli transkripsiyonu alın\n\n<b>Bot desteği 'yanıtlar' ve 'iletilen' mesajlar.</b>");

            migrationBuilder.InsertData(
                schema: "app",
                table: "Translation",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 436, "app.menu.userInfo", 1, "<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}\n\nМова аудіо транскрипції: {2}\n\nМова інтерфейсу: {3}\n\nПоказувати значення англійських слів - {4}" },
                    { 437, "app.menu.userInfo", 2, "<b>Ваши языки</b>\nОсновной язык: {0}\nЦелевой язык: {1}\n\nЯзык аудио транскрипции: {2}\n\nЯзык интерфейса: {3}\n\nПоказывать значение английских слов - {4}" },
                    { 438, "app.menu.userInfo", 3, "<b>Your languages</b>\nMain Language: {0}\nTarget Language: {1}\n\nAudio transcription language: {2}\n\nYour interface language: {3}\n\nShow english words meaning - {4}" },
                    { 439, "app.menu.userInfo", 4, "b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}\n\nIdioma de transcripción de audio: {2}\n\nTu idioma de interfaz: {3}\n\nMostrar el significado de las palabras en inglés - {4}" },
                    { 440, "app.menu.userInfo", 5, "<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}\n\nLangue de transcription audio: {2}\n\nLa langue de votre interface: {3}\n\nAfficher le sens des mots anglais - {4}" },
                    { 441, "app.menu.userInfo", 6, "<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}\n\n音声転写言語: {2}\n\nインターフェース言語: {3}\n\n英単語の意味を表示 - {4}" },
                    { 442, "app.menu.userInfo", 7, "<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}\n\n音频转录语言：{2}\n\n界面语言： {3}\n\n显示英文单词的意思 - {4}" },
                    { 443, "app.menu.userInfo", 8, "<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}\n\nJazyk zvukového přepisu: {2}\n\nVáš jazyk rozhraní: {3}\n\nZobrazit význam anglických slov - {4}" },
                    { 444, "app.menu.userInfo", 9, "<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}\n\nLydtransskriptionssprog: {2}\n\nDit grænsefladesprog: {3}\n\nVis engelske ords betydning - {4}" },
                    { 445, "app.menu.userInfo", 10, "<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}\n\nऑडियो ट्रांसक्रिप्शन भाषा: {2}\n\nअंतरफलक भाषा: {3}\n\nअंग्रेजी शब्दों का अर्थ दिखाएँ - {4}" },
                    { 446, "app.menu.userInfo", 11, "<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}\n\nLingua di trascrizione audio: {2}\n\nLa lingua dell'interfaccia: {3}\n\nMostra il significato delle parole inglesi - {4}" },
                    { 447, "app.menu.userInfo", 12, "<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}\n\nSpråk för ljudtranskription: {2}\n\nDitt gränssnittsspråk: {3}\n\nVisa engelska ords betydelse - {4}" },
                    { 448, "app.menu.userInfo", 13, "<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}\n\nSprache der Audiotranskription: {2}\n\nIhre Oberflächensprache: {3}\n\nVisa engelska ords betydelse - {4}" },
                    { 449, "app.menu.userInfo", 14, "<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}\n\nJęzyk transkrypcji dźwięku: {2}\n\nTwój język interfejsu: {3}\n\nPokaż znaczenie angielskich słów - {4}" },
                    { 450, "app.menu.userInfo", 15, "<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}\n\nSes transkripsiyon dili: {2}\n\nArayüz diliniz: {3}\n\nİngilizce kelimelerin anlamını göster - {4}" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 5,
                column: "Translate",
                value: "La langue de votre interface :");

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
                keyValue: 17,
                column: "Translate",
                value: "Языки были установлены.\n\n<b>Возможности бота</b>\n\nОтправьте текст для автоматического перевода на выбранный язык.\n\nОтправьте /meaning_english, чтобы показывать английское значение и синоними.\n\n<b>Отправьте фотографии и получите </b>\n- Текст с фото\n- Все объекты с фото с переводом\n- Краткое описание фото, если возможно\n\n<b>Отправьте аудио и получите</b>\n- аудио транскрипцию\n\n<b>Ваши языки</b>\nОсновной язык: {0}\nЦелевой язык: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 18,
                column: "Translate",
                value: "The languages were established.\n\n<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nUse /meaning_english to enable show English meaning and synonyms for the words.\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audio\n\n<b>Your languages</b>\nMain Language: {0}\nTarget Language: {1}");

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
        }
    }
}
