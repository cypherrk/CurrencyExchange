using System.Collections.Generic;

namespace OctetWebApi.ExternalApi.Models
{
    public record ThirdPartyCurrencyExchangeResult
    {
        public IReadOnlyList<CurrencyExchangeRateResult> CurrencyExchangeRates { get; init; }
    }
}
