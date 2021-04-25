using ExternalWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalWebApi.Domain.Configuration
{
    public class CurrencyExchangeRateConfiguration : IEntityTypeConfiguration<CurrencyExchangeRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyExchangeRate> builder)
        {
            builder.HasData(
                new CurrencyExchangeRate
                {
                    Id = 1,
                    CurrencyExchangeId = 1,
                    Rate = 0.7727F,
                    IsLatest = true
                },
                new CurrencyExchangeRate
                {
                    Id = 2,
                    CurrencyExchangeId = 2,
                    Rate = 1.0749F,
                    IsLatest = true
                },
                new CurrencyExchangeRate
                {
                    Id = 3,
                    CurrencyExchangeId = 3,
                    Rate = 83.5389F,
                    IsLatest = true
                },
                new CurrencyExchangeRate
                {
                    Id = 4,
                    CurrencyExchangeId = 4,
                    Rate = 5.0197F,
                    IsLatest = true
                });
        }
    }
}
