using Microsoft.EntityFrameworkCore;
using OctetWebApi.Common.Interfaces;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using OctetWebApi.Domain.Entities;

namespace OctetWebApi.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }

        public DbSet<CurrencyExchangeMarkup> Markups { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
