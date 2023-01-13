using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixestablishedmessage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 18,
                column: "Translate",
                value: "The languages were established.\n<b>Bot features</b>\n\nSend text for automatic translation into the selected language.\n\nUse /meaning_english to enable show English meaning and synonyms for the words.\n\n<b>Send photos and receive</b>\n- Text from photos\n- All objects from the photo with translations\n- Short description of the photo if possible\n\n<b>Send audio and receive</b>\n- Transcription of the audioYour languages\nMain Language: {0}\nTarget Language: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 22,
                column: "Translate",
                value: "设置了语言。\n<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n\n<b>提交照片并获取 </b > \n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录你的语言\n主要语言： {0}\n选择母语: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 23,
                column: "Translate",
                value: "Jazyky byly nastaveny.\n<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\n\n<b>Odešlete fotografie a získejte </b > \n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- zvukový přepisVaše jazyky\nHlavní jazyk: {0}\nCílový jazyk: {1}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 18,
                column: "Translate",
                value: "The languages were established.\n<b>Можливості бота</b>\n\nНадішліть текст для автоматичного перекладу на вибрану мову.\n\nНадішліть /meaning_english, щоб показувати англійське значення та синоніми.\n\n<b>Надішліть фотографії та отримайте </ b>\n- Текст з фото\n- Всі об'єкти з фото з перекладом\n- Короткий опис фото, якщо можливо\n\n<b>Надішліть аудіо та отримайте</b>\n- аудіо транскрипціюYour languages\nMain Language: {0}\nTarget Language: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 22,
                column: "Translate",
                value: "设置了语言。\n<b>Funkce robota</b>\n\nOdešlete text k automatickému překladu do vybraného jazyka.\n\nOdešlete /meaning_english, chcete-li získat anglický význam a synonyma.\n\n<b>Odešlete fotografie a získejte </b > \n- Text s fotografií\n- Všechny objekty s fotografií s překladem\n- Stručný popis fotografie, pokud je to možné\n\n<b>Odešlete zvuk a získejte</b>\n- zvukový přepis你的语言\n主要语言： {0}\n选择母语: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 23,
                column: "Translate",
                value: "Jazyky byly nastaveny.\n<b>Bot 功能</b>\n\n提交文本以自动翻译成所选语言。\n\n提交 /meaning_english 以调用英语含义和同义词。\n\n<b>提交照片并获取 </b > \n- 带照片的文本\n- 所有带照片的对象和翻译\n- 如果可能的话，对照片进行简要描述\n\n<b>提交音频并获得</b>\n- 音频转录Vaše jazyky\nHlavní jazyk: {0}\nCílový jazyk: {1}");
        }
    }
}
