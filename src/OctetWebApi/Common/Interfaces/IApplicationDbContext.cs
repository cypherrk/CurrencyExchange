using Microsoft.EntityFrameworkCore;
using OctetWebApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OctetWebApi.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<CurrencyExchangeMarkup> Markups { get; set; }

        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
