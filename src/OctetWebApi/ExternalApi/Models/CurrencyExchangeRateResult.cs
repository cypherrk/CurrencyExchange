namespace OctetWebApi.ExternalApi.Models
{
    public record CurrencyExchangeRateResult
    {
        public string Currency { get; init; }

        public string ToCurrency { get; init; }

        public float Rate { get; init; }
    }
}