using Microsoft.EntityFrameworkCore.Migrations;

namespace ExternalWebApi.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyCode" },
                values: new object[,]
                {
                    { 1, "AUD" },
                    { 2, "USD" },
                    { 3, "NZD" },
                    { 4, "JPY" },
                    { 5, "CNY" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyExchanges",
                columns: new[] { "Id", "BaseRate", "FromCurrencyId", "ToCurrencyId" },
                values: new object[,]
                {
                    { 1, 0.7727f, 1, 2 },
                    { 2, 1.0749f, 1, 3 },
                    { 3, 83.5389f, 1, 4 },
                    { 4, 5.0197f, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "CurrencyExchangeRates",
                columns: new[] { "Id", "CurrencyExchangeId", "IsLatest", "Rate" },
                values: new object[,]
                {
                    { 1, 1, true, 0.7727f },
                    { 2, 2, true, 1.0749f },
                    { 3, 3, true, 83.5389f },
                    { 4, 4, true, 5.0197f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CurrencyExchangeRates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CurrencyExchangeRates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CurrencyExchangeRates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CurrencyExchangeRates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CurrencyExchanges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CurrencyExchanges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CurrencyExchanges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CurrencyExchanges",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
