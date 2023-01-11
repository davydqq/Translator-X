using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class initexceedmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "app",
                table: "Translation",
                columns: new[] { "Id", "Key", "LanguageId", "Translate" },
                values: new object[,]
                {
                    { 436, "billing.exceedLimit", 1, "Перевищено ліміт цього місяця надішліть /stats для деталей." },
                    { 437, "billing.exceedLimit", 2, "Превышенный предел этого месяца отправьте /stats для деталей." },
                    { 438, "billing.exceedLimit", 3, "This month's limit has been exceeded, send /stats for details." },
                    { 439, "billing.exceedLimit", 4, "Se superó el límite de este mes, envíe /stats para obtener más detalles." },
                    { 440, "billing.exceedLimit", 5, "La limite de ce mois a été dépassée, envoyez /stats pour plus de détails." },
                    { 441, "billing.exceedLimit", 6, "今月の制限を超えました。詳細については /stats を送信してください。" },
                    { 442, "billing.exceedLimit", 7, "已超过本月的限制，请发送 /stats 了解详情。" },
                    { 443, "billing.exceedLimit", 8, "Limit pro tento měsíc byl překročen, pro podrobnosti zašlete /stats ." },
                    { 444, "billing.exceedLimit", 9, "Denne måneds grænse er overskredet, send /stats for detaljer." },
                    { 445, "billing.exceedLimit", 10, "इस माह की सीमा पार हो गई है, विवरण के लिए /stats भेजें।" },
                    { 446, "billing.exceedLimit", 11, "Il limite di questo mese è stato superato, invia /stats per i dettagli." },
                    { 447, "billing.exceedLimit", 12, "Denna månads gräns har överskridits, skicka /stats för mer information." },
                    { 448, "billing.exceedLimit", 13, "Das Limit dieses Monats wurde überschritten, senden Sie /stats für Details." },
                    { 449, "billing.exceedLimit", 14, "Limit w tym miesiącu został przekroczony, wyślij /stats, aby uzyskać szczegółowe informacje." },
                    { 450, "billing.exceedLimit", 15, "Bu ayın limiti aşıldı, detaylar için /stats gönderin." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 450);
        }
    }
}
