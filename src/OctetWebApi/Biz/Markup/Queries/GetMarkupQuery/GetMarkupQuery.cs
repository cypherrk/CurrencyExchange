using MediatR;
using Microsoft.EntityFrameworkCore;
using OctetWebApi.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OctetWebApi.Biz.Markup.Queries.GetMarkupQuery
{
    public class GetMarkupQuery : IRequest<MarkupsVm>
    {

    }
    public class GetMarkupQueryHandler : IRequestHandler<GetMarkupQuery, MarkupsVm>
    {
        private IApplicationDbContext _context;

        public GetMarkupQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MarkupsVm> Handle(GetMarkupQuery request, CancellationToken cancellationToken)
        {
            return new MarkupsVm
            {
                Markups = await _context
                .Markups
                .Where(w => w.IsLatest)
                .AsNoTracking()
                .Select(s => new MarkupDto(s.CurrencyExchange.Currency, s.CurrencyExchange.ToCurrency, s.MarkupPercent))
                .ToListAsync(cancellationToken)
            };
        }
    }
}
