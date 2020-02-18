using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Patients
{
    public partial class frmSlip : Form
    {
        private string _patient;
        private string _doctor;
        private int _cost;
        private String _patiId;
        private PrintDocument printDocument1 = new PrintDocument();
        public frmSlip()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        public frmSlip(string patient, string doctor, int cost, String id):this()
        {
            _patient = patient;
            _doctor = doctor;
            _cost = cost;
            _patiId = id;
        }

        private void frmSlip_Load(object sender, EventArgs e)
        {
            lblPatient.Text = _patient;
            lblDoctor.Text = _doctor;
            lblCost.Text = _cost + " Rs.";
            lblDate.Text = DateTime.Now.ToString();
            lblPatientId.Text = _patiId.Replace("(","").Replace(")","");

        }

        private void frmSlip_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

    }
}
