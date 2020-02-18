using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClinicManagement.Persistence
{
    class NpgsqlConnectionImpl : IConnection
    {
        private Npgsql.NpgsqlConnection connection;
        private string connectionString;
      
        private static IConnection _instance = null;
        private static object _lock = new object();

        private NpgsqlConnectionImpl() {
            connectionString = String.Format("Host={0};Username={1};Password={2};Database=Clinic",
            getDbHost(), getDbUser(), getDbPassword());

        }
        public static IConnection GetInstance()
        {
            lock (_lock)
            {
                if(_instance == null)
                {
                    _instance = new NpgsqlConnectionImpl();
                }
            }
            return _instance;
        }
        public object GetCurrentConnection()
        {
            if(connection != null)
            {
                return connection;
            }
            else
            {
                return (connection = (Npgsql.NpgsqlConnection)GetNewConnection());
            }
        }

        public object GetNewConnection()
        {
            Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        private static String getDbHost()
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines("dbsettings.txt"))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            if(data["host"] != null)
            {
                return data["host"];
            }
            else
            {
                return "locahost";
            }

        }
        private static String getDbUser()
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines("dbsettings.txt"))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            if (data["user"] != null)
            {
                return data["user"];
            }
            else
            {
                return "postgres";
            }

        }
        private static String getDbPassword()
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines("dbsettings.txt"))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            if (data["password"] != null)
            {
                return data["password"];
            }
            else
            {
                return "Password123$";
            }

        }
    }
}
