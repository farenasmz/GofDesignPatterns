using MySql.Data.MySqlClient;
using System.Data;

namespace FactoryMethod.Implementation
{
    public class MySqlAdapter : IDBAdapter
    {
        private static readonly string DB_PROPERTIES = "./DBMySQL.properties";

        //Propiedades de los archivos properties
        private static readonly string DB_NAME_PROP = "dbname";
        private static readonly string DB_HOST_PROP = "host";
        private static readonly string DB_PASSWORD_PROP = "password";
        private static readonly string DB_PORT_PROP = "port";
        private static readonly string DB_USER_PROP = "user";

        public IDbConnection GetConnection()
        {
            string connectionString = CreateConnectionString();
            MySqlConnection? connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection class ==> " + connection.GetType().Name);
            return connection;
        }

        private String CreateConnectionString()
        {
            IDictionary<string, string> prop = null;
            using (TextReader reader = new StreamReader(DB_PROPERTIES))
            {
                //prop = PropertiesLoader.Load(reader);
            }
            //Properties prop = PropertiesUtil.loadProperty(DB_PROPERTIES);
            String host = prop[DB_HOST_PROP];
            String port = prop[DB_PORT_PROP];
            String db = prop[DB_NAME_PROP];
            String user = prop[DB_USER_PROP];
            String password = prop[DB_PASSWORD_PROP];

            string connectionString = "SERVER=" + host + ";" + "DATABASE=" + db + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
            Console.WriteLine("ConnectionString ==> " + connectionString);
            return connectionString;
        }
    }
}
