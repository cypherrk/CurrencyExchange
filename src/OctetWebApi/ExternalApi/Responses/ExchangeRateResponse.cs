namespace OctetWebApi.ExternalApi.Responses
{
    public record ExchangeRateResponse
    {
        public string Currency { get; set; }

        public string ToCurrency { get; set; }

        public float Rate { get; set; }
    }
}