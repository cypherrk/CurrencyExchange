using OctetWebApi.ExternalApi.Models;
using OctetWebApi.ExternalApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctetWebApi.ExternalApi.Mapping
{
    public static class ThirdPartyContractToModelMapping
    {
        public static CurrencyExchangeRateResult  ToCurrencyExchangeRatesResult(this ExchangeRateResponse response)
        {
            return new()
            {
                Currency = response.Currency,
                ToCurrency = response.ToCurrency,
                Rate = response.Rate
            }; 
        }
    }
}
