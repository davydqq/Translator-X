using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;

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
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Language>()
            .HasMany(m => m.UserSettingsTargetLangs)
            .WithOne(t => t.TargetLanguage)
            .HasForeignKey(m => m.TargetLanguageId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Language>()
            .HasMany(m => m.UserSettingsInterfaceLangs)
            .WithOne(t => t.InterfaceLanguage)
            .HasForeignKey(m => m.InterfaceLanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Language>().HasData(
                new Language { 
                    Id = LanguageENUM.Ukrainian, 
                    Name = SupportedLanguages.Ukrainian, 
                    Code = "uk",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language
                {
                    Id = LanguageENUM.Russian,
                    Name = SupportedLanguages.Russian,
                    Code = "ru",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.English, 
                    Name = SupportedLanguages.English, 
                    Code = "en",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language
                {
                    Id = LanguageENUM.Spanish,
                    Name = SupportedLanguages.Spanish,
                    Code = "es",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.French, 
                    Name = SupportedLanguages.French, 
                    Code = "fr",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Japanese, 
                    Name = SupportedLanguages.Japanese, 
                    Code = "ja",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Chinese, 
                    Name = SupportedLanguages.Chinese, 
                    Code = "zh-Hans",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Czech, 
                    Name = SupportedLanguages.Czech, 
                    Code = "cs",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Danish, 
                    Name = SupportedLanguages.Danish, 
                    Code = "da",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Hindi, 
                    Name = SupportedLanguages.Hindi, 
                    Code = "hi",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Italian, 
                    Name = SupportedLanguages.Italian, 
                    Code = "it",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Swedish, 
                    Name = SupportedLanguages.Swedish, 
                    Code = "sv",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.German, 
                    Name = SupportedLanguages.German, 
                    Code = "de",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Polish, 
                    Name = SupportedLanguages.Polish, 
                    Code = "pl",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                },
                new Language { 
                    Id = LanguageENUM.Turkish, 
                    Name = SupportedLanguages.Turkish, 
                    Code = "tr",
                    IsSupportInteface = true,
                    IsSupportNativeLanguage = true,
                    IsSupportTargetLanguage = true,
                }
            );

        InitTranslations(modelBuilder);
    }

    private void InitTranslations(ModelBuilder modelBuilder)
    {
        var interfaceKey = "app.languages.interfaceLanguage";
        var languagesSettedKey = "app.languages.established";
        var languageYourLanguagesKey = "app.languages.yourLanguages";
        var nativeLanguageKey = "app.languages.nativeL";
        var targetLanguageKey = "app.languages.targetL";
        var canSendKey = "app.languages.canSend";

        var textImageKey = "app.images.text";
        var descriptionImageKey = "app.images.description";
        var objectsImageKey = "app.images.objects";

        var textMaybeMeanKey = "app.texts.maybeMean";

        modelBuilder.Entity<Translation>().HasData(
            new Translation { Id = 1, Key = interfaceKey, LanguageId = LanguageENUM.Ukrainian, Translate = "Мова інтерфейсу:" },
            new Translation { Id = 2, Key = interfaceKey, LanguageId = LanguageENUM.Russian, Translate = "Язык интерфейса:" },
            new Translation { Id = 3, Key = interfaceKey, LanguageId = LanguageENUM.English, Translate = "Your interface language:" },
            new Translation { Id = 4, Key = interfaceKey, LanguageId = LanguageENUM.Spanish, Translate = "Tu idioma de interfaz:" },
            new Translation { Id = 5, Key = interfaceKey, LanguageId = LanguageENUM.French, Translate = "La langue de votre interface :" },
            new Translation { Id = 6, Key = interfaceKey, LanguageId = LanguageENUM.Japanese, Translate = "" },
            new Translation { Id = 7, Key = interfaceKey, LanguageId = LanguageENUM.Chinese, Translate = "" },
            new Translation { Id = 8, Key = interfaceKey, LanguageId = LanguageENUM.Czech, Translate = "Váš jazyk rozhraní:" },
            new Translation { Id = 9, Key = interfaceKey, LanguageId = LanguageENUM.Danish, Translate = "Dit grænsefladesprog:" },
            new Translation { Id = 10, Key = interfaceKey, LanguageId = LanguageENUM.Hindi, Translate = "" },
            new Translation { Id = 11, Key = interfaceKey, LanguageId = LanguageENUM.Italian, Translate = "La lingua dell'interfaccia:" },
            new Translation { Id = 12, Key = interfaceKey, LanguageId = LanguageENUM.Swedish, Translate = "Ditt gränssnittsspråk:" },
            new Translation { Id = 13, Key = interfaceKey, LanguageId = LanguageENUM.German, Translate = "Ihre Oberflächensprache:" },
            new Translation { Id = 14, Key = interfaceKey, LanguageId = LanguageENUM.Polish, Translate = "Twój język interfejsu:" },
            new Translation { Id = 15, Key = interfaceKey, LanguageId = LanguageENUM.Turkish, Translate = "Arayüz diliniz:" },
            //
            new Translation { Id = 16, Key = languagesSettedKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 17, Key = languagesSettedKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 18, Key = languagesSettedKey, LanguageId = LanguageENUM.English, Translate = "The languages were established." },
            new Translation { Id = 19, Key = languagesSettedKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 20, Key = languagesSettedKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 21, Key = languagesSettedKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 22, Key = languagesSettedKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 23, Key = languagesSettedKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 24, Key = languagesSettedKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 25, Key = languagesSettedKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 26, Key = languagesSettedKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 27, Key = languagesSettedKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 28, Key = languagesSettedKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 29, Key = languagesSettedKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 30, Key = languagesSettedKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 31, Key = nativeLanguageKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 32, Key = nativeLanguageKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 33, Key = nativeLanguageKey, LanguageId = LanguageENUM.English, Translate = "Native Language:" },
            new Translation { Id = 34, Key = nativeLanguageKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 35, Key = nativeLanguageKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 36, Key = nativeLanguageKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 37, Key = nativeLanguageKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 38, Key = nativeLanguageKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 39, Key = nativeLanguageKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 40, Key = nativeLanguageKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 41, Key = nativeLanguageKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 42, Key = nativeLanguageKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 43, Key = nativeLanguageKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 44, Key = nativeLanguageKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 45, Key = nativeLanguageKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 46, Key = targetLanguageKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 47, Key = targetLanguageKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 48, Key = targetLanguageKey, LanguageId = LanguageENUM.English, Translate = "Target Language:" },
            new Translation { Id = 49, Key = targetLanguageKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 50, Key = targetLanguageKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 51, Key = targetLanguageKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 52, Key = targetLanguageKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 53, Key = targetLanguageKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 54, Key = targetLanguageKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 55, Key = targetLanguageKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 56, Key = targetLanguageKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 57, Key = targetLanguageKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 58, Key = targetLanguageKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 59, Key = targetLanguageKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 60, Key = targetLanguageKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 61, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 62, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 63, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.English, Translate = "Your languages" },
            new Translation { Id = 64, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 65, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 66, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 67, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 68, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 69, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 70, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 71, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 72, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 73, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 74, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 75, Key = languageYourLanguagesKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 76, Key = canSendKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 77, Key = canSendKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 78, Key = canSendKey, LanguageId = LanguageENUM.English, Translate = "Send text, photo, audio for translating." },
            new Translation { Id = 79, Key = canSendKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 80, Key = canSendKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 81, Key = canSendKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 82, Key = canSendKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 83, Key = canSendKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 84, Key = canSendKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 85, Key = canSendKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 86, Key = canSendKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 87, Key = canSendKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 88, Key = canSendKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 89, Key = canSendKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 90, Key = canSendKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 91, Key = textImageKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 92, Key = textImageKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 93, Key = textImageKey, LanguageId = LanguageENUM.English, Translate = "<b>Text on photo</b>" },
            new Translation { Id = 94, Key = textImageKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 95, Key = textImageKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 96, Key = textImageKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 97, Key = textImageKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 98, Key = textImageKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 99, Key = textImageKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 100, Key = textImageKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 101, Key = textImageKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 102, Key = textImageKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 103, Key = textImageKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 104, Key = textImageKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 105, Key = textImageKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 106, Key = objectsImageKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 107, Key = objectsImageKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 108, Key = objectsImageKey, LanguageId = LanguageENUM.English, Translate = "<b>Image objects</b>" },
            new Translation { Id = 109, Key = objectsImageKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 110, Key = objectsImageKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 111, Key = objectsImageKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 112, Key = objectsImageKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 113, Key = objectsImageKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 114, Key = objectsImageKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 115, Key = objectsImageKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 116, Key = objectsImageKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 117, Key = objectsImageKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 118, Key = objectsImageKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 119, Key = objectsImageKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 120, Key = objectsImageKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 121, Key = descriptionImageKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 122, Key = descriptionImageKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 123, Key = descriptionImageKey, LanguageId = LanguageENUM.English, Translate = "<b>Image description</b>" },
            new Translation { Id = 124, Key = descriptionImageKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 125, Key = descriptionImageKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 126, Key = descriptionImageKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 127, Key = descriptionImageKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 128, Key = descriptionImageKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 129, Key = descriptionImageKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 130, Key = descriptionImageKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 131, Key = descriptionImageKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 132, Key = descriptionImageKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 133, Key = descriptionImageKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 134, Key = descriptionImageKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 135, Key = descriptionImageKey, LanguageId = LanguageENUM.Turkish, Translate = "" },
            //
            new Translation { Id = 136, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Ukrainian, Translate = "" },
            new Translation { Id = 137, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Russian, Translate = "" },
            new Translation { Id = 138, Key = textMaybeMeanKey, LanguageId = LanguageENUM.English, Translate = "<b>Maybe you mean</b>" },
            new Translation { Id = 139, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Spanish, Translate = "" },
            new Translation { Id = 140, Key = textMaybeMeanKey, LanguageId = LanguageENUM.French, Translate = "" },
            new Translation { Id = 141, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Japanese, Translate = "1" },
            new Translation { Id = 142, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Chinese, Translate = "1" },
            new Translation { Id = 143, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Czech, Translate = "" },
            new Translation { Id = 144, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Danish, Translate = "" },
            new Translation { Id = 145, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Hindi, Translate = "1" },
            new Translation { Id = 146, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Italian, Translate = "" },
            new Translation { Id = 147, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Swedish, Translate = "" },
            new Translation { Id = 148, Key = textMaybeMeanKey, LanguageId = LanguageENUM.German, Translate = "" },
            new Translation { Id = 149, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Polish, Translate = "" },
            new Translation { Id = 150, Key = textMaybeMeanKey, LanguageId = LanguageENUM.Turkish, Translate = "" }
        );
    }
}
