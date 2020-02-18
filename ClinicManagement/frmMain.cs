using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Doctors;
using ClinicManagement.Patients;
using ClinicManagement.Embulance;
using ClinicManagement.Departments;

namespace ClinicManagement
{
	public partial class frmClinicMgmtMain : Form
	{
		public frmClinicMgmtMain()
		{
			InitializeComponent();
		}

        private void frmClinicMgmtMain_Load(object sender, EventArgs e)
        {
           
        }

        private void registerDocsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegisterDocs frmReg = new frmRegisterDocs();
            frmReg.ShowDialog();

        }

        private void searchDocsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchDocs frmSearch = new frmSearchDocs();
            frmSearch.ShowDialog();
        }

        private void registerPatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegisterPat frmReg = new frmRegisterPat();
            frmReg.ShowDialog();
        }

        private void searchPatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchPat frmSrch = new frmSearchPat();
            frmSrch.ShowDialog();
        }

        private void registerEmbuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegisterAmbu frmReg = new frmRegisterAmbu();
            frmReg.ShowDialog();
        }

        private void searchEmbuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchAmbu frmSrch = new frmSearchAmbu();
            frmSrch.ShowDialog();
        }

        private void registerDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegisterDept frmDept = new frmRegisterDept();
            frmDept.ShowDialog();
        }

        private void patientVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatVisits patVisit = new frmPatVisits();
            patVisit.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void patientVisitSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchPatVisit patVisit = new frmSearchPatVisit();
            patVisit.ShowDialog();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegisterPat frmReg = new frmRegisterPat();
            frmReg.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchPat frmSrch = new frmSearchPat();
            frmSrch.ShowDialog();
        }

        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRegisterDocs frmReg = new frmRegisterDocs();
            frmReg.ShowDialog();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSearchDocs frmSearch = new frmSearchDocs();
            frmSearch.ShowDialog();
        }

        private void newVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatVisits patVisit = new frmPatVisits();
            patVisit.ShowDialog();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchPatVisit patVisit = new frmSearchPatVisit();
            patVisit.ShowDialog();
        }

        private void registerToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmRegisterDept frmDept = new frmRegisterDept();
            frmDept.ShowDialog();
        }

        private void ambulanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmRegisterAmbu frmReg = new frmRegisterAmbu();
            frmReg.ShowDialog();
        }

        private void searchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSearchAmbu frmReg = new frmSearchAmbu();
            frmReg.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDoctorReport report = new frmDoctorReport();
            report.ShowDialog();
        }
    }
}
