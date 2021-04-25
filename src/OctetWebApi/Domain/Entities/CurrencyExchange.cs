namespace OctetWebApi.Domain.Entities
{
    public class CurrencyExchange
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string ToCurrency { get; set; }

    }
}
