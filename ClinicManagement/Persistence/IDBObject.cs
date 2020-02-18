using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistence
{
    public interface IDBObject
    {
        string GetAddStatement();
        string GetUpdateStatement();
        string GetObjectByIdQuery();
        string GetDeleteStatement();
        string GetUniqueObjectQuery();
        void SetId(int id);
    }
}
