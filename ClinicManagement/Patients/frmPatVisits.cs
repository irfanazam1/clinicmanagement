using ClinicManagement.Domain;
using ClinicManagement.Persistence;
using ClinicManagement.Util;
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
    public partial class frmPatVisits : Form
    {
        string _id;

        public frmPatVisits()
        {
            InitializeComponent();
        }

        public frmPatVisits(string id) : this()
        {
            _id = id;
        }

        private void frmPatVisits_Load(object sender, EventArgs e)
        {
            txtVisitRefNumber.Enabled = false;

            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData("SELECT id, name FROM  doctor ORDER BY 2");
            foreach (List<object> row in record.Records)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = row[1].ToString();
                item.Value = row[0];
                cmbDoctor.Items.Add(item);

            }
            if (cmbDoctor.Items != null && cmbDoctor.Items.Count > 0)
            {
                cmbDoctor.SelectedIndex = 0;
            }

            record = NpgsqlDatabaseImpl.GetInstance().GetData("SELECT id, name, pat_id FROM  patient ORDER BY 2");
            foreach (List<object> row in record.Records)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = string.Format("{0} - ( {1} )", row[1].ToString(), row[2].ToString());
                item.Value = row[0];
                cmbPatient.Items.Add(item);

            }
            if (cmbPatient.Items != null && cmbPatient.Items.Count > 0)
            {
                cmbPatient.SelectedIndex = 0;
            }

            if (_id != null)
            {
                string query = "SELECT pv.visit_ref_number, pat.name, doc.name, pv.visit_date, " +
                    "pv.visit_notes, pv.followup, pv.followup_date, pv.followup_reason, pv.visit_cost" +
                    " FROM public.patient_visit pv, patient pat, doctor doc " +
                    " WHERE pv.doctor_id =  doc.id" +
                    " AND pv.patient_id = pat.id" +
                    " AND pv.visit_ref_number = '" + _id + "'";

                DbRecord rec = NpgsqlDatabaseImpl.GetInstance().GetData(query);
                if (rec != null && rec.RowCount == 1)
                {
                    txtVisitRefNumber.Text = rec.Records[0][0].ToString();
                    int patIndex = cmbPatient.FindString(rec.Records[0][1].ToString());
                    if (patIndex >= 0)
                    {
                        cmbPatient.SelectedItem = cmbPatient.Items[patIndex];
                    }
                    int docIndex = cmbDoctor.FindString(rec.Records[0][2].ToString());
                    if (docIndex >= 0) {
                        cmbDoctor.SelectedItem = cmbDoctor.Items[docIndex];
                    }
                    dateVisit.Text = rec.Records[0][3].ToString();
                    txtVisitNotes.Text = rec.Records[0][4].ToString();
                    bool isFollowUp = false;
                    if (rec.Records[0][5] != null )
                    {
                        isFollowUp = bool.Parse(rec.Records[0][5].ToString());
                    }
                    if (isFollowUp)
                    {
                        chkFollowup.Checked = true;
                    }
                    else
                    {
                        chkFollowup.Checked = false;
                    }
                    dateFollowup.Text = rec.Records[0][6].ToString();
                    txtReason.Text = rec.Records[0][7].ToString();
                    visitCost.Value = Decimal.Parse(rec.Records[0][8].ToString());
                }
            }


        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            PatientVisit visit = new PatientVisit();
            visit.DoctorId = Int32.Parse(((ComboBoxItem)cmbDoctor.SelectedItem).Value.ToString());
            visit.PatientId = Int32.Parse(((ComboBoxItem)cmbPatient.SelectedItem).Value.ToString());
            visit.Followup = chkFollowup.Checked;
            visit.FollowupDate = dateFollowup.Value;
            visit.FollowupReason = txtReason.Text;
            visit.VisitDate = dateVisit.Value;
            visit.Notes = txtVisitNotes.Text;
            visit.VisitCost = Int32.Parse(visitCost.Value.ToString());
            if (this.txtVisitRefNumber.Text == null
                || this.txtVisitRefNumber.Text.Length < 10)
            {
                visit.VisitRefNumber = Utils.RandomString(10);
            }
            else
            {
                visit.VisitRefNumber = txtVisitRefNumber.Text;
            }
                       
            try
            {
                if (NpgsqlDatabaseImpl.GetInstance().AddObject(visit))
                {
                    this.txtVisitRefNumber.Text = visit.VisitRefNumber;
                    this.txtVisitRefNumber.Enabled = false;
                    MessageBox.Show("Patient Visit Saved ...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdPrint.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Failed to save Patient Visit", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save Patient Visit", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtVisitRefNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patient = "";
            string doctor = "";
            string patientNumber = "";
            if (cmbPatient.SelectedItem != null)
            {
                ComboBoxItem item = (ComboBoxItem)cmbPatient.SelectedItem;
                patient = item.Text.Split(new char[] { '-' })[0].Trim();
                patientNumber = item.Text.Split(new char[] { '-' })[1].Trim();
            }
            if (cmbDoctor.SelectedItem != null)
            {
                ComboBoxItem item = (ComboBoxItem)cmbDoctor.SelectedItem;
                doctor = item.Text;
            }
            frmSlip slip = new frmSlip(patient, doctor, Int32.Parse(visitCost.Value.ToString()), patientNumber);
            slip.ShowDialog();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            cmdPrint.Enabled = false;
            txtVisitRefNumber.Text = "";
            txtVisitNotes.Text = "";
            txtReason.Text = "";
            chkFollowup.Checked = false;
        }
    }
}
