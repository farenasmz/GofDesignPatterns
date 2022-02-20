namespace Facade.Implementation
{
    public class PaymentRequest
    {
        public Int64 CustomerId { get; set; }
        public double Ammount { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpDate { get; set; }
        public string CardSecureNum { get; set; }
    }
}
