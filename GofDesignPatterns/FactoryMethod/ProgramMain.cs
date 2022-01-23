using FactoryMethod.DAO;
using FactoryMethod.Entity;

namespace FactoryMethod
{
    public class ProgramMain
    {
        public void Action()
        {
            Product product = new Product
            {
                IdProduct = 1,
                Price = 2000,
                ProductName = "Cream"
            };

            ProductDao dao = new ProductDao(Util.DbType.SQLServer);
            List<Product>? result = dao.FindAllProducts();
            dao.SaveProduct(product);
        }
    }
}
