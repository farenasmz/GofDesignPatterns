using AbstractFactory.Service;

namespace AbstractFactory.Factory
{
    public interface IAbstractFactory
    {
        IEmployeeService GetEmployeeService();
        IProductService GetProductService();
    }
}
