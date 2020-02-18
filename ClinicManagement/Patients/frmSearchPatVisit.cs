using ClinicManagement.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Patients
{
    public partial class frmSearchPatVisit : Form
    {
        public frmSearchPatVisit()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT pt.name, dc.name, pv.visit_ref_number, to_char(pv.visit_date,'DD/MM/YYYY HH24:MI'), pv.visit_notes, to_char(pv.followup_date, 'DD/MM/YYYY HH24:MI'), pt.pat_id FROM patient_visit pv, patient pt, doctor dc " +
                " WHERE pt.id = pv.patient_id" +
                " AND dc.id = pv.doctor_id AND (");
            query.Append(string.Format(" pt.name ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR pt.phone ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR pt.email ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR pt.nic ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR pv.visit_ref_number ilike '%{0}%' ", txtSearch.Text));
            query.Append(string.Format(" OR pt.pat_id ilike '%{0}%' ", txtSearch.Text));
            query.Append(string.Format(" OR dc.name ilike '%{0}%' ", txtSearch.Text));
            query.Append(string.Format(" OR pv.visit_notes ilike '%{0}%' ", txtSearch.Text));
            query.Append(string.Format(" OR to_char(pv.visit_date, 'DD/MM/YYYY') ilike '%{0}%' ", txtSearch.Text));
            query.Append(string.Format(" OR to_char(pv.followup_date,'DD/MM/YYYY') ilike '%{0}%' )", txtSearch.Text));
            query.Append(" ORDER BY pv.visit_date");
            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData(query.ToString());
            DataTable table = new DataTable();
            table.Columns.Add("VisitReferenceNumber");
            table.Columns.Add("PatientNumber");
            table.Columns.Add("PatientName");
            table.Columns.Add("DoctorName");
            table.Columns.Add("VisitDate");
            table.Columns.Add("Notes");
            table.Columns.Add("FollowUpDate");
            
            foreach (List<object> row in record.Records)
            {
                DataRow dr = table.NewRow();
                dr["VisitReferenceNumber"] = row[2].ToString();
                dr["PatientNumber"] = row[6].ToString();
                dr["PatientName"] = row[0].ToString();
                dr["DoctorName"] = row[1].ToString();
                dr["VisitDate"] = row[3].ToString();
                dr["Notes"] = row[4].ToString();
                dr["FollowUpDate"] = row[5].ToString();
                table.Rows.Add(dr);
            }
            dgSearch.DataSource = table;
        }

        private void dgSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSearch.Rows[e.RowIndex] != null)
            {
                object id = dgSearch.Rows[e.RowIndex].Cells[0].Value;
                frmPatVisits pat = new frmPatVisits(id.ToString());
                pat.ShowDialog();
            }
        }

        private void frmSearchPatVisit_Load(object sender, EventArgs e)
        {

        }
    }
}
