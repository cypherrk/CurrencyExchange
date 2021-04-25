using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExternalWebApi.Biz;
using ExternalWebApi.Biz.CurrencyExchangeRates.Queries;

namespace ExternalWebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CurrencyExchangeController : ControllerBase {

        private IGetCurrencyExchangeRates _getCurrencyExchangeRates;
        public CurrencyExchangeController(IGetCurrencyExchangeRates getCurrencyExchangeRates)
        {
            _getCurrencyExchangeRates = getCurrencyExchangeRates;
        }

        [HttpGet]
        public async ValueTask<CurrencyExchangeRatesVm> Get()
        {
            return await _getCurrencyExchangeRates.Get();
        }
    }

}