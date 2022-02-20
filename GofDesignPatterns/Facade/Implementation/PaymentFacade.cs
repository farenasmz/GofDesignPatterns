using Facade.SubSystems.Bank;
using Facade.SubSystems.Biller;
using Facade.SubSystems.CRM;
using Facade.SubSystems.Email;
using Facade.Util;

namespace Facade.Implementation
{
    public class PaymentFacade : IPaymentFacade
    {
        private static readonly CRMSystem CrmSystem = new CRMSystem();
        private static readonly BillingSystem BillingSystem = new BillingSystem();
        private static readonly BankSystem BankSystem = new BankSystem();
        private static readonly EmailSystem EmailSenderSystem = new EmailSystem();

        public PaymentResponse Pay(PaymentRequest request)
        {
            Customer customer = CrmSystem.FindCustomer(request.CustomerId);
            //Validate Set
            if (customer == null)
            {
                throw new GeneralPaymentException("Customer ID does not exist '" + request.CustomerId + "' not exist.");
            }
            else if ("Inactive".Equals(customer.Status))
            {
                throw new GeneralPaymentException("Customer ID does not exist '" + request.CustomerId + "' is inactive.");
            }
            else if (request.Ammount > BillingSystem.QueryCustomerBalance(customer.Id))
            {
                throw new GeneralPaymentException("You are trying to make a payment " + "\n\tgreater than the customer's balance");
            }

            //charge to the card
            TransferRequest transfer = new TransferRequest(
                    request.Ammount, request.CardNumber,
                    request.CardName, request.CardExpDate,
                    request.CardNumber);
            string payReference = BankSystem.Transfer(transfer);

            //Impact of the balance in the billing system
            BillingPayRequest billingRequest = new BillingPayRequest(
                    request.CustomerId, request.Ammount);
            double newBalance = BillingSystem.Pay(billingRequest);

            //The client is reactivated if the new balance is less than $ 51
            string newStatus = customer.Status;
            if (newBalance <= 50)
            {
                OnMemoryDataBase.changeCustomerStatus(request.CustomerId, "Active");
                newStatus = "Active";
            }

            //Envio de la confirmación de pago por Email.
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            parameters.Add("$name", customer.Name);
            parameters.Add("$ammount", request.Ammount + "");
            parameters.Add("$newBalance", newBalance + "");
            string number = request.CardNumber;
            string subfix = number.Substring(number.Length - 4, 4);
            parameters.Add("$cardNumber", subfix);
            parameters.Add("$reference", payReference);
            parameters.Add("$newStatus", newStatus);
            EmailSenderSystem.SendEmail(parameters);
            return new PaymentResponse(payReference, newBalance, newStatus);
        }
    }
}
