namespace Adapter.Implementation
{
    public interface IBankAdapter
    {
        BankCreditResponse SendCreditRequest(BankCreditRequest request);
    }
}
