using AutoMapper;
using ExternalWebApi.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalWebApi.Biz.CurrencyExchangeRates.Queries
{
    public class GetCurrencyExchangeRatesQuery : IRequest<CurrencyExchangeRatesVm>
    {

    }
    public class GetCurrencyExchangeRatesQueryHandler : IRequestHandler<GetCurrencyExchangeRatesQuery, CurrencyExchangeRatesVm>
    {
        private IApplicationDbContext _context;

        public GetCurrencyExchangeRatesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CurrencyExchangeRatesVm> Handle(GetCurrencyExchangeRatesQuery request, CancellationToken cancellationToken)
        {
            return new CurrencyExchangeRatesVm {
                CurrencyExchangeRates = await _context
                .CurrencyExchangeRates
                .Where(w => w.IsLatest)
                .AsNoTracking()
                .Select(s => new CurrencyExchangeRateDto(
                    s.CurrencyExchange.FromCurrency.CurrencyCode,
                    s.CurrencyExchange.ToCurrency.CurrencyCode,
                    s.Rate
                )).ToListAsync(cancellationToken)
            };
        }
    }
}
