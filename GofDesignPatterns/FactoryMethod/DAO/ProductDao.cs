using FactoryMethod.Entity;
using System.Data;

namespace FactoryMethod.DAO
{
    public class ProductDao
    {
        private IDBAdapter DbAdapter;

        public ProductDao(Util.DbType dbType)
        {
            DbAdapter = DBFactory.GetDBAdapter(dbType);
        }

        public List<Product> FindAllProducts()
        {
            IDbConnection connection = DbAdapter.GetConnection();
            List<Product> productList = new List<Product>();
            try
            {
                IDbCommand statement = connection.CreateCommand();
                statement.CommandText = "SELECT idProductos, productName, productPrice FROM Productos";
                statement.CommandType = CommandType.Text;

                IDataReader query = statement.ExecuteReader();

                while (query.Read())
                {
                    productList.Add(new Product((Int32)query["idProductos"], (string)query["productName"], (Int32)query["productPrice"]));
                }
                query.Close();
                connection.Close();
                return productList;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool SaveProduct(Product product)
        {
            IDbConnection connection = DbAdapter.GetConnection();
            try
            {
                IDbCommand statement = connection.CreateCommand();
                //PreparedStatement statement = connection.prepareStatement("INSERT INTO Productos(idProductos," + "productName,productPrice) VALUES (?,?,?)");
                statement.CommandText = "INSERT INTO Productos(idProductos, productName, productPrice) VALUES (?idProductos, ?productName, ?productPrice)";
                statement.CommandType = CommandType.Text;

                IDbDataParameter idProdParam = statement.CreateParameter();
                idProdParam.ParameterName = "idProductos";
                idProdParam.Value = product.IdProduct;

                IDbDataParameter nameProdParam = statement.CreateParameter();
                nameProdParam.ParameterName = "productName";
                nameProdParam.Value = product.ProductName;

                IDbDataParameter priceProdParam = statement.CreateParameter();
                priceProdParam.ParameterName = "productPrice";
                priceProdParam.Value = product.Price;

                statement.Parameters.Add(idProdParam);
                statement.Parameters.Add(nameProdParam);
                statement.Parameters.Add(priceProdParam);

                statement.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
