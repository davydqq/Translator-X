using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;
using TB.Database.Entities.Requests;
using TB.Database.Entities.Users;
using TB.Database.Initing;

namespace TB.Database;

public class TBDatabaseContext : DbContext
{
    public TBDatabaseContext(DbContextOptions<TBDatabaseContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<TelegramUser> Users { get; set; }

    public DbSet<UserRole> UserRoles { set; get; }

    public DbSet<Role> Roles { set; get; }


    public DbSet<Language> Languages { set; get; }

    public DbSet<UserSettings> UserSettings { set; get; }

    public DbSet<Translation> Translations { set; get; }

    public DbSet<Plan> Plans { set; get; }

    // Requests
    public DbSet<BaseRequest> BasePayableRequests { set; get; }

    public DbSet<TextRequest> TextRequests { set; get; }

    public DbSet<ImageRequest> ImageRequests { set; get; }

    public DbSet<AudioRequest> AudioRequests { set; get; }

    public DbSet<TextRequestType> TextRequestTypes { set; get; }

    public DbSet<ImageRequestType> ImageRequestTypes { set; get; }

    public DbSet<AudioRequestType> AudioRequestTypes { set; get; }

    public DbSet<ApiType> ApiTypes { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>()
            .HasMany(m => m.UserSettingsNativeLangs)
            .WithOne(t => t.NativeLanguage)
            .HasForeignKey(m => m.NativeLanguageId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        modelBuilder.Entity<Language>()
            .HasMany(m => m.UserSettingsTargetLangs)
            .WithOne(t => t.TargetLanguage)
            .HasForeignKey(m => m.TargetLanguageId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);


        modelBuilder.Entity<Language>()
            .HasMany(m => m.UserSettingsInterfaceLangs)
            .WithOne(t => t.InterfaceLanguage)
            .HasForeignKey(m => m.InterfaceLanguageId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        modelBuilder.Entity<Language>()
            .HasMany(m => m.UserSettingsAudioLangs)
            .WithOne(t => t.AudioLanguage)
            .HasForeignKey(m => m.AudioLanguageId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        modelBuilder.Entity<TextRequestType>().HasData(
                new TextRequestType { Id = TextRequestTypeENUM.Translate, Name = nameof(TextRequestTypeENUM.Translate) },
                new TextRequestType { Id = TextRequestTypeENUM.DetectLanguage, Name = nameof(TextRequestTypeENUM.DetectLanguage) },
                new TextRequestType { Id = TextRequestTypeENUM.Synonyms, Name = nameof(TextRequestTypeENUM.Synonyms) },
                new TextRequestType { Id = TextRequestTypeENUM.Meaning, Name = nameof(TextRequestTypeENUM.Meaning) }
            );

        modelBuilder.Entity<ImageRequestType>().HasData(
                new ImageRequestType { Id = ImageRequestTypeENUM.OCR, Name = nameof(ImageRequestTypeENUM.OCR) },
                new ImageRequestType { Id = ImageRequestTypeENUM.ImageAnalysis, Name = nameof(ImageRequestTypeENUM.ImageAnalysis) }
            );

        modelBuilder.Entity<AudioRequestType>().HasData(
                new AudioRequestType { Id = AudioRequestTypeENUM.Transcription, Name = nameof(AudioRequestTypeENUM.Transcription) }
            );

        modelBuilder.Entity<ApiType>().HasData(
            new ApiType { Id = ApiTypeENUM.Google, Name = nameof(ApiTypeENUM.Google) },
            new ApiType { Id = ApiTypeENUM.Azure, Name = nameof(ApiTypeENUM.Azure) },
            new ApiType { Id = ApiTypeENUM.Cambridge, Name = nameof(ApiTypeENUM.Cambridge) },
            new ApiType { Id = ApiTypeENUM.Thesaurus, Name = nameof(ApiTypeENUM.Thesaurus) }
        );

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = RoleENUM.User, Name = nameof(RoleENUM.User) },
            new Role { Id = RoleENUM.Admin, Name = nameof(RoleENUM.Admin) }
        );

        modelBuilder.Entity<Plan>().HasData(
            new Plan
            {
                Id = PlanENUM.Standart,
                Name = "Standart",
                Price = 0,
                IsCustomPlan = false,
                MaxAnalysisPhotoCountMonth = 30,
                MaxAudioTranscriptionSecondsMonth = 300,
                MaxTranslateCharsMonth = 10000,
                Priority = 1000,
            },
            new Plan
            {
                Id = PlanENUM.Premium,
                Name = "Premium",
                Price = 3.00,
                IsCustomPlan = false,
                MaxAnalysisPhotoCountMonth = 150,
                MaxAudioTranscriptionSecondsMonth = 900,
                MaxTranslateCharsMonth = 50000,
                Priority = 999,
            },
            new Plan
            {
                Id = PlanENUM.PremiumPlus,
                Name = "Premium +",
                Price = 11.00,
                IsCustomPlan = false,
                MaxAnalysisPhotoCountMonth = 500,
                MaxAudioTranscriptionSecondsMonth = 5000,
                MaxTranslateCharsMonth = 200000,
                Priority = 998,
            },
            new Plan
            {
                Id = PlanENUM.Unlimit,
                Name = "Unlimit",
                Price = int.MaxValue,
                IsCustomPlan = true,
                MaxAudioTranscriptionSecondsMonth = int.MaxValue,
                MaxAnalysisPhotoCountMonth = int.MaxValue,
                MaxTranslateCharsMonth = int.MaxValue,
                Priority = 1,
            }
        );

        modelBuilder.Entity<UserRole>()
            .HasKey(bc => new { bc.RoleId, bc.TelegramUserId });
        modelBuilder.Entity<UserRole>()
            .HasOne(bc => bc.Role)
            .WithMany(b => b.UserRoles)
            .HasForeignKey(bc => bc.RoleId);
        modelBuilder.Entity<UserRole>()
            .HasOne(bc => bc.TelegramUser)
            .WithMany(c => c.UserRoles)
            .HasForeignKey(bc => bc.TelegramUserId);

        modelBuilder.Entity<Language>().HasData(
                new Language { 
                    Id = LanguageENUM.Ukrainian, 
                    Name = SupportedLanguages.Ukrainian, 
                    Code = "uk",
                    DisplayCode = "ua",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language
                {
                    Id = LanguageENUM.Russian,
                    Name = SupportedLanguages.Russian,
                    Code = "ru",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.English, 
                    Name = SupportedLanguages.English, 
                    Code = "en",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language
                {
                    Id = LanguageENUM.Spanish,
                    Name = SupportedLanguages.Spanish,
                    Code = "es",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.French, 
                    Name = SupportedLanguages.French, 
                    Code = "fr",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Japanese, 
                    Name = SupportedLanguages.Japanese, 
                    Code = "ja",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Chinese, 
                    Name = SupportedLanguages.Chinese, 
                    Code = "zh-Hans",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Czech, 
                    Name = SupportedLanguages.Czech, 
                    Code = "cs",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Danish, 
                    Name = SupportedLanguages.Danish, 
                    Code = "da",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Hindi, 
                    Name = SupportedLanguages.Hindi, 
                    Code = "hi",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Italian, 
                    Name = SupportedLanguages.Italian, 
                    Code = "it",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Swedish, 
                    Name = SupportedLanguages.Swedish, 
                    Code = "sv",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.German, 
                    Name = SupportedLanguages.German, 
                    Code = "de",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Polish, 
                    Name = SupportedLanguages.Polish, 
                    Code = "pl",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                },
                new Language { 
                    Id = LanguageENUM.Turkish, 
                    Name = SupportedLanguages.Turkish, 
                    Code = "tr",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                    IsSupportAudioTranscription = true,
                }
            );

        InitTranslations(modelBuilder);
    }

    private void InitTranslations(ModelBuilder modelBuilder)
    {
        // CALLBACKS
        var interfaceKey = "app.languages.interfaceLanguage";
        var audioLanguageKey = "app.languages.audioLanguageKey";
        var audioResendKey = "app.languages.audioResendKey";

        var languagesSettedKey = "app.languages.established";

        // IMAGES
        var textImageKey = "app.images.text";
        var descriptionImageKey = "app.images.description";
        var objectsImageKey = "app.images.objects";

        // TEXTS
        var textMaybeMeanKey = "app.texts.maybeMean";

        // Audios
        var audioText = "app.audios.audioText";
        var audioLanguageWarning = "app.audios.languageWarning";

        // Contents
        var contentInProcessing = "app.content.processing";

        // MENU
        var menuChooseNativeKey = "app.menu.chooseNative";
        var menuChooseTargetKey = "app.menu.chooseTarget";
        var menuEnglishMeaningKey = "app.menu.englishMeaning";
        var menuDisable = "app.menu.disabled";
        var menuActivated = "app.menu.activated";
        var menuChooseLang = "app.menu.chooseLang";
        var menuInfoKey = "app.menu.info";
        var menuAudioLangKey = "app.menu.audioLang";

        // validation
        var fileNoSupportContentTypeKey = "app.file.noSupportContent";

        var audioNoSupportFormatKey = "app.audio.noSupportFormat";
        var audioCantProcess = "app.audio.cantProcess";
        var audioExceedDurationKey = "app.audio.noExceedDuration";
        var audioEmptyResult = "app.audio.EmptyResult";

        var photoNoSupportFormatKey = "app.photo.noSupportFormat";
        var photoCantProcess = "app.photo.cantProcess";
        var photoLargeFile = "app.photo.tooLargeFile";

        var textMaxLengthKey = "app.text.maxLength";

        var billingExceedLimit = "billing.exceedLimit";

        var statsMessage = "stats.message";

        var botFeaturesEN = "<b>Bot features</b>\n\n" + 
                            "Send text for automatic translation into the selected language.\n\n" + 
                            "Send /meaning_english to enable show English meaning and synonyms for the words.\n" +
                            "Send /interface_language to change the interface language\n\n" +
                            "<b>Send photos and receive</b>\n" + 
                            "- Text from photos\n" + 
                            "- All objects from the photo with translations\n" + 
                            "- Short description of the photo if possible\n\n" + 
                            "<b>Send audio and receive</b>\n" + 
                            "- Transcription of the audio" +
                            "\n\n<b>Bot support 'replies' and 'forwards' messages.</b>";

        var botFeaturesUA = "<b>Можливості бота</b>\n\n" + 
                            "Надішліть текст для автоматичного перекладу на вибрану мову.\n\n" + 
                            "Надішліть /meaning_english, щоб показувати англійське значення та синоніми.\n" +
                            "Надішліть /interface_language, щоб змінити мову інтерфейсу\n\n" +
                            "<b>Надішліть фотографії та отримайте </b>\n" + 
                            "- Текст з фото\n" + 
                            "- Всі об'єкти з фото з перекладом\n" + 
                            "- Короткий опис фото, якщо можливо\n\n" + 
                            "<b>Надішліть аудіо та отримайте</b>\n" + 
                            "- Аудіо транскрипцію" +
                            "\n\n<b>Бот підтримує «відповіді» та «пересилання» повідомлень.</b>";

        var botFeaturesRU = "<b>Возможности бота</b>\n\n" + 
                            "Отправьте текст для автоматического перевода на выбранный язык.\n\n" + 
                            "Отправьте /meaning_english, чтобы показывать английское значение и синоними.\n" +
                            "Отправьте /interface_language, чтобы изменить язык интерфейса\n\n" +
                            "<b>Отправьте фотографии и получите </b>\n" + 
                            "- Текст с фото\n" + 
                            "- Все объекты с фото с переводом\n" + 
                            "- Краткое описание фото, если возможно\n\n" + 
                            "<b>Отправьте аудио и получите</b>\n" + 
                            "- Аудио транскрипцию" +
                            "\n\n<b>Бот поддерживает 'ответы' и 'пересылки' сообщений.</b>";

        var botFeaturesSpain = "<b>Características del bot</b>\n\n" + 
                                "Envíe texto para traducción automática al idioma seleccionado.\n\n" + 
                                "Envíe /meaning_english para solicitar significado y sinónimos en inglés.\n" +
                                "Envía /interface_language para cambiar el idioma de la interfaz\n\n" +
                                "<b>Envíe fotos y obtenga </b>\n" + 
                                "- Texto con foto\n" + 
                                "- Todos los objetos con foto con traducción\n" + 
                                "- Breve descripción de la foto, si es posible\n\n" + 
                                "<b>Envíe el audio y obtenga</b>\n" + 
                                "- La transcripción del audio" +
                                "\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>";

        var botFeaturesFrench = "<b>Fonctionnalités du bot</b>\n\n" + 
                                "Soumettez le texte pour traduction automatique dans la langue sélectionnée.\n\n" + 
                                "Soumettez /meaning_english pour demander la signification et les synonymes en anglais.\n" +
                                "Envoyez /interface_language pour changer la langue de l'interface\n\n" +
                                "<b>Soumettez des photos et obtenez </b>\n" + 
                                "- Texte avec photo\n" + 
                                "- Tous les objets avec photo avec traduction\n" + 
                                "- Brève description de la photo, si possible\n\n" + 
                                "<b>Soumettre l'audio et obtenir</b>\n" + 
                                "- Transcription audio" +
                                "\n\n<b>Le bot prend en charge les messages 'répondre' et 'transférer'.</b>";

        var botFeaturesJapanese = "<b>ボットの機能</b>\n\n" + 
                                  "テキストを送信して、選択した言語に自動翻訳します。\n\n" + 
                                  "/meaning_english を送信して、英語の意味と同義語を求めます。\n" +
                                  "インターフェイス言語を変更するには、/interface_language を送信します\n\n" +
                                  "<b>写真を送信して </b> を入手してください\n" + 
                                  "- 写真付きテキスト\n" + 
                                  "- 写真付きのすべてのオブジェクトと翻訳\n" + 
                                  "- 可能であれば、写真の簡単な説明\n\n" + 
                                  "<b>音声を送信して取得</b>\n" + 
                                  "- 音声文字起こし" +
                                  "\n\n<b>ボットはメッセージの「返信」と「転送」をサポートします。</b>";

        var botFeaturesChinese = "<b>Bot 功能</b>\n\n" + 
                                 "提交文本以自动翻译成所选语言。\n\n" + 
                                 "提交 /meaning_english 以调用英语含义和同义词。\n" +
                                 "发送 /interface_language 更改界面语言\n\n" +
                                 "<b>提交照片并获取</b>\n" + 
                                 "- 带照片的文本\n" + 
                                 "- 所有带照片的对象和翻译\n" + 
                                 "- 如果可能的话，对照片进行简要描述\n\n" + 
                                 "<b>提交音频并获得</b>\n" + 
                                 "- 音频转录" +
                                 "\n\n<b>Bot 支持“回复”和“转发”消息。</b>";

        var botFeaturesCzech = "<b>Funkce robota</b>\n\n" + 
                               "Odešlete text k automatickému překladu do vybraného jazyka.\n\n" + 
                               "Odešlete /meaning_english, chcete-li získat anglický význam a synonyma.\n" +
                               "Pro změnu jazyka rozhraní odešlete /interface_language\n\n" +
                               "<b>Odešlete fotografie a získejte</b>\n" + 
                               "- Text s fotografií\n" + 
                               "- Všechny objekty s fotografií s překladem\n" + 
                               "- Stručný popis fotografie, pokud je to možné\n\n" + 
                               "<b>Odešlete zvuk a získejte</b>\n" + 
                               "- Zvukový přepis" +
                               "\n\n<b>Bot podporuje „odpovědi“ a „přeposílání“ zpráv.</b>";

        var botFeaturesDanish = "<b>Bot-funktioner</b>\n\n" + 
                                "Send tekst til automatisk oversættelse til det valgte sprog.\n\n" + 
                                "Send /meaning_english for at kalde på engelsk betydning og synonymer.\n" +
                                "Send /interface_language for at ændre grænsefladesproget\n\n" +
                                "<b>Indsend billeder og få </b>\n" + 
                                "- Tekst med foto\n" + 
                                "- Alle objekter med foto med oversættelse\n" + 
                                "- Kort beskrivelse af billedet, hvis det er muligt\n\n" + 
                                "<b>Send lyd og få</b>\n" + 
                                "- Lydtransskription" +
                                "\n\n<b>Bot understøtter 'svar' og 'videresendelser'-meddelelser.</b>";

        var botFeaturesHindi = "<b>बॉट सुविधाएँ</b>\n\n" + 
                               "चयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\n" + 
                               "अंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\n" +
                               "इंटरफ़ेस भाषा बदलने के लिए /interface_language भेजें\n\n" +
                               "<b>फ़ोटो सबमिट करें और प्राप्त करें</b>\n" + 
                               "- फ़ोटो के साथ टेक्स्ट\n" + 
                               "- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n" + 
                               "- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n" + 
                               "<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n" + 
                               "- ऑडियो ट्रांसक्रिप्शन" +
                               "\n\n<b>बॉट 'जवाब' और 'फॉरवर्ड' संदेशों का समर्थन करता है।</b>";

        var botFeaturesItalian = "<b>Caratteristiche del bot</b>\n\n" + 
                                 "Invia il testo per la traduzione automatica nella lingua selezionata.\n\n" + 
                                 "Invia /meaning_english per richiedere significato e sinonimi in inglese.\n" +
                                 "Invia /interface_language per cambiare la lingua dell'interfaccia\n\n" +
                                 "<b>Invia foto e ottieni </b>\n" + 
                                 "- Testo con foto\n" + 
                                 "- Tutti gli oggetti con foto con traduzione\n" + 
                                 "- Breve descrizione della foto, se possibile\n\n" + 
                                 "<b>Invia audio e ottieni</b>\n" + 
                                 "- Trascrizione audio" +
                                 "\n\n<b>Il bot supporta i messaggi di 'risposta' e 'inoltro'.</b>";

        var botFeaturesSwedish = "<b>Botfunktioner</b>\n\n" + 
                                 "Skicka in text för automatisk översättning till det valda språket.\n\n" + 
                                 "Skicka in /meaning_english för att få engelska betydelser och synonymer.\n" +
                                 "Skicka /interface_language för att ändra gränssnittsspråket\n\n" +
                                 "<b>Skicka in foton och få </b>\n" + 
                                 "- Text med foto\n" + 
                                 "- Alla objekt med foto med översättning\n" + 
                                 "- Kort beskrivning av fotot, om möjligt\n\n" + 
                                 "<b>Skicka in ljud och få</b>\n" + 
                                 "- Ljudtranskription" +
                                 "\n\n<b>Bot stöder 'svar' och 'vidarebefordrar' meddelanden.</b>";

        var botFeaturesGerman = "<b>Bot-Funktionen</b>\n\n" + 
                                "Senden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\n" + 
                                "Senden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\n" +
                                "Senden Sie /interface_language, um die Sprache der Benutzeroberfläche zu ändern\n\n" +
                                "<b>Senden Sie Fotos und erhalten Sie</b>\n" + 
                                "- Text mit Foto\n" + 
                                "- Alle Objekte mit Foto mit Übersetzung\n" + 
                                "- Kurze Beschreibung des Fotos, wenn möglich\n\n" + 
                                "<b>Audio einreichen und</b>\n" + 
                                "- Audiotranskription erhalten" +
                                "\n\n<b>Bot unterstützt 'Antworten' und 'Weiterleiten' von Nachrichten.</b>";

        var botFeaturesPolish = "<b>Funkcje bota</b>\n\n" + 
                                "Prześlij tekst do automatycznego tłumaczenia na wybrany język.\n\n" + 
                                "Prześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\n" +
                                "Wyślij /interface_language, aby zmienić język interfejsu\n\n" +
                                "<b>Prześlij zdjęcia i uzyskaj </b>\n" + 
                                "- Tekst ze zdjęciem\n" + 
                                "- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n" + 
                                "- Krótki opis zdjęcia, jeśli to możliwe\n\n" + 
                                "<b>Prześlij dźwięk i pobierz</b>\n" + 
                                "- Transkrypcję dźwięku" +
                                "\n\n<b>Bot obsługuje 'odpowiedzi' i 'przekazuje dalej' wiadomości.</b>";

        var botFeaturesTurkish = "<b>Bot özellikleri</b>\n\n" + 
                                 "Seçilen dile otomatik çeviri için metin gönderin.\n\n" + 
                                 "İngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\n" +
                                 "Arayüz dilini değiştirmek için /interface_language gönderin\n\n" +
                                 "<b>Fotoğraf gönderin ve </b>\n" + 
                                 "- Fotoğraflı metin\n" + 
                                 "- Fotoğraflı tüm nesneler ve çevirisi\n" + 
                                 "- Mümkünse fotoğrafın kısa açıklaması\n\n" + 
                                 "<b>Sesi gönderin ve</b>\n" + 
                                 "- Sesli transkripsiyonu alın" +
                                 "\n\n<b>Bot desteği 'yanıtlar' ve 'iletilen' mesajlar.</b>";

        var userLanguagesUA = "<b>Ваші мови</b>\n" + "Основна мова: {0}\n" + "Мова перекладу: {1}";
        var userLanguagesRU = "<b>Ваши языки</b>\n" + "Основной язык: {0}\n" + "Целевой язык: {1}";
        var userLanguagesEN = "<b>Your languages</b>\n" + "Main Language: {0}\n" + "Target Language: {1}";
        var userLanguagesSP = "b>Tus idiomas</b>\n" + "Lenguaje principal: {0}\n" + "Lengua meta: {1}";
        var userLanguagesFR = "<b>Vos langues</b>\n" + "Langage principal: {0}\n" + "Langue cible: {1}";
        var userLanguagesJA = "<b>あなたの言語</b>\n" + "主要言語：{0}\n" + "ターゲット言語: {1}";
        var userLanguagesCHINESE = "<b>你的语言</b>\n" + "主要语言： {0}\n" + "选择母语: {1}";
        var userLanguagesCZHECH = "<b>Vaše jazyky</b>\n" + "Hlavní jazyk: {0}\n" + "Cílový jazyk: {1}";
        var userLanguagesDANISH = "<b>Dine sprog</b>\n" + "Hovedsprog: {0}\n" + "Målsprog: {1}";
        var userLanguagesHindi = "<b>आपकी भाषाएँ</b>\n" + "मुख्य भाषा: {0}\n" + "लक्ष्य भाषा: {1}";
        var userLanguagesItalian = "<b>Le tue lingue</b>\n" + "Lingua principale: {0}\n" + "Lingua di destinazione: {1}";
        var userLanguagesSwedish = "<b>Dina språk</b>\n" + "Modersmål: {0}\n" + "Målspråk: {1}";
        var userLanguagesGerman = "<b>Ihre Sprachen</b>\n" + "Muttersprache: {0}\n" + "Zielsprache: {1}";
        var userLanguagesPolish = "<b>Twoje języki</b>\n" + "Główny język: {0}\n" + "Język docelowy: {1}";
        var userLanguagesTurkish = "<b>Dilleriniz</b>\n" + "Ana dil: {0}\n" + "Hedef dil: {1}";


        var userInfoKey = "app.menu.userInfo";

        var userInfoUA = $"{userLanguagesUA}\n\n" +
                         "Мова аудіо транскрипції: {2}\n\n" +
                         "Мова інтерфейсу: {3}\n\n" +
                         "Показувати значення англійських слів - {4}";

        var userInfoRU = $"{userLanguagesRU}\n\n" +
                         "Язык аудио транскрипции: {2}\n\n" +
                         "Язык интерфейса: {3}\n\n" +
                         "Показывать значение английских слов - {4}";

        var userInfoEN = $"{userLanguagesEN}\n\n" +
                        "Audio transcription language: {2}\n\n" +
                        "Your interface language: {3}\n\n" +
                        "Show english words meaning - {4}";

        var userInfoSP = $"{userLanguagesSP}\n\n" +
                         "Idioma de transcripción de audio: {2}\n\n" +
                         "Tu idioma de interfaz: {3}\n\n" +
                         "Mostrar el significado de las palabras en inglés - {4}";

        var userInfoFR = $"{userLanguagesFR}\n\n" +
                         "Langue de transcription audio: {2}\n\n" +
                         "La langue de votre interface: {3}\n\n" +
                         "Afficher le sens des mots anglais - {4}";

        var userInfoJA = $"{userLanguagesJA}\n\n" +
                         "音声転写言語: {2}\n\n" +
                         "インターフェース言語: {3}\n\n" +
                         "英単語の意味を表示 - {4}";

        var userInfoCHINESE = $"{userLanguagesCHINESE}\n\n" +
                              "音频转录语言：{2}\n\n" +
                              "界面语言： {3}\n\n" +
                              "显示英文单词的意思 - {4}";

        var userInfoCZHECH = $"{userLanguagesCZHECH}\n\n" +
                             "Jazyk zvukového přepisu: {2}\n\n" +
                             "Váš jazyk rozhraní: {3}\n\n" +
                             "Zobrazit význam anglických slov - {4}";

        var userInfoDANISH = $"{userLanguagesDANISH}\n\n" +
                             "Lydtransskriptionssprog: {2}\n\n" +
                             "Dit grænsefladesprog: {3}\n\n" +
                             "Vis engelske ords betydning - {4}";

        var userInfoHindi = $"{userLanguagesHindi}\n\n" +
                            "ऑडियो ट्रांसक्रिप्शन भाषा: {2}\n\n" +
                            "अंतरफलक भाषा: {3}\n\n" +
                            "अंग्रेजी शब्दों का अर्थ दिखाएँ - {4}";

        var userInfoItalian = $"{userLanguagesItalian}\n\n" +
                              "Lingua di trascrizione audio: {2}\n\n" +
                              "La lingua dell'interfaccia: {3}\n\n" +
                              "Mostra il significato delle parole inglesi - {4}";

        var userInfoSwedish = $"{userLanguagesSwedish}\n\n" +
                              "Språk för ljudtranskription: {2}\n\n" +
                              "Ditt gränssnittsspråk: {3}\n\n" +
                              "Visa engelska ords betydelse - {4}";

        var userInfoGerman = $"{userLanguagesGerman}\n\n" +
                             "Sprache der Audiotranskription: {2}\n\n" +
                             "Ihre Oberflächensprache: {3}\n\n" +
                             "Visa engelska ords betydelse - {4}";

        var userInfoPolish = $"{userLanguagesPolish}\n\n" +
                             "Język transkrypcji dźwięku: {2}\n\n" +
                             "Twój język interfejsu: {3}\n\n" +
                             "Pokaż znaczenie angielskich słów - {4}";

        var userInfoTurkish = $"{userLanguagesTurkish}\n\n" +
                              "Ses transkripsiyon dili: {2}\n\n" +
                              "Arayüz diliniz: {3}\n\n" +
                              "İngilizce kelimelerin anlamını göster - {4}";

        // User info settings languages established, audio language, meaning, inteface language 

        var data = new List<KeyTranslationsInitEntity>
        {
            new KeyTranslationsInitEntity(interfaceKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Мова інтерфейсу:")
                .AddTranslate(LanguageENUM.Russian, "Язык интерфейса:")
                .AddTranslate(LanguageENUM.English, "Your interface language:")
                .AddTranslate(LanguageENUM.Spanish, "Tu idioma de interfaz:")
                .AddTranslate(LanguageENUM.French, "La langue de votre interface:")
                .AddTranslate(LanguageENUM.Japanese, "インターフェース言語:")
                .AddTranslate(LanguageENUM.Chinese, "界面语言：")
                .AddTranslate(LanguageENUM.Czech, "Váš jazyk rozhraní:")
                .AddTranslate(LanguageENUM.Danish, "Dit grænsefladesprog:")
                .AddTranslate(LanguageENUM.Hindi, "अंतरफलक भाषा:")
                .AddTranslate(LanguageENUM.Italian, "La lingua dell'interfaccia:")
                .AddTranslate(LanguageENUM.Swedish, "Ditt gränssnittsspråk:")
                .AddTranslate(LanguageENUM.German, "Ihre Oberflächensprache:")
                .AddTranslate(LanguageENUM.Polish, "Twój język interfejsu:")
                .AddTranslate(LanguageENUM.Turkish, "Arayüz diliniz:"),
            new KeyTranslationsInitEntity(languagesSettedKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Мови були встановлені.\n\n" + botFeaturesUA + $"\n\n{userLanguagesUA}")
                .AddTranslate(LanguageENUM.Russian, "Языки были установлены.\n\n" + botFeaturesRU + $"\n\n{userLanguagesRU}")
                .AddTranslate(LanguageENUM.English, "The languages were established.\n\n" + botFeaturesEN + $"\n\n{userLanguagesEN}")
                .AddTranslate(LanguageENUM.Spanish, "Se han establecido las lenguas.\n\n" + botFeaturesSpain + $"\n\n{userLanguagesSP}")
                .AddTranslate(LanguageENUM.French, "Les langues ont été définies.\n\n" + botFeaturesFrench + $"\n\n{userLanguagesFR}")
                .AddTranslate(LanguageENUM.Japanese, "言語が設定されました。\n\n" + botFeaturesJapanese + $"\n\n{userLanguagesJA}")
                .AddTranslate(LanguageENUM.Chinese, "设置了语言。\n\n" + botFeaturesChinese + $"\n\n{userLanguagesCHINESE}")
                .AddTranslate(LanguageENUM.Czech, "Jazyky byly nastaveny.\n\n" + botFeaturesCzech + $"\n\n{userLanguagesCZHECH}")
                .AddTranslate(LanguageENUM.Danish, "Sprog blev sat.\n\n" + botFeaturesDanish + $"\n\n{userLanguagesDANISH}")
                .AddTranslate(LanguageENUM.Hindi, "भाषाएँ निर्धारित की गईं।\n\n" + botFeaturesHindi + $"\n\n{userLanguagesHindi}")
                .AddTranslate(LanguageENUM.Italian, "Le lingue sono state impostate.\n\n" + botFeaturesItalian + $"\n\n{userLanguagesItalian}")
                .AddTranslate(LanguageENUM.Swedish, "Språk sattes.\n\n" + botFeaturesSwedish + $"\n\n{userLanguagesSwedish}")
                .AddTranslate(LanguageENUM.German, "Sprachen wurden eingestellt.\n\n" + botFeaturesGerman + $"\n\n{userLanguagesGerman}")
                .AddTranslate(LanguageENUM.Polish, "Ustawiono języki.\n\n" + botFeaturesPolish + $"\n\n{userLanguagesPolish}")
                .AddTranslate(LanguageENUM.Turkish, "Diller ayarlandı.\n\n" + botFeaturesTurkish + $"\n\n{userLanguagesTurkish}"),
            new KeyTranslationsInitEntity(textImageKey)
                .AddTranslate(LanguageENUM.Ukrainian, "<b>Текст фото</b>")
                .AddTranslate(LanguageENUM.Russian, "<b>Фото текст</b>")
                .AddTranslate(LanguageENUM.English, "<b>Photo text</b>")
                .AddTranslate(LanguageENUM.Spanish, "<b>Foto texto</b>")
                .AddTranslate(LanguageENUM.French, "<b>Texte photo</b>")
                .AddTranslate(LanguageENUM.Japanese, "<b>写真テキスト</b>")
                .AddTranslate(LanguageENUM.Chinese, "<b>照片文字</b>")
                .AddTranslate(LanguageENUM.Czech, "<b>Text fotografie</b>")
                .AddTranslate(LanguageENUM.Danish, "<b>Fototekst</b>")
                .AddTranslate(LanguageENUM.Hindi, "<b>फोटो पाठ</b>")
                .AddTranslate(LanguageENUM.Italian, "<b>Testo fotografico</b>")
                .AddTranslate(LanguageENUM.Swedish, "<b>Fototext</b>")
                .AddTranslate(LanguageENUM.German, "<b>Fototext</b>")
                .AddTranslate(LanguageENUM.Polish, "<b>Tekst zdjęcia</b>")
                .AddTranslate(LanguageENUM.Turkish, "<b>Fotoğraf metni</b>"),
            new KeyTranslationsInitEntity(objectsImageKey)
                .AddTranslate(LanguageENUM.Ukrainian, "<b>Об'єкти зображення</b>")
                .AddTranslate(LanguageENUM.Russian, "<b>Объекты изображения</b>")
                .AddTranslate(LanguageENUM.English, "<b>Image objects</b>")
                .AddTranslate(LanguageENUM.Spanish, "<b>Objetos de imagen</b>")
                .AddTranslate(LanguageENUM.French, "<b>Objets images</b>")
                .AddTranslate(LanguageENUM.Japanese, "<b>画像オブジェクト</b>")
                .AddTranslate(LanguageENUM.Chinese, "<b>图像对象</b>")
                .AddTranslate(LanguageENUM.Czech, "<b>Obrazové objekty</b>")
                .AddTranslate(LanguageENUM.Danish, "<b>Billedobjekter</b>")
                .AddTranslate(LanguageENUM.Hindi, "<b>छवि वस्तुएं</b>")
                .AddTranslate(LanguageENUM.Italian, "<b>Oggetti immagine</b>")
                .AddTranslate(LanguageENUM.Swedish, "<b>Bildobjekt</b>")
                .AddTranslate(LanguageENUM.German, "<b>Bildobjekte</b>")
                .AddTranslate(LanguageENUM.Polish, "<b>Obiekty obrazu</b>")
                .AddTranslate(LanguageENUM.Turkish, "<b>Görüntü nesneleri</b>"),
            new KeyTranslationsInitEntity(descriptionImageKey)
                .AddTranslate(LanguageENUM.Ukrainian, "<b>Опис зображення</b>")
                .AddTranslate(LanguageENUM.Russian, "<b>Описание изображения</b>")
                .AddTranslate(LanguageENUM.English, "<b>Image description</b>")
                .AddTranslate(LanguageENUM.Spanish, "<b>Descripción de la imagen</b>")
                .AddTranslate(LanguageENUM.French, "<b>Description de l'image</b>")
                .AddTranslate(LanguageENUM.Japanese, "<b>画像の説明</b>")
                .AddTranslate(LanguageENUM.Chinese, "<b>图片描述</b>")
                .AddTranslate(LanguageENUM.Czech, "<b>Popis obrázku</b>")
                .AddTranslate(LanguageENUM.Danish, "<b>Billedbeskrivelse</b>")
                .AddTranslate(LanguageENUM.Hindi, "<b>चित्र का वर्णन</b>")
                .AddTranslate(LanguageENUM.Italian, "<b>Descrizione dell'immagine</b>")
                .AddTranslate(LanguageENUM.Swedish, "<b>Bildbeskrivning</b>")
                .AddTranslate(LanguageENUM.German, "<b>Bildbeschreibung</b>")
                .AddTranslate(LanguageENUM.Polish, "<b>Opis obrazu</b>")
                .AddTranslate(LanguageENUM.Turkish, "<b>Görüntü açıklaması</b>"),
            new KeyTranslationsInitEntity(textMaybeMeanKey)
                .AddTranslate(LanguageENUM.Ukrainian, "<b>Можливо, ви маєте на увазі</b>")
                .AddTranslate(LanguageENUM.Russian, "<b>Может быть, вы имеете в виду</b>")
                .AddTranslate(LanguageENUM.English, "<b>Maybe you mean</b>")
                .AddTranslate(LanguageENUM.Spanish, "<b>Tal vez te refieres</b>")
                .AddTranslate(LanguageENUM.French, "<b>Peut-être que tu veux dire</b>")
                .AddTranslate(LanguageENUM.Japanese, "<b>多分あなたが意味する</b>")
                .AddTranslate(LanguageENUM.Chinese, "<b>也许你的意思是</b>")
                .AddTranslate(LanguageENUM.Czech, "<b>Možná myslíš</b>")
                .AddTranslate(LanguageENUM.Danish, "<b>Måske mener du</b>")
                .AddTranslate(LanguageENUM.Hindi, "<b>शायद आपका मतलब है</b>")
                .AddTranslate(LanguageENUM.Italian, "<b>Forse intendi</b>")
                .AddTranslate(LanguageENUM.Swedish, "<b>Du kanske menar</b>")
                .AddTranslate(LanguageENUM.German, "<b>Vielleicht meinst du</b>")
                .AddTranslate(LanguageENUM.Polish, "<b>Może masz na myśli</b>")
                .AddTranslate(LanguageENUM.Turkish, "<b>Belki demek istiyorsun</b>"),
            new KeyTranslationsInitEntity(menuChooseNativeKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Виберіть мову")
                .AddTranslate(LanguageENUM.Russian, "Выберите родной язык")
                .AddTranslate(LanguageENUM.English, "Choose native language")
                .AddTranslate(LanguageENUM.Spanish, "Elija el idioma nativo")
                .AddTranslate(LanguageENUM.French, "Choisissez la langue maternelle")
                .AddTranslate(LanguageENUM.Japanese, "母国語を選択")
                .AddTranslate(LanguageENUM.Chinese, "选择母语")
                .AddTranslate(LanguageENUM.Czech, "Vyberte rodný jazyk")
                .AddTranslate(LanguageENUM.Danish, "Vælg modersmål")
                .AddTranslate(LanguageENUM.Hindi, "अपनी मूल भाषा चुनें")
                .AddTranslate(LanguageENUM.Italian, "Scegli la lingua madre")
                .AddTranslate(LanguageENUM.Swedish, "Välj modersmål")
                .AddTranslate(LanguageENUM.German, "Muttersprache wählen")
                .AddTranslate(LanguageENUM.Polish, "Wybierz język ojczysty")
                .AddTranslate(LanguageENUM.Turkish, "Yerel dili seçin"),
            new KeyTranslationsInitEntity(menuChooseTargetKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Виберіть цільову мову")
                .AddTranslate(LanguageENUM.Russian, "Выберите целевой язык")
                .AddTranslate(LanguageENUM.English, "Choose target language")
                .AddTranslate(LanguageENUM.Spanish, "Elija el idioma de destino")
                .AddTranslate(LanguageENUM.French, "Choisissez la langue cible")
                .AddTranslate(LanguageENUM.Japanese, "ターゲット言語を選択")
                .AddTranslate(LanguageENUM.Chinese, "选择目标语言")
                .AddTranslate(LanguageENUM.Czech, "Vyberte cílový jazyk")
                .AddTranslate(LanguageENUM.Danish, "Vælg målsprog")
                .AddTranslate(LanguageENUM.Hindi, "लक्षित भाषा चुनें")
                .AddTranslate(LanguageENUM.Italian, "Scegli la lingua di destinazione")
                .AddTranslate(LanguageENUM.Swedish, "Välj målspråk")
                .AddTranslate(LanguageENUM.German, "Zielsprache wählen")
                .AddTranslate(LanguageENUM.Polish, "Wybierz język docelowy")
                .AddTranslate(LanguageENUM.Turkish, "Hedef dili seçin"),
            new KeyTranslationsInitEntity(menuEnglishMeaningKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Показувати значення англійських слів")
                .AddTranslate(LanguageENUM.Russian, "Показывать значение английских слов")
                .AddTranslate(LanguageENUM.English, "Show english words meaning")
                .AddTranslate(LanguageENUM.Spanish, "Mostrar el significado de las palabras en inglés")
                .AddTranslate(LanguageENUM.French, "Afficher le sens des mots anglais")
                .AddTranslate(LanguageENUM.Japanese, "英単語の意味を表示")
                .AddTranslate(LanguageENUM.Chinese, "显示英文单词的意思")
                .AddTranslate(LanguageENUM.Czech, "Zobrazit význam anglických slov")
                .AddTranslate(LanguageENUM.Danish, "Vis engelske ords betydning")
                .AddTranslate(LanguageENUM.Hindi, "अंग्रेजी शब्दों का अर्थ दिखाएँ")
                .AddTranslate(LanguageENUM.Italian, "Mostra il significato delle parole inglesi")
                .AddTranslate(LanguageENUM.Swedish, "Visa engelska ords betydelse")
                .AddTranslate(LanguageENUM.German, "Zeigen Sie die Bedeutung der englischen Wörter")
                .AddTranslate(LanguageENUM.Polish, "Pokaż znaczenie angielskich słów")
                .AddTranslate(LanguageENUM.Turkish, "İngilizce kelimelerin anlamını göster"),
            new KeyTranslationsInitEntity(menuDisable)
                .AddTranslate(LanguageENUM.Ukrainian, "вимкнено")
                .AddTranslate(LanguageENUM.Russian, "отключено")
                .AddTranslate(LanguageENUM.English, "disabled")
                .AddTranslate(LanguageENUM.Spanish, "discapacitado")
                .AddTranslate(LanguageENUM.French, "désactivé")
                .AddTranslate(LanguageENUM.Japanese, "無効")
                .AddTranslate(LanguageENUM.Chinese, "禁用")
                .AddTranslate(LanguageENUM.Czech, "zakázáno")
                .AddTranslate(LanguageENUM.Danish, "handicappet")
                .AddTranslate(LanguageENUM.Hindi, "अक्षम")
                .AddTranslate(LanguageENUM.Italian, "disabilitato")
                .AddTranslate(LanguageENUM.Swedish, "Inaktiverad")
                .AddTranslate(LanguageENUM.German, "deaktiviert")
                .AddTranslate(LanguageENUM.Polish, "wyłączony")
                .AddTranslate(LanguageENUM.Turkish, "engelli"),
            new KeyTranslationsInitEntity(menuActivated)
                .AddTranslate(LanguageENUM.Ukrainian, "активовано")
                .AddTranslate(LanguageENUM.Russian, "активировано")
                .AddTranslate(LanguageENUM.English, "activated")
                .AddTranslate(LanguageENUM.Spanish, "activado")
                .AddTranslate(LanguageENUM.French, "activé")
                .AddTranslate(LanguageENUM.Japanese, "アクティブ化")
                .AddTranslate(LanguageENUM.Chinese, "活性")
                .AddTranslate(LanguageENUM.Czech, "aktivováno")
                .AddTranslate(LanguageENUM.Danish, "aktiveret")
                .AddTranslate(LanguageENUM.Hindi, "सक्रिय")
                .AddTranslate(LanguageENUM.Italian, "attivato")
                .AddTranslate(LanguageENUM.Swedish, "aktiveras")
                .AddTranslate(LanguageENUM.German, "aktiviert")
                .AddTranslate(LanguageENUM.Polish, "aktywowany")
                .AddTranslate(LanguageENUM.Turkish, "aktif"),
            new KeyTranslationsInitEntity(menuChooseLang)
                .AddTranslate(LanguageENUM.Ukrainian, "Виберіть мову інтерфейсу")
                .AddTranslate(LanguageENUM.Russian, "Выберите язык интерфейса")
                .AddTranslate(LanguageENUM.English, "Choose interface language")
                .AddTranslate(LanguageENUM.Spanish, "Elija el idioma de la interfaz")
                .AddTranslate(LanguageENUM.French, "Choisissez la langue de l'interface")
                .AddTranslate(LanguageENUM.Japanese, "インターフェイス言語の選択")
                .AddTranslate(LanguageENUM.Chinese, "选择界面语言")
                .AddTranslate(LanguageENUM.Czech, "Vyberte jazyk rozhraní")
                .AddTranslate(LanguageENUM.Danish, "Vælg grænsefladesprog")
                .AddTranslate(LanguageENUM.Hindi, "इंटरफ़ेस भाषा चुनें")
                .AddTranslate(LanguageENUM.Italian, "Scegli la lingua dell'interfaccia")
                .AddTranslate(LanguageENUM.Swedish, "Välj gränssnittsspråk")
                .AddTranslate(LanguageENUM.German, "Wählen Sie die Sprache der Benutzeroberfläche")
                .AddTranslate(LanguageENUM.Polish, "Wybierz język interfejsu")
                .AddTranslate(LanguageENUM.Turkish, "Arayüz dilini seçin"),
            new KeyTranslationsInitEntity(menuInfoKey)
                .AddTranslate(LanguageENUM.Ukrainian,  botFeaturesUA)
                .AddTranslate(LanguageENUM.Russian, botFeaturesRU)
                .AddTranslate(LanguageENUM.English,  botFeaturesEN)
                .AddTranslate(LanguageENUM.Spanish, botFeaturesSpain)
                .AddTranslate(LanguageENUM.French, botFeaturesFrench)
                .AddTranslate(LanguageENUM.Japanese, botFeaturesJapanese)
                .AddTranslate(LanguageENUM.Chinese, botFeaturesChinese)
                .AddTranslate(LanguageENUM.Czech, botFeaturesCzech)
                .AddTranslate(LanguageENUM.Danish, botFeaturesDanish)
                .AddTranslate(LanguageENUM.Hindi, botFeaturesHindi)
                .AddTranslate(LanguageENUM.Italian, botFeaturesItalian)
                .AddTranslate(LanguageENUM.Swedish, botFeaturesSwedish)
                .AddTranslate(LanguageENUM.German, botFeaturesGerman)
                .AddTranslate(LanguageENUM.Polish, botFeaturesPolish)
                .AddTranslate(LanguageENUM.Turkish, botFeaturesTurkish),
            new KeyTranslationsInitEntity(audioText)
                .AddTranslate(LanguageENUM.Ukrainian, "Аудіо-транскрипція")
                .AddTranslate(LanguageENUM.Russian, "Транскрипция аудио")
                .AddTranslate(LanguageENUM.English, "Audio transcription")
                .AddTranslate(LanguageENUM.Spanish, "Transcripción de audio")
                .AddTranslate(LanguageENUM.French, "Transcription audio")
                .AddTranslate(LanguageENUM.Japanese, "音声トランスクリプション")
                .AddTranslate(LanguageENUM.Chinese, "音频转录")
                .AddTranslate(LanguageENUM.Czech, "Přepis zvuku")
                .AddTranslate(LanguageENUM.Danish, "Lydtransskription")
                .AddTranslate(LanguageENUM.Hindi, "ऑडियो ट्रांसक्रिप्शन")
                .AddTranslate(LanguageENUM.Italian, "Trascrizione audio")
                .AddTranslate(LanguageENUM.Swedish, "Ljudtranskription")
                .AddTranslate(LanguageENUM.German, "Audiotranskription")
                .AddTranslate(LanguageENUM.Polish, "Transkrypcja dźwięku")
                .AddTranslate(LanguageENUM.Turkish, "Ses transkripsiyonu"),
            new KeyTranslationsInitEntity(menuAudioLangKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Виберіть мову аудіо при транскрипії")
                .AddTranslate(LanguageENUM.Russian, "Выберите язык аудио при транскрипции")
                .AddTranslate(LanguageENUM.English, "Select the audio language when transcribing")
                .AddTranslate(LanguageENUM.Spanish, "Seleccionar el idioma del audio al transcribir")
                .AddTranslate(LanguageENUM.French, "Sélectionnez la langue audio lors de la transcription")
                .AddTranslate(LanguageENUM.Japanese, "文字起こし時の音声言語の選択")
                .AddTranslate(LanguageENUM.Chinese, "转录时选择音频语言")
                .AddTranslate(LanguageENUM.Czech, "Vyberte jazyk zvuku při přepisu")
                .AddTranslate(LanguageENUM.Danish, "Vælg lydsproget, når du transskriberer")
                .AddTranslate(LanguageENUM.Hindi, "लिप्यंतरण करते समय ऑडियो भाषा का चयन करें")
                .AddTranslate(LanguageENUM.Italian, "Seleziona la lingua dell'audio durante la trascrizione")
                .AddTranslate(LanguageENUM.Swedish, "Välj ljudspråk när du transkriberar")
                .AddTranslate(LanguageENUM.German, "Wählen Sie beim Transkribieren die Audiosprache aus")
                .AddTranslate(LanguageENUM.Polish, "Wybierz język ścieżki dźwiękowej podczas transkrypcji")
                .AddTranslate(LanguageENUM.Turkish, "Yazıya dökerken ses dilini seçin"),
            new KeyTranslationsInitEntity(audioLanguageKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Мова аудіо транскрипції:")
                .AddTranslate(LanguageENUM.Russian, "Язык аудио транскрипции:")
                .AddTranslate(LanguageENUM.English, "Audio transcription language:")
                .AddTranslate(LanguageENUM.Spanish, "Idioma de transcripción de audio:")
                .AddTranslate(LanguageENUM.French, "Langue de transcription audio :")
                .AddTranslate(LanguageENUM.Japanese, "音声転写言語:")
                .AddTranslate(LanguageENUM.Chinese, "音频转录语言：")
                .AddTranslate(LanguageENUM.Czech, "Jazyk zvukového přepisu:")
                .AddTranslate(LanguageENUM.Danish, "Lydtransskriptionssprog:")
                .AddTranslate(LanguageENUM.Hindi, "ऑडियो ट्रांसक्रिप्शन भाषा:")
                .AddTranslate(LanguageENUM.Italian, "Lingua di trascrizione audio:")
                .AddTranslate(LanguageENUM.Swedish, "Språk för ljudtranskription:")
                .AddTranslate(LanguageENUM.German, "Sprache der Audiotranskription:")
                .AddTranslate(LanguageENUM.Polish, "Język transkrypcji dźwięku:")
                .AddTranslate(LanguageENUM.Turkish, "Ses transkripsiyon dili:"),
            new KeyTranslationsInitEntity(audioResendKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Надішліть аудіо ще раз, ви можете використати 'reply'")
                .AddTranslate(LanguageENUM.Russian, "Отправьте аудио еще раз, вы можете использовать 'reply'")
                .AddTranslate(LanguageENUM.English, "Send the audio again, you can use 'reply'")
                .AddTranslate(LanguageENUM.Spanish, "Envía el audio de nuevo, puedes usar 'reply'")
                .AddTranslate(LanguageENUM.French, "Envoyez à nouveau l'audio, vous pouvez utiliser 'reply'")
                .AddTranslate(LanguageENUM.Japanese, "音声をもう一度送信してください。'reply' を使用できます")
                .AddTranslate(LanguageENUM.Chinese, "再次发送音频，您可以使用 'reply'")
                .AddTranslate(LanguageENUM.Czech, "Pošlete zvuk znovu, můžete použít 'reply'")
                .AddTranslate(LanguageENUM.Danish, "Send lyden igen, du kan bruge 'reply'")
                .AddTranslate(LanguageENUM.Hindi, "ऑडियो फिर से भेजें, आप 'reply' का उपयोग कर सकते हैं")
                .AddTranslate(LanguageENUM.Italian, "Invia di nuovo l'audio, puoi usare 'reply'")
                .AddTranslate(LanguageENUM.Swedish, "Skicka ljudet igen, du kan använda 'svara'")
                .AddTranslate(LanguageENUM.German, "Senden Sie das Audio erneut, Sie können 'reply' verwenden")
                .AddTranslate(LanguageENUM.Polish, "Wyślij dźwięk ponownie, możesz użyć 'reply'")
                .AddTranslate(LanguageENUM.Turkish, "Sesi tekrar gönderin, 'reply' kullanabilirsiniz"),
            new KeyTranslationsInitEntity(fileNoSupportContentTypeKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Бот не підтримує цей тип контенту")
                .AddTranslate(LanguageENUM.Russian, "Бот не поддерживает этот тип контента")
                .AddTranslate(LanguageENUM.English, "The bot does not support this type of content")
                .AddTranslate(LanguageENUM.Spanish, "El bot no soporta este tipo de contenido.")
                .AddTranslate(LanguageENUM.French, "Le bot ne prend pas en charge ce type de contenu")
                .AddTranslate(LanguageENUM.Japanese, "ボットはこのタイプのコンテンツをサポートしていません")
                .AddTranslate(LanguageENUM.Chinese, "该机器人不支持此类内容")
                .AddTranslate(LanguageENUM.Czech, "Robot tento typ obsahu nepodporuje")
                .AddTranslate(LanguageENUM.Danish, "Botten understøtter ikke denne type indhold")
                .AddTranslate(LanguageENUM.Hindi, "बॉट इस प्रकार की सामग्री का समर्थन नहीं करता है")
                .AddTranslate(LanguageENUM.Italian, "Il bot non supporta questo tipo di contenuto")
                .AddTranslate(LanguageENUM.Swedish, "Boten stöder inte den här typen av innehåll")
                .AddTranslate(LanguageENUM.German, "Der Bot unterstützt diese Art von Inhalten nicht")
                .AddTranslate(LanguageENUM.Polish, "Bot nie obsługuje tego typu treści")
                .AddTranslate(LanguageENUM.Turkish, "Bot bu tür içeriği desteklemiyor"),
            new KeyTranslationsInitEntity(audioNoSupportFormatKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Формат не підтримується. Використовуйте (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Russian, "Не поддерживаемый формат. Используйте (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.English, "Not supported format. Use (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Spanish, "Formato no compatible. Usar (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.French, "Format non pris en charge. Utiliser (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Japanese, "サポートされていない形式です。 使用 (.mp3、.ogg、.flac、.wav)")
                .AddTranslate(LanguageENUM.Chinese, "不支持的格式。 使用（.mp3、.ogg、.flac、.wav）")
                .AddTranslate(LanguageENUM.Czech, "Nepodporovaný formát. Použít (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Danish, "Ikke understøttet format. Brug (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Hindi, "समर्थित प्रारूप नहीं। उपयोग करें (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Italian, "Formato non supportato. Usa (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Swedish, "Format som inte stöds. Använd (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.German, "Nicht unterstütztes Format. Verwendung (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Polish, "Nieobsługiwany format. Użyj (.mp3, .ogg, .flac, .wav)")
                .AddTranslate(LanguageENUM.Turkish, "Desteklenmeyen biçim. (.mp3, .ogg, .flac, .wav) kullanın"),
            new KeyTranslationsInitEntity(audioCantProcess)
                .AddTranslate(LanguageENUM.Ukrainian, "Не вдається обробити це аудіо, спробуйте інше.")
                .AddTranslate(LanguageENUM.Russian, "Не удается обработать этот звук, попробуйте другой.")
                .AddTranslate(LanguageENUM.English, "Can't process this audio try another one.")
                .AddTranslate(LanguageENUM.Spanish, "No se puede procesar este audio, prueba con otro.")
                .AddTranslate(LanguageENUM.French, "Impossible de traiter cet audio, essayez-en un autre.")
                .AddTranslate(LanguageENUM.Japanese, "この音声を処理できません。別の音声を試してください。")
                .AddTranslate(LanguageENUM.Chinese, "无法处理此音频，请尝试另一个。")
                .AddTranslate(LanguageENUM.Czech, "Tento zvuk nelze zpracovat, zkuste jiný.")
                .AddTranslate(LanguageENUM.Danish, "Kan ikke behandle denne lyd prøv en anden.")
                .AddTranslate(LanguageENUM.Hindi, "इस ऑडियो को प्रोसेस नहीं किया जा सकता, एक और ऑडियो आज़माएं.")
                .AddTranslate(LanguageENUM.Italian, "Impossibile elaborare questo audio, provane un altro.")
                .AddTranslate(LanguageENUM.Swedish, "Det går inte att bearbeta det här ljudet, försök med ett annat.")
                .AddTranslate(LanguageENUM.German, "Dieses Audio kann nicht verarbeitet werden, versuchen Sie es mit einem anderen.")
                .AddTranslate(LanguageENUM.Polish, "Nie można przetworzyć tego dźwięku, spróbuj innego.")
                .AddTranslate(LanguageENUM.Turkish, "Bu ses işlenemiyor başka bir ses deneyin."),
            new KeyTranslationsInitEntity(audioExceedDurationKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Тривалість аудіо не повинна перевищувати 60 секунд")
                .AddTranslate(LanguageENUM.Russian, "Продолжительность аудио не должна превышать 60 секунд.")
                .AddTranslate(LanguageENUM.English, "Audio duration must not exceed 60 seconds")
                .AddTranslate(LanguageENUM.Spanish, "La duración del audio no debe exceder los 60 segundos.")
                .AddTranslate(LanguageENUM.French, "La durée audio ne doit pas dépasser 60 secondes")
                .AddTranslate(LanguageENUM.Japanese, "音声の長さは 60 秒を超えてはなりません")
                .AddTranslate(LanguageENUM.Chinese, "音频时长不得超过 60 秒")
                .AddTranslate(LanguageENUM.Czech, "Délka zvuku nesmí přesáhnout 60 sekund")
                .AddTranslate(LanguageENUM.Danish, "Lydens varighed må ikke overstige 60 sekunder")
                .AddTranslate(LanguageENUM.Hindi, "ऑडियो की अवधि 60 सेकंड से अधिक नहीं होनी चाहिए")
                .AddTranslate(LanguageENUM.Italian, "La durata dell'audio non deve superare i 60 secondi")
                .AddTranslate(LanguageENUM.Swedish, "Ljudlängden får inte överstiga 60 sekunder")
                .AddTranslate(LanguageENUM.German, "Die Audiodauer darf 60 Sekunden nicht überschreiten")
                .AddTranslate(LanguageENUM.Polish, "Czas trwania dźwięku nie może przekraczać 60 sekund")
                .AddTranslate(LanguageENUM.Turkish, "Ses süresi 60 saniyeyi geçmemelidir"),
            new KeyTranslationsInitEntity(photoNoSupportFormatKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Формат не підтримується. Використовуйте (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Russian, "Не поддерживаемый формат. Использовать (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.English, "Not supported format. Use (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Spanish, "Formato no compatible. Usar (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.French, "Format non pris en charge. Utiliser (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Japanese, "サポートされていない形式です。 使用 (.png、.jpeg、.jpg)")
                .AddTranslate(LanguageENUM.Chinese, "不支持的格式。 使用（.png、.jpeg、.jpg）")
                .AddTranslate(LanguageENUM.Czech, "Nepodporovaný formát. Použít (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Danish, "Ikke understøttet format. Brug (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Hindi, "समर्थित प्रारूप नहीं। (.पीएनजी, .जेपीईजी, .जेपीजी) का प्रयोग करें")
                .AddTranslate(LanguageENUM.Italian, "Formato non supportato. Usa (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Swedish, "Format som inte stöds. Använd (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.German, "Nicht unterstütztes Format. Verwenden Sie (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Polish, "Nieobsługiwany format. Użyj (.png, .jpeg, .jpg)")
                .AddTranslate(LanguageENUM.Turkish, "Desteklenmeyen biçim. (.png, .jpeg, .jpg) kullanın"),
            new KeyTranslationsInitEntity(photoCantProcess)
                .AddTranslate(LanguageENUM.Ukrainian, "Не вдається обробити цю фотографію, спробуйте іншу.")
                .AddTranslate(LanguageENUM.Russian, "Не удается обработать это фото. Попробуйте другое.")
                .AddTranslate(LanguageENUM.English, "Can't process this photo try another one.")
                .AddTranslate(LanguageENUM.Spanish, "No se puede procesar esta foto, prueba con otra.")
                .AddTranslate(LanguageENUM.French, "Impossible de traiter cette photo, essayez-en une autre.")
                .AddTranslate(LanguageENUM.Japanese, "この写真を処理できません。別の写真を試してください。")
                .AddTranslate(LanguageENUM.Chinese, "无法处理这张照片，请尝试另一张。")
                .AddTranslate(LanguageENUM.Czech, "Tuto fotografii nelze zpracovat, zkuste jinou.")
                .AddTranslate(LanguageENUM.Danish, "Kan ikke behandle dette billede prøv et andet.")
                .AddTranslate(LanguageENUM.Hindi, "इस फ़ोटो को प्रोसेस नहीं किया जा सकता, कोई और फ़ोटो आज़माएं.")
                .AddTranslate(LanguageENUM.Italian, "Impossibile elaborare questa foto, provane un'altra.")
                .AddTranslate(LanguageENUM.Swedish, "Det går inte att bearbeta det här fotot, försök med ett annat.")
                .AddTranslate(LanguageENUM.German, "Dieses Foto kann nicht verarbeitet werden, versuchen Sie es mit einem anderen.")
                .AddTranslate(LanguageENUM.Polish, "Nie można przetworzyć tego zdjęcia, spróbuj innego.")
                .AddTranslate(LanguageENUM.Turkish, "Bu fotoğraf işlenemiyor başka bir fotoğraf deneyin."),
            new KeyTranslationsInitEntity(photoLargeFile)
                .AddTranslate(LanguageENUM.Ukrainian, "Занадто великий файл. Використовуйте фото до 4 Мб")
                .AddTranslate(LanguageENUM.Russian, "Слишком большой файл. Используйте фото до 4 МБ")
                .AddTranslate(LanguageENUM.English, "Too large a file. Use photo up to 4 MB")
                .AddTranslate(LanguageENUM.Spanish, "Un archivo demasiado grande. Usar foto de hasta 4 MB")
                .AddTranslate(LanguageENUM.French, "Fichier trop volumineux. Utiliser une photo jusqu'à 4 Mo")
                .AddTranslate(LanguageENUM.Japanese, "ファイルが大きすぎます。 4 MB までの写真を使用")
                .AddTranslate(LanguageENUM.Chinese, "文件太大。 使用最大 4 MB 的照片")
                .AddTranslate(LanguageENUM.Czech, "Příliš velký soubor. Použijte fotografii do velikosti 4 MB")
                .AddTranslate(LanguageENUM.Danish, "For stor fil. Brug foto op til 4 MB")
                .AddTranslate(LanguageENUM.Hindi, "फ़ाइल बहुत बड़ी है. 4 एमबी तक फोटो का प्रयोग करें")
                .AddTranslate(LanguageENUM.Italian, "Un file troppo grande. Usa foto fino a 4 MB")
                .AddTranslate(LanguageENUM.Swedish, "För stor fil. Använd foto upp till 4 MB")
                .AddTranslate(LanguageENUM.German, "Eine zu große Datei. Verwenden Sie Fotos bis zu 4 MB")
                .AddTranslate(LanguageENUM.Polish, "Zbyt duży plik. Użyj zdjęcia do 4 MB")
                .AddTranslate(LanguageENUM.Turkish, "Çok büyük bir dosya. 4 MB'a kadar fotoğraf kullan"),
            new KeyTranslationsInitEntity(textMaxLengthKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Максимальна довжина тексту одного повідомлення не повинна перевищувати 40 тис. символів.")
                .AddTranslate(LanguageENUM.Russian, "Максимальная длина текста одного сообщения не должна превышать 40 тыс. символов.")
                .AddTranslate(LanguageENUM.English, "The maximum text length of one message must not exceed 40k characters.")
                .AddTranslate(LanguageENUM.Spanish, "La longitud máxima del texto de un mensaje no debe exceder los 40k caracteres.")
                .AddTranslate(LanguageENUM.French, "La longueur maximale du texte d'un message ne doit pas dépasser 40 000 caractères")
                .AddTranslate(LanguageENUM.Japanese, "1 つのメッセージの最大テキスト長は 40,000 文字を超えてはなりません")
                .AddTranslate(LanguageENUM.Chinese, "一條消息的最大文本長度不得超過 40k 個字符")
                .AddTranslate(LanguageENUM.Czech, "Maximální délka textu jedné zprávy nesmí přesáhnout 40 000 znaků")
                .AddTranslate(LanguageENUM.Danish, "Den maksimale tekstlængde på én besked må ikke overstige 40.000 tegn")
                .AddTranslate(LanguageENUM.Hindi, "एक संदेश की अधिकतम टेक्स्ट लंबाई 40k वर्णों से अधिक नहीं होनी चाहिए")
                .AddTranslate(LanguageENUM.Italian, "La lunghezza massima del testo di un messaggio non deve superare i 40k caratteri")
                .AddTranslate(LanguageENUM.Swedish, "Den maximala textlängden för ett meddelande får inte överstiga 40 000 tecken")
                .AddTranslate(LanguageENUM.German, "Die maximale Textlänge einer Nachricht darf 40.000 Zeichen nicht überschreiten")
                .AddTranslate(LanguageENUM.Polish, "Maksymalna długość tekstu jednej wiadomości nie może przekraczać 40 tys. znaków")
                .AddTranslate(LanguageENUM.Turkish, "Bir mesajın maksimum metin uzunluğu 40k karakteri geçmemelidir"),
            new KeyTranslationsInitEntity(audioEmptyResult)
                .AddTranslate(LanguageENUM.Ukrainian, "Не вдалося транскрибувати. Спробуйте вибрати іншу мову транскрибування /audio_language або надішліть інший аудіоформат.")
                .AddTranslate(LanguageENUM.Russian, "Не удалось расшифровать. Попробуйте выбрать другой язык расшифровки /audio_language или отправьте аудио в другом формате.")
                .AddTranslate(LanguageENUM.English, "Failed to transcribe, please try selecting a different transcribing language /audio_language or send a different audio format.")
                .AddTranslate(LanguageENUM.Spanish, "No se pudo transcribir, intente seleccionar un idioma de transcripción diferente /audio_language o envíe un formato de audio diferente.")
                .AddTranslate(LanguageENUM.French, "Échec de la transcription, veuillez essayer de sélectionner une autre langue de transcription /audio_language ou envoyer un format audio différent.")
                .AddTranslate(LanguageENUM.Japanese, "文字起こしに失敗しました。別の文字起こし言語 /audio_language を選択するか、別の音声形式を送信してください。")
                .AddTranslate(LanguageENUM.Chinese, "转录失败，请尝试选择不同的转录语言 /audio_language 或发送不同的音频格式。")
                .AddTranslate(LanguageENUM.Czech, "Přepis se nezdařil, zkuste prosím vybrat jiný jazyk přepisu /audio_language nebo pošlete jiný formát zvuku.")
                .AddTranslate(LanguageENUM.Danish, "Kunne ikke transskriberes. Prøv at vælge et andet transskriberingssprog /audio_language eller send et andet lydformat.")
                .AddTranslate(LanguageENUM.Hindi, "लिप्यंतरण करने में विफल, कृपया एक भिन्न अनुलेखन भाषा /audio_language का चयन करने का प्रयास करें या एक भिन्न ऑडियो प्रारूप भेजें।")
                .AddTranslate(LanguageENUM.Italian, "Impossibile trascrivere, prova a selezionare una lingua di trascrizione diversa /audio_language o invia un formato audio diverso.")
                .AddTranslate(LanguageENUM.Swedish, "Det gick inte att transkribera, försök att välja ett annat transkriberingsspråk /audio_language eller skicka ett annat ljudformat.")
                .AddTranslate(LanguageENUM.German, "Transkription fehlgeschlagen, bitte versuchen Sie es mit der Auswahl einer anderen Transkriptionssprache /audio_language oder senden Sie ein anderes Audioformat.")
                .AddTranslate(LanguageENUM.Polish, "Transkrypcja nie powiodła się. Spróbuj wybrać inny język transkrypcji /audio_language lub wyślij inny format audio.")
                .AddTranslate(LanguageENUM.Turkish, "Metne dönüştürülemedi, lütfen farklı bir transkripsiyon dili /audio_language seçmeyi deneyin veya farklı bir ses formatı gönderin."),
            new KeyTranslationsInitEntity(billingExceedLimit)
                .AddTranslate(LanguageENUM.Ukrainian, "Перевищено ліміт цього місяця надішліть /stats для деталей.")
                .AddTranslate(LanguageENUM.Russian, "Превышенный предел этого месяца отправьте /stats для деталей.")
                .AddTranslate(LanguageENUM.English, "This month's limit has been exceeded, send /stats for details.")
                .AddTranslate(LanguageENUM.Spanish, "Se superó el límite de este mes, envíe /stats para obtener más detalles.")
                .AddTranslate(LanguageENUM.French, "La limite de ce mois a été dépassée, envoyez /stats pour plus de détails.")
                .AddTranslate(LanguageENUM.Japanese, "今月の制限を超えました。詳細については /stats を送信してください。")
                .AddTranslate(LanguageENUM.Chinese, "已超过本月的限制，请发送 /stats 了解详情。")
                .AddTranslate(LanguageENUM.Czech, "Limit pro tento měsíc byl překročen, pro podrobnosti zašlete /stats .")
                .AddTranslate(LanguageENUM.Danish, "Denne måneds grænse er overskredet, send /stats for detaljer.")
                .AddTranslate(LanguageENUM.Hindi, "इस माह की सीमा पार हो गई है, विवरण के लिए /stats भेजें।")
                .AddTranslate(LanguageENUM.Italian, "Il limite di questo mese è stato superato, invia /stats per i dettagli.")
                .AddTranslate(LanguageENUM.Swedish, "Denna månads gräns har överskridits, skicka /stats för mer information.")
                .AddTranslate(LanguageENUM.German, "Das Limit dieses Monats wurde überschritten, senden Sie /stats für Details.")
                .AddTranslate(LanguageENUM.Polish, "Limit w tym miesiącu został przekroczony, wyślij /stats, aby uzyskać szczegółowe informacje.")
                .AddTranslate(LanguageENUM.Turkish, "Bu ayın limiti aşıldı, detaylar için /stats gönderin."),
            new KeyTranslationsInitEntity(statsMessage)

                .AddTranslate(LanguageENUM.Ukrainian, "<b>Статистика</b>\n\n" + 
                                                      "Тариф: {0}\n\n" + 
                                                      "<b>Зображення</b> {1} з {2} використано\n" + 
                                                      "<b>Символов текста для перевода</b> использовано {3} из {4}\n" + 
                                                      "<b>Аудіохвилин</b> використано {5} із {6}\n\n" + 
                                                      "Залишилося {7} днів підписки\n" + 
                                                      "Залишилося {8} хвилин підписки\n\n" +
                                                      "Підписка автоматично оновлюється кожного місяця")

                .AddTranslate(LanguageENUM.Russian, "<b>Статистика</b>\n\n" + 
                                                    "Тариф: {0}\n\n" + 
                                                    "<b>Изображения</b> {1} из {2} использованных\n" + 
                                                    "<b>Символів тексту для перекладу</b> використано {3} з {4}\n" + 
                                                    "<b>Аудио минут</b> использовано {5} из {6}\n\n" + 
                                                    "Осталось {7} дней подписки\n" + 
                                                    "Осталось {8} минут подписки\n\n" +
                                                    "Подписка автоматически обновляется каждый месяц")

                .AddTranslate(LanguageENUM.English, "<b>Statistic</b>\n\n" + 
                                                    "Plan: {0}\n\n" + 
                                                    "<b>Images</b> {1} of {2} used\n" + 
                                                    "<b>Text characters for translation</b> {3} of {4} used\n" + 
                                                    "<b>Audio minutes</b> {5} of {6} used\n\n" + 
                                                    "{7} days of subscription left\n" + 
                                                    "{8} minutes of subscription left\n\n" +
                                                    "Subscription automatically renews each month")

                .AddTranslate(LanguageENUM.Spanish, "<b>Estadística</b>\n\n" + 
                                                    "Tarifa: {0}\n\n" + 
                                                    "<b>Imágenes</b> {1} de {2} usadas\n" + 
                                                    "<b>Caracteres de texto para traducción</b> {3} de {4} utilizados\n" + 
                                                    "<b>Minutos de audio</b> {5} de {6} utilizados\n\n" + 
                                                    "Quedan {7} días de suscripción\n" + 
                                                    "Quedan {8} minutos de suscripción\n\n" +
                                                    "Mes de skin actualizado automáticamente por suscripción")

                .AddTranslate(LanguageENUM.French, "<b>Statistique</b>\n\n" + 
                                                   "Tarif : {0}\n\n" + 
                                                   "<b>Images</b> {1} sur {2} utilisées\n" + 
                                                   "<b>Caractères de texte à traduire</b> {3} sur {4} utilisés\n" + 
                                                   "<b>Minutes audio</b> {5} sur {6} utilisées\n\n" + 
                                                   "{7} jours d'abonnement restants\n" + 
                                                   "{8} minutes d'abonnement restantes\n\n" +
                                                   "Abonnement automatiquement mis à jour skin mois")

                .AddTranslate(LanguageENUM.Japanese, "<b>統計</b>\n\n" + 
                                                     "料金: {0}\n\n" + 
                                                     "<b>画像</b> {1}/{2} 使用\n" + 
                                                     "<b>翻訳用テキスト文字</b> {4} 個中 {3} 個使用\n" + 
                                                     "<b>音声時間</b> {6} 中 {5} を使用\n\n" + 
                                                     "サブスクリプションは残り {7} 日\n" + 
                                                     "{8} 分のサブスクリプションが残っています\n\n" +
                                                     "サブスクリプションは自動的にスキン月を更新します")

                .AddTranslate(LanguageENUM.Chinese, "<b>统计</b>\n\n" + 
                                                    "关税：{0}\n\n" + 
                                                    "<b>Images</b> {1} of {2} 使用了\n" + 
                                                    "<b>用于翻译的文本字符</b> 使用了 {3} 个，共 {4} 个\n" + 
                                                    "<b>音频分钟数</b>已使用 {5} 分钟，共 {6} 分钟\n\n" + 
                                                    "订阅还剩 {7} 天\n" + 
                                                    "还剩 {8} 分钟的订阅时间\n\n" +
                                                    "订阅自动更新皮肤月份")

                .AddTranslate(LanguageENUM.Czech, "<b>Statistika</b>\n\n" + 
                                                  "Tarif: {0}\n\n" + 
                                                  "<b>Obrázky</b> použité {1} z {2}\n" + 
                                                  "<b>Textové znaky pro překlad</b> Využito {3} z {4}\n" + 
                                                  "<b>Zvukové minuty</b> Využito {5} z {6}\n\n" + 
                                                  "Zbývá {7} dní předplatného\n" + 
                                                  "Zbývá {8} minut předplatného\n\n" +
                                                  "Předplatné automaticky aktualizovalo měsíc vzhledu")

                .AddTranslate(LanguageENUM.Danish, "<b>Statistik</b>\n\n" + 
                                                   "Takst: {0}\n\n" + 
                                                   "<b>Billeder</b> {1} af {2} brugt\n" + 
                                                   "<b>Teksttegn til oversættelse</b> {3} af {4} brugt\n" + 
                                                   "<b>Lydminutter</b> {5} af {6} brugt\n\n" + 
                                                   "{7} dages abonnement tilbage\n" + 
                                                   "{8} minutters abonnement tilbage\n\n" +
                                                   "Abonnement opdateret automatisk hudmåned")

                .AddTranslate(LanguageENUM.Hindi, "<b>आँकड़ा</b>\n\n" + 
                                                  "शुल्क: {0}\n\n" + 
                                                  "<b>इमेज</b> {2} में से {1} इस्तेमाल की गई\n" + 
                                                  "<b>अनुवाद के लिए पाठ वर्ण</b> {4} में से {3} का उपयोग किया गया\n" + 
                                                  "<b>ऑडियो मिनट</b> {6} में से {5} का उपयोग किया गया\n\n" + 
                                                  "{7} दिनों की सदस्‍यता शेष\n" + 
                                                  "{8} मिनट की सदस्यता बाकी है\n\n" +
                                                  "सदस्यता स्वचालित रूप से अद्यतन त्वचा माह")

                .AddTranslate(LanguageENUM.Italian, "<b>Statistica</b>\n\n" + 
                                                    "Tariffa: {0}\n\n" + 
                                                    "<b>Immagini</b> {1} di {2} usate\n" + 
                                                    "<b>Caratteri di testo per la traduzione</b> {3} di {4} utilizzati\n" + 
                                                    "<b>Minuti audio</b> {5} su {6} utilizzati\n\n" + 
                                                    "{7} giorni di abbonamento rimanenti\n" + 
                                                    "{8} minuti di abbonamento rimanenti\n\n" +
                                                    "Abbonamento aggiornato automaticamente skin mese")

                .AddTranslate(LanguageENUM.Swedish, "<b>Statistik</b>\n\n" + 
                                                    "Pris: {0}\n\n" + 
                                                    "<b>Bilder</b> {1} av {2} används\n" + 
                                                    "<b>Textecken för översättning</b> {3} av {4} används\n" + 
                                                    "<b>Ljudminuter</b> {5} av {6} används\n\n" + 
                                                    "{7} dagars prenumeration kvar\n" + 
                                                    "{8} minuters prenumeration kvar\n\n" +
                                                    "Abonnemanget uppdateras automatiskt hudmånad")

                .AddTranslate(LanguageENUM.German, "<b>Statistik</b>\n\n" + 
                                                   "Tarif: {0}\n\n" + 
                                                   "<b>Bilder</b> {1} von {2} verwendet\n" + 
                                                   "<b>Textzeichen für die Übersetzung</b> {3} von {4} verwendet\n" + 
                                                   "<b>Audiominuten</b> {5} von {6} verbraucht\n\n" + 
                                                   "{7} Tage Abonnement verbleibend\n" + 
                                                   "{8} Minuten Abonnement verbleiben\n\n" +
                                                   "Abonnement automatisch aktualisiert Skin Monat")

                .AddTranslate(LanguageENUM.Polish, "<b>Statystyki</b>\n\n" + 
                                                   "Taryfa: {0}\n\n" + 
                                                   "<b>Obrazy</b> użyto {1} z {2}\n" + 
                                                   "<b>Znaki tekstowe do tłumaczenia</b> Użyto {3} z {4}\n" + 
                                                   "<b>Wykorzystano minuty audio</b> {5} z {6}\n\n" + 
                                                   "Pozostało {7} dni subskrypcji\n" + 
                                                   "Pozostało {8} minut subskrypcji\n\n" +
                                                   "Subskrypcja automatycznie aktualizuje miesiąc skórki")

                .AddTranslate(LanguageENUM.Turkish, "<b>İstatistik</b>\n\n" + 
                                                    "Tarife: {0}\n\n" + 
                                                    "{2} resimden {1} <b>resim</b> kullanıldı\n" + 
                                                    "<b>Çeviri için metin karakterleri</b> {3} / {4} kullanıldı\n" +
                                                    "<b>Ses dakikaları</b> {5} / {6} kullanıldı\n\n" + 
                                                    "{7} günlük abonelik kaldı\n" + 
                                                    "{8} dakikalık abonelik kaldı\n\n" +
                                                    "Abonelik otomatik olarak güncellenen cilt ayı"),

            new KeyTranslationsInitEntity(contentInProcessing)
                .AddTranslate(LanguageENUM.Ukrainian, "Взято на обробку, будь ласка, зачекайте хвилинку. 😌")
                .AddTranslate(LanguageENUM.Russian, "Взято на обработку, пожалуйста, подождите немного. 😌")
                .AddTranslate(LanguageENUM.English, "Taken for processing, please wait a moment. 😌")
                .AddTranslate(LanguageENUM.Spanish, "Tomado para procesar, por favor espere un momento. 😌")
                .AddTranslate(LanguageENUM.French, "Pris pour traitement, veuillez patienter un moment. 😌")
                .AddTranslate(LanguageENUM.Japanese, "処理に時間がかかっています、しばらくお待ちください。😌")
                .AddTranslate(LanguageENUM.Chinese, "正在处理中，请稍等片刻。😌")
                .AddTranslate(LanguageENUM.Czech, "Převzato ke zpracování, chvíli prosím počkejte. 😌")
                .AddTranslate(LanguageENUM.Danish, "Optaget til behandling, vent venligst et øjeblik. 😌")
                .AddTranslate(LanguageENUM.Hindi, "प्रसंस्करण के लिए लिया गया, कृपया एक क्षण प्रतीक्षा करें। 😌")
                .AddTranslate(LanguageENUM.Italian, "Assunto per l'elaborazione, si prega di attendere un momento. 😌")
                .AddTranslate(LanguageENUM.Swedish, "Upptaget för behandling, vänligen vänta ett ögonblick. 😌")
                .AddTranslate(LanguageENUM.German, "Zur Bearbeitung angenommen, bitte warten Sie einen Moment. 😌")
                .AddTranslate(LanguageENUM.Polish, "Pobrane do przetworzenia, proszę chwilę poczekać. 😌")
                .AddTranslate(LanguageENUM.Turkish, "İşlem için alındı, lütfen bir dakika bekleyin. 😌"),
            new KeyTranslationsInitEntity(audioLanguageWarning)
                .AddTranslate(LanguageENUM.Ukrainian, "Якщо аудіо транскрипція неправильна, спробуйте вибрати аудіо мову /audio_language і надіслати знову аудіо")
                .AddTranslate(LanguageENUM.Russian, "Если аудио транскрипция неверна, попробуйте выбрать аудио язык /audio_language и отправить снова аудио")
                .AddTranslate(LanguageENUM.English, "If the audio transcription is incorrect, try to select the audio language /audio_language and send the audio again")
                .AddTranslate(LanguageENUM.Spanish, "Si la transcripción del audio es incorrecta, intente seleccionar el idioma del audio /audio_language")
                .AddTranslate(LanguageENUM.French, "Si la transcription audio est incorrecte, essayez de sélectionner la langue audio /audio_language")
                .AddTranslate(LanguageENUM.Japanese, "音声の書き起こしが正しくない場合は、音声言語 /audio_language を選択してみてください")
                .AddTranslate(LanguageENUM.Chinese, "如果音频转录不正确，请尝试选择音频语言 /audio_language")
                .AddTranslate(LanguageENUM.Czech, "Pokud je přepis zvuku nesprávný, zkuste vybrat jazyk zvuku /audio_language")
                .AddTranslate(LanguageENUM.Danish, "Hvis lydtransskriptionen er forkert, prøv at vælge lydsproget /audio_language")
                .AddTranslate(LanguageENUM.Hindi, "यदि ऑडियो ट्रांसक्रिप्शन गलत है, तो ऑडियो भाषा /audio_language का चयन करने का प्रयास करें")
                .AddTranslate(LanguageENUM.Italian, "se la trascrizione audio non è corretta, prova a selezionare la lingua audio /audio_language")
                .AddTranslate(LanguageENUM.Swedish, "Om ljudtranskriptionen är felaktig, prova att välja ljudspråket /audio_language")
                .AddTranslate(LanguageENUM.German, "Wenn die Audiotranskription nicht korrekt ist, versuchen Sie, die Audiosprache /audio_language auszuwählen")
                .AddTranslate(LanguageENUM.Polish, "Jeśli transkrypcja dźwięku jest nieprawidłowa, spróbuj wybrać język dźwięku /audio_language")
                .AddTranslate(LanguageENUM.Turkish, "Ses dökümü yanlışsa, ses dilini /audio_language seçmeyi deneyin"),
            new KeyTranslationsInitEntity(userInfoKey)
                .AddTranslate(LanguageENUM.Ukrainian, userInfoUA)
                .AddTranslate(LanguageENUM.Russian, userInfoRU)
                .AddTranslate(LanguageENUM.English, userInfoEN)
                .AddTranslate(LanguageENUM.Spanish, userInfoSP)
                .AddTranslate(LanguageENUM.French, userInfoFR)
                .AddTranslate(LanguageENUM.Japanese, userInfoJA)
                .AddTranslate(LanguageENUM.Chinese, userInfoCHINESE)
                .AddTranslate(LanguageENUM.Czech, userInfoCZHECH)
                .AddTranslate(LanguageENUM.Danish, userInfoDANISH)
                .AddTranslate(LanguageENUM.Hindi, userInfoHindi)
                .AddTranslate(LanguageENUM.Italian, userInfoItalian)
                .AddTranslate(LanguageENUM.Swedish, userInfoSwedish)
                .AddTranslate(LanguageENUM.German, userInfoGerman)
                .AddTranslate(LanguageENUM.Polish, userInfoPolish)
                .AddTranslate(LanguageENUM.Turkish, userInfoTurkish),
            //new KeyTranslationsInitEntity("")
            //    .AddTranslate(LanguageENUM.Ukrainian, "")
            //    .AddTranslate(LanguageENUM.Russian, "")
            //    .AddTranslate(LanguageENUM.English, "")
            //    .AddTranslate(LanguageENUM.Spanish, "")
            //    .AddTranslate(LanguageENUM.French, "")
            //    .AddTranslate(LanguageENUM.Japanese, "")
            //    .AddTranslate(LanguageENUM.Chinese, "")
            //    .AddTranslate(LanguageENUM.Czech, "")
            //    .AddTranslate(LanguageENUM.Danish, "")
            //    .AddTranslate(LanguageENUM.Hindi, "")
            //    .AddTranslate(LanguageENUM.Italian, "")
            //    .AddTranslate(LanguageENUM.Swedish, "")
            //    .AddTranslate(LanguageENUM.German, "")
            //    .AddTranslate(LanguageENUM.Polish, "")
            //    .AddTranslate(LanguageENUM.Turkish, ""),
        };

        var i = 1;

        var translation = data.SelectMany((x) => x.Translates.Select(q => new Translation
        {
            Id = i++,
            Key = x.Key,
            LanguageId = q.LanguageENUM,
            Translate = q.Translate
        })).ToList();

        modelBuilder.Entity<Translation>().HasData(translation);
    }
}
