using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;
using TB.Database.Initing;

namespace TB.Database;

public class TBDatabaseContext : DbContext
{
    public TBDatabaseContext(DbContextOptions<TBDatabaseContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<TelegramUser> Users { get; set; }

    public DbSet<Language> Languages { set; get; }

    public DbSet<UserSettings> UserSettings { set; get; }

    public DbSet<Translation> Translations { set; get; }


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

        modelBuilder.Entity<Language>().HasData(
                new Language { 
                    Id = LanguageENUM.Ukrainian, 
                    Name = SupportedLanguages.Ukrainian, 
                    Code = "uk",
                    DisplayName = "ua",
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
        var languagesSettedKey = "app.languages.established";
        var languageYourLanguagesKey = "app.languages.yourLanguages";
        var nativeLanguageKey = "app.languages.nativeL";
        var targetLanguageKey = "app.languages.targetL";
        var canSendKey = "app.languages.canSend";

        // IMAGES
        var textImageKey = "app.images.text";
        var descriptionImageKey = "app.images.description";
        var objectsImageKey = "app.images.objects";

        // TEXTS
        var textMaybeMeanKey = "app.texts.maybeMean";

        // Audios
        var audioText = "app.audios.audioText";

        // MENU
        var menuChooseNativeKey = "app.menu.chooseNative";
        var menuChooseTargetKey = "app.menu.chooseTarget";
        var menuEnglishMeaningKey = "app.menu.englishMeaning";
        var menuDisable = "app.menu.disabled";
        var menuActivated = "app.menu.activated";
        var menuChooseLang = "app.menu.chooseLang";
        var menuInfoKey = "app.menu.info";
        var menuAudioLangKey = "app.menu.audioLang";

        var data = new List<KeyTranslationsInitEntity>
        {
            new KeyTranslationsInitEntity(interfaceKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Мова інтерфейсу:")
                .AddTranslate(LanguageENUM.Russian, "Язык интерфейса:")
                .AddTranslate(LanguageENUM.English, "Your interface language:")
                .AddTranslate(LanguageENUM.Spanish, "Tu idioma de interfaz:")
                .AddTranslate(LanguageENUM.French, "La langue de votre interface :")
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
                .AddTranslate(LanguageENUM.Ukrainian, "Мови були встановлені.")
                .AddTranslate(LanguageENUM.Russian, "Языки были установлены.")
                .AddTranslate(LanguageENUM.English, "The languages were established.")
                .AddTranslate(LanguageENUM.Spanish, "Se han establecido las lenguas.")
                .AddTranslate(LanguageENUM.French, "Les langues ont été définies.")
                .AddTranslate(LanguageENUM.Japanese, "言語が設定されました。")
                .AddTranslate(LanguageENUM.Chinese, "设置了语言。")
                .AddTranslate(LanguageENUM.Czech, "Jazyky byly nastaveny.")
                .AddTranslate(LanguageENUM.Danish, "Sprog blev sat.")
                .AddTranslate(LanguageENUM.Hindi, "भाषाएँ निर्धारित की गईं।")
                .AddTranslate(LanguageENUM.Italian, "Le lingue sono state impostate.")
                .AddTranslate(LanguageENUM.Swedish, "Språk sattes.")
                .AddTranslate(LanguageENUM.German, "Sprachen wurden eingestellt.")
                .AddTranslate(LanguageENUM.Polish, "Ustawiono języki.")
                .AddTranslate(LanguageENUM.Turkish, "Diller ayarlandı."),
            new KeyTranslationsInitEntity(nativeLanguageKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Основна мова:")
                .AddTranslate(LanguageENUM.Russian, "Основной язык:")
                .AddTranslate(LanguageENUM.English, "Main Language:")
                .AddTranslate(LanguageENUM.Spanish, "Lenguaje principal:")
                .AddTranslate(LanguageENUM.French, "Langage principal:")
                .AddTranslate(LanguageENUM.Japanese, "主要言語：")
                .AddTranslate(LanguageENUM.Chinese, "主要语言：")
                .AddTranslate(LanguageENUM.Czech, "Hlavní jazyk:")
                .AddTranslate(LanguageENUM.Danish, "Hovedsprog:")
                .AddTranslate(LanguageENUM.Hindi, "मुख्य भाषा:")
                .AddTranslate(LanguageENUM.Italian, "Lingua principale:")
                .AddTranslate(LanguageENUM.Swedish, "Modersmål:")
                .AddTranslate(LanguageENUM.German, "Muttersprache:")
                .AddTranslate(LanguageENUM.Polish, "Główny język:")
                .AddTranslate(LanguageENUM.Turkish, "Ana dil:"),
            new KeyTranslationsInitEntity(languageYourLanguagesKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Ваші мови")
                .AddTranslate(LanguageENUM.Russian, "Ваши языки")
                .AddTranslate(LanguageENUM.English, "Your languages")
                .AddTranslate(LanguageENUM.Spanish, "Tus idiomas")
                .AddTranslate(LanguageENUM.French, "Vos langues")
                .AddTranslate(LanguageENUM.Japanese, "あなたの言語")
                .AddTranslate(LanguageENUM.Chinese, "你的语言")
                .AddTranslate(LanguageENUM.Czech, "Vaše jazyky")
                .AddTranslate(LanguageENUM.Danish, "Dine sprog")
                .AddTranslate(LanguageENUM.Hindi, "आपकी भाषाएँ")
                .AddTranslate(LanguageENUM.Italian, "Le tue lingue")
                .AddTranslate(LanguageENUM.Swedish, "Dina språk")
                .AddTranslate(LanguageENUM.German, "Ihre Sprachen")
                .AddTranslate(LanguageENUM.Polish, "Twoje języki")
                .AddTranslate(LanguageENUM.Turkish, "Dilleriniz"),
            new KeyTranslationsInitEntity(canSendKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Russian, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.English, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Spanish, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.French, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Japanese, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Chinese, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Czech, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Danish, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Hindi, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Italian, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Swedish, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.German, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Polish, "Send text, photo, audio for translating. TODO")
                .AddTranslate(LanguageENUM.Turkish, "Send text, photo, audio for translating. TODO"),
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
            new KeyTranslationsInitEntity(targetLanguageKey)
                .AddTranslate(LanguageENUM.Ukrainian, "Мова перекладу:")
                .AddTranslate(LanguageENUM.Russian, "Целевой язык:")
                .AddTranslate(LanguageENUM.English, "Target Language:")
                .AddTranslate(LanguageENUM.Spanish, "Lengua meta:")
                .AddTranslate(LanguageENUM.French, "Langue cible :")
                .AddTranslate(LanguageENUM.Japanese, "ターゲット言語")
                .AddTranslate(LanguageENUM.Chinese, "目标语言。")
                .AddTranslate(LanguageENUM.Czech, "Cílový jazyk:")
                .AddTranslate(LanguageENUM.Danish, "Målsprog:")
                .AddTranslate(LanguageENUM.Hindi, "लक्ष्य भाषा:")
                .AddTranslate(LanguageENUM.Italian, "Lingua di destinazione:")
                .AddTranslate(LanguageENUM.Swedish, "Målspråk:")
                .AddTranslate(LanguageENUM.German, "Zielsprache:")
                .AddTranslate(LanguageENUM.Polish, "Język docelowy:")
                .AddTranslate(LanguageENUM.Turkish, "Hedef dil:"),
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
                .AddTranslate(LanguageENUM.Ukrainian, "Info")
                .AddTranslate(LanguageENUM.Russian, "Info")
                .AddTranslate(LanguageENUM.English, "Info")
                .AddTranslate(LanguageENUM.Spanish, "Info")
                .AddTranslate(LanguageENUM.French, "Info")
                .AddTranslate(LanguageENUM.Japanese, "Info")
                .AddTranslate(LanguageENUM.Chinese, "Info")
                .AddTranslate(LanguageENUM.Czech, "Info")
                .AddTranslate(LanguageENUM.Danish, "Info")
                .AddTranslate(LanguageENUM.Hindi, "Info")
                .AddTranslate(LanguageENUM.Italian, "Info")
                .AddTranslate(LanguageENUM.Swedish, "Info")
                .AddTranslate(LanguageENUM.German, "Info")
                .AddTranslate(LanguageENUM.Polish, "Info")
                .AddTranslate(LanguageENUM.Turkish, "Info"),
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
