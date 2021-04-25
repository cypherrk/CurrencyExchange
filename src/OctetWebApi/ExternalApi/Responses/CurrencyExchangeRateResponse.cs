using System.Collections.Generic;

namespace OctetWebApi.ExternalApi.Responses
{
    public record CurrencyExchangeRateResponse
    {
        public IReadOnlyList<ExchangeRateResponse> currencyExchangeRates { get; set; }
    }
}
