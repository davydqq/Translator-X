using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class statsmessage : Migration
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
                    { 451, "stats.message", 1, "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Зображення</b> {1} з {2} використано\n<b>Символов текста для перевода</b> использовано {3} из {4}\n<b>Аудіохвилин</b> використано {5} із {6}\n\nЗалишилося {7} днів підписки\nОсталось {8} минут подписки" },
                    { 452, "stats.message", 2, "<b>Статистика</b>\n\nТариф: {0}\n\n<b>Изображения</b> {1} из {2} использованных\n<b>Символів тексту для перекладу</b> використано {3} з {4}\n<b>Аудио минут</b> использовано {5} из {6}\n\nОсталось {7} дней подписки\nЗалишилося {8} хвилин підписки" },
                    { 453, "stats.message", 3, "<b>Statistic</b>\n\nPlan: {0}\n\n<b>Images</b> {1} of {2} used\n<b>Text characters for translation</b> {3} of {4} used\n<b>Audio minutes</b> {5} of {6} used\n\n{7} days of subscription left\n{8} minutes of subscription left" },
                    { 454, "stats.message", 4, "<b>Estadística</b>\n\nTarifa: {0}\n\n<b>Imágenes</b> {1} de {2} usadas\n<b>Caracteres de texto para traducción</b> {3} de {4} utilizados\n<b>Minutos de audio</b> {5} de {6} utilizados\n\nQuedan {7} días de suscripción\nQuedan {8} minutos de suscripción" },
                    { 455, "stats.message", 5, "<b>Statistique</b>\n\nTarif : {0}\n\n<b>Images</b> {1} sur {2} utilisées\n<b>Caractères de texte à traduire</b> {3} sur {4} utilisés\n<b>Minutes audio</b> {5} sur {6} utilisées\n\n{7} jours d'abonnement restants\n{8} minutes d'abonnement restantes" },
                    { 456, "stats.message", 6, "<b>統計</b>\n\n料金: {0}\n\n<b>画像</b> {1}/{2} 使用\n<b>翻訳用テキスト文字</b> {4} 個中 {3} 個使用\n<b>音声時間</b> {6} 中 {5} を使用\n\nサブスクリプションは残り {7} 日\n{8} 分のサブスクリプションが残っています" },
                    { 457, "stats.message", 7, "<b>统计</b>\n\n关税：{0}\n\n<b>Images</b> {1} of {2} 使用了\n<b>用于翻译的文本字符</b> 使用了 {3} 个，共 {4} 个\n<b>音频分钟数</b>已使用 {5} 分钟，共 {6} 分钟\n\n订阅还剩 {7} 天\n还剩 {8} 分钟的订阅时间" },
                    { 458, "stats.message", 8, "<b>Statistika</b>\n\nTarif: {0}\n\n<b>Obrázky</b> použité {1} z {2}\n<b>Textové znaky pro překlad</b> Využito {3} z {4}\n<b>Zvukové minuty</b> Využito {5} z {6}\n\nZbývá {7} dní předplatného\nZbývá {8} minut předplatného" },
                    { 459, "stats.message", 9, "<b>Statistik</b>\n\nTakst: {0}\n\n<b>Billeder</b> {1} af {2} brugt\n<b>Teksttegn til oversættelse</b> {3} af {4} brugt\n<b>Lydminutter</b> {5} af {6} brugt\n\n{7} dages abonnement tilbage\n{8} minutters abonnement tilbage" },
                    { 460, "stats.message", 10, "<b>आँकड़ा</b>\n\nशुल्क: {0}\n\n<b>इमेज</b> {2} में से {1} इस्तेमाल की गई\n<b>अनुवाद के लिए पाठ वर्ण</b> {4} में से {3} का उपयोग किया गया\n<b>ऑडियो मिनट</b> {6} में से {5} का उपयोग किया गया\n\n{7} दिनों की सदस्‍यता शेष\n{8} मिनट की सदस्यता बाकी है" },
                    { 461, "stats.message", 11, "<b>Statistica</b>\n\nTariffa: {0}\n\n<b>Immagini</b> {1} di {2} usate\n<b>Caratteri di testo per la traduzione</b> {3} di {4} utilizzati\n<b>Minuti audio</b> {5} su {6} utilizzati\n\n{7} giorni di abbonamento rimanenti\n{8} minuti di abbonamento rimanenti" },
                    { 462, "stats.message", 12, "<b>Statistik</b>\n\nPris: {0}\n\n<b>Bilder</b> {1} av {2} används\n<b>Textecken för översättning</b> {3} av {4} används\n<b>Ljudminuter</b> {5} av {6} används\n\n{7} dagars prenumeration kvar\n{8} minuters prenumeration kvar" },
                    { 463, "stats.message", 13, "<b>Statistik</b>\n\nTarif: {0}\n\n<b>Bilder</b> {1} von {2} verwendet\n<b>Textzeichen für die Übersetzung</b> {3} von {4} verwendet\n<b>Audiominuten</b> {5} von {6} verbraucht\n\n{7} Tage Abonnement verbleibend\n{8} Minuten Abonnement verbleiben" },
                    { 464, "stats.message", 14, "<b>Statystyki</b>\n\nTaryfa: {0}\n\n<b>Obrazy</b> użyto {1} z {2}\n<b>Znaki tekstowe do tłumaczenia</b> Użyto {3} z {4}\n<b>Wykorzystano minuty audio</b> {5} z {6}\n\nPozostało {7} dni subskrypcji\nPozostało {8} minut subskrypcji" },
                    { 465, "stats.message", 15, "<b>İstatistik</b>\n\nTarife: {0}\n\n{2} resimden {1} <b>resim</b> kullanıldı\n<b>Çeviri için metin karakterleri</b> {3} / {4} kullanıldı\n<b>Ses dakikaları</b> {5} / {6} kullanıldı\n\n{7} günlük abonelik kaldı\n{8} dakikalık abonelik kaldı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 465);
        }
    }
}
