using MediatR;
using OctetWebApi.Biz.Markup.Queries.GetCurrencyExchange;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using OctetWebApi.Biz.Markup.Commands.CreateCurrencyExchange;

namespace OctetWebApi.Biz.Markup.Commands.AddCurrencyExchangeIfDoesntExist
{
    public class AddCurrencyExchangeIfDoesntExist : IRequest<Unit>
    {
        public CurrencyExchangeVm CurrencyExchangeVm { get; set; }
    }

    public class AddCurrencyExchangeIfDoesntExistHandler : IRequestHandler<AddCurrencyExchangeIfDoesntExist, Unit>
    {
        private readonly ISender mediator;

        public AddCurrencyExchangeIfDoesntExistHandler(ISender mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(AddCurrencyExchangeIfDoesntExist request, CancellationToken cancellationToken)
        {
            var currencyExchanges = (await mediator.Send(new GetCurrencyExchangeQuery())).CurrencyExchanges;
 
            foreach (var curr in request.CurrencyExchangeVm.CurrencyExchanges)
            {
                if (!currencyExchanges.Any(a => a.Currency == curr.Currency && a.ToCurrency == curr.ToCurrency))
                {
                    await mediator.Send(new CreateCurrencyExchangeCommand { Currency = curr.Currency, ToCurrency = curr.ToCurrency });
                }
            }
            return Unit.Value;
        }
    }
}
