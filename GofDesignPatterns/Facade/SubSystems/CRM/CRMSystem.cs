using Facade.Util;

namespace Facade.SubSystems.CRM
{
    public class CRMSystem
    {
        public Customer FindCustomer(Int64 customerId)
        {
            return OnMemoryDataBase.findCustomerById(customerId);
        }
    }
}
