using System.Collections.Generic;

namespace ClinicManagement.Persistence
{
    public interface IDatabase
    {
        bool AddObject(IDBObject dbObject);
        bool DeleteObject(IDBObject dbObject);
        bool UpdateObject(IDBObject dbObject);
        object GetDataReader(string query, System.Data.IDbConnection connection);
        DbRecord GetData(string query);
    }
}
