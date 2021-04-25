using ExternalWebApi.Data.StaticData;
using ExternalWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalWebApi.Domain.Configuration
{
    public class CurrencyExchangeConfiguration : IEntityTypeConfiguration<CurrencyExchange>
    {
        public void Configure(EntityTypeBuilder<CurrencyExchange> builder)
        {
            builder.HasData(
                new CurrencyExchange
                {
                    Id = 1,
                    FromCurrencyId = CurrencyStaticData.GetAUDCurrency().Id,
                    ToCurrencyId = CurrencyStaticData.GetUSDCurrency().Id,
                    BaseRate = 0.7727F
                },
                new CurrencyExchange
                {
                    Id = 2,
                    FromCurrencyId = CurrencyStaticData.GetAUDCurrency().Id,
                    ToCurrencyId = CurrencyStaticData.GetNZDCurrency().Id,
                    BaseRate = 1.0749F
                },
                new CurrencyExchange
                {
                    Id = 3,
                    FromCurrencyId = CurrencyStaticData.GetAUDCurrency().Id,
                    ToCurrencyId = CurrencyStaticData.GetJPYCurrency().Id,
                    BaseRate = 83.5389F
                },
                new CurrencyExchange
                {
                    Id = 4,
                    FromCurrencyId = CurrencyStaticData.GetAUDCurrency().Id,
                    ToCurrencyId = CurrencyStaticData.GetCNYCurrency().Id,
                    BaseRate = 5.0197F
                });
        }
    }
}
