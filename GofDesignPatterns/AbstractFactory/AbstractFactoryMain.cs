using AbstractFactory.Factory;

namespace AbstractFactory
{
    public class AbstractFactoryMain
    {
        public void Action()
        {
            Factory.AbstractFactory? abstractFactory = new Factory.AbstractFactory(ServiceType.Rest);
            IAbstractFactory? factory = abstractFactory.CreateFactory();
            Service.IEmployeeService? employees = factory.GetEmployeeService();
            Service.IProductService? products = factory.GetProductService();
        }
    }
}