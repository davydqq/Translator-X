using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class initaudiolanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InterfaceLanguageId",
                table: "UserSettings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AudioLanguageId",
                table: "UserSettings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSupportAudioTranscription",
                table: "Languages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsSupportAudioTranscription",
                value: true);

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
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
                    { 285, "app.menu.audioLang", 15, "Yazıya dökerken ses dilini seçin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_AudioLanguageId",
                table: "UserSettings",
                column: "AudioLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Languages_AudioLanguageId",
                table: "UserSettings",
                column: "AudioLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Languages_AudioLanguageId",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_AudioLanguageId",
                table: "UserSettings");

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DropColumn(
                name: "AudioLanguageId",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "IsSupportAudioTranscription",
                table: "Languages");

            migrationBuilder.AlterColumn<int>(
                name: "InterfaceLanguageId",
                table: "UserSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
