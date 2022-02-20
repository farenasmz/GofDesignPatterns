using Facade.Util;

namespace Facade.SubSystems.Biller
{
    public class BillingSystem
    {
        public double QueryCustomerBalance(Int64 customerId)
        {
            Customer customer = OnMemoryDataBase.findCustomerById(customerId);
            return customer.Balance;
        }

        public double Pay(BillingPayRequest billingPay)
        {
            Customer customer = OnMemoryDataBase.findCustomerById(billingPay.CustomerId);
            customer.Balance = customer.Balance - billingPay.Amount;
            Console.WriteLine("Payment applied to the client '" + customer.Name + "', " + "the new balance is '" + customer.Balance + "'");
            return customer.Balance;//new Balance.
        }
    }
}
