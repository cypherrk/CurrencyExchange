using OctetWebApi.ExternalApi.Models;
using OctetWebApi.ExternalApi.Services;
using System.Threading.Tasks;

namespace OctetWebApi
{
    public class ThirdPartyCurrencyExchangeApplication
    {
        private readonly IThirdPartyCurrencyExchangeService _thirdPartyCurrencyExchangeService;

        public ThirdPartyCurrencyExchangeApplication(IThirdPartyCurrencyExchangeService thirdPartyCurrencyExchangeService)
        {
            _thirdPartyCurrencyExchangeService = thirdPartyCurrencyExchangeService;
        }
        public async Task<ThirdPartyCurrencyExchangeResult> RunAsync()
        {
            var result = await _thirdPartyCurrencyExchangeService.GetRates();
            return result;
        }
    }
}
