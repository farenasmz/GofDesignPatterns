using AbstractFactory.Service;

namespace AbstractFactory.Rest
{
    public class ProductServiceRest : IProductService
    {
        public string[] GetProducts()
        {
            return new string[] { "Cream", "Soap", "Mouse" };
        }
    }
}
