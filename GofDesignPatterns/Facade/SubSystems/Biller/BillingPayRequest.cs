namespace Facade.SubSystems.Biller
{
    public class BillingPayRequest
    {
        public Int64 CustomerId { get; set; }
        public double Amount { get; set; }

        public BillingPayRequest(Int64 customerId, double amount)
        {
            this.CustomerId = customerId;
            this.Amount = amount;
        }
    }
}
