using ExternalWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalWebApi.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }

        public DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
