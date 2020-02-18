using ClinicManagement.Domain;
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
    public partial class frmDoctorReport : Form
    {
        private DataTable _records;
        public frmDoctorReport()
        {
            InitializeComponent();
        }

        private void frmPatReport_Load(object sender, EventArgs e)
        {
            string query = "SELECT id, name" +
                    " FROM  doctor";
            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData(query);

            if (record != null)
            {
                foreach (List<object> row in record.Records)
                {
                  
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = row[1].ToString();
                    item.Value = row[0];
                    lstDoctors.Items.Add(item);

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String docId = "";
            if (lstDoctors.SelectedItem != null)
            {
                docId = ((ComboBoxItem)lstDoctors.SelectedItem).Value.ToString();

                StringBuilder query = new StringBuilder();
                query.Append("SELECT pt.name, dc.name, pv.visit_ref_number, to_char(pv.visit_date,'DD/MM/YYYY'), pv.visit_notes, to_char(pv.followup_date, 'DD/MM/YYYY'), pt.pat_id, pv.visit_cost FROM patient_visit pv, patient pt, doctor dc " +
                    " WHERE pt.id = pv.patient_id" +
                    " AND dc.id = pv.doctor_id AND" +
                    " dc.id = " + docId +
                    " AND to_date(to_char(pv.visit_date,'DD/MM/YYYY'),'DD/MM/YYYY') between to_date('" + dateFrom.Text + "', 'DD/MM/YYYY')" +
                    " AND to_date('" + dateTo.Text + "', 'DD/MM/YYYY')");
                query.Append(" ORDER BY pv.visit_date");
                DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData(query.ToString());
                if (_records != null)
                {
                    _records.Clear();
                }
                else
                {
                    _records = new DataTable();
                    _records.Columns.Add("VisitReferenceNumber");
                    _records.Columns.Add("PatientNumber");
                    _records.Columns.Add("PatientName");
                    _records.Columns.Add("DoctorName");
                    _records.Columns.Add("VisitDate");
                    _records.Columns.Add("Notes");
                    _records.Columns.Add("FollowUpDate");
                    _records.Columns.Add("VisitCost");
                }
                foreach (List<object> row in record.Records)
                {
                    DataRow dr = _records.NewRow();
                    dr["VisitReferenceNumber"] = row[2].ToString();
                    dr["PatientNumber"] = row[6].ToString();
                    dr["PatientName"] = row[0].ToString();
                    dr["DoctorName"] = row[1].ToString();
                    dr["VisitDate"] = row[3].ToString();
                    dr["Notes"] = row[4].ToString();
                    dr["FollowUpDate"] = row[5].ToString();
                    dr["VisitCost"] = row[7].ToString();
                    _records.Rows.Add(dr);
                }
                dgSearch.DataSource = _records;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_records != null && _records.Rows.Count > 0)
            {
                StringBuilder report = new StringBuilder();
                report.Append("Visit Reference#,");
                report.Append("Patient#,");
                report.Append("Patient's Name,");
                report.Append("Doctor's Name,");
                report.Append("Visit Date,");
                report.Append("Followup Date,");
                report.Append("Visit Cost");
                report.Append("\r\n");
                foreach (DataRow dr in _records.Rows)
                {
                    report.Append(getRowValue(dr[0])).Append(",")
                        .Append(getRowValue(dr[1])).Append(",")
                        .Append(getRowValue(dr[2])).Append(",")
                        .Append(getRowValue(dr[3])).Append(",")
                        .Append(getRowValue(dr[4])).Append(",")
                        .Append(getRowValue(dr[6])).Append(",")
                        .Append(getRowValue(dr[7])).Append("")
                        .Append("\r\n");

                }
                if (report.ToString() != null &&
                    report.ToString() != "")
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Comma Separated Files(csv)| *.csv | All Files(*.*) | *.*";
                    DialogResult result = saveFile.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (saveFile.FileName != null && saveFile.FileName != "")
                        {
                            saveTextFile(report, saveFile.FileName);
                        }
                    }
                }
            }
        }

        private String getRowValue(Object value)
        {
            String strValue = (value == null || value.ToString() == "") ? "N/A" : value.ToString();
            return strValue;
            
        }

        private void saveTextFile(StringBuilder text, String fileName)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(@fileName);
                sw.WriteLine(text.ToString()); // "sb" is the StringBuilder
                
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to save the report\nPermission Denied", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
               
            
        }
        
    }
}
