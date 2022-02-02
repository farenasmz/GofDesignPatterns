using Adapter.CreditApi.BankX;

namespace Adapter.Implementation
{
    public class XBankCreditAdapter : IBankAdapter
    {
        public BankCreditResponse SendCreditRequest(BankCreditRequest request)
        {
            XBankCreditRequest xRequest = new()
            {
                CustomerName = request.Customer,
                RequestAmount = request.Amount
            };

            XBankCreditApi api = new XBankCreditApi();
            XBankCreditResponse xResponse = api.SendCreditRequest(xRequest);
            return new BankCreditResponse()
            {
                Approved = xResponse.Approval
            };
        }
    }
}
