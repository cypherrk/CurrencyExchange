using OctetWebApi.ExternalApi.Mapping;
using OctetWebApi.ExternalApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OctetWebApi.ExternalApi.Services
{
    public class ThirdPartyCurrencyExchangeService : IThirdPartyCurrencyExchangeService
    {
        private readonly IThirdPartyCurrencyExchangeApi _thirdPartyCurrencyExchangeApi;

        public ThirdPartyCurrencyExchangeService(IThirdPartyCurrencyExchangeApi thirdPartyCurrencyExchangeApi)
        {
            _thirdPartyCurrencyExchangeApi = thirdPartyCurrencyExchangeApi;
        }

        public async Task<ThirdPartyCurrencyExchangeResult> GetRates()
        {
            //validate the request

            //call the api and map the response
            var response = await _thirdPartyCurrencyExchangeApi.GetRatesAsync();
            return new ThirdPartyCurrencyExchangeResult
            {
                CurrencyExchangeRates = response.currencyExchangeRates.Select(s => s.ToCurrencyExchangeRatesResult()).ToList()
            };
        }
    }

}
