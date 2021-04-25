using OctetWebApi.ExternalApi.Responses;
using Refit;
using System.Threading.Tasks;

namespace OctetWebApi.ExternalApi
{
    public interface IThirdPartyCurrencyExchangeApi
    {
        [Get("/CurrencyExchange")]
        Task<CurrencyExchangeRateResponse> GetRatesAsync();

    }
}
