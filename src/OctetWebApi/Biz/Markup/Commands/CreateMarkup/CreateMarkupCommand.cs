using MediatR;
using Microsoft.EntityFrameworkCore;
using OctetWebApi.Common.Interfaces;
using OctetWebApi.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OctetWebApi.Biz.Markup.Commands.CreateMarkup
{
    public class CreateMarkupCommand : IRequest<int>
    {
        public int CurrencyExchangeId { get; set; }
        public float MarkupPercent { get; set; }
    }

    public class CreateMarkupCommandHandler : IRequestHandler<CreateMarkupCommand, int>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public CreateMarkupCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateMarkupCommand request, CancellationToken cancellationToken)
        {
            var currentMarkup = await applicationDbContext
                .Markups
                .Where(w => w.CurrencyExchangeId == request.CurrencyExchangeId && w.IsLatest)
                .FirstOrDefaultAsync(cancellationToken);

            if (currentMarkup != null)
            {
                currentMarkup.IsLatest = false;
            }

            var entity = new CurrencyExchangeMarkup
            {
                CurrencyExchangeId = request.CurrencyExchangeId,
                MarkupPercent =request.MarkupPercent,
                IsLatest =true
            };

            applicationDbContext.Markups.Add(entity);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
