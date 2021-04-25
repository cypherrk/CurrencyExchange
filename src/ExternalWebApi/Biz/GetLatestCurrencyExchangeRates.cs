using Microsoft.Extensions.Options;
using ExternalWebApi.Models;
using System.Threading.Tasks;
using MediatR;
using ExternalWebApi.Biz.CurrencyExchangeRates.Queries;

namespace ExternalWebApi.Biz
{
    public class GetLatestCurrencyExchangeRates : IGetLatestCurrencyExchangeRates 
    {
        public GetLatestCurrencyExchangeRates(ISender mediator)
        {
            Mediator = mediator;
        }

        public ISender Mediator { get; }

        public async ValueTask<CurrencyExchangeRatesVm> Get()
        {
            return await Mediator.Send(new GetCurrencyExchangeRatesQuery());
        }
        
    }
    public interface IGetLatestCurrencyExchangeRates 
    {
        ValueTask<CurrencyExchangeRatesVm> Get();
    }
}