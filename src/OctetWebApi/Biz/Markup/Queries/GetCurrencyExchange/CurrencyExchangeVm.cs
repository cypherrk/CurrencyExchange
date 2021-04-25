using System.Collections.Generic;

namespace OctetWebApi.Biz.Markup.Queries.GetCurrencyExchange
{
    public class CurrencyExchangeVm
    {
        public IEnumerable<CurrencyExchangeDto> CurrencyExchanges { get; set; }
    }
}