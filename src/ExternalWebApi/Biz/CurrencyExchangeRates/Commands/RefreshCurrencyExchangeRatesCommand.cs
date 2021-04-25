using ExternalWebApi.Common.Interfaces;
using ExternalWebApi.Domain.Entities;
using ExternalWebApi.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalWebApi.Biz.CurrencyExchangeRates.Commands
{
    public class RefreshCurrencyExchangeRatesCommand : IRequest
    {
    }

    public class RefreshCurrencyExchangeRatesCommandHandler : IRequestHandler<RefreshCurrencyExchangeRatesCommand>
    {
        private readonly IApplicationDbContext _context;

        public RefreshCurrencyExchangeRatesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RefreshCurrencyExchangeRatesCommand request, CancellationToken cancellationToken)
        {
            var RefreshLatest = await _context.CurrencyExchangeRates
                .Where(w => w.IsLatest)
                .ToListAsync();

            RefreshLatest.ForEach(f => f.IsLatest = false);

            RefreshLatest
                .ForEach(s => 
                _context.CurrencyExchangeRates.Add( 
                    new CurrencyExchangeRate
                    {
                        CurrencyExchangeId = s.CurrencyExchangeId,
                        Rate = s.Rate + Utils.RandomFloat() - Utils.RandomFloat(),
                        IsLatest = true
                    }));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
