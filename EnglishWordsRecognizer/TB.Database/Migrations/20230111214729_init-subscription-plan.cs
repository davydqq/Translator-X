using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TB.Database.Migrations
{
    /// <inheritdoc />
    public partial class initsubscriptionplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { true, 2147483647, 2147483647, 2147483647, "Unlimit", 2147483647.0 });

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { 30, 300, 10000, "Standart", 0.0 });

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { false, 150, 900, 50000, "Premium", 3.0 });

            migrationBuilder.InsertData(
                schema: "billing",
                table: "Plan",
                columns: new[] { "Id", "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { 4, false, 500, 5000, 200000, "Premium +", 11.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { false, 30, 300, 10000, "Standart", 0.0 });

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { 150, 900, 50000, "Premium", 3.0 });

            migrationBuilder.UpdateData(
                schema: "billing",
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsCustomPlan", "MaxAnalysisPhotoCountMonth", "MaxAudioTranscriptionSecondsMonth", "MaxTranslateCharsMonth", "Name", "Price" },
                values: new object[] { true, 2147483647, 2147483647, 2147483647, "Unlimit", 2147483647.0 });
        }
    }
}
