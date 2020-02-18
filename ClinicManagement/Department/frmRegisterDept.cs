using ClinicManagement.Domain;
using ClinicManagement.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Departments
{
    public partial class frmRegisterDept : Form
    {
        //private KeyValuePair<>
        public frmRegisterDept()
        {
            InitializeComponent();
        }

        private void frmRegisterDept_Load(object sender, EventArgs e)
        {
            DbRecord record = NpgsqlDatabaseImpl.GetInstance().GetData("SELECT id, name, description FROM  department ORDER BY name");
            foreach(List<object> row in record.Records)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = row[1].ToString();
                DepartmentValue value = new DepartmentValue();
                value.Id = row[0].ToString();
                value.Description = row[2].ToString();
                item.Value = value;
                cmbName.Items.Add(item);
            }
            if(cmbName.Items != null && cmbName.Items.Count > 0)
            {
                cmbName.SelectedIndex = 0;

            }
        }

        private bool ValidateData()
        {
            if (this.controlPanel.HasChildren)
            {
                Control.ControlCollection collection = controlPanel.Controls;
                foreach (Control control in collection)
                {
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
            if (!this.ValidateData())
            {
                MessageBox.Show("Fill all the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Department department = new Department();
            try
            {
                if(cmbName.SelectedItem == null)
                {
                    department.Name = cmbName.Text;
                    department.Id = 0;
                       
                }
                else
                {
                    ComboBoxItem item = (ComboBoxItem)cmbName.SelectedItem;
                    department.Name = item.Text;
                    DepartmentValue value = (DepartmentValue)item.Value;
                    department.Id = int.Parse(value.Id);
                }

                department.Description = txtDescription.Text;

                if (NpgsqlDatabaseImpl.GetInstance().AddObject(department))
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = department.Name;
                    DepartmentValue value = new DepartmentValue();
                    value.Id = department.Id.ToString();
                    value.Description = department.Description;
                    item.Value = value;
                    if (!this.FindDepartment(item))
                    {
                        cmbName.Items.Insert(0, item);
                        cmbName.SelectedIndex = 0;
                    }
                    
                    MessageBox.Show("Department Saved ...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to save Department", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save Department: "+ ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbName.SelectedItem != null)
            {
                ComboBoxItem item = (ComboBoxItem)cmbName.SelectedItem;
                DepartmentValue value = (DepartmentValue)item.Value;
                txtDescription.Text = value.Description;
            }
        }

        private bool FindDepartment(ComboBoxItem item)
        {
            bool result = false;
            if(item != null)
            {
                DepartmentValue value = (DepartmentValue)item.Value;
                foreach(object it in cmbName.Items)
                {
                    ComboBoxItem dept = (ComboBoxItem)it;
                    DepartmentValue val = (DepartmentValue)dept.Value;
                    if (val.Id.Equals(value.Id))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbName.SelectedItem = null;
            txtDescription.Text = null;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (cmbName.SelectedItem != null) {
                ComboBoxItem item = (ComboBoxItem)cmbName.SelectedItem;
                DepartmentValue value = (DepartmentValue)item.Value;
                Department dept = new Department();
                dept.Id = Int32.Parse(value.Id);
                dept.Description = value.Description;
                try
                {
                    if (MessageBox.Show("Do you really want to delete?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (NpgsqlDatabaseImpl.GetInstance().DeleteObject(dept))
                        {
                            MessageBox.Show("Department deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbName.SelectedItem = null;
                            txtDescription.Text = null;
                        }
                    }
                }
                catch(Exception ex)
                {
                    if (ex.Message.Contains("constraint"))
                    {
                        MessageBox.Show("Can't delete this department. It has doctor/patient records attached ","Deletion not allowed!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete Department: " + ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
