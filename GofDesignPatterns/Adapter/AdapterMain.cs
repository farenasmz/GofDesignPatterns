using Adapter.Implementation;

namespace Adapter
{
    public class AdapterMain
    {
        public void Action()
        {
            BankCreditRequest request = new BankCreditRequest()
            {
                Amount = 1000,
                Customer = "Fabian"
            };

            IBankAdapter xBank = new XBankCreditAdapter();
            BankCreditResponse response = xBank.SendCreditRequest(request);
            Console.WriteLine("XBank response: " + response.Approved);

            IBankAdapter yBank = new YBankCreditAdapter();
            BankCreditResponse yResponse = yBank.SendCreditRequest(request);
            Console.WriteLine("YBank response: " + yResponse.Approved);
        }
    }
}