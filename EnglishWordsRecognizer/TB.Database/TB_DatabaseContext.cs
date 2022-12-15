using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;

namespace TB.Database;

public class TB_DatabaseContext : DbContext
{
    public TB_DatabaseContext(DbContextOptions<TB_DatabaseContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<TelegramUser> Users { get; set; }

    public DbSet<Language> Languages { set; get; }

    public DbSet<UserSettings> UserSettings { set; get; }

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
    }
}
