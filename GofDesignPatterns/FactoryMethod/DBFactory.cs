using FactoryMethod.Implementation;
using FactoryMethod.Util;

namespace FactoryMethod
{
    public class DBFactory
    {
        public static IDBAdapter GetDBAdapter(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.MySQL:
                    return new MySqlAdapter();
                case DbType.SQLServer:
                    return new SqlServerAdapter();
                default:
                    throw new ArgumentException("");
            }
        }
    }
}
