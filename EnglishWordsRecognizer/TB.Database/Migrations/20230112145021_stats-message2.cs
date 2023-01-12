using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class statsmessage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 451,
                column: "Translate",
                value: "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Зображення</b> {1} з {2} використано\n<b>Символов текста для перевода</b> использовано {3} из {4}\n<b>Аудіохвилин</b> використано {5} із {6}\n\nЗалишилося {7} днів підписки\nЗалишилося {8} хвилин підписки");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 452,
                column: "Translate",
                value: "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Изображения</b> {1} из {2} использованных\n<b>Символів тексту для перекладу</b> використано {3} з {4}\n<b>Аудио минут</b> использовано {5} из {6}\n\nОсталось {7} дней подписки\nОсталось {8} минут подписки");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 451,
                column: "Translate",
                value: "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Зображення</b> {1} з {2} використано\n<b>Символов текста для перевода</b> использовано {3} из {4}\n<b>Аудіохвилин</b> використано {5} із {6}\n\nЗалишилося {7} днів підписки\nОсталось {8} минут подписки");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 452,
                column: "Translate",
                value: "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Изображения</b> {1} из {2} использованных\n<b>Символів тексту для перекладу</b> використано {3} з {4}\n<b>Аудио минут</b> использовано {5} из {6}\n\nОсталось {7} дней подписки\nЗалишилося {8} хвилин підписки");
        }
    }
}
