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
    public partial class frmSearchPat : Form
    {
        public frmSearchPat()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT pat_id, name, address, phone, email, nic, gender FROM patient ");
            query.Append(string.Format(" WHERE name ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR phone ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR pat_id ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR email ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR nic ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR address ilike '%{0}%'", txtSearch.Text));
            query.Append(" ORDER BY name");
            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData(query.ToString());
            DataTable table = new DataTable();
            table.Columns.Add("PatientNumber");
            table.Columns.Add("Name");
            table.Columns.Add("Address");
            table.Columns.Add("Phone");
            table.Columns.Add("Email");
            table.Columns.Add("NIC");
            table.Columns.Add("Gender");
            foreach (List<object> row in record.Records)
            {
                DataRow dr = table.NewRow();
                dr["PatientNumber"] = row[0].ToString();
                dr["Name"] = row[1].ToString();
                dr["Address"] = row[2].ToString();
                dr["Phone"] = row[3].ToString();
                dr["Email"] = row[4].ToString();
                dr["NIC"] = row[5].ToString();
                dr["Gender"] = row[6].ToString();
                table.Rows.Add(dr);
            }
            dgSearch.DataSource = table;
        }

        private void dgSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSearch.Rows[e.RowIndex] != null)
            {
                object id = dgSearch.Rows[e.RowIndex].Cells[0].Value;
                frmRegisterPat pat = new frmRegisterPat(id.ToString());
                pat.ShowDialog();
            }
        }

        private void frmSearchPat_Load(object sender, EventArgs e)
        {

        }
    }
}
