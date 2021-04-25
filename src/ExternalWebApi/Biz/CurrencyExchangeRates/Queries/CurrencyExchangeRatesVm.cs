using System.Collections.Generic;

namespace ExternalWebApi.Biz.CurrencyExchangeRates.Queries
{
    public class CurrencyExchangeRatesVm
    {
        public IList<CurrencyExchangeRateDto> CurrencyExchangeRates { get; set; }
    }
}
