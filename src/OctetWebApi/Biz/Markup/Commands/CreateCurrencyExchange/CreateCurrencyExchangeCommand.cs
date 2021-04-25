using MediatR;
using OctetWebApi.Common.Interfaces;
using OctetWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OctetWebApi.Biz.Markup.Commands.CreateCurrencyExchange
{
    public class CreateCurrencyExchangeCommand : IRequest<int>
    {
        public string Currency { get; set; }

        public string ToCurrency { get; set; }
    }

    public class CreateCurrencyExchangeCommandHandler : IRequestHandler<CreateCurrencyExchangeCommand, int>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public CreateCurrencyExchangeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateCurrencyExchangeCommand request, CancellationToken cancellationToken)
        {
            var entity = new CurrencyExchange
            {
                Currency = request.Currency,
                ToCurrency = request.ToCurrency
            };

            applicationDbContext.CurrencyExchanges.Add(entity);

            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
