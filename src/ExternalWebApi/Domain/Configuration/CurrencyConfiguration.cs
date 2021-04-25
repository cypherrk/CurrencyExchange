using ExternalWebApi.Data.StaticData;
using ExternalWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalWebApi.Domain.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(
                    CurrencyStaticData.GetAUDCurrency(),
                    CurrencyStaticData.GetUSDCurrency(),
                    CurrencyStaticData.GetNZDCurrency(),
                    CurrencyStaticData.GetJPYCurrency(),
                    CurrencyStaticData.GetCNYCurrency());
        }
    }
}
