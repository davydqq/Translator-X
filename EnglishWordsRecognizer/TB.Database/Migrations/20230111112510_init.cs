using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "requests");

            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.EnsureSchema(
                name: "billing");

            migrationBuilder.CreateTable(
                name: "ApiTypes",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioRequestTypes",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioRequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageRequestTypes",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    DisplayCode = table.Column<string>(type: "text", nullable: true),
                    IsSupportInteface = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportAudioTranscription = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportTargetLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportNativeLanguage = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                schema: "billing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxAnalysisPhotoCountMonth = table.Column<int>(type: "integer", nullable: false),
                    MaxAudioTranscriptionSecondsMonth = table.Column<int>(type: "integer", nullable: false),
                    MaxTranslateCharsMonth = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsCustomPlan = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUser",
                schema: "app",
                columns: table => new
                {
                    TelegramUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsBot = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    LanguageCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUser", x => x.TelegramUserId);
                });

            migrationBuilder.CreateTable(
                name: "TextRequestTypes",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TextRequestTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextRequestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextRequestTypes_TextRequestTypes_TextRequestTypeId",
                        column: x => x.TextRequestTypeId,
                        principalSchema: "requests",
                        principalTable: "TextRequestTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Translate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "app",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseRequest",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RequestCost = table.Column<double>(type: "double precision", nullable: false),
                    ApiTypeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Response = table.Column<string>(type: "jsonb", nullable: false),
                    IsSuccess = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseRequest_ApiTypes_ApiTypeId",
                        column: x => x.ApiTypeId,
                        principalSchema: "requests",
                        principalTable: "ApiTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseRequest_TelegramUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "TelegramUser",
                        principalColumn: "TelegramUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlans",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpireDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PlanId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlans_Plan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "billing",
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlans_TelegramUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "TelegramUser",
                        principalColumn: "TelegramUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NativeLanguageId = table.Column<int>(type: "integer", nullable: true),
                    TargetLanguageId = table.Column<int>(type: "integer", nullable: true),
                    InterfaceLanguageId = table.Column<int>(type: "integer", nullable: true),
                    AudioLanguageId = table.Column<int>(type: "integer", nullable: true),
                    RecognizeEnglishMeaning = table.Column<bool>(type: "boolean", nullable: false),
                    TelegramUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Language_AudioLanguageId",
                        column: x => x.AudioLanguageId,
                        principalSchema: "app",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_Language_InterfaceLanguageId",
                        column: x => x.InterfaceLanguageId,
                        principalSchema: "app",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_Language_NativeLanguageId",
                        column: x => x.NativeLanguageId,
                        principalSchema: "app",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_Language_TargetLanguageId",
                        column: x => x.TargetLanguageId,
                        principalSchema: "app",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_TelegramUser_TelegramUserId",
                        column: x => x.TelegramUserId,
                        principalSchema: "app",
                        principalTable: "TelegramUser",
                        principalColumn: "TelegramUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioRequests",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    AudioRequestTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProcessedSeconds = table.Column<long>(type: "bigint", nullable: false),
                    SecondCost = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioRequests_AudioRequestTypes_AudioRequestTypeId",
                        column: x => x.AudioRequestTypeId,
                        principalSchema: "requests",
                        principalTable: "AudioRequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioRequests_BaseRequest_Id",
                        column: x => x.Id,
                        principalSchema: "requests",
                        principalTable: "BaseRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageRequests",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ImageRequestTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageRequests_BaseRequest_Id",
                        column: x => x.Id,
                        principalSchema: "requests",
                        principalTable: "BaseRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageRequests_ImageRequestTypes_ImageRequestTypeId",
                        column: x => x.ImageRequestTypeId,
                        principalSchema: "requests",
                        principalTable: "ImageRequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextRequests",
                schema: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Texts = table.Column<string[]>(type: "jsonb", nullable: false),
                    TotalChars = table.Column<int>(type: "integer", nullable: false),
                    LanguageCodes = table.Column<string[]>(type: "jsonb", nullable: true),
                    TextRequestTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextRequests_BaseRequest_Id",
                        column: x => x.Id,
                        principalSchema: "requests",
                        principalTable: "BaseRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextRequests_TextRequestTypes_TextRequestTypeId",
                        column: x => x.TextRequestTypeId,
                        principalSchema: "requests",
                        principalTable: "TextRequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "requests",
                table: "ApiTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Google" },
                    { 2, "Azure" },
                    { 3, "Cambridge" },
                    { 4, "Thesaurus" }
                });

            migrationBuilder.InsertData(
                schema: "requests",
                table: "AudioRequestTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Transcription" });

            migrationBuilder.InsertData(
                schema: "requests",
                table: "ImageRequestTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OCR" },
                    { 2, "ImageAnalysis" }
                });

            migrationBuilder.InsertData(
                schema: "app",
                table: "Language",
                columns: new[] { "Id", "Code", "DisplayCode", "IsSupportAudioTranscription", "IsSupportInteface", "IsSupportNativeLanguage", "IsSupportTargetLanguage", "Name" },
                values: new object[,]
                {
                    { 1, "uk", "ua", true, true, true, true, "Ukrainian 🇺🇦" },
                    { 2, "ru", null, true, true, true, true, "Russian 🇷🇺" },
                    { 3, "en", null, true, true, true, true, "English 🇺🇸" },
                    { 4, "es", null, true, true, true, true, "Spanish 🇪🇸" },
                    { 5, "fr", null, true, true, true, true, "French 🇫🇷" },
                    { 6, "ja", null, true, true, true, true, "Japanese 🇯🇵" },
                    { 7, "zh-Hans", null, true, true, true, true, "Chinese 🇨🇳" },
                    { 8, "cs", null, true, true, true, true, "Czech 🇨🇿" },
                    { 9, "da", null, true, true, true, true, "Danish 🇩🇰" },
                    { 10, "hi", null, true, true, true, true, "Hindi 🇮🇳" },
                    { 11, "it", null, true, true, true, true, "Italian 🇮🇹" },
                    { 12, "sv", null, true, true, true, true, "Swedish 🇸🇪" },
                    { 13, "de", null, true, true, true, true, "German 🇩🇪" },
                    { 14, "pl", null, true, true, true, true, "Polish 🇵🇱" },
                    { 15, "tr", null, true, true, true, true, "Turkish 🇹🇷" }
                });

            migrationBuilder.InsertData(
                schema: "billing",
                table: "Plan",
                columns: new[] { "Id", "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, 30, 300, 10000, "Standart", 0.0 },
                    { 2, false, 150, 900, 50000, "Premium", 3.0 },
                    { 3, true, 2147483647, 2147483647, 2147483647, "Unlimit", 2147483647.0 }
                });

            migrationBuilder.InsertData(
                schema: "requests",
                table: "TextRequestTypes",
                columns: new[] { "Id", "Name", "TextRequestTypeId" },
                values: new object[,]
                {
                    { 1, "Translate", null },
                    { 2, "DetectLanguage", null },
                    { 3, "Synonyms", null },
                    { 4, "Meaning", null }
                });

            migrationBuilder.InsertData(
                schema: "app",
                table: "Translation",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 1, "app.languages.interfaceLanguage", 1, "Мова інтерфейсу:" },
                    { 2, "app.languages.interfaceLanguage", 2, "Язык интерфейса:" },
                    { 3, "app.languages.interfaceLanguage", 3, "Your interface language:" },
                    { 4, "app.languages.interfaceLanguage", 4, "Tu idioma de interfaz:" },
                    { 5, "app.languages.interfaceLanguage", 5, "La langue de votre interface :" },
                    { 6, "app.languages.interfaceLanguage", 6, "インターフェース言語:" },
                    { 7, "app.languages.interfaceLanguage", 7, "界面语言：" },
                    { 8, "app.languages.interfaceLanguage", 8, "Váš jazyk rozhraní:" },
                    { 9, "app.languages.interfaceLanguage", 9, "Dit grænsefladesprog:" },
                    { 10, "app.languages.interfaceLanguage", 10, "अंतरफलक भाषा:" },
                    { 11, "app.languages.interfaceLanguage", 11, "La lingua dell'interfaccia:" },
                    { 12, "app.languages.interfaceLanguage", 12, "Ditt gränssnittsspråk:" },
                    { 13, "app.languages.interfaceLanguage", 13, "Ihre Oberflächensprache:" },
                    { 14, "app.languages.interfaceLanguage", 14, "Twój język interfejsu:" },
                    { 15, "app.languages.interfaceLanguage", 15, "Arayüz diliniz:" },
                    { 16, "app.languages.established", 1, "Мови були встановлені." },
                    { 17, "app.languages.established", 2, "Языки были установлены." },
                    { 18, "app.languages.established", 3, "The languages were established." },
                    { 19, "app.languages.established", 4, "Se han establecido las lenguas." },
                    { 20, "app.languages.established", 5, "Les langues ont été définies." },
                    { 21, "app.languages.established", 6, "言語が設定されました。" },
                    { 22, "app.languages.established", 7, "设置了语言。" },
                    { 23, "app.languages.established", 8, "Jazyky byly nastaveny." },
                    { 24, "app.languages.established", 9, "Sprog blev sat." },
                    { 25, "app.languages.established", 10, "भाषाएँ निर्धारित की गईं।" },
                    { 26, "app.languages.established", 11, "Le lingue sono state impostate." },
                    { 27, "app.languages.established", 12, "Språk sattes." },
                    { 28, "app.languages.established", 13, "Sprachen wurden eingestellt." },
                    { 29, "app.languages.established", 14, "Ustawiono języki." },
                    { 30, "app.languages.established", 15, "Diller ayarlandı." },
                    { 31, "app.languages.nativeL", 1, "Основна мова:" },
                    { 32, "app.languages.nativeL", 2, "Основной язык:" },
                    { 33, "app.languages.nativeL", 3, "Main Language:" },
                    { 34, "app.languages.nativeL", 4, "Lenguaje principal:" },
                    { 35, "app.languages.nativeL", 5, "Langage principal:" },
                    { 36, "app.languages.nativeL", 6, "主要言語：" },
                    { 37, "app.languages.nativeL", 7, "主要语言：" },
                    { 38, "app.languages.nativeL", 8, "Hlavní jazyk:" },
                    { 39, "app.languages.nativeL", 9, "Hovedsprog:" },
                    { 40, "app.languages.nativeL", 10, "मुख्य भाषा:" },
                    { 41, "app.languages.nativeL", 11, "Lingua principale:" },
                    { 42, "app.languages.nativeL", 12, "Modersmål:" },
                    { 43, "app.languages.nativeL", 13, "Muttersprache:" },
                    { 44, "app.languages.nativeL", 14, "Główny język:" },
                    { 45, "app.languages.nativeL", 15, "Ana dil:" },
                    { 46, "app.languages.yourLanguages", 1, "Ваші мови" },
                    { 47, "app.languages.yourLanguages", 2, "Ваши языки" },
                    { 48, "app.languages.yourLanguages", 3, "Your languages" },
                    { 49, "app.languages.yourLanguages", 4, "Tus idiomas" },
                    { 50, "app.languages.yourLanguages", 5, "Vos langues" },
                    { 51, "app.languages.yourLanguages", 6, "あなたの言語" },
                    { 52, "app.languages.yourLanguages", 7, "你的语言" },
                    { 53, "app.languages.yourLanguages", 8, "Vaše jazyky" },
                    { 54, "app.languages.yourLanguages", 9, "Dine sprog" },
                    { 55, "app.languages.yourLanguages", 10, "आपकी भाषाएँ" },
                    { 56, "app.languages.yourLanguages", 11, "Le tue lingue" },
                    { 57, "app.languages.yourLanguages", 12, "Dina språk" },
                    { 58, "app.languages.yourLanguages", 13, "Ihre Sprachen" },
                    { 59, "app.languages.yourLanguages", 14, "Twoje języki" },
                    { 60, "app.languages.yourLanguages", 15, "Dilleriniz" },
                    { 61, "app.languages.canSend", 1, "Send text, photo, audio for translating. TODO" },
                    { 62, "app.languages.canSend", 2, "Send text, photo, audio for translating. TODO" },
                    { 63, "app.languages.canSend", 3, "Send text, photo, audio for translating. TODO" },
                    { 64, "app.languages.canSend", 4, "Send text, photo, audio for translating. TODO" },
                    { 65, "app.languages.canSend", 5, "Send text, photo, audio for translating. TODO" },
                    { 66, "app.languages.canSend", 6, "Send text, photo, audio for translating. TODO" },
                    { 67, "app.languages.canSend", 7, "Send text, photo, audio for translating. TODO" },
                    { 68, "app.languages.canSend", 8, "Send text, photo, audio for translating. TODO" },
                    { 69, "app.languages.canSend", 9, "Send text, photo, audio for translating. TODO" },
                    { 70, "app.languages.canSend", 10, "Send text, photo, audio for translating. TODO" },
                    { 71, "app.languages.canSend", 11, "Send text, photo, audio for translating. TODO" },
                    { 72, "app.languages.canSend", 12, "Send text, photo, audio for translating. TODO" },
                    { 73, "app.languages.canSend", 13, "Send text, photo, audio for translating. TODO" },
                    { 74, "app.languages.canSend", 14, "Send text, photo, audio for translating. TODO" },
                    { 75, "app.languages.canSend", 15, "Send text, photo, audio for translating. TODO" },
                    { 76, "app.images.text", 1, "<b>Текст фото</b>" },
                    { 77, "app.images.text", 2, "<b>Фото текст</b>" },
                    { 78, "app.images.text", 3, "<b>Photo text</b>" },
                    { 79, "app.images.text", 4, "<b>Foto texto</b>" },
                    { 80, "app.images.text", 5, "<b>Texte photo</b>" },
                    { 81, "app.images.text", 6, "<b>写真テキスト</b>" },
                    { 82, "app.images.text", 7, "<b>照片文字</b>" },
                    { 83, "app.images.text", 8, "<b>Text fotografie</b>" },
                    { 84, "app.images.text", 9, "<b>Fototekst</b>" },
                    { 85, "app.images.text", 10, "<b>फोटो पाठ</b>" },
                    { 86, "app.images.text", 11, "<b>Testo fotografico</b>" },
                    { 87, "app.images.text", 12, "<b>Fototext</b>" },
                    { 88, "app.images.text", 13, "<b>Fototext</b>" },
                    { 89, "app.images.text", 14, "<b>Tekst zdjęcia</b>" },
                    { 90, "app.images.text", 15, "<b>Fotoğraf metni</b>" },
                    { 91, "app.images.objects", 1, "<b>Об'єкти зображення</b>" },
                    { 92, "app.images.objects", 2, "<b>Объекты изображения</b>" },
                    { 93, "app.images.objects", 3, "<b>Image objects</b>" },
                    { 94, "app.images.objects", 4, "<b>Objetos de imagen</b>" },
                    { 95, "app.images.objects", 5, "<b>Objets images</b>" },
                    { 96, "app.images.objects", 6, "<b>画像オブジェクト</b>" },
                    { 97, "app.images.objects", 7, "<b>图像对象</b>" },
                    { 98, "app.images.objects", 8, "<b>Obrazové objekty</b>" },
                    { 99, "app.images.objects", 9, "<b>Billedobjekter</b>" },
                    { 100, "app.images.objects", 10, "<b>छवि वस्तुएं</b>" },
                    { 101, "app.images.objects", 11, "<b>Oggetti immagine</b>" },
                    { 102, "app.images.objects", 12, "<b>Bildobjekt</b>" },
                    { 103, "app.images.objects", 13, "<b>Bildobjekte</b>" },
                    { 104, "app.images.objects", 14, "<b>Obiekty obrazu</b>" },
                    { 105, "app.images.objects", 15, "<b>Görüntü nesneleri</b>" },
                    { 106, "app.images.description", 1, "<b>Опис зображення</b>" },
                    { 107, "app.images.description", 2, "<b>Описание изображения</b>" },
                    { 108, "app.images.description", 3, "<b>Image description</b>" },
                    { 109, "app.images.description", 4, "<b>Descripción de la imagen</b>" },
                    { 110, "app.images.description", 5, "<b>Description de l'image</b>" },
                    { 111, "app.images.description", 6, "<b>画像の説明</b>" },
                    { 112, "app.images.description", 7, "<b>图片描述</b>" },
                    { 113, "app.images.description", 8, "<b>Popis obrázku</b>" },
                    { 114, "app.images.description", 9, "<b>Billedbeskrivelse</b>" },
                    { 115, "app.images.description", 10, "<b>चित्र का वर्णन</b>" },
                    { 116, "app.images.description", 11, "<b>Descrizione dell'immagine</b>" },
                    { 117, "app.images.description", 12, "<b>Bildbeskrivning</b>" },
                    { 118, "app.images.description", 13, "<b>Bildbeschreibung</b>" },
                    { 119, "app.images.description", 14, "<b>Opis obrazu</b>" },
                    { 120, "app.images.description", 15, "<b>Görüntü açıklaması</b>" },
                    { 121, "app.texts.maybeMean", 1, "<b>Можливо, ви маєте на увазі</b>" },
                    { 122, "app.texts.maybeMean", 2, "<b>Может быть, вы имеете в виду</b>" },
                    { 123, "app.texts.maybeMean", 3, "<b>Maybe you mean</b>" },
                    { 124, "app.texts.maybeMean", 4, "<b>Tal vez te refieres</b>" },
                    { 125, "app.texts.maybeMean", 5, "<b>Peut-être que tu veux dire</b>" },
                    { 126, "app.texts.maybeMean", 6, "<b>多分あなたが意味する</b>" },
                    { 127, "app.texts.maybeMean", 7, "<b>也许你的意思是</b>" },
                    { 128, "app.texts.maybeMean", 8, "<b>Možná myslíš</b>" },
                    { 129, "app.texts.maybeMean", 9, "<b>Måske mener du</b>" },
                    { 130, "app.texts.maybeMean", 10, "<b>शायद आपका मतलब है</b>" },
                    { 131, "app.texts.maybeMean", 11, "<b>Forse intendi</b>" },
                    { 132, "app.texts.maybeMean", 12, "<b>Du kanske menar</b>" },
                    { 133, "app.texts.maybeMean", 13, "<b>Vielleicht meinst du</b>" },
                    { 134, "app.texts.maybeMean", 14, "<b>Może masz na myśli</b>" },
                    { 135, "app.texts.maybeMean", 15, "<b>Belki demek istiyorsun</b>" },
                    { 136, "app.languages.targetL", 1, "Мова перекладу:" },
                    { 137, "app.languages.targetL", 2, "Целевой язык:" },
                    { 138, "app.languages.targetL", 3, "Target Language:" },
                    { 139, "app.languages.targetL", 4, "Lengua meta:" },
                    { 140, "app.languages.targetL", 5, "Langue cible :" },
                    { 141, "app.languages.targetL", 6, "ターゲット言語" },
                    { 142, "app.languages.targetL", 7, "目标语言。" },
                    { 143, "app.languages.targetL", 8, "Cílový jazyk:" },
                    { 144, "app.languages.targetL", 9, "Målsprog:" },
                    { 145, "app.languages.targetL", 10, "लक्ष्य भाषा:" },
                    { 146, "app.languages.targetL", 11, "Lingua di destinazione:" },
                    { 147, "app.languages.targetL", 12, "Målspråk:" },
                    { 148, "app.languages.targetL", 13, "Zielsprache:" },
                    { 149, "app.languages.targetL", 14, "Język docelowy:" },
                    { 150, "app.languages.targetL", 15, "Hedef dil:" },
                    { 151, "app.menu.chooseNative", 1, "Виберіть мову" },
                    { 152, "app.menu.chooseNative", 2, "Выберите родной язык" },
                    { 153, "app.menu.chooseNative", 3, "Choose native language" },
                    { 154, "app.menu.chooseNative", 4, "Elija el idioma nativo" },
                    { 155, "app.menu.chooseNative", 5, "Choisissez la langue maternelle" },
                    { 156, "app.menu.chooseNative", 6, "母国語を選択" },
                    { 157, "app.menu.chooseNative", 7, "选择母语" },
                    { 158, "app.menu.chooseNative", 8, "Vyberte rodný jazyk" },
                    { 159, "app.menu.chooseNative", 9, "Vælg modersmål" },
                    { 160, "app.menu.chooseNative", 10, "अपनी मूल भाषा चुनें" },
                    { 161, "app.menu.chooseNative", 11, "Scegli la lingua madre" },
                    { 162, "app.menu.chooseNative", 12, "Välj modersmål" },
                    { 163, "app.menu.chooseNative", 13, "Muttersprache wählen" },
                    { 164, "app.menu.chooseNative", 14, "Wybierz język ojczysty" },
                    { 165, "app.menu.chooseNative", 15, "Yerel dili seçin" },
                    { 166, "app.menu.chooseTarget", 1, "Виберіть цільову мову" },
                    { 167, "app.menu.chooseTarget", 2, "Выберите целевой язык" },
                    { 168, "app.menu.chooseTarget", 3, "Choose target language" },
                    { 169, "app.menu.chooseTarget", 4, "Elija el idioma de destino" },
                    { 170, "app.menu.chooseTarget", 5, "Choisissez la langue cible" },
                    { 171, "app.menu.chooseTarget", 6, "ターゲット言語を選択" },
                    { 172, "app.menu.chooseTarget", 7, "选择目标语言" },
                    { 173, "app.menu.chooseTarget", 8, "Vyberte cílový jazyk" },
                    { 174, "app.menu.chooseTarget", 9, "Vælg målsprog" },
                    { 175, "app.menu.chooseTarget", 10, "लक्षित भाषा चुनें" },
                    { 176, "app.menu.chooseTarget", 11, "Scegli la lingua di destinazione" },
                    { 177, "app.menu.chooseTarget", 12, "Välj målspråk" },
                    { 178, "app.menu.chooseTarget", 13, "Zielsprache wählen" },
                    { 179, "app.menu.chooseTarget", 14, "Wybierz język docelowy" },
                    { 180, "app.menu.chooseTarget", 15, "Hedef dili seçin" },
                    { 181, "app.menu.englishMeaning", 1, "Показувати значення англійських слів" },
                    { 182, "app.menu.englishMeaning", 2, "Показывать значение английских слов" },
                    { 183, "app.menu.englishMeaning", 3, "Show english words meaning" },
                    { 184, "app.menu.englishMeaning", 4, "Mostrar el significado de las palabras en inglés" },
                    { 185, "app.menu.englishMeaning", 5, "Afficher le sens des mots anglais" },
                    { 186, "app.menu.englishMeaning", 6, "英単語の意味を表示" },
                    { 187, "app.menu.englishMeaning", 7, "显示英文单词的意思" },
                    { 188, "app.menu.englishMeaning", 8, "Zobrazit význam anglických slov" },
                    { 189, "app.menu.englishMeaning", 9, "Vis engelske ords betydning" },
                    { 190, "app.menu.englishMeaning", 10, "अंग्रेजी शब्दों का अर्थ दिखाएँ" },
                    { 191, "app.menu.englishMeaning", 11, "Mostra il significato delle parole inglesi" },
                    { 192, "app.menu.englishMeaning", 12, "Visa engelska ords betydelse" },
                    { 193, "app.menu.englishMeaning", 13, "Zeigen Sie die Bedeutung der englischen Wörter" },
                    { 194, "app.menu.englishMeaning", 14, "Pokaż znaczenie angielskich słów" },
                    { 195, "app.menu.englishMeaning", 15, "İngilizce kelimelerin anlamını göster" },
                    { 196, "app.menu.disabled", 1, "вимкнено" },
                    { 197, "app.menu.disabled", 2, "отключено" },
                    { 198, "app.menu.disabled", 3, "disabled" },
                    { 199, "app.menu.disabled", 4, "discapacitado" },
                    { 200, "app.menu.disabled", 5, "désactivé" },
                    { 201, "app.menu.disabled", 6, "無効" },
                    { 202, "app.menu.disabled", 7, "禁用" },
                    { 203, "app.menu.disabled", 8, "zakázáno" },
                    { 204, "app.menu.disabled", 9, "handicappet" },
                    { 205, "app.menu.disabled", 10, "अक्षम" },
                    { 206, "app.menu.disabled", 11, "disabilitato" },
                    { 207, "app.menu.disabled", 12, "Inaktiverad" },
                    { 208, "app.menu.disabled", 13, "deaktiviert" },
                    { 209, "app.menu.disabled", 14, "wyłączony" },
                    { 210, "app.menu.disabled", 15, "engelli" },
                    { 211, "app.menu.activated", 1, "активовано" },
                    { 212, "app.menu.activated", 2, "активировано" },
                    { 213, "app.menu.activated", 3, "activated" },
                    { 214, "app.menu.activated", 4, "activado" },
                    { 215, "app.menu.activated", 5, "activé" },
                    { 216, "app.menu.activated", 6, "アクティブ化" },
                    { 217, "app.menu.activated", 7, "活性" },
                    { 218, "app.menu.activated", 8, "aktivováno" },
                    { 219, "app.menu.activated", 9, "aktiveret" },
                    { 220, "app.menu.activated", 10, "सक्रिय" },
                    { 221, "app.menu.activated", 11, "attivato" },
                    { 222, "app.menu.activated", 12, "aktiveras" },
                    { 223, "app.menu.activated", 13, "aktiviert" },
                    { 224, "app.menu.activated", 14, "aktywowany" },
                    { 225, "app.menu.activated", 15, "aktif" },
                    { 226, "app.menu.chooseLang", 1, "Виберіть мову інтерфейсу" },
                    { 227, "app.menu.chooseLang", 2, "Выберите язык интерфейса" },
                    { 228, "app.menu.chooseLang", 3, "Choose interface language" },
                    { 229, "app.menu.chooseLang", 4, "Elija el idioma de la interfaz" },
                    { 230, "app.menu.chooseLang", 5, "Choisissez la langue de l'interface" },
                    { 231, "app.menu.chooseLang", 6, "インターフェイス言語の選択" },
                    { 232, "app.menu.chooseLang", 7, "选择界面语言" },
                    { 233, "app.menu.chooseLang", 8, "Vyberte jazyk rozhraní" },
                    { 234, "app.menu.chooseLang", 9, "Vælg grænsefladesprog" },
                    { 235, "app.menu.chooseLang", 10, "इंटरफ़ेस भाषा चुनें" },
                    { 236, "app.menu.chooseLang", 11, "Scegli la lingua dell'interfaccia" },
                    { 237, "app.menu.chooseLang", 12, "Välj gränssnittsspråk" },
                    { 238, "app.menu.chooseLang", 13, "Wählen Sie die Sprache der Benutzeroberfläche" },
                    { 239, "app.menu.chooseLang", 14, "Wybierz język interfejsu" },
                    { 240, "app.menu.chooseLang", 15, "Arayüz dilini seçin" },
                    { 241, "app.menu.info", 1, "Info" },
                    { 242, "app.menu.info", 2, "Info" },
                    { 243, "app.menu.info", 3, "Info" },
                    { 244, "app.menu.info", 4, "Info" },
                    { 245, "app.menu.info", 5, "Info" },
                    { 246, "app.menu.info", 6, "Info" },
                    { 247, "app.menu.info", 7, "Info" },
                    { 248, "app.menu.info", 8, "Info" },
                    { 249, "app.menu.info", 9, "Info" },
                    { 250, "app.menu.info", 10, "Info" },
                    { 251, "app.menu.info", 11, "Info" },
                    { 252, "app.menu.info", 12, "Info" },
                    { 253, "app.menu.info", 13, "Info" },
                    { 254, "app.menu.info", 14, "Info" },
                    { 255, "app.menu.info", 15, "Info" },
                    { 256, "app.audios.audioText", 1, "Аудіо-транскрипція" },
                    { 257, "app.audios.audioText", 2, "Транскрипция аудио" },
                    { 258, "app.audios.audioText", 3, "Audio transcription" },
                    { 259, "app.audios.audioText", 4, "Transcripción de audio" },
                    { 260, "app.audios.audioText", 5, "Transcription audio" },
                    { 261, "app.audios.audioText", 6, "音声トランスクリプション" },
                    { 262, "app.audios.audioText", 7, "音频转录" },
                    { 263, "app.audios.audioText", 8, "Přepis zvuku" },
                    { 264, "app.audios.audioText", 9, "Lydtransskription" },
                    { 265, "app.audios.audioText", 10, "ऑडियो ट्रांसक्रिप्शन" },
                    { 266, "app.audios.audioText", 11, "Trascrizione audio" },
                    { 267, "app.audios.audioText", 12, "Ljudtranskription" },
                    { 268, "app.audios.audioText", 13, "Audiotranskription" },
                    { 269, "app.audios.audioText", 14, "Transkrypcja dźwięku" },
                    { 270, "app.audios.audioText", 15, "Ses transkripsiyonu" },
                    { 271, "app.menu.audioLang", 1, "Виберіть мову аудіо при транскрипії" },
                    { 272, "app.menu.audioLang", 2, "Выберите язык аудио при транскрипции" },
                    { 273, "app.menu.audioLang", 3, "Select the audio language when transcribing" },
                    { 274, "app.menu.audioLang", 4, "Seleccionar el idioma del audio al transcribir" },
                    { 275, "app.menu.audioLang", 5, "Sélectionnez la langue audio lors de la transcription" },
                    { 276, "app.menu.audioLang", 6, "文字起こし時の音声言語の選択" },
                    { 277, "app.menu.audioLang", 7, "转录时选择音频语言" },
                    { 278, "app.menu.audioLang", 8, "Vyberte jazyk zvuku při přepisu" },
                    { 279, "app.menu.audioLang", 9, "Vælg lydsproget, når du transskriberer" },
                    { 280, "app.menu.audioLang", 10, "लिप्यंतरण करते समय ऑडियो भाषा का चयन करें" },
                    { 281, "app.menu.audioLang", 11, "Seleziona la lingua dell'audio durante la trascrizione" },
                    { 282, "app.menu.audioLang", 12, "Välj ljudspråk när du transkriberar" },
                    { 283, "app.menu.audioLang", 13, "Wählen Sie beim Transkribieren die Audiosprache aus" },
                    { 284, "app.menu.audioLang", 14, "Wybierz język ścieżki dźwiękowej podczas transkrypcji" },
                    { 285, "app.menu.audioLang", 15, "Yazıya dökerken ses dilini seçin" },
                    { 286, "app.languages.audioLanguageKey", 1, "Мова аудіо транскрипції:" },
                    { 287, "app.languages.audioLanguageKey", 2, "Язык аудио транскрипции:" },
                    { 288, "app.languages.audioLanguageKey", 3, "Audio transcription language:" },
                    { 289, "app.languages.audioLanguageKey", 4, "Idioma de transcripción de audio:" },
                    { 290, "app.languages.audioLanguageKey", 5, "Langue de transcription audio :" },
                    { 291, "app.languages.audioLanguageKey", 6, "音声転写言語:" },
                    { 292, "app.languages.audioLanguageKey", 7, "音频转录语言：" },
                    { 293, "app.languages.audioLanguageKey", 8, "Jazyk zvukového přepisu:" },
                    { 294, "app.languages.audioLanguageKey", 9, "Lydtransskriptionssprog:" },
                    { 295, "app.languages.audioLanguageKey", 10, "ऑडियो ट्रांसक्रिप्शन भाषा:" },
                    { 296, "app.languages.audioLanguageKey", 11, "Lingua di trascrizione audio:" },
                    { 297, "app.languages.audioLanguageKey", 12, "Språk för ljudtranskription:" },
                    { 298, "app.languages.audioLanguageKey", 13, "Sprache der Audiotranskription:" },
                    { 299, "app.languages.audioLanguageKey", 14, "Język transkrypcji dźwięku:" },
                    { 300, "app.languages.audioLanguageKey", 15, "Ses transkripsiyon dili:" },
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
                    { 405, "app.photo.tooLargeFile", 15, "Çok büyük bir dosya. 4 MB'a kadar fotoğraf kullan" },
                    { 406, "app.text.maxLength", 1, "Максимальна довжина тексту одного повідомлення не повинна перевищувати 40 тис. символів." },
                    { 407, "app.text.maxLength", 2, "Максимальная длина текста одного сообщения не должна превышать 40 тыс. символов." },
                    { 408, "app.text.maxLength", 3, "The maximum text length of one message must not exceed 40k characters." },
                    { 409, "app.text.maxLength", 4, "La longitud máxima del texto de un mensaje no debe exceder los 40k caracteres." },
                    { 410, "app.text.maxLength", 5, "La longueur maximale du texte d'un message ne doit pas dépasser 40 000 caractères" },
                    { 411, "app.text.maxLength", 6, "1 つのメッセージの最大テキスト長は 40,000 文字を超えてはなりません" },
                    { 412, "app.text.maxLength", 7, "一條消息的最大文本長度不得超過 40k 個字符" },
                    { 413, "app.text.maxLength", 8, "Maximální délka textu jedné zprávy nesmí přesáhnout 40 000 znaků" },
                    { 414, "app.text.maxLength", 9, "Den maksimale tekstlængde på én besked må ikke overstige 40.000 tegn" },
                    { 415, "app.text.maxLength", 10, "एक संदेश की अधिकतम टेक्स्ट लंबाई 40k वर्णों से अधिक नहीं होनी चाहिए" },
                    { 416, "app.text.maxLength", 11, "La lunghezza massima del testo di un messaggio non deve superare i 40k caratteri" },
                    { 417, "app.text.maxLength", 12, "Den maximala textlängden för ett meddelande får inte överstiga 40 000 tecken" },
                    { 418, "app.text.maxLength", 13, "Die maximale Textlänge einer Nachricht darf 40.000 Zeichen nicht überschreiten" },
                    { 419, "app.text.maxLength", 14, "Maksymalna długość tekstu jednej wiadomości nie może przekraczać 40 tys. znaków" },
                    { 420, "app.text.maxLength", 15, "Bir mesajın maksimum metin uzunluğu 40k karakteri geçmemelidir" },
                    { 421, "app.audio.EmptyResult", 1, "Не вдалося транскрибувати. Спробуйте вибрати іншу мову транскрибування /audio_language або надішліть інший аудіоформат." },
                    { 422, "app.audio.EmptyResult", 2, "Не удалось расшифровать. Попробуйте выбрать другой язык расшифровки /audio_language или отправьте аудио в другом формате." },
                    { 423, "app.audio.EmptyResult", 3, "Failed to transcribe, please try selecting a different transcribing language /audio_language or send a different audio format." },
                    { 424, "app.audio.EmptyResult", 4, "No se pudo transcribir, intente seleccionar un idioma de transcripción diferente /audio_language o envíe un formato de audio diferente." },
                    { 425, "app.audio.EmptyResult", 5, "Échec de la transcription, veuillez essayer de sélectionner une autre langue de transcription /audio_language ou envoyer un format audio différent." },
                    { 426, "app.audio.EmptyResult", 6, "文字起こしに失敗しました。別の文字起こし言語 /audio_language を選択するか、別の音声形式を送信してください。" },
                    { 427, "app.audio.EmptyResult", 7, "转录失败，请尝试选择不同的转录语言 /audio_language 或发送不同的音频格式。" },
                    { 428, "app.audio.EmptyResult", 8, "Přepis se nezdařil, zkuste prosím vybrat jiný jazyk přepisu /audio_language nebo pošlete jiný formát zvuku." },
                    { 429, "app.audio.EmptyResult", 9, "Kunne ikke transskriberes. Prøv at vælge et andet transskriberingssprog /audio_language eller send et andet lydformat." },
                    { 430, "app.audio.EmptyResult", 10, "लिप्यंतरण करने में विफल, कृपया एक भिन्न अनुलेखन भाषा /audio_language का चयन करने का प्रयास करें या एक भिन्न ऑडियो प्रारूप भेजें।" },
                    { 431, "app.audio.EmptyResult", 11, "Impossibile trascrivere, prova a selezionare una lingua di trascrizione diversa /audio_language o invia un formato audio diverso." },
                    { 432, "app.audio.EmptyResult", 12, "Det gick inte att transkribera, försök att välja ett annat transkriberingsspråk /audio_language eller skicka ett annat ljudformat." },
                    { 433, "app.audio.EmptyResult", 13, "Transkription fehlgeschlagen, bitte versuchen Sie es mit der Auswahl einer anderen Transkriptionssprache /audio_language oder senden Sie ein anderes Audioformat." },
                    { 434, "app.audio.EmptyResult", 14, "Transkrypcja nie powiodła się. Spróbuj wybrać inny język transkrypcji /audio_language lub wyślij inny format audio." },
                    { 435, "app.audio.EmptyResult", 15, "Metne dönüştürülemedi, lütfen farklı bir transkripsiyon dili /audio_language seçmeyi deneyin veya farklı bir ses formatı gönderin." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioRequests_AudioRequestTypeId",
                schema: "requests",
                table: "AudioRequests",
                column: "AudioRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequest_ApiTypeId",
                schema: "requests",
                table: "BaseRequest",
                column: "ApiTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseRequest_UserId",
                schema: "requests",
                table: "BaseRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageRequests_ImageRequestTypeId",
                schema: "requests",
                table: "ImageRequests",
                column: "ImageRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TextRequests_TextRequestTypeId",
                schema: "requests",
                table: "TextRequests",
                column: "TextRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TextRequestTypes_TextRequestTypeId",
                schema: "requests",
                table: "TextRequestTypes",
                column: "TextRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_LanguageId",
                schema: "app",
                table: "Translation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_PlanId",
                schema: "app",
                table: "UserPlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_UserId",
                schema: "app",
                table: "UserPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_AudioLanguageId",
                schema: "app",
                table: "UserSettings",
                column: "AudioLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_InterfaceLanguageId",
                schema: "app",
                table: "UserSettings",
                column: "InterfaceLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_NativeLanguageId",
                schema: "app",
                table: "UserSettings",
                column: "NativeLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_TargetLanguageId",
                schema: "app",
                table: "UserSettings",
                column: "TargetLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_TelegramUserId",
                schema: "app",
                table: "UserSettings",
                column: "TelegramUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioRequests",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "ImageRequests",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "TextRequests",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "Translation",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserPlans",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserSettings",
                schema: "app");

            migrationBuilder.DropTable(
                name: "AudioRequestTypes",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "ImageRequestTypes",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "BaseRequest",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "TextRequestTypes",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "Plan",
                schema: "billing");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "app");

            migrationBuilder.DropTable(
                name: "ApiTypes",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "TelegramUser",
                schema: "app");
        }
    }
}
