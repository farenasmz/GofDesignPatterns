namespace Adapter.CreditApi.BankX
{
    internal class XBankCreditApi
    {
        public XBankCreditResponse SendCreditRequest(XBankCreditRequest request)
        {
            XBankCreditResponse response = new XBankCreditResponse();
            response.Approval = false;

            if (request.RequestAmount < 5000)
            {
                response.Approval = true;
            }

            return response;
        }
    }
}
