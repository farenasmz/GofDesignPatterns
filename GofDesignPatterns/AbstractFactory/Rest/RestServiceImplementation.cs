using AbstractFactory.Factory;
using AbstractFactory.Service;

namespace AbstractFactory.Rest
{
    public class RestServiceImplementation : IAbstractFactory
    {
        public IEmployeeService GetEmployeeService()
        {
            return new EmployeeServiceRest();
        }

        public IProductService GetProductService()
        {
            return new ProductServiceRest();
        }
    }
}
