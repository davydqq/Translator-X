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
                    IsCustomPlan = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false)
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
                    UserPlanId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_BaseRequest_UserPlans_UserPlanId",
                        column: x => x.UserPlanId,
                        principalSchema: "app",
                        principalTable: "UserPlans",
                        principalColumn: "Id",
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
                columns: new[] { "Id", "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price", "Priority" },
                values: new object[,]
                {
                    { 1, true, 2147483647, 2147483647, 2147483647, "Unlimit", 2147483647.0, 1 },
                    { 2, false, 30, 300, 10000, "Standart", 0.0, 1000 },
                    { 3, false, 150, 900, 50000, "Premium", 3.0, 999 },
                    { 4, false, 500, 5000, 200000, "Premium +", 11.0, 998 }
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
                    { 5, "app.languages.interfaceLanguage", 5, "La langue de votre interface:" },
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
                    { 16, "app.languages.established", 1, "Мови були встановлені.\n\n<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\nНадішліть /interface_language, щоб змінити мову інтерфейсу\n\n<b>Надішліть фотографії та отримайте </b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- Аудіо транскрипцію\n\n<b>Бот підтримує «відповіді» та «пересилання» повідомлень.</b>\n\n<b>Ваші мови</b>\nОсновна мова: {0}\nМова перекладу: {1}" },
                    { 17, "app.languages.established", 2, "Языки были установлены.\n\n<b>Возможности бота</b>\n\nОтправьте текст для автоматического перевода на выбранный язык.\n\nОтправьте /meaning_english, чтобы показывать английское значение и синоними.\nОтправьте /interface_language, чтобы изменить язык интерфейса\n\n<b>Отправьте фотографии и получите </b>\n- Текст с фото\n- Все объекты с фото с переводом\n- Краткое описание фото, если возможно\n\n<b>Отправьте аудио и получите</b>\n- Аудио транскрипцию\n\n<b>Бот поддерживает 'ответы' и 'пересылки' сообщений.</b>\n\n<b>Ваши языки</b>\nОсновной язык: {0}\nЦелевой язык: {1}" },
                    { 18, "app.languages.established", 3, "The languages were established.\n\n<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nSend /meaning_english to enable show English meaning and synonyms for the words.\nSend /interface_language to change the interface language\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audio\n\n<b>Bot support 'replies' and 'forwards' messages.</b>\n\n<b>Your languages</b>\nMain Language: {0}\nTarget Language: {1}" },
                    { 19, "app.languages.established", 4, "Se han establecido las lenguas.\n\n<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\nEnvía /interface_language para cambiar el idioma de la interfaz\n\n<b>Envíe fotos y obtenga </b>\n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- La transcripción del audio\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>\n\nb>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}" },
                    { 20, "app.languages.established", 5, "Les langues ont été définies.\n\n<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\nEnvoyez /interface_language pour changer la langue de l'interface\n\n<b>Soumettez des photos et obtenez </b>\n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio\n\n<b>Le bot prend en charge les messages 'répondre' et 'transférer'.</b>\n\n<b>Vos langues</b>\nLangage principal: {0}\nLangue cible: {1}" },
                    { 21, "app.languages.established", 6, "言語が設定されました。\n\n<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\nインターフェイス言語を変更するには、/interface_language を送信します\n\n<b>写真を送信して </b> を入手してください\n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし\n\n<b>ボットはメッセージの「返信」と「転送」をサポートします。</b>\n\n<b>あなたの言語</b>\n主要言語：{0}\nターゲット言語: {1}" },
                    { 22, "app.languages.established", 7, "设置了语言。\n\n<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n发送 /interface_language 更改界面语言\n\n<b>提交照片并获取</b>\n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录\n\n<b>Bot 支持“回复”和“转发”消息。</b>\n\n<b>你的语言</b>\n主要语言： {0}\n选择母语: {1}" },
                    { 23, "app.languages.established", 8, "Jazyky byly nastaveny.\n\n<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\nPro změnu jazyka rozhraní odešlete /interface_language\n\n<b>Odešlete fotografie a získejte</b>\n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- Zvukový přepis\n\n<b>Bot podporuje „odpovědi“ a „přeposílání“ zpráv.</b>\n\n<b>Vaše jazyky</b>\nHlavní jazyk: {0}\nCílový jazyk: {1}" },
                    { 24, "app.languages.established", 9, "Sprog blev sat.\n\n<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\nSend /interface_language for at ændre grænsefladesproget\n\n<b>Indsend billeder og få </b>\n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- Lydtransskription\n\n<b>Bot understøtter 'svar' og 'videresendelser'-meddelelser.</b>\n\n<b>Dine sprog</b>\nHovedsprog: {0}\nMålsprog: {1}" },
                    { 25, "app.languages.established", 10, "भाषाएँ निर्धारित की गईं।\n\n<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\nइंटरफ़ेस भाषा बदलने के लिए /interface_language भेजें\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें</b>\n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन\n\n<b>बॉट 'जवाब' और 'फॉरवर्ड' संदेशों का समर्थन करता है।</b>\n\n<b>आपकी भाषाएँ</b>\nमुख्य भाषा: {0}\nलक्ष्य भाषा: {1}" },
                    { 26, "app.languages.established", 11, "Le lingue sono state impostate.\n\n<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\nInvia /interface_language per cambiare la lingua dell'interfaccia\n\n<b>Invia foto e ottieni </b>\n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- Trascrizione audio\n\n<b>Il bot supporta i messaggi di 'risposta' e 'inoltro'.</b>\n\n<b>Le tue lingue</b>\nLingua principale: {0}\nLingua di destinazione: {1}" },
                    { 27, "app.languages.established", 12, "Språk sattes.\n\n<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\nSkicka /interface_language för att ändra gränssnittsspråket\n\n<b>Skicka in foton och få </b>\n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- Ljudtranskription\n\n<b>Bot stöder 'svar' och 'vidarebefordrar' meddelanden.</b>\n\n<b>Dina språk</b>\nModersmål: {0}\nMålspråk: {1}" },
                    { 28, "app.languages.established", 13, "Sprachen wurden eingestellt.\n\n<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\nSenden Sie /interface_language, um die Sprache der Benutzeroberfläche zu ändern\n\n<b>Senden Sie Fotos und erhalten Sie</b>\n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten\n\n<b>Bot unterstützt 'Antworten' und 'Weiterleiten' von Nachrichten.</b>\n\n<b>Ihre Sprachen</b>\nMuttersprache: {0}\nZielsprache: {1}" },
                    { 29, "app.languages.established", 14, "Ustawiono języki.\n\n<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\nWyślij /interface_language, aby zmienić język interfejsu\n\n<b>Prześlij zdjęcia i uzyskaj </b>\n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- Transkrypcję dźwięku\n\n<b>Bot obsługuje 'odpowiedzi' i 'przekazuje dalej' wiadomości.</b>\n\n<b>Twoje języki</b>\nGłówny język: {0}\nJęzyk docelowy: {1}" },
                    { 30, "app.languages.established", 15, "Diller ayarlandı.\n\n<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\nArayüz dilini değiştirmek için /interface_language gönderin\n\n<b>Fotoğraf gönderin ve </b>\n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- Sesli transkripsiyonu alın\n\n<b>Bot desteği 'yanıtlar' ve 'iletilen' mesajlar.</b>\n\n<b>Dilleriniz</b>\nAna dil: {0}\nHedef dil: {1}" },
                    { 31, "app.images.text", 1, "<b>Текст фото</b>" },
                    { 32, "app.images.text", 2, "<b>Фото текст</b>" },
                    { 33, "app.images.text", 3, "<b>Photo text</b>" },
                    { 34, "app.images.text", 4, "<b>Foto texto</b>" },
                    { 35, "app.images.text", 5, "<b>Texte photo</b>" },
                    { 36, "app.images.text", 6, "<b>写真テキスト</b>" },
                    { 37, "app.images.text", 7, "<b>照片文字</b>" },
                    { 38, "app.images.text", 8, "<b>Text fotografie</b>" },
                    { 39, "app.images.text", 9, "<b>Fototekst</b>" },
                    { 40, "app.images.text", 10, "<b>फोटो पाठ</b>" },
                    { 41, "app.images.text", 11, "<b>Testo fotografico</b>" },
                    { 42, "app.images.text", 12, "<b>Fototext</b>" },
                    { 43, "app.images.text", 13, "<b>Fototext</b>" },
                    { 44, "app.images.text", 14, "<b>Tekst zdjęcia</b>" },
                    { 45, "app.images.text", 15, "<b>Fotoğraf metni</b>" },
                    { 46, "app.images.objects", 1, "<b>Об'єкти зображення</b>" },
                    { 47, "app.images.objects", 2, "<b>Объекты изображения</b>" },
                    { 48, "app.images.objects", 3, "<b>Image objects</b>" },
                    { 49, "app.images.objects", 4, "<b>Objetos de imagen</b>" },
                    { 50, "app.images.objects", 5, "<b>Objets images</b>" },
                    { 51, "app.images.objects", 6, "<b>画像オブジェクト</b>" },
                    { 52, "app.images.objects", 7, "<b>图像对象</b>" },
                    { 53, "app.images.objects", 8, "<b>Obrazové objekty</b>" },
                    { 54, "app.images.objects", 9, "<b>Billedobjekter</b>" },
                    { 55, "app.images.objects", 10, "<b>छवि वस्तुएं</b>" },
                    { 56, "app.images.objects", 11, "<b>Oggetti immagine</b>" },
                    { 57, "app.images.objects", 12, "<b>Bildobjekt</b>" },
                    { 58, "app.images.objects", 13, "<b>Bildobjekte</b>" },
                    { 59, "app.images.objects", 14, "<b>Obiekty obrazu</b>" },
                    { 60, "app.images.objects", 15, "<b>Görüntü nesneleri</b>" },
                    { 61, "app.images.description", 1, "<b>Опис зображення</b>" },
                    { 62, "app.images.description", 2, "<b>Описание изображения</b>" },
                    { 63, "app.images.description", 3, "<b>Image description</b>" },
                    { 64, "app.images.description", 4, "<b>Descripción de la imagen</b>" },
                    { 65, "app.images.description", 5, "<b>Description de l'image</b>" },
                    { 66, "app.images.description", 6, "<b>画像の説明</b>" },
                    { 67, "app.images.description", 7, "<b>图片描述</b>" },
                    { 68, "app.images.description", 8, "<b>Popis obrázku</b>" },
                    { 69, "app.images.description", 9, "<b>Billedbeskrivelse</b>" },
                    { 70, "app.images.description", 10, "<b>चित्र का वर्णन</b>" },
                    { 71, "app.images.description", 11, "<b>Descrizione dell'immagine</b>" },
                    { 72, "app.images.description", 12, "<b>Bildbeskrivning</b>" },
                    { 73, "app.images.description", 13, "<b>Bildbeschreibung</b>" },
                    { 74, "app.images.description", 14, "<b>Opis obrazu</b>" },
                    { 75, "app.images.description", 15, "<b>Görüntü açıklaması</b>" },
                    { 76, "app.texts.maybeMean", 1, "<b>Можливо, ви маєте на увазі</b>" },
                    { 77, "app.texts.maybeMean", 2, "<b>Может быть, вы имеете в виду</b>" },
                    { 78, "app.texts.maybeMean", 3, "<b>Maybe you mean</b>" },
                    { 79, "app.texts.maybeMean", 4, "<b>Tal vez te refieres</b>" },
                    { 80, "app.texts.maybeMean", 5, "<b>Peut-être que tu veux dire</b>" },
                    { 81, "app.texts.maybeMean", 6, "<b>多分あなたが意味する</b>" },
                    { 82, "app.texts.maybeMean", 7, "<b>也许你的意思是</b>" },
                    { 83, "app.texts.maybeMean", 8, "<b>Možná myslíš</b>" },
                    { 84, "app.texts.maybeMean", 9, "<b>Måske mener du</b>" },
                    { 85, "app.texts.maybeMean", 10, "<b>शायद आपका मतलब है</b>" },
                    { 86, "app.texts.maybeMean", 11, "<b>Forse intendi</b>" },
                    { 87, "app.texts.maybeMean", 12, "<b>Du kanske menar</b>" },
                    { 88, "app.texts.maybeMean", 13, "<b>Vielleicht meinst du</b>" },
                    { 89, "app.texts.maybeMean", 14, "<b>Może masz na myśli</b>" },
                    { 90, "app.texts.maybeMean", 15, "<b>Belki demek istiyorsun</b>" },
                    { 91, "app.menu.chooseNative", 1, "Виберіть мову" },
                    { 92, "app.menu.chooseNative", 2, "Выберите родной язык" },
                    { 93, "app.menu.chooseNative", 3, "Choose native language" },
                    { 94, "app.menu.chooseNative", 4, "Elija el idioma nativo" },
                    { 95, "app.menu.chooseNative", 5, "Choisissez la langue maternelle" },
                    { 96, "app.menu.chooseNative", 6, "母国語を選択" },
                    { 97, "app.menu.chooseNative", 7, "选择母语" },
                    { 98, "app.menu.chooseNative", 8, "Vyberte rodný jazyk" },
                    { 99, "app.menu.chooseNative", 9, "Vælg modersmål" },
                    { 100, "app.menu.chooseNative", 10, "अपनी मूल भाषा चुनें" },
                    { 101, "app.menu.chooseNative", 11, "Scegli la lingua madre" },
                    { 102, "app.menu.chooseNative", 12, "Välj modersmål" },
                    { 103, "app.menu.chooseNative", 13, "Muttersprache wählen" },
                    { 104, "app.menu.chooseNative", 14, "Wybierz język ojczysty" },
                    { 105, "app.menu.chooseNative", 15, "Yerel dili seçin" },
                    { 106, "app.menu.chooseTarget", 1, "Виберіть цільову мову" },
                    { 107, "app.menu.chooseTarget", 2, "Выберите целевой язык" },
                    { 108, "app.menu.chooseTarget", 3, "Choose target language" },
                    { 109, "app.menu.chooseTarget", 4, "Elija el idioma de destino" },
                    { 110, "app.menu.chooseTarget", 5, "Choisissez la langue cible" },
                    { 111, "app.menu.chooseTarget", 6, "ターゲット言語を選択" },
                    { 112, "app.menu.chooseTarget", 7, "选择目标语言" },
                    { 113, "app.menu.chooseTarget", 8, "Vyberte cílový jazyk" },
                    { 114, "app.menu.chooseTarget", 9, "Vælg målsprog" },
                    { 115, "app.menu.chooseTarget", 10, "लक्षित भाषा चुनें" },
                    { 116, "app.menu.chooseTarget", 11, "Scegli la lingua di destinazione" },
                    { 117, "app.menu.chooseTarget", 12, "Välj målspråk" },
                    { 118, "app.menu.chooseTarget", 13, "Zielsprache wählen" },
                    { 119, "app.menu.chooseTarget", 14, "Wybierz język docelowy" },
                    { 120, "app.menu.chooseTarget", 15, "Hedef dili seçin" },
                    { 121, "app.menu.englishMeaning", 1, "Показувати значення англійських слів" },
                    { 122, "app.menu.englishMeaning", 2, "Показывать значение английских слов" },
                    { 123, "app.menu.englishMeaning", 3, "Show english words meaning" },
                    { 124, "app.menu.englishMeaning", 4, "Mostrar el significado de las palabras en inglés" },
                    { 125, "app.menu.englishMeaning", 5, "Afficher le sens des mots anglais" },
                    { 126, "app.menu.englishMeaning", 6, "英単語の意味を表示" },
                    { 127, "app.menu.englishMeaning", 7, "显示英文单词的意思" },
                    { 128, "app.menu.englishMeaning", 8, "Zobrazit význam anglických slov" },
                    { 129, "app.menu.englishMeaning", 9, "Vis engelske ords betydning" },
                    { 130, "app.menu.englishMeaning", 10, "अंग्रेजी शब्दों का अर्थ दिखाएँ" },
                    { 131, "app.menu.englishMeaning", 11, "Mostra il significato delle parole inglesi" },
                    { 132, "app.menu.englishMeaning", 12, "Visa engelska ords betydelse" },
                    { 133, "app.menu.englishMeaning", 13, "Zeigen Sie die Bedeutung der englischen Wörter" },
                    { 134, "app.menu.englishMeaning", 14, "Pokaż znaczenie angielskich słów" },
                    { 135, "app.menu.englishMeaning", 15, "İngilizce kelimelerin anlamını göster" },
                    { 136, "app.menu.disabled", 1, "вимкнено" },
                    { 137, "app.menu.disabled", 2, "отключено" },
                    { 138, "app.menu.disabled", 3, "disabled" },
                    { 139, "app.menu.disabled", 4, "discapacitado" },
                    { 140, "app.menu.disabled", 5, "désactivé" },
                    { 141, "app.menu.disabled", 6, "無効" },
                    { 142, "app.menu.disabled", 7, "禁用" },
                    { 143, "app.menu.disabled", 8, "zakázáno" },
                    { 144, "app.menu.disabled", 9, "handicappet" },
                    { 145, "app.menu.disabled", 10, "अक्षम" },
                    { 146, "app.menu.disabled", 11, "disabilitato" },
                    { 147, "app.menu.disabled", 12, "Inaktiverad" },
                    { 148, "app.menu.disabled", 13, "deaktiviert" },
                    { 149, "app.menu.disabled", 14, "wyłączony" },
                    { 150, "app.menu.disabled", 15, "engelli" },
                    { 151, "app.menu.activated", 1, "активовано" },
                    { 152, "app.menu.activated", 2, "активировано" },
                    { 153, "app.menu.activated", 3, "activated" },
                    { 154, "app.menu.activated", 4, "activado" },
                    { 155, "app.menu.activated", 5, "activé" },
                    { 156, "app.menu.activated", 6, "アクティブ化" },
                    { 157, "app.menu.activated", 7, "活性" },
                    { 158, "app.menu.activated", 8, "aktivováno" },
                    { 159, "app.menu.activated", 9, "aktiveret" },
                    { 160, "app.menu.activated", 10, "सक्रिय" },
                    { 161, "app.menu.activated", 11, "attivato" },
                    { 162, "app.menu.activated", 12, "aktiveras" },
                    { 163, "app.menu.activated", 13, "aktiviert" },
                    { 164, "app.menu.activated", 14, "aktywowany" },
                    { 165, "app.menu.activated", 15, "aktif" },
                    { 166, "app.menu.chooseLang", 1, "Виберіть мову інтерфейсу" },
                    { 167, "app.menu.chooseLang", 2, "Выберите язык интерфейса" },
                    { 168, "app.menu.chooseLang", 3, "Choose interface language" },
                    { 169, "app.menu.chooseLang", 4, "Elija el idioma de la interfaz" },
                    { 170, "app.menu.chooseLang", 5, "Choisissez la langue de l'interface" },
                    { 171, "app.menu.chooseLang", 6, "インターフェイス言語の選択" },
                    { 172, "app.menu.chooseLang", 7, "选择界面语言" },
                    { 173, "app.menu.chooseLang", 8, "Vyberte jazyk rozhraní" },
                    { 174, "app.menu.chooseLang", 9, "Vælg grænsefladesprog" },
                    { 175, "app.menu.chooseLang", 10, "इंटरफ़ेस भाषा चुनें" },
                    { 176, "app.menu.chooseLang", 11, "Scegli la lingua dell'interfaccia" },
                    { 177, "app.menu.chooseLang", 12, "Välj gränssnittsspråk" },
                    { 178, "app.menu.chooseLang", 13, "Wählen Sie die Sprache der Benutzeroberfläche" },
                    { 179, "app.menu.chooseLang", 14, "Wybierz język interfejsu" },
                    { 180, "app.menu.chooseLang", 15, "Arayüz dilini seçin" },
                    { 181, "app.menu.info", 1, "<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\nНадішліть /interface_language, щоб змінити мову інтерфейсу\n\n<b>Надішліть фотографії та отримайте </b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- Аудіо транскрипцію\n\n<b>Бот підтримує «відповіді» та «пересилання» повідомлень.</b>" },
                    { 182, "app.menu.info", 2, "<b>Возможности бота</b>\n\nОтправьте текст для автоматического перевода на выбранный язык.\n\nОтправьте /meaning_english, чтобы показывать английское значение и синоними.\nОтправьте /interface_language, чтобы изменить язык интерфейса\n\n<b>Отправьте фотографии и получите </b>\n- Текст с фото\n- Все объекты с фото с переводом\n- Краткое описание фото, если возможно\n\n<b>Отправьте аудио и получите</b>\n- Аудио транскрипцию\n\n<b>Бот поддерживает 'ответы' и 'пересылки' сообщений.</b>" },
                    { 183, "app.menu.info", 3, "<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nSend /meaning_english to enable show English meaning and synonyms for the words.\nSend /interface_language to change the interface language\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audio\n\n<b>Bot support 'replies' and 'forwards' messages.</b>" },
                    { 184, "app.menu.info", 4, "<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\nEnvía /interface_language para cambiar el idioma de la interfaz\n\n<b>Envíe fotos y obtenga </b>\n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- La transcripción del audio\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>" },
                    { 185, "app.menu.info", 5, "<b>Fonctionnalités du bot</b>\n\nSoumettez le texte pour traduction automatique dans la langue sélectionnée.\n\nSoumettez /meaning_english pour demander la signification et les synonymes en anglais.\nEnvoyez /interface_language pour changer la langue de l'interface\n\n<b>Soumettez des photos et obtenez </b>\n- Texte avec photo\n- Tous les objets avec photo avec traduction\n- Brève description de la photo, si possible\n\n<b>Soumettre l'audio et obtenir</b>\n- Transcription audio\n\n<b>Le bot prend en charge les messages 'répondre' et 'transférer'.</b>" },
                    { 186, "app.menu.info", 6, "<b>ボットの機能</b>\n\nテキストを送信して、選択した言語に自動翻訳します。\n\n/meaning_english を送信して、英語の意味と同義語を求めます。\nインターフェイス言語を変更するには、/interface_language を送信します\n\n<b>写真を送信して </b> を入手してください\n- 写真付きテキスト\n- 写真付きのすべてのオブジェクトと翻訳\n- 可能であれば、写真の簡単な説明\n\n<b>音声を送信して取得</b>\n- 音声文字起こし\n\n<b>ボットはメッセージの「返信」と「転送」をサポートします。</b>" },
                    { 187, "app.menu.info", 7, "<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n发送 /interface_language 更改界面语言\n\n<b>提交照片并获取</b>\n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录\n\n<b>Bot 支持“回复”和“转发”消息。</b>" },
                    { 188, "app.menu.info", 8, "<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\nPro změnu jazyka rozhraní odešlete /interface_language\n\n<b>Odešlete fotografie a získejte</b>\n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- Zvukový přepis\n\n<b>Bot podporuje „odpovědi“ a „přeposílání“ zpráv.</b>" },
                    { 189, "app.menu.info", 9, "<b>Bot-funktioner</b>\n\nSend tekst til automatisk oversættelse til det valgte sprog.\n\nSend /meaning_english for at kalde på engelsk betydning og synonymer.\nSend /interface_language for at ændre grænsefladesproget\n\n<b>Indsend billeder og få </b>\n- Tekst med foto\n- Alle objekter med foto med oversættelse\n- Kort beskrivelse af billedet, hvis det er muligt\n\n<b>Send lyd og få</b>\n- Lydtransskription\n\n<b>Bot understøtter 'svar' og 'videresendelser'-meddelelser.</b>" },
                    { 190, "app.menu.info", 10, "<b>बॉट सुविधाएँ</b>\n\nचयनित भाषा में स्वचालित अनुवाद के लिए टेक्स्ट सबमिट करें।\n\nअंग्रेज़ी अर्थ और समानार्थक शब्द के लिए कॉल करने के लिए /meaning_english सबमिट करें।\nइंटरफ़ेस भाषा बदलने के लिए /interface_language भेजें\n\n<b>फ़ोटो सबमिट करें और प्राप्त करें</b>\n- फ़ोटो के साथ टेक्स्ट\n- अनुवाद के साथ फ़ोटो के साथ सभी ऑब्जेक्ट\n- फ़ोटो का संक्षिप्त विवरण, यदि संभव हो तो\n\n<b>ऑडियो सबमिट करें और प्राप्त करें</b>\n- ऑडियो ट्रांसक्रिप्शन\n\n<b>बॉट 'जवाब' और 'फॉरवर्ड' संदेशों का समर्थन करता है।</b>" },
                    { 191, "app.menu.info", 11, "<b>Caratteristiche del bot</b>\n\nInvia il testo per la traduzione automatica nella lingua selezionata.\n\nInvia /meaning_english per richiedere significato e sinonimi in inglese.\nInvia /interface_language per cambiare la lingua dell'interfaccia\n\n<b>Invia foto e ottieni </b>\n- Testo con foto\n- Tutti gli oggetti con foto con traduzione\n- Breve descrizione della foto, se possibile\n\n<b>Invia audio e ottieni</b>\n- Trascrizione audio\n\n<b>Il bot supporta i messaggi di 'risposta' e 'inoltro'.</b>" },
                    { 192, "app.menu.info", 12, "<b>Botfunktioner</b>\n\nSkicka in text för automatisk översättning till det valda språket.\n\nSkicka in /meaning_english för att få engelska betydelser och synonymer.\nSkicka /interface_language för att ändra gränssnittsspråket\n\n<b>Skicka in foton och få </b>\n- Text med foto\n- Alla objekt med foto med översättning\n- Kort beskrivning av fotot, om möjligt\n\n<b>Skicka in ljud och få</b>\n- Ljudtranskription\n\n<b>Bot stöder 'svar' och 'vidarebefordrar' meddelanden.</b>" },
                    { 193, "app.menu.info", 13, "<b>Bot-Funktionen</b>\n\nSenden Sie Text zur automatischen Übersetzung in die ausgewählte Sprache.\n\nSenden Sie /meaning_english, um nach englischer Bedeutung und Synonymen zu fragen.\nSenden Sie /interface_language, um die Sprache der Benutzeroberfläche zu ändern\n\n<b>Senden Sie Fotos und erhalten Sie</b>\n- Text mit Foto\n- Alle Objekte mit Foto mit Übersetzung\n- Kurze Beschreibung des Fotos, wenn möglich\n\n<b>Audio einreichen und</b>\n- Audiotranskription erhalten\n\n<b>Bot unterstützt 'Antworten' und 'Weiterleiten' von Nachrichten.</b>" },
                    { 194, "app.menu.info", 14, "<b>Funkcje bota</b>\n\nPrześlij tekst do automatycznego tłumaczenia na wybrany język.\n\nPrześlij /meaning_english, aby uzyskać angielskie znaczenie i synonimy.\nWyślij /interface_language, aby zmienić język interfejsu\n\n<b>Prześlij zdjęcia i uzyskaj </b>\n- Tekst ze zdjęciem\n- Wszystkie obiekty ze zdjęciem z tłumaczeniem\n- Krótki opis zdjęcia, jeśli to możliwe\n\n<b>Prześlij dźwięk i pobierz</b>\n- Transkrypcję dźwięku\n\n<b>Bot obsługuje 'odpowiedzi' i 'przekazuje dalej' wiadomości.</b>" },
                    { 195, "app.menu.info", 15, "<b>Bot özellikleri</b>\n\nSeçilen dile otomatik çeviri için metin gönderin.\n\nİngilizce anlamı ve eşanlamlıları aramak için /meaning_english gönderin.\nArayüz dilini değiştirmek için /interface_language gönderin\n\n<b>Fotoğraf gönderin ve </b>\n- Fotoğraflı metin\n- Fotoğraflı tüm nesneler ve çevirisi\n- Mümkünse fotoğrafın kısa açıklaması\n\n<b>Sesi gönderin ve</b>\n- Sesli transkripsiyonu alın\n\n<b>Bot desteği 'yanıtlar' ve 'iletilen' mesajlar.</b>" },
                    { 196, "app.audios.audioText", 1, "Аудіо-транскрипція" },
                    { 197, "app.audios.audioText", 2, "Транскрипция аудио" },
                    { 198, "app.audios.audioText", 3, "Audio transcription" },
                    { 199, "app.audios.audioText", 4, "Transcripción de audio" },
                    { 200, "app.audios.audioText", 5, "Transcription audio" },
                    { 201, "app.audios.audioText", 6, "音声トランスクリプション" },
                    { 202, "app.audios.audioText", 7, "音频转录" },
                    { 203, "app.audios.audioText", 8, "Přepis zvuku" },
                    { 204, "app.audios.audioText", 9, "Lydtransskription" },
                    { 205, "app.audios.audioText", 10, "ऑडियो ट्रांसक्रिप्शन" },
                    { 206, "app.audios.audioText", 11, "Trascrizione audio" },
                    { 207, "app.audios.audioText", 12, "Ljudtranskription" },
                    { 208, "app.audios.audioText", 13, "Audiotranskription" },
                    { 209, "app.audios.audioText", 14, "Transkrypcja dźwięku" },
                    { 210, "app.audios.audioText", 15, "Ses transkripsiyonu" },
                    { 211, "app.menu.audioLang", 1, "Виберіть мову аудіо при транскрипії" },
                    { 212, "app.menu.audioLang", 2, "Выберите язык аудио при транскрипции" },
                    { 213, "app.menu.audioLang", 3, "Select the audio language when transcribing" },
                    { 214, "app.menu.audioLang", 4, "Seleccionar el idioma del audio al transcribir" },
                    { 215, "app.menu.audioLang", 5, "Sélectionnez la langue audio lors de la transcription" },
                    { 216, "app.menu.audioLang", 6, "文字起こし時の音声言語の選択" },
                    { 217, "app.menu.audioLang", 7, "转录时选择音频语言" },
                    { 218, "app.menu.audioLang", 8, "Vyberte jazyk zvuku při přepisu" },
                    { 219, "app.menu.audioLang", 9, "Vælg lydsproget, når du transskriberer" },
                    { 220, "app.menu.audioLang", 10, "लिप्यंतरण करते समय ऑडियो भाषा का चयन करें" },
                    { 221, "app.menu.audioLang", 11, "Seleziona la lingua dell'audio durante la trascrizione" },
                    { 222, "app.menu.audioLang", 12, "Välj ljudspråk när du transkriberar" },
                    { 223, "app.menu.audioLang", 13, "Wählen Sie beim Transkribieren die Audiosprache aus" },
                    { 224, "app.menu.audioLang", 14, "Wybierz język ścieżki dźwiękowej podczas transkrypcji" },
                    { 225, "app.menu.audioLang", 15, "Yazıya dökerken ses dilini seçin" },
                    { 226, "app.languages.audioLanguageKey", 1, "Мова аудіо транскрипції:" },
                    { 227, "app.languages.audioLanguageKey", 2, "Язык аудио транскрипции:" },
                    { 228, "app.languages.audioLanguageKey", 3, "Audio transcription language:" },
                    { 229, "app.languages.audioLanguageKey", 4, "Idioma de transcripción de audio:" },
                    { 230, "app.languages.audioLanguageKey", 5, "Langue de transcription audio :" },
                    { 231, "app.languages.audioLanguageKey", 6, "音声転写言語:" },
                    { 232, "app.languages.audioLanguageKey", 7, "音频转录语言：" },
                    { 233, "app.languages.audioLanguageKey", 8, "Jazyk zvukového přepisu:" },
                    { 234, "app.languages.audioLanguageKey", 9, "Lydtransskriptionssprog:" },
                    { 235, "app.languages.audioLanguageKey", 10, "ऑडियो ट्रांसक्रिप्शन भाषा:" },
                    { 236, "app.languages.audioLanguageKey", 11, "Lingua di trascrizione audio:" },
                    { 237, "app.languages.audioLanguageKey", 12, "Språk för ljudtranskription:" },
                    { 238, "app.languages.audioLanguageKey", 13, "Sprache der Audiotranskription:" },
                    { 239, "app.languages.audioLanguageKey", 14, "Język transkrypcji dźwięku:" },
                    { 240, "app.languages.audioLanguageKey", 15, "Ses transkripsiyon dili:" },
                    { 241, "app.languages.audioResendKey", 1, "Надішліть аудіо ще раз, ви можете використати 'reply'" },
                    { 242, "app.languages.audioResendKey", 2, "Отправьте аудио еще раз, вы можете использовать 'reply'" },
                    { 243, "app.languages.audioResendKey", 3, "Send the audio again, you can use 'reply'" },
                    { 244, "app.languages.audioResendKey", 4, "Envía el audio de nuevo, puedes usar 'reply'" },
                    { 245, "app.languages.audioResendKey", 5, "Envoyez à nouveau l'audio, vous pouvez utiliser 'reply'" },
                    { 246, "app.languages.audioResendKey", 6, "音声をもう一度送信してください。'reply' を使用できます" },
                    { 247, "app.languages.audioResendKey", 7, "再次发送音频，您可以使用 'reply'" },
                    { 248, "app.languages.audioResendKey", 8, "Pošlete zvuk znovu, můžete použít 'reply'" },
                    { 249, "app.languages.audioResendKey", 9, "Send lyden igen, du kan bruge 'reply'" },
                    { 250, "app.languages.audioResendKey", 10, "ऑडियो फिर से भेजें, आप 'reply' का उपयोग कर सकते हैं" },
                    { 251, "app.languages.audioResendKey", 11, "Invia di nuovo l'audio, puoi usare 'reply'" },
                    { 252, "app.languages.audioResendKey", 12, "Skicka ljudet igen, du kan använda 'svara'" },
                    { 253, "app.languages.audioResendKey", 13, "Senden Sie das Audio erneut, Sie können 'reply' verwenden" },
                    { 254, "app.languages.audioResendKey", 14, "Wyślij dźwięk ponownie, możesz użyć 'reply'" },
                    { 255, "app.languages.audioResendKey", 15, "Sesi tekrar gönderin, 'reply' kullanabilirsiniz" },
                    { 256, "app.file.noSupportContent", 1, "Бот не підтримує цей тип контенту" },
                    { 257, "app.file.noSupportContent", 2, "Бот не поддерживает этот тип контента" },
                    { 258, "app.file.noSupportContent", 3, "The bot does not support this type of content" },
                    { 259, "app.file.noSupportContent", 4, "El bot no soporta este tipo de contenido." },
                    { 260, "app.file.noSupportContent", 5, "Le bot ne prend pas en charge ce type de contenu" },
                    { 261, "app.file.noSupportContent", 6, "ボットはこのタイプのコンテンツをサポートしていません" },
                    { 262, "app.file.noSupportContent", 7, "该机器人不支持此类内容" },
                    { 263, "app.file.noSupportContent", 8, "Robot tento typ obsahu nepodporuje" },
                    { 264, "app.file.noSupportContent", 9, "Botten understøtter ikke denne type indhold" },
                    { 265, "app.file.noSupportContent", 10, "बॉट इस प्रकार की सामग्री का समर्थन नहीं करता है" },
                    { 266, "app.file.noSupportContent", 11, "Il bot non supporta questo tipo di contenuto" },
                    { 267, "app.file.noSupportContent", 12, "Boten stöder inte den här typen av innehåll" },
                    { 268, "app.file.noSupportContent", 13, "Der Bot unterstützt diese Art von Inhalten nicht" },
                    { 269, "app.file.noSupportContent", 14, "Bot nie obsługuje tego typu treści" },
                    { 270, "app.file.noSupportContent", 15, "Bot bu tür içeriği desteklemiyor" },
                    { 271, "app.audio.noSupportFormat", 1, "Формат не підтримується. Використовуйте (.mp3, .ogg, .flac, .wav)" },
                    { 272, "app.audio.noSupportFormat", 2, "Не поддерживаемый формат. Используйте (.mp3, .ogg, .flac, .wav)" },
                    { 273, "app.audio.noSupportFormat", 3, "Not supported format. Use (.mp3, .ogg, .flac, .wav)" },
                    { 274, "app.audio.noSupportFormat", 4, "Formato no compatible. Usar (.mp3, .ogg, .flac, .wav)" },
                    { 275, "app.audio.noSupportFormat", 5, "Format non pris en charge. Utiliser (.mp3, .ogg, .flac, .wav)" },
                    { 276, "app.audio.noSupportFormat", 6, "サポートされていない形式です。 使用 (.mp3、.ogg、.flac、.wav)" },
                    { 277, "app.audio.noSupportFormat", 7, "不支持的格式。 使用（.mp3、.ogg、.flac、.wav）" },
                    { 278, "app.audio.noSupportFormat", 8, "Nepodporovaný formát. Použít (.mp3, .ogg, .flac, .wav)" },
                    { 279, "app.audio.noSupportFormat", 9, "Ikke understøttet format. Brug (.mp3, .ogg, .flac, .wav)" },
                    { 280, "app.audio.noSupportFormat", 10, "समर्थित प्रारूप नहीं। उपयोग करें (.mp3, .ogg, .flac, .wav)" },
                    { 281, "app.audio.noSupportFormat", 11, "Formato non supportato. Usa (.mp3, .ogg, .flac, .wav)" },
                    { 282, "app.audio.noSupportFormat", 12, "Format som inte stöds. Använd (.mp3, .ogg, .flac, .wav)" },
                    { 283, "app.audio.noSupportFormat", 13, "Nicht unterstütztes Format. Verwendung (.mp3, .ogg, .flac, .wav)" },
                    { 284, "app.audio.noSupportFormat", 14, "Nieobsługiwany format. Użyj (.mp3, .ogg, .flac, .wav)" },
                    { 285, "app.audio.noSupportFormat", 15, "Desteklenmeyen biçim. (.mp3, .ogg, .flac, .wav) kullanın" },
                    { 286, "app.audio.cantProcess", 1, "Не вдається обробити це аудіо, спробуйте інше." },
                    { 287, "app.audio.cantProcess", 2, "Не удается обработать этот звук, попробуйте другой." },
                    { 288, "app.audio.cantProcess", 3, "Can't process this audio try another one." },
                    { 289, "app.audio.cantProcess", 4, "No se puede procesar este audio, prueba con otro." },
                    { 290, "app.audio.cantProcess", 5, "Impossible de traiter cet audio, essayez-en un autre." },
                    { 291, "app.audio.cantProcess", 6, "この音声を処理できません。別の音声を試してください。" },
                    { 292, "app.audio.cantProcess", 7, "无法处理此音频，请尝试另一个。" },
                    { 293, "app.audio.cantProcess", 8, "Tento zvuk nelze zpracovat, zkuste jiný." },
                    { 294, "app.audio.cantProcess", 9, "Kan ikke behandle denne lyd prøv en anden." },
                    { 295, "app.audio.cantProcess", 10, "इस ऑडियो को प्रोसेस नहीं किया जा सकता, एक और ऑडियो आज़माएं." },
                    { 296, "app.audio.cantProcess", 11, "Impossibile elaborare questo audio, provane un altro." },
                    { 297, "app.audio.cantProcess", 12, "Det går inte att bearbeta det här ljudet, försök med ett annat." },
                    { 298, "app.audio.cantProcess", 13, "Dieses Audio kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." },
                    { 299, "app.audio.cantProcess", 14, "Nie można przetworzyć tego dźwięku, spróbuj innego." },
                    { 300, "app.audio.cantProcess", 15, "Bu ses işlenemiyor başka bir ses deneyin." },
                    { 301, "app.audio.noExceedDuration", 1, "Тривалість аудіо не повинна перевищувати 60 секунд" },
                    { 302, "app.audio.noExceedDuration", 2, "Продолжительность аудио не должна превышать 60 секунд." },
                    { 303, "app.audio.noExceedDuration", 3, "Audio duration must not exceed 60 seconds" },
                    { 304, "app.audio.noExceedDuration", 4, "La duración del audio no debe exceder los 60 segundos." },
                    { 305, "app.audio.noExceedDuration", 5, "La durée audio ne doit pas dépasser 60 secondes" },
                    { 306, "app.audio.noExceedDuration", 6, "音声の長さは 60 秒を超えてはなりません" },
                    { 307, "app.audio.noExceedDuration", 7, "音频时长不得超过 60 秒" },
                    { 308, "app.audio.noExceedDuration", 8, "Délka zvuku nesmí přesáhnout 60 sekund" },
                    { 309, "app.audio.noExceedDuration", 9, "Lydens varighed må ikke overstige 60 sekunder" },
                    { 310, "app.audio.noExceedDuration", 10, "ऑडियो की अवधि 60 सेकंड से अधिक नहीं होनी चाहिए" },
                    { 311, "app.audio.noExceedDuration", 11, "La durata dell'audio non deve superare i 60 secondi" },
                    { 312, "app.audio.noExceedDuration", 12, "Ljudlängden får inte överstiga 60 sekunder" },
                    { 313, "app.audio.noExceedDuration", 13, "Die Audiodauer darf 60 Sekunden nicht überschreiten" },
                    { 314, "app.audio.noExceedDuration", 14, "Czas trwania dźwięku nie może przekraczać 60 sekund" },
                    { 315, "app.audio.noExceedDuration", 15, "Ses süresi 60 saniyeyi geçmemelidir" },
                    { 316, "app.photo.noSupportFormat", 1, "Формат не підтримується. Використовуйте (.png, .jpeg, .jpg)" },
                    { 317, "app.photo.noSupportFormat", 2, "Не поддерживаемый формат. Использовать (.png, .jpeg, .jpg)" },
                    { 318, "app.photo.noSupportFormat", 3, "Not supported format. Use (.png, .jpeg, .jpg)" },
                    { 319, "app.photo.noSupportFormat", 4, "Formato no compatible. Usar (.png, .jpeg, .jpg)" },
                    { 320, "app.photo.noSupportFormat", 5, "Format non pris en charge. Utiliser (.png, .jpeg, .jpg)" },
                    { 321, "app.photo.noSupportFormat", 6, "サポートされていない形式です。 使用 (.png、.jpeg、.jpg)" },
                    { 322, "app.photo.noSupportFormat", 7, "不支持的格式。 使用（.png、.jpeg、.jpg）" },
                    { 323, "app.photo.noSupportFormat", 8, "Nepodporovaný formát. Použít (.png, .jpeg, .jpg)" },
                    { 324, "app.photo.noSupportFormat", 9, "Ikke understøttet format. Brug (.png, .jpeg, .jpg)" },
                    { 325, "app.photo.noSupportFormat", 10, "समर्थित प्रारूप नहीं। (.पीएनजी, .जेपीईजी, .जेपीजी) का प्रयोग करें" },
                    { 326, "app.photo.noSupportFormat", 11, "Formato non supportato. Usa (.png, .jpeg, .jpg)" },
                    { 327, "app.photo.noSupportFormat", 12, "Format som inte stöds. Använd (.png, .jpeg, .jpg)" },
                    { 328, "app.photo.noSupportFormat", 13, "Nicht unterstütztes Format. Verwenden Sie (.png, .jpeg, .jpg)" },
                    { 329, "app.photo.noSupportFormat", 14, "Nieobsługiwany format. Użyj (.png, .jpeg, .jpg)" },
                    { 330, "app.photo.noSupportFormat", 15, "Desteklenmeyen biçim. (.png, .jpeg, .jpg) kullanın" },
                    { 331, "app.photo.cantProcess", 1, "Не вдається обробити цю фотографію, спробуйте іншу." },
                    { 332, "app.photo.cantProcess", 2, "Не удается обработать это фото. Попробуйте другое." },
                    { 333, "app.photo.cantProcess", 3, "Can't process this photo try another one." },
                    { 334, "app.photo.cantProcess", 4, "No se puede procesar esta foto, prueba con otra." },
                    { 335, "app.photo.cantProcess", 5, "Impossible de traiter cette photo, essayez-en une autre." },
                    { 336, "app.photo.cantProcess", 6, "この写真を処理できません。別の写真を試してください。" },
                    { 337, "app.photo.cantProcess", 7, "无法处理这张照片，请尝试另一张。" },
                    { 338, "app.photo.cantProcess", 8, "Tuto fotografii nelze zpracovat, zkuste jinou." },
                    { 339, "app.photo.cantProcess", 9, "Kan ikke behandle dette billede prøv et andet." },
                    { 340, "app.photo.cantProcess", 10, "इस फ़ोटो को प्रोसेस नहीं किया जा सकता, कोई और फ़ोटो आज़माएं." },
                    { 341, "app.photo.cantProcess", 11, "Impossibile elaborare questa foto, provane un'altra." },
                    { 342, "app.photo.cantProcess", 12, "Det går inte att bearbeta det här fotot, försök med ett annat." },
                    { 343, "app.photo.cantProcess", 13, "Dieses Foto kann nicht verarbeitet werden, versuchen Sie es mit einem anderen." },
                    { 344, "app.photo.cantProcess", 14, "Nie można przetworzyć tego zdjęcia, spróbuj innego." },
                    { 345, "app.photo.cantProcess", 15, "Bu fotoğraf işlenemiyor başka bir fotoğraf deneyin." },
                    { 346, "app.photo.tooLargeFile", 1, "Занадто великий файл. Використовуйте фото до 4 Мб" },
                    { 347, "app.photo.tooLargeFile", 2, "Слишком большой файл. Используйте фото до 4 МБ" },
                    { 348, "app.photo.tooLargeFile", 3, "Too large a file. Use photo up to 4 MB" },
                    { 349, "app.photo.tooLargeFile", 4, "Un archivo demasiado grande. Usar foto de hasta 4 MB" },
                    { 350, "app.photo.tooLargeFile", 5, "Fichier trop volumineux. Utiliser une photo jusqu'à 4 Mo" },
                    { 351, "app.photo.tooLargeFile", 6, "ファイルが大きすぎます。 4 MB までの写真を使用" },
                    { 352, "app.photo.tooLargeFile", 7, "文件太大。 使用最大 4 MB 的照片" },
                    { 353, "app.photo.tooLargeFile", 8, "Příliš velký soubor. Použijte fotografii do velikosti 4 MB" },
                    { 354, "app.photo.tooLargeFile", 9, "For stor fil. Brug foto op til 4 MB" },
                    { 355, "app.photo.tooLargeFile", 10, "फ़ाइल बहुत बड़ी है. 4 एमबी तक फोटो का प्रयोग करें" },
                    { 356, "app.photo.tooLargeFile", 11, "Un file troppo grande. Usa foto fino a 4 MB" },
                    { 357, "app.photo.tooLargeFile", 12, "För stor fil. Använd foto upp till 4 MB" },
                    { 358, "app.photo.tooLargeFile", 13, "Eine zu große Datei. Verwenden Sie Fotos bis zu 4 MB" },
                    { 359, "app.photo.tooLargeFile", 14, "Zbyt duży plik. Użyj zdjęcia do 4 MB" },
                    { 360, "app.photo.tooLargeFile", 15, "Çok büyük bir dosya. 4 MB'a kadar fotoğraf kullan" },
                    { 361, "app.text.maxLength", 1, "Максимальна довжина тексту одного повідомлення не повинна перевищувати 40 тис. символів." },
                    { 362, "app.text.maxLength", 2, "Максимальная длина текста одного сообщения не должна превышать 40 тыс. символов." },
                    { 363, "app.text.maxLength", 3, "The maximum text length of one message must not exceed 40k characters." },
                    { 364, "app.text.maxLength", 4, "La longitud máxima del texto de un mensaje no debe exceder los 40k caracteres." },
                    { 365, "app.text.maxLength", 5, "La longueur maximale du texte d'un message ne doit pas dépasser 40 000 caractères" },
                    { 366, "app.text.maxLength", 6, "1 つのメッセージの最大テキスト長は 40,000 文字を超えてはなりません" },
                    { 367, "app.text.maxLength", 7, "一條消息的最大文本長度不得超過 40k 個字符" },
                    { 368, "app.text.maxLength", 8, "Maximální délka textu jedné zprávy nesmí přesáhnout 40 000 znaků" },
                    { 369, "app.text.maxLength", 9, "Den maksimale tekstlængde på én besked må ikke overstige 40.000 tegn" },
                    { 370, "app.text.maxLength", 10, "एक संदेश की अधिकतम टेक्स्ट लंबाई 40k वर्णों से अधिक नहीं होनी चाहिए" },
                    { 371, "app.text.maxLength", 11, "La lunghezza massima del testo di un messaggio non deve superare i 40k caratteri" },
                    { 372, "app.text.maxLength", 12, "Den maximala textlängden för ett meddelande får inte överstiga 40 000 tecken" },
                    { 373, "app.text.maxLength", 13, "Die maximale Textlänge einer Nachricht darf 40.000 Zeichen nicht überschreiten" },
                    { 374, "app.text.maxLength", 14, "Maksymalna długość tekstu jednej wiadomości nie może przekraczać 40 tys. znaków" },
                    { 375, "app.text.maxLength", 15, "Bir mesajın maksimum metin uzunluğu 40k karakteri geçmemelidir" },
                    { 376, "app.audio.EmptyResult", 1, "Не вдалося транскрибувати. Спробуйте вибрати іншу мову транскрибування /audio_language або надішліть інший аудіоформат." },
                    { 377, "app.audio.EmptyResult", 2, "Не удалось расшифровать. Попробуйте выбрать другой язык расшифровки /audio_language или отправьте аудио в другом формате." },
                    { 378, "app.audio.EmptyResult", 3, "Failed to transcribe, please try selecting a different transcribing language /audio_language or send a different audio format." },
                    { 379, "app.audio.EmptyResult", 4, "No se pudo transcribir, intente seleccionar un idioma de transcripción diferente /audio_language o envíe un formato de audio diferente." },
                    { 380, "app.audio.EmptyResult", 5, "Échec de la transcription, veuillez essayer de sélectionner une autre langue de transcription /audio_language ou envoyer un format audio différent." },
                    { 381, "app.audio.EmptyResult", 6, "文字起こしに失敗しました。別の文字起こし言語 /audio_language を選択するか、別の音声形式を送信してください。" },
                    { 382, "app.audio.EmptyResult", 7, "转录失败，请尝试选择不同的转录语言 /audio_language 或发送不同的音频格式。" },
                    { 383, "app.audio.EmptyResult", 8, "Přepis se nezdařil, zkuste prosím vybrat jiný jazyk přepisu /audio_language nebo pošlete jiný formát zvuku." },
                    { 384, "app.audio.EmptyResult", 9, "Kunne ikke transskriberes. Prøv at vælge et andet transskriberingssprog /audio_language eller send et andet lydformat." },
                    { 385, "app.audio.EmptyResult", 10, "लिप्यंतरण करने में विफल, कृपया एक भिन्न अनुलेखन भाषा /audio_language का चयन करने का प्रयास करें या एक भिन्न ऑडियो प्रारूप भेजें।" },
                    { 386, "app.audio.EmptyResult", 11, "Impossibile trascrivere, prova a selezionare una lingua di trascrizione diversa /audio_language o invia un formato audio diverso." },
                    { 387, "app.audio.EmptyResult", 12, "Det gick inte att transkribera, försök att välja ett annat transkriberingsspråk /audio_language eller skicka ett annat ljudformat." },
                    { 388, "app.audio.EmptyResult", 13, "Transkription fehlgeschlagen, bitte versuchen Sie es mit der Auswahl einer anderen Transkriptionssprache /audio_language oder senden Sie ein anderes Audioformat." },
                    { 389, "app.audio.EmptyResult", 14, "Transkrypcja nie powiodła się. Spróbuj wybrać inny język transkrypcji /audio_language lub wyślij inny format audio." },
                    { 390, "app.audio.EmptyResult", 15, "Metne dönüştürülemedi, lütfen farklı bir transkripsiyon dili /audio_language seçmeyi deneyin veya farklı bir ses formatı gönderin." },
                    { 391, "billing.exceedLimit", 1, "Перевищено ліміт цього місяця надішліть /stats для деталей." },
                    { 392, "billing.exceedLimit", 2, "Превышенный предел этого месяца отправьте /stats для деталей." },
                    { 393, "billing.exceedLimit", 3, "This month's limit has been exceeded, send /stats for details." },
                    { 394, "billing.exceedLimit", 4, "Se superó el límite de este mes, envíe /stats para obtener más detalles." },
                    { 395, "billing.exceedLimit", 5, "La limite de ce mois a été dépassée, envoyez /stats pour plus de détails." },
                    { 396, "billing.exceedLimit", 6, "今月の制限を超えました。詳細については /stats を送信してください。" },
                    { 397, "billing.exceedLimit", 7, "已超过本月的限制，请发送 /stats 了解详情。" },
                    { 398, "billing.exceedLimit", 8, "Limit pro tento měsíc byl překročen, pro podrobnosti zašlete /stats ." },
                    { 399, "billing.exceedLimit", 9, "Denne måneds grænse er overskredet, send /stats for detaljer." },
                    { 400, "billing.exceedLimit", 10, "इस माह की सीमा पार हो गई है, विवरण के लिए /stats भेजें।" },
                    { 401, "billing.exceedLimit", 11, "Il limite di questo mese è stato superato, invia /stats per i dettagli." },
                    { 402, "billing.exceedLimit", 12, "Denna månads gräns har överskridits, skicka /stats för mer information." },
                    { 403, "billing.exceedLimit", 13, "Das Limit dieses Monats wurde überschritten, senden Sie /stats für Details." },
                    { 404, "billing.exceedLimit", 14, "Limit w tym miesiącu został przekroczony, wyślij /stats, aby uzyskać szczegółowe informacje." },
                    { 405, "billing.exceedLimit", 15, "Bu ayın limiti aşıldı, detaylar için /stats gönderin." },
                    { 406, "stats.message", 1, "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Зображення</b> {1} з {2} використано\n<b>Символов текста для перевода</b> использовано {3} из {4}\n<b>Аудіохвилин</b> використано {5} із {6}\n\nЗалишилося {7} днів підписки\nЗалишилося {8} хвилин підписки\n\nПідписка автоматично оновлюється кожного місяця" },
                    { 407, "stats.message", 2, "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Изображения</b> {1} из {2} использованных\n<b>Символів тексту для перекладу</b> використано {3} з {4}\n<b>Аудио минут</b> использовано {5} из {6}\n\nОсталось {7} дней подписки\nОсталось {8} минут подписки\n\nПодписка автоматически обновляется каждый месяц" },
                    { 408, "stats.message", 3, "<b>Statistic</b>\n\nPlan: {0}\n\n<b>Images</b> {1} of {2} used\n<b>Text characters for translation</b> {3} of {4} used\n<b>Audio minutes</b> {5} of {6} used\n\n{7} days of subscription left\n{8} minutes of subscription left\n\nSubscription automatically renews each month" },
                    { 409, "stats.message", 4, "<b>Estadística</b>\n\nTarifa: {0}\n\n<b>Imágenes</b> {1} de {2} usadas\n<b>Caracteres de texto para traducción</b> {3} de {4} utilizados\n<b>Minutos de audio</b> {5} de {6} utilizados\n\nQuedan {7} días de suscripción\nQuedan {8} minutos de suscripción\n\nMes de skin actualizado automáticamente por suscripción" },
                    { 410, "stats.message", 5, "<b>Statistique</b>\n\nTarif : {0}\n\n<b>Images</b> {1} sur {2} utilisées\n<b>Caractères de texte à traduire</b> {3} sur {4} utilisés\n<b>Minutes audio</b> {5} sur {6} utilisées\n\n{7} jours d'abonnement restants\n{8} minutes d'abonnement restantes\n\nAbonnement automatiquement mis à jour skin mois" },
                    { 411, "stats.message", 6, "<b>統計</b>\n\n料金: {0}\n\n<b>画像</b> {1}/{2} 使用\n<b>翻訳用テキスト文字</b> {4} 個中 {3} 個使用\n<b>音声時間</b> {6} 中 {5} を使用\n\nサブスクリプションは残り {7} 日\n{8} 分のサブスクリプションが残っています\n\nサブスクリプションは自動的にスキン月を更新します" },
                    { 412, "stats.message", 7, "<b>统计</b>\n\n关税：{0}\n\n<b>Images</b> {1} of {2} 使用了\n<b>用于翻译的文本字符</b> 使用了 {3} 个，共 {4} 个\n<b>音频分钟数</b>已使用 {5} 分钟，共 {6} 分钟\n\n订阅还剩 {7} 天\n还剩 {8} 分钟的订阅时间\n\n订阅自动更新皮肤月份" },
                    { 413, "stats.message", 8, "<b>Statistika</b>\n\nTarif: {0}\n\n<b>Obrázky</b> použité {1} z {2}\n<b>Textové znaky pro překlad</b> Využito {3} z {4}\n<b>Zvukové minuty</b> Využito {5} z {6}\n\nZbývá {7} dní předplatného\nZbývá {8} minut předplatného\n\nPředplatné automaticky aktualizovalo měsíc vzhledu" },
                    { 414, "stats.message", 9, "<b>Statistik</b>\n\nTakst: {0}\n\n<b>Billeder</b> {1} af {2} brugt\n<b>Teksttegn til oversættelse</b> {3} af {4} brugt\n<b>Lydminutter</b> {5} af {6} brugt\n\n{7} dages abonnement tilbage\n{8} minutters abonnement tilbage\n\nAbonnement opdateret automatisk hudmåned" },
                    { 415, "stats.message", 10, "<b>आँकड़ा</b>\n\nशुल्क: {0}\n\n<b>इमेज</b> {2} में से {1} इस्तेमाल की गई\n<b>अनुवाद के लिए पाठ वर्ण</b> {4} में से {3} का उपयोग किया गया\n<b>ऑडियो मिनट</b> {6} में से {5} का उपयोग किया गया\n\n{7} दिनों की सदस्‍यता शेष\n{8} मिनट की सदस्यता बाकी है\n\nसदस्यता स्वचालित रूप से अद्यतन त्वचा माह" },
                    { 416, "stats.message", 11, "<b>Statistica</b>\n\nTariffa: {0}\n\n<b>Immagini</b> {1} di {2} usate\n<b>Caratteri di testo per la traduzione</b> {3} di {4} utilizzati\n<b>Minuti audio</b> {5} su {6} utilizzati\n\n{7} giorni di abbonamento rimanenti\n{8} minuti di abbonamento rimanenti\n\nAbbonamento aggiornato automaticamente skin mese" },
                    { 417, "stats.message", 12, "<b>Statistik</b>\n\nPris: {0}\n\n<b>Bilder</b> {1} av {2} används\n<b>Textecken för översättning</b> {3} av {4} används\n<b>Ljudminuter</b> {5} av {6} används\n\n{7} dagars prenumeration kvar\n{8} minuters prenumeration kvar\n\nAbonnemanget uppdateras automatiskt hudmånad" },
                    { 418, "stats.message", 13, "<b>Statistik</b>\n\nTarif: {0}\n\n<b>Bilder</b> {1} von {2} verwendet\n<b>Textzeichen für die Übersetzung</b> {3} von {4} verwendet\n<b>Audiominuten</b> {5} von {6} verbraucht\n\n{7} Tage Abonnement verbleibend\n{8} Minuten Abonnement verbleiben\n\nAbonnement automatisch aktualisiert Skin Monat" },
                    { 419, "stats.message", 14, "<b>Statystyki</b>\n\nTaryfa: {0}\n\n<b>Obrazy</b> użyto {1} z {2}\n<b>Znaki tekstowe do tłumaczenia</b> Użyto {3} z {4}\n<b>Wykorzystano minuty audio</b> {5} z {6}\n\nPozostało {7} dni subskrypcji\nPozostało {8} minut subskrypcji\n\nSubskrypcja automatycznie aktualizuje miesiąc skórki" },
                    { 420, "stats.message", 15, "<b>İstatistik</b>\n\nTarife: {0}\n\n{2} resimden {1} <b>resim</b> kullanıldı\n<b>Çeviri için metin karakterleri</b> {3} / {4} kullanıldı\n<b>Ses dakikaları</b> {5} / {6} kullanıldı\n\n{7} günlük abonelik kaldı\n{8} dakikalık abonelik kaldı\n\nAbonelik otomatik olarak güncellenen cilt ayı" },
                    { 421, "app.content.processing", 1, "Взято на обробку, будь ласка, зачекайте хвилинку. 😌" },
                    { 422, "app.content.processing", 2, "Взято на обработку, пожалуйста, подождите немного. 😌" },
                    { 423, "app.content.processing", 3, "Taken for processing, please wait a moment. 😌" },
                    { 424, "app.content.processing", 4, "Tomado para procesar, por favor espere un momento. 😌" },
                    { 425, "app.content.processing", 5, "Pris pour traitement, veuillez patienter un moment. 😌" },
                    { 426, "app.content.processing", 6, "処理に時間がかかっています、しばらくお待ちください。😌" },
                    { 427, "app.content.processing", 7, "正在处理中，请稍等片刻。😌" },
                    { 428, "app.content.processing", 8, "Převzato ke zpracování, chvíli prosím počkejte. 😌" },
                    { 429, "app.content.processing", 9, "Optaget til behandling, vent venligst et øjeblik. 😌" },
                    { 430, "app.content.processing", 10, "प्रसंस्करण के लिए लिया गया, कृपया एक क्षण प्रतीक्षा करें। 😌" },
                    { 431, "app.content.processing", 11, "Assunto per l'elaborazione, si prega di attendere un momento. 😌" },
                    { 432, "app.content.processing", 12, "Upptaget för behandling, vänligen vänta ett ögonblick. 😌" },
                    { 433, "app.content.processing", 13, "Zur Bearbeitung angenommen, bitte warten Sie einen Moment. 😌" },
                    { 434, "app.content.processing", 14, "Pobrane do przetworzenia, proszę chwilę poczekać. 😌" },
                    { 435, "app.content.processing", 15, "İşlem için alındı, lütfen bir dakika bekleyin. 😌" },
                    { 436, "app.audios.languageWarning", 1, "Якщо аудіо транскрипція неправильна, спробуйте вибрати аудіо мову /audio_language і надіслати знову аудіо" },
                    { 437, "app.audios.languageWarning", 2, "Если аудио транскрипция неверна, попробуйте выбрать аудио язык /audio_language и отправить снова аудио" },
                    { 438, "app.audios.languageWarning", 3, "If the audio transcription is incorrect, try to select the audio language /audio_language and send the audio again" },
                    { 439, "app.audios.languageWarning", 4, "Si la transcripción del audio es incorrecta, intente seleccionar el idioma del audio /audio_language" },
                    { 440, "app.audios.languageWarning", 5, "Si la transcription audio est incorrecte, essayez de sélectionner la langue audio /audio_language" },
                    { 441, "app.audios.languageWarning", 6, "音声の書き起こしが正しくない場合は、音声言語 /audio_language を選択してみてください" },
                    { 442, "app.audios.languageWarning", 7, "如果音频转录不正确，请尝试选择音频语言 /audio_language" },
                    { 443, "app.audios.languageWarning", 8, "Pokud je přepis zvuku nesprávný, zkuste vybrat jazyk zvuku /audio_language" },
                    { 444, "app.audios.languageWarning", 9, "Hvis lydtransskriptionen er forkert, prøv at vælge lydsproget /audio_language" },
                    { 445, "app.audios.languageWarning", 10, "यदि ऑडियो ट्रांसक्रिप्शन गलत है, तो ऑडियो भाषा /audio_language का चयन करने का प्रयास करें" },
                    { 446, "app.audios.languageWarning", 11, "se la trascrizione audio non è corretta, prova a selezionare la lingua audio /audio_language" },
                    { 447, "app.audios.languageWarning", 12, "Om ljudtranskriptionen är felaktig, prova att välja ljudspråket /audio_language" },
                    { 448, "app.audios.languageWarning", 13, "Wenn die Audiotranskription nicht korrekt ist, versuchen Sie, die Audiosprache /audio_language auszuwählen" },
                    { 449, "app.audios.languageWarning", 14, "Jeśli transkrypcja dźwięku jest nieprawidłowa, spróbuj wybrać język dźwięku /audio_language" },
                    { 450, "app.audios.languageWarning", 15, "Ses dökümü yanlışsa, ses dilini /audio_language seçmeyi deneyin" },
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
                name: "IX_BaseRequest_UserPlanId",
                schema: "requests",
                table: "BaseRequest",
                column: "UserPlanId");

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
                name: "Language",
                schema: "app");

            migrationBuilder.DropTable(
                name: "ApiTypes",
                schema: "requests");

            migrationBuilder.DropTable(
                name: "UserPlans",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Plan",
                schema: "billing");

            migrationBuilder.DropTable(
                name: "TelegramUser",
                schema: "app");
        }
    }
}
