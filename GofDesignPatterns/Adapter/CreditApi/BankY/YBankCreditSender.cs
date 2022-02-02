namespace Adapter.CreditApi.BankY
{
    public class YBankCreditSender
    {
        YBankCreditApprove Request;
        IYBankCreditSenderListener Listener;

        public void StartThread()
        {
            Console.WriteLine("YBank received your request, please wait...");
            YBankCreditApproveResult result = new();
            result.Approved = "Y";

            if (Request.Credit > 1500)
            {
                result.Approved = "N";
            }

            try
            {
                Thread.Sleep(1000 * 30);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Listener.NotifyCreditResult(result);
        }

        public void SendCreditForValidate(YBankCreditApprove request, IYBankCreditSenderListener listener)
        {
            Thread thread;
            Request = request;
            Listener = listener;
            thread = new Thread(StartThread);
            thread.Start();
        }
    }
}
