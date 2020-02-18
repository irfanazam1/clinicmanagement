using ClinicManagement.Persistence;
using ClinicManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain
{
    public class Patient : IDBObject
    {
        private int id;
        private string patientId = "0";
        private string name;
        private string address;
        private string gender;
        private DateTime dateOfBirth;
        private string phone;
        private string email;
        private string nic;

        public int Id { get => id; set => id = value; }
        public string PatientId { get => patientId; set => patientId = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Nic { get => nic; set => nic = value; }

        public static string TABLE_NAME = "patient";

        public string GetAddStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ").Append(TABLE_NAME);
            sb.Append(" (pat_id, name, dob, gender, phone, address, email, nic) VALUES ( ");
            sb.Append("'").Append(PatientId).Append("',");
            sb.Append("'").Append(Name).Append("',");
            sb.Append("'").Append(DateOfBirth).Append("',");
            sb.Append("'").Append(Gender).Append("',");
            sb.Append("'").Append(Phone).Append("',");
            sb.Append("'").Append(Address).Append("',");
            sb.Append("'").Append(Email).Append("',");
            sb.Append("'").Append(Nic).Append("'").Append(")");
            return sb.ToString();
        }

        public string GetDeleteStatement()
        {
            return String.Format("DELETE FROM {0} WHERE pat_id = '{1}'", TABLE_NAME, this.patientId);
        }

        public string GetObjectByIdQuery()
        {
            return String.Format("SELECT * FROM {0} WHERE pat_id = '{1}'", TABLE_NAME, this.patientId);
        }

        public string GetUpdateStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ").Append(TABLE_NAME).Append(" SET ")
            .Append("name = '").Append(Name).Append("',")
            .Append("address = '").Append(Address).Append("',")
            .Append("dob = '").Append(DateOfBirth).Append("',")
            .Append("nic = '").Append(Nic).Append("',")
            .Append("phone = '").Append(Phone).Append("',")
            .Append("gender = '").Append(Gender).Append("',")
            .Append("email = '").Append(Email).Append("'")
            .Append(" WHERE pat_id = '").Append(patientId).Append("'");
            return sb.ToString(); 
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public string GetUniqueObjectQuery()
        {
            return this.GetObjectByIdQuery();
        }
    }
}
