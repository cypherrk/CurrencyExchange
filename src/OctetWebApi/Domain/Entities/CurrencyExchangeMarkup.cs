namespace OctetWebApi.Domain.Entities
{
    public class CurrencyExchangeMarkup
    {
        public int Id { get; set; }

        public CurrencyExchange CurrencyExchange { get; set; }

        public int CurrencyExchangeId { get; set; }

        public float MarkupPercent { get; set; }

        public bool IsLatest { get; set; }
    }
}
