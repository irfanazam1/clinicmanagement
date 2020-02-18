namespace ClinicManagement.Patients
{
    partial class frmPatVisits
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.visitCost = new System.Windows.Forms.NumericUpDown();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dateVisit = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.chkFollowup = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVisitNotes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateFollowup = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVisitRefNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visitCost)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(176, 321);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(70, 28);
            this.cmdDelete.TabIndex = 12;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(102, 321);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(70, 28);
            this.cmdNew.TabIndex = 10;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(28, 321);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(70, 28);
            this.cmdSave.TabIndex = 9;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdPrint);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.visitCost);
            this.panel1.Controls.Add(this.txtReason);
            this.panel1.Controls.Add(this.dateVisit);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.chkFollowup);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtVisitNotes);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateFollowup);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtVisitRefNumber);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbDoctor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbPatient);
            this.panel1.Controls.Add(this.cmdDelete);
            this.panel1.Controls.Add(this.cmdNew);
            this.panel1.Controls.Add(this.cmdSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 364);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Enabled = false;
            this.cmdPrint.Location = new System.Drawing.Point(250, 321);
            this.cmdPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(70, 28);
            this.cmdPrint.TabIndex = 13;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 293);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Visit Cost";
            // 
            // visitCost
            // 
            this.visitCost.Location = new System.Drawing.Point(107, 292);
            this.visitCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.visitCost.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.visitCost.Name = "visitCost";
            this.visitCost.Size = new System.Drawing.Size(90, 20);
            this.visitCost.TabIndex = 8;
            this.visitCost.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(107, 223);
            this.txtReason.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(214, 65);
            this.txtReason.TabIndex = 7;
            // 
            // dateVisit
            // 
            this.dateVisit.Location = new System.Drawing.Point(107, 84);
            this.dateVisit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateVisit.Name = "dateVisit";
            this.dateVisit.Size = new System.Drawing.Size(214, 20);
            this.dateVisit.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 225);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Followup Reason";
            // 
            // chkFollowup
            // 
            this.chkFollowup.AutoSize = true;
            this.chkFollowup.Location = new System.Drawing.Point(107, 204);
            this.chkFollowup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFollowup.Name = "chkFollowup";
            this.chkFollowup.Size = new System.Drawing.Size(15, 14);
            this.chkFollowup.TabIndex = 5;
            this.chkFollowup.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 203);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Follow Up?";
            // 
            // txtVisitNotes
            // 
            this.txtVisitNotes.Location = new System.Drawing.Point(107, 107);
            this.txtVisitNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVisitNotes.Multiline = true;
            this.txtVisitNotes.Name = "txtVisitNotes";
            this.txtVisitNotes.Size = new System.Drawing.Size(214, 88);
            this.txtVisitNotes.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Notes";
            // 
            // dateFollowup
            // 
            this.dateFollowup.Location = new System.Drawing.Point(136, 200);
            this.dateFollowup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateFollowup.Name = "dateFollowup";
            this.dateFollowup.Size = new System.Drawing.Size(185, 20);
            this.dateFollowup.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Visit Date:";
            // 
            // txtVisitRefNumber
            // 
            this.txtVisitRefNumber.Location = new System.Drawing.Point(107, 13);
            this.txtVisitRefNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVisitRefNumber.Name = "txtVisitRefNumber";
            this.txtVisitRefNumber.Size = new System.Drawing.Size(214, 20);
            this.txtVisitRefNumber.TabIndex = 26;
            this.txtVisitRefNumber.TextChanged += new System.EventHandler(this.txtVisitRefNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Visit Ref#";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(107, 60);
            this.cmbDoctor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(214, 21);
            this.cmbDoctor.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Doctor:";
            // 
            // cmbPatient
            // 
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(107, 36);
            this.cmbPatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(214, 21);
            this.cmbPatient.TabIndex = 1;
            this.cmbPatient.SelectedIndexChanged += new System.EventHandler(this.cmbPatient_SelectedIndexChanged);
            // 
            // frmPatVisits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(376, 390);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatVisits";
            this.Text = "Patient Visit";
            this.Load += new System.EventHandler(this.frmPatVisits_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visitCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.TextBox txtVisitRefNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateVisit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkFollowup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVisitNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateFollowup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown visitCost;
        private System.Windows.Forms.Button cmdPrint;
    }
}