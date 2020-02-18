using ClinicManagement.Persistence;
using System;
using System.Text;

namespace ClinicManagement.Domain
{
    public class Doctor : IDBObject
    {
        private int id;
        private string doctorId;
        private string name;
        private string adress;
        private int departmentId;
        private string qualification;
        private string specialization;
        private string phone;
        private string schedule;
        private string gender;
        private string email;
        private static string TABLE_NAME = "doctor";

        public int Id { get => id; set => id = value; }
        public string DoctorId { get => doctorId; set => doctorId = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => adress; set => adress = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public string Qualification { get => qualification; set => qualification = value; }
        public string Specialization { get => specialization; set => specialization = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Schedule { get => schedule; set => schedule = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }

        public string GetAddStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ").Append(TABLE_NAME);
            sb.Append(" (doctor_id, name, address, qualification, specialization, phone, department_id, schedule, gender, email) VALUES ( ");
            sb.Append("'").Append(DoctorId).Append("',");
            sb.Append("'").Append(Name).Append("',");
            sb.Append("'").Append(Address).Append("',");
            sb.Append("'").Append(Qualification).Append("',");
            sb.Append("'").Append(Specialization).Append("',");
            sb.Append("'").Append(Phone).Append("',");
            sb.Append("'").Append(DepartmentId).Append("',");
            sb.Append("'").Append(Schedule).Append("',");
            sb.Append("'").Append(Gender).Append("',");
            sb.Append("'").Append(Email).Append("'").Append(")");
            return sb.ToString();
        }

        public string GetDeleteStatement()
        {
            return String.Format("DELETE FROM {0} WHERE doctor_id = '{1}'", TABLE_NAME, this.doctorId);
        }

        public string GetObjectByIdQuery()
        {
            return String.Format("SELECT * FROM {0} WHERE doctor_id = '{1}'", TABLE_NAME, this.doctorId);
        }

        public string GetUpdateStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ").Append(TABLE_NAME).Append(" SET ")
            .Append("name = '").Append(Name).Append("',")
            .Append("address = '").Append(Address).Append("',")
            .Append("qualification = '").Append(Qualification).Append("',")
            .Append("specialization = '").Append(Specialization).Append("',")
            .Append("phone = '").Append(Phone).Append("',")
            .Append("gender = '").Append(Gender).Append("',")
            .Append("department_id = '").Append(DepartmentId).Append("',")
            .Append("schedule = '").Append(Schedule).Append("',")
            .Append("email = '").Append(Email).Append("'")
            .Append(" WHERE doctor_id = '").Append(DoctorId).Append("'");
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
