using System;
using System.Collections.Generic;
using ExternalWebApi.Models;
using System.Runtime.Caching;
using ExternalWebApi.Biz.CurrencyExchangeRates.Queries;

namespace ExternalWebApi.Biz
{
    public class GetCurrencyExchangeRatesFromCache : IGetCurrencyExchangeRatesFromCache
    {
        public CurrencyExchangeRatesVm Get() 
        {
            var cache = MemoryCache.Default;
            var currencyExchangeRates = (CurrencyExchangeRatesVm) cache.Get("currencyExchangeRatesVm");
            Console.WriteLine("calling from cache");
            return currencyExchangeRates;
        }
        
    }

    public interface IGetCurrencyExchangeRatesFromCache 
    {
        CurrencyExchangeRatesVm Get(); 

    }
}