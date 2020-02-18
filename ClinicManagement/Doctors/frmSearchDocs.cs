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

namespace ClinicManagement.Doctors
{
    public partial class frmSearchDocs : Form
    {
        public frmSearchDocs()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT doctor_id, name, phone, email, qualification, specialization FROM doctor ");
            query.Append(string.Format(" WHERE name ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR phone ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR email ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR qualification ilike '%{0}%'", txtSearch.Text));
            query.Append(string.Format(" OR specialization ilike '%{0}%'", txtSearch.Text));
            query.Append(" ORDER BY name");
            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData(query.ToString());
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Qualification");
            table.Columns.Add("Specialization");
            table.Columns.Add("Phone");
            table.Columns.Add("Email");
            foreach (List<object> row in record.Records)
            {
                DataRow dr = table.NewRow();
                dr["ID"] = row[0].ToString();
                dr["Name"] = row[1].ToString();
                dr["Phone"] = row[2].ToString();
                dr["Email"] = row[3].ToString();
                dr["Qualification"] = row[4].ToString();
                dr["Specialization"] = row[5].ToString();
                table.Rows.Add(dr);
            }
            dgSearch.DataSource = table;
        }

        private void dgSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgSearch.Rows[e.RowIndex] != null)
            {
                object id = dgSearch.Rows[e.RowIndex].Cells[0].Value;
                frmRegisterDocs docs = new frmRegisterDocs(id.ToString());
                docs.ShowDialog();
            } 
        }

        private void frmSearchDocs_Load(object sender, EventArgs e)
        {

        }
    }
}
