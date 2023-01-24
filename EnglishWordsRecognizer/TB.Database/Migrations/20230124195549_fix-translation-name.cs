using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixtranslationname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 19,
                column: "Translate",
                value: "Se han establecido las lenguas.\n\n<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\nEnvía /interface_language para cambiar el idioma de la interfaz\n\n<b>Envíe fotos y obtenga </b>\n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- La transcripción del audio\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>\n\n<b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 454,
                column: "Translate",
                value: "<b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}\n\nIdioma de transcripción de audio: {2}\n\nTu idioma de interfaz: {3}\n\nMostrar el significado de las palabras en inglés - {4}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 19,
                column: "Translate",
                value: "Se han establecido las lenguas.\n\n<b>Características del bot</b>\n\nEnvíe texto para traducción automática al idioma seleccionado.\n\nEnvíe /meaning_english para solicitar significado y sinónimos en inglés.\nEnvía /interface_language para cambiar el idioma de la interfaz\n\n<b>Envíe fotos y obtenga </b>\n- Texto con foto\n- Todos los objetos con foto con traducción\n- Breve descripción de la foto, si es posible\n\n<b>Envíe el audio y obtenga</b>\n- La transcripción del audio\n\n<b>El bot admite mensajes de 'respuestas' y 'reenvíos'.</b>\n\nb>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}");

            migrationBuilder.UpdateData(
                schema: "app",
                table: "Translation",
                keyColumn: "Id",
                keyValue: 454,
                column: "Translate",
                value: "b>Tus idiomas</b>\nLenguaje principal: {0}\nLengua meta: {1}\n\nIdioma de transcripción de audio: {2}\n\nTu idioma de interfaz: {3}\n\nMostrar el significado de las palabras en inglés - {4}");
        }
    }
}
