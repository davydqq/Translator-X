using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class initvalidationtext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
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
                    { 420, "app.text.maxLength", 15, "Bir mesajın maksimum metin uzunluğu 40k karakteri geçmemelidir" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 420);
        }
    }
}
