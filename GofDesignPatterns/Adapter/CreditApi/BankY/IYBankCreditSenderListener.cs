namespace Adapter.CreditApi.BankY
{
    public interface IYBankCreditSenderListener
    {
        void NotifyCreditResult(YBankCreditApproveResult result);
    }
}
