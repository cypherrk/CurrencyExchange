using Microsoft.Extensions.Options;
using ExternalWebApi.Models;
using System.Threading.Tasks;
using MediatR;
using ExternalWebApi.Biz.CurrencyExchangeRates.Commands;

namespace ExternalWebApi.Biz
{
    public class RefreshLatestCurrencyExchangeRates : IRefreshLatestCurrencyExchangeRates 
    {
        public RefreshLatestCurrencyExchangeRates(ISender mediator)
        {
            Mediator = mediator;
        }

        public ISender Mediator { get; }

        public async Task Refresh()
        {
            await Mediator.Send(new RefreshCurrencyExchangeRatesCommand());
        }
        
    }
    public interface IRefreshLatestCurrencyExchangeRates 
    {
        Task Refresh();
    }
}