using AbstractFactory.Factory;
using AbstractFactory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.WebService
{
    internal class WSServiceImplementation : IAbstractFactory
    {
        public IEmployeeService GetEmployeeService()
        {
            return new EmployeeServiceWS();
        }

        public IProductService GetProductService()
        {
            return new ProductServiceWS();
        }
    }
}
