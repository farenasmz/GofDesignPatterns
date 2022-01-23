using System.Data;

namespace FactoryMethod
{
    public interface IDBAdapter
    {
        public IDbConnection GetConnection();
    }
}
