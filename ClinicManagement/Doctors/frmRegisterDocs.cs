using ClinicManagement.Domain;
using ClinicManagement.Persistence;
using ClinicManagement.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClinicManagement.Doctors
{
    public partial class frmRegisterDocs : Form
    {
        private string _doctorid = null;

        public frmRegisterDocs()
        {
            InitializeComponent();
        }

        public frmRegisterDocs(string doc):this()
        {
            _doctorid = doc;
        }

        private void frmRegisterDocs_Load(object sender, EventArgs e)
        {
            string qualification = "";
            string specialization = "";
            string dept = "";

            if (_doctorid != null)
            {
                string query = "SELECT id, doctor_id, name, address, " +
                    " qualification, specialization, phone, " +
                    " email, schedule, gender, department_id " +
                    " FROM  doctor WHERE doctor_id = '" + _doctorid + "'";
                DbRecord rec = NpgsqlDatabaseImpl.GetInstance().GetData(query);
                if (rec != null && rec.RowCount == 1)
                {
                    txtId.Text = rec.Records[0][1].ToString();
                    txtId.Enabled = false;
                    txtName.Text = rec.Records[0][2].ToString();
                    txtAddress.Text = rec.Records[0][3].ToString();
                    qualification = rec.Records[0][4].ToString();
                    specialization = rec.Records[0][5].ToString();
                    txtPhone.Text = rec.Records[0][6].ToString();
                    txtEmail.Text = rec.Records[0][7].ToString();
                    txtSchedule.Text = rec.Records[0][8].ToString();
                    if (rec.Records[0][9].ToString().Equals("Male"))
                    {
                        optMale.Checked = true;
                    }
                    else
                    {
                        optFemale.Checked = true;
                    }
                    dept = rec.Records[0][9].ToString();
                }
            }

            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData("SELECT id, name, description FROM  department ORDER BY name");
            foreach (List<object> row in record.Records)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = row[1].ToString();
                DepartmentValue value = new DepartmentValue();
                value.Id = row[0].ToString();
                value.Description = row[2].ToString();
                item.Value = value;
                cmbDept.Items.Add(item);
                if (row[0].ToString().Equals(dept))
                {
                    cmbDept.SelectedItem = item;
                }
            }
            if (cmbDept.Items != null 
                && cmbDept.Items.Count > 0 
                && cmbDept.SelectedItem == null)
            {
                cmbDept.SelectedIndex = 0;

            }

            record = NpgsqlDatabaseImpl.GetInstance().GetData("SELECT DISTINCT specialization  FROM  doctor ORDER BY 1");
            foreach (List<object> row in record.Records)
            {
                cmbSpecialization.Items.Add(row[0].ToString());
                if (row[0].ToString().Equals(specialization))
                {
                    cmbSpecialization.SelectedItem = cmbSpecialization.Items[cmbSpecialization.Items.Count - 1];
                }

            }

            if (cmbSpecialization.Items != null 
                && cmbSpecialization.Items.Count > 0
                && cmbSpecialization.SelectedItem == null)
            {
                cmbSpecialization.SelectedIndex = 0;
            }

            record = NpgsqlDatabaseImpl.GetInstance().GetData("SELECT DISTINCT qualification  FROM  doctor ORDER BY 1");
            foreach (List<object> row in record.Records)
            {
                cmbQualification.Items.Add(row[0].ToString());
                if (row[0].ToString().Equals(qualification))
                {
                    cmbQualification.SelectedItem = cmbQualification.Items[cmbQualification.Items.Count - 1];
                }

            }
            if (cmbQualification.Items != null
                && cmbQualification.Items.Count > 0
                && cmbQualification.SelectedItem == null)
            {
                cmbQualification.SelectedIndex = 0;
            }

            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                MessageBox.Show("One or more fields are empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validateEmail())
            {
                MessageBox.Show("Email address is invalid.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Utils.isValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Phone number is invalid.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            {
                Doctor doctor = new Doctor();
                doctor.Name = txtName.Text;
                doctor.Address = txtAddress.Text;
                doctor.DepartmentId = Int32.Parse(((DepartmentValue)((ComboBoxItem)cmbDept.SelectedItem).Value).Id);
                doctor.Phone = txtPhone.Text;
                doctor.Email = txtEmail.Text;
                if (cmbQualification.SelectedValue != null)
                {
                    doctor.Qualification = cmbQualification.SelectedValue.ToString();
                }
                else
                {
                    doctor.Qualification = cmbQualification.Text;
                }

                if (cmbSpecialization.SelectedValue != null)
                {
                    doctor.Specialization = cmbSpecialization.SelectedValue.ToString();
                }
                else
                {
                    doctor.Specialization = cmbSpecialization.Text;
                }
                doctor.Schedule = txtSchedule.Text;
                doctor.Gender = "Male";
                if (optFemale.Checked)
                {
                    doctor.Gender = "Female";
                }
                if (this.txtId.Text == null
                    || this.txtId.Text.Length < 10)
                {
                    doctor.DoctorId = Utils.RandomString(10);
                }
                else
                {
                    doctor.DoctorId = txtId.Text;
                }

                try
                {
                    if (NpgsqlDatabaseImpl.GetInstance().AddObject(doctor))
                    {
                        this.txtId.Text = doctor.DoctorId;
                        this.txtId.Enabled = false;
                        MessageBox.Show("Doctor Saved ...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to save Doctor", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save Doctor: "+ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private bool ValidateData()
        {
            if (this.controlPanel.HasChildren)
            {
                Control.ControlCollection collection = controlPanel.Controls;
                foreach(Control control in collection)
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

        private bool validateEmail()
        {
            if (txtEmail.Text != null && !Utils.IsValidEmail(txtEmail.Text))
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            txtAddress.Text = null;
            txtEmail.Text = null;
            txtId.Text = null;
            txtName.Text = null;
            txtPhone.Text = null;
            txtSchedule.Text = null;
            cmbDept.SelectedItem = null;
            cmbQualification.SelectedItem = null;
            cmbSpecialization.SelectedItem = null;

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {

        }
    }
}
