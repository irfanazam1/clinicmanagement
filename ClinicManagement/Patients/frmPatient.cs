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
    public partial class frmPatient : Form
    {
        String _id;
        String _name;
        String _address;
        String _nic;
        String _email;
        String _phone;

        public frmPatient()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        public frmPatient(String id,  String name, String address, String Nic, String email, String phone):this()
        {
            _id = id;
            _name = name;
            _address = address;
            _nic = Nic;
            _email = email;
            _phone = phone;
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            lblAddress.Text = _address;
            lblPhone.Text = _phone;
            lblEmail.Text = _email;
            lblNic.Text = _nic;
            lblNumber.Text = _id;
            lblName.Text = _name;
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

        private void frmPatient_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }
    }
}
