using Adapter.CreditApi.BankY;

namespace Adapter.Implementation
{
    public class YBankCreditAdapter : IBankAdapter, IYBankCreditSenderListener
    {
        private YBankCreditApproveResult YResponse;

        public void NotifyCreditResult(YBankCreditApproveResult result)
        {
            throw new NotImplementedException();
        }

        public BankCreditResponse SendCreditRequest(BankCreditRequest request)
        {
            YBankCreditApprove yRequest = new YBankCreditApprove();
            yRequest.Credit = (float)request.Amount;
            yRequest.Name = request.Customer;

            YBankCreditSender sender = new();
            sender.SendCreditForValidate(yRequest, this);
            do
            {
                try
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("YBank is working...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (YResponse == null);

            return new BankCreditResponse()
            {
                Approved = YResponse.Approved == "Y"
            };
        }
    }
}
