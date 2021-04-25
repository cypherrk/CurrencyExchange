using System.Threading.Tasks;
using ExternalWebApi.Biz.CurrencyExchangeRates.Queries;

namespace ExternalWebApi.Biz
{
    public class GetCurrencyExchangeRates : IGetCurrencyExchangeRates
    {

        private readonly IGetCurrencyExchangeRatesFromCache _getCurrencyExchangeRatesFromCache;
        private readonly IGetLatestCurrencyExchangeRates _getLatestCurrencyExchangeRates;
        private readonly ISetCurrencyExchangeRatesToCache _setCurrencyExchangeRatesToCache;
        private readonly IRefreshLatestCurrencyExchangeRates _refreshLatestCurrencyExchangeRates;

        public GetCurrencyExchangeRates(IGetCurrencyExchangeRatesFromCache getCurrencyExchangeRatesFromCache,
        IGetLatestCurrencyExchangeRates getLatestCurrencyExchangeRates,
        ISetCurrencyExchangeRatesToCache setCurrencyExchangeRatesToCache,
        IRefreshLatestCurrencyExchangeRates refreshLatestCurrencyExchangeRates)
        {
            _setCurrencyExchangeRatesToCache = setCurrencyExchangeRatesToCache;
            _refreshLatestCurrencyExchangeRates = refreshLatestCurrencyExchangeRates;
            _getCurrencyExchangeRatesFromCache = getCurrencyExchangeRatesFromCache;
            _getLatestCurrencyExchangeRates = getLatestCurrencyExchangeRates;
        }

        public async ValueTask<CurrencyExchangeRatesVm> Get()
        {
            return _getCurrencyExchangeRatesFromCache.Get() ?? await GetLatest();
        }

        private async ValueTask<CurrencyExchangeRatesVm> GetLatest()
        {
            await _refreshLatestCurrencyExchangeRates.Refresh();
            var latestRates = await _getLatestCurrencyExchangeRates.Get();
            _setCurrencyExchangeRatesToCache.Set(latestRates);
            return latestRates;
        }

    }

    public interface IGetCurrencyExchangeRates
    {
        ValueTask<CurrencyExchangeRatesVm> Get();

    }

}