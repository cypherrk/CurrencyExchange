using ExternalWebApi.Domain.Entities;

namespace ExternalWebApi.Data.StaticData
{
    public static class CurrencyStaticData
    {
        public static Currency GetAUDCurrency()
        {
            return new Currency
            {
                Id = 1,
                CurrencyCode = "AUD"
            };
        }

        public static Currency GetUSDCurrency()
        {
            return new Currency
            {
                Id = 2,
                CurrencyCode = "USD"
            };
        }

        public static Currency GetNZDCurrency()
        {
            return new Currency
            {
                Id = 3,
                CurrencyCode = "NZD"
            };
        }

        public static Currency GetJPYCurrency()
        {
            return new Currency
            {
                Id = 4,
                CurrencyCode = "JPY"
            };
        }

        public static Currency GetCNYCurrency()
        {
            return new Currency
            {
                Id = 5,
                CurrencyCode = "CNY"
            };
        }

    }
}
