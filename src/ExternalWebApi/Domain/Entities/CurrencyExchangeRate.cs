namespace ExternalWebApi.Domain.Entities
{
    public class CurrencyExchangeRate
    {
        public int Id { get; set; }

        public int CurrencyExchangeId { get; set; }
        public CurrencyExchange CurrencyExchange { get; set; }

        public float Rate { get; set; }

        public bool IsLatest { get; set; }
    }

}
