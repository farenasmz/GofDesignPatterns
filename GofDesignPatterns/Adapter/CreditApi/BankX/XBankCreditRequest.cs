using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.CreditApi.BankX
{
    public class XBankCreditRequest
    {
        public string CustomerName { get; set; }
        public double RequestAmount { get; set; }
    }
}
