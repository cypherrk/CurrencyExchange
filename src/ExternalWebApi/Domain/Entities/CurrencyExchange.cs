namespace ExternalWebApi.Domain.Entities
{
    public class CurrencyExchange
    {
        public int Id { get; set; }

        public int FromCurrencyId { get; set; }
        public Currency FromCurrency { get; set; }

        public int ToCurrencyId { get; set; }
        public Currency ToCurrency { get; set; }

        public float BaseRate { get; set; }
    }

}
