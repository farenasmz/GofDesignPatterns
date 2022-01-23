using AbstractFactory.Service;

namespace AbstractFactory.WebService
{
    public class ProductServiceWS : IProductService
    {
        public string[] GetProducts()
        {
            return new string[] { "KeyBoard", "Mouse", "Monitor" };
        }
    }
}
