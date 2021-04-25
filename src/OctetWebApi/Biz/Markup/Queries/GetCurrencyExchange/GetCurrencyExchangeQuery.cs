using MediatR;
using Microsoft.EntityFrameworkCore;
using OctetWebApi.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OctetWebApi.Biz.Markup.Queries.GetCurrencyExchange
{
    public class GetCurrencyExchangeQuery : IRequest<CurrencyExchangeVm>
    {

    }

    public class GetCurrencyExchangeQueryHandler : IRequestHandler<GetCurrencyExchangeQuery, CurrencyExchangeVm>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public GetCurrencyExchangeQueryHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<CurrencyExchangeVm> Handle(GetCurrencyExchangeQuery request, CancellationToken cancellationToken)
        {
            return new CurrencyExchangeVm
            {
                CurrencyExchanges = await applicationDbContext
                .CurrencyExchanges
                .AsNoTracking()
                .Select(s => new CurrencyExchangeDto(s.Currency, s.ToCurrency))
                .ToListAsync(cancellationToken)
            };
        }
    }
}
