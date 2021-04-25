using OctetWebApi.ExternalApi.Models;
using System.Threading.Tasks;

namespace OctetWebApi.ExternalApi.Services
{
    public interface IThirdPartyCurrencyExchangeService
    {
        Task<ThirdPartyCurrencyExchangeResult> GetRates();
    }

}
