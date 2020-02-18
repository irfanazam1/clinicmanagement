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
    public partial class frmRegisterPat : Form
    {
        private string _id;

        public frmRegisterPat()
        {
            InitializeComponent();
        }
        public frmRegisterPat(string id) : this()
        {
            _id = id;
        }

        private bool ValidateData()
        {
            if (this.controlPanel.HasChildren)
            {
                Control.ControlCollection collection = controlPanel.Controls;
                foreach (Control control in collection)
                {
                    if (control.Name.Equals("txtId"))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                MessageBox.Show("Fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!validateEmail())
            {
                MessageBox.Show("Email address is invalid.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Utils.isValidNIC(txtNIC.Text))
            {
                MessageBox.Show("NIC is invalid.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Utils.isValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Phone number is invalid.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Patient patient = new Patient();
            patient.Name = txtName.Text;
            patient.Nic = txtNIC.Text;
            patient.Phone = txtPhone.Text;
            patient.Email = txtEmail.Text;
            patient.DateOfBirth = dateDOB.Value;
            if (this.txtId.Text == null 
                || this.txtId.Text.Length < 10)
            {
                patient.PatientId = Utils.RandomString(10);
            }
            else
            {
                patient.PatientId = txtId.Text;
            }

            if (optFemale.Checked)
            {
                patient.Gender = "Female";
            }
            else
            {
                patient.Gender = "Male";
            }
            patient.Address = txtAddress.Text;
            try
            {
                if (NpgsqlDatabaseImpl.GetInstance().AddObject(patient))
                {
                    this.txtId.Text = patient.PatientId;
                    this.txtId.Enabled = false;
                    MessageBox.Show("Patient Saved ...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdPrint.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Failed to save patient", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to save patient", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool validateEmail()
        {
            if (txtEmail.Text != null && !Utils.IsValidEmail(txtEmail.Text))
            {
                return false;
            }
            return true;
        }

        private void frmRegisterPat_Load(object sender, EventArgs e)
        {
            if (_id != null)
            {
                string query = "SELECT id, pat_id, name, address, nic, " +
                    " phone, email, gender, dob " +
                    " FROM  patient WHERE pat_id = '" + _id + "'";
                DbRecord rec = NpgsqlDatabaseImpl.GetInstance().GetData(query);
                if (rec != null && rec.RowCount == 1)
                {
                    txtId.Text = rec.Records[0][1].ToString();
                    txtId.Enabled = false;
                    txtName.Text = rec.Records[0][2].ToString();
                    txtAddress.Text = rec.Records[0][3].ToString();
                    txtNIC.Text = rec.Records[0][4].ToString();
                    txtPhone.Text = rec.Records[0][5].ToString();
                    txtEmail.Text = rec.Records[0][6].ToString();
                    if(rec.Records[0][7].ToString().Equals("Male"))
                    {
                        optMale.Checked = true;
                    }
                    else
                    {
                        optFemale.Checked = true;
                    }
                    dateDOB.Text = rec.Records[0][8].ToString();
                }
            }
        }

        private void ClearAll()
        {
            txtAddress.Text = null;
            txtEmail.Text = null;
            txtId.Text = "";
            txtName.Text = null;
            txtPhone.Text = null;
            txtNIC.Text = null;
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            cmdPrint.Enabled = false;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            frmPatient patient = new frmPatient(txtId.Text, txtName.Text, txtAddress.Text, txtNIC.Text, txtEmail.Text, txtPhone.Text);
            patient.ShowDialog();
        }
    }
}
