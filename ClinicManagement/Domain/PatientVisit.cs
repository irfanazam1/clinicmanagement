using ClinicManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain
{
   public  class PatientVisit : IDBObject
    {
        private int id;
        private int patientId;
        private int doctorId;
        private DateTime visitDate;
        private string notes;
        private bool followup;
        private string followupReason;
        private DateTime followupDate;
        private string visitRefNumber;
        private int visitCost;
        
        public bool Followup { get => followup; set => followup = value; }
        public string Notes { get => notes; set => notes = value; }
        public int Id { get => id; set => id = value; }
        public int PatientId { get => patientId; set => patientId = value; }
        public int DoctorId { get => doctorId; set => doctorId = value; }
        public DateTime VisitDate { get => visitDate; set => visitDate = value; }
        public string VisitRefNumber { get => visitRefNumber; set => visitRefNumber = value; }
        public DateTime FollowupDate { get => followupDate; set => followupDate = value; }
        public string FollowupReason { get => followupReason; set => followupReason = value; }
        public int VisitCost { get => visitCost; set => visitCost = value; }

        public static string TABLE_NAME = "patient_visit";

        public string GetAddStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ").Append(TABLE_NAME);
            sb.Append(" (patient_id, doctor_id, visit_date, visit_notes, followup, followup_date, followup_reason, visit_ref_number, visit_cost ) VALUES ( ");
            sb.Append("'").Append(PatientId).Append("',");
            sb.Append("'").Append(DoctorId).Append("',");
            sb.Append("'").Append(VisitDate).Append("',");
            sb.Append("'").Append(Notes).Append("',");
            if (followup)
            {
                sb.Append("'").Append("1").Append("',");
            }
            else
            {
                sb.Append("'").Append("0").Append("',");
            }
            sb.Append("'").Append(FollowupDate).Append("',");
            sb.Append("'").Append(FollowupReason).Append("',");
            sb.Append("'").Append(VisitRefNumber).Append("',");
            sb.Append("'").Append(VisitCost).Append("')");
            
            return sb.ToString();
        }

        public string GetDeleteStatement()
        {
            return String.Format("DELETE FROM {0} WHERE  visit_ref_number = '{1}'", TABLE_NAME, this.VisitRefNumber);
        }

        public string GetObjectByIdQuery()
        {
            return String.Format("SELECT * FROM {0} WHERE visit_ref_number = '{1}'", TABLE_NAME, this.VisitRefNumber);
        }

        public string GetUniqueObjectQuery()
        {
            return GetObjectByIdQuery();
        }

        public string GetUpdateStatement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ").Append(TABLE_NAME).Append(" SET ");
            sb.Append("patient_id = '").Append(PatientId).Append("',");
            sb.Append("doctor_id = '").Append(DoctorId).Append("',");
            sb.Append("visit_date = '").Append(VisitDate).Append("',");
            sb.Append("visit_notes = '").Append(Notes).Append("',");
            sb.Append("visit_cost = '").Append(VisitCost).Append("',");
            if (Followup)
            {
                sb.Append("followup = '").Append("1").Append("',");
            }
            else
            {
                sb.Append("followup = '").Append("0").Append("',");
            }
            
            sb.Append("followup_date = '").Append(FollowupDate).Append("',")
            .Append("followup_reason = '").Append(FollowupReason).Append("'")
            .Append(" WHERE visit_ref_number = '").Append(VisitRefNumber).Append("'");
            return sb.ToString();
        }
              
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
