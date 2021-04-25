using System;
using System.Collections.Generic;
using System.Linq;
using ExternalWebApi.Models;
using System.Runtime.Caching;
using ExternalWebApi.Biz.CurrencyExchangeRates.Queries;

namespace ExternalWebApi.Biz
{
    public class SetCurrencyExchangeRatesToCache : ISetCurrencyExchangeRatesToCache
    {

        public  CurrencyExchangeRatesVm Set(CurrencyExchangeRatesVm rates)
        {       
            var cache = MemoryCache.Default;
            var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(60);
            cache.Set("currencyExchangeRatesVm", rates,  policy);
            Console.WriteLine("set to cache");
            return rates;
        }

    }

    public interface ISetCurrencyExchangeRatesToCache
    {
        CurrencyExchangeRatesVm Set(CurrencyExchangeRatesVm rates);
    }
}