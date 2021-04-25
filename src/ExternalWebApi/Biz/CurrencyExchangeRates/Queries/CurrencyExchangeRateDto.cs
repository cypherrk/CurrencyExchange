namespace ExternalWebApi.Biz.CurrencyExchangeRates.Queries
{
    public record CurrencyExchangeRateDto(string Currency, string ToCurrency, float Rate);

    public record CurrencyDto (string CurrencyCode);
}