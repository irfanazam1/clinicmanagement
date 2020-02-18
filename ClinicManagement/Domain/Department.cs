using ClinicManagement.Persistence;
using System;
using System.Text;

namespace ClinicManagement.Domain
{
    public class Department : IDBObject
    {
        private int id;
        private String name;
        private String description;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Id { get => id; set => id = value; }

        public static string TABLE_NAME = "department";

        public string GetAddStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ").Append(TABLE_NAME);
            sb.Append(" (name, description) VALUES ( ");
            sb.Append("'").Append(Name).Append("',");
            sb.Append("'").Append(Description).Append("'").Append(")");
            return sb.ToString();
        }

        public string GetDeleteStatement()
        {
            return String.Format("DELETE FROM {0} WHERE id = '{1}'", TABLE_NAME, Id);
        }

        public string GetObjectByIdQuery()
        {
            return String.Format("SELECT * FROM {0} WHERE Id = '{1}'", TABLE_NAME, Id);
        }

        public string GetUniqueObjectQuery()
        {
            return String.Format("SELECT * FROM {0} WHERE name = '{1}'", TABLE_NAME, Name);
        }

        public string GetUpdateStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ").Append(TABLE_NAME).Append(" SET ")
            .Append("name = '").Append(Name).Append("',")
            .Append("description = '").Append(Description).Append("' ")
            .Append(" WHERE id = ").Append(Id);
            return sb.ToString();
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
