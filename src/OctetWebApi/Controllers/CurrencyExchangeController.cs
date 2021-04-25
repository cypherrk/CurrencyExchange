using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OctetWebApi.Biz.Markup.Commands.AddCurrencyExchangeIfDoesntExist;
using OctetWebApi.Biz.Markup.Queries.GetCurrencyExchange;
using System.Linq;
using System.Threading.Tasks;

namespace OctetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyExchangeController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeController> _logger;
        private readonly ISender _mediator;
        private readonly ThirdPartyCurrencyExchangeApplication _app;

        public CurrencyExchangeController(ILogger<CurrencyExchangeController> logger, ISender mediator, ThirdPartyCurrencyExchangeApplication app)
        {
            _logger = logger;
            _mediator = mediator;
            _app = app;
        }


        [HttpPost]
        public async Task<Unit> AddCurrencyExchange()
        {
            var currencyExchangeResult = (await _app.RunAsync()).CurrencyExchangeRates.Select(s =>
            new CurrencyExchangeDto(s.Currency, s.ToCurrency));

            var vm = new CurrencyExchangeVm
            {
                CurrencyExchanges = currencyExchangeResult
            };

            return await _mediator.Send(new AddCurrencyExchangeIfDoesntExist { 
            CurrencyExchangeVm = vm});
        }
    }
}
