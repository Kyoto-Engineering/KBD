namespace PhonebookApp.UI
{
    partial class frmViewAndReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewAndReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PersonUnderACompanyButton = new System.Windows.Forms.Button();
            this.ViewCompanybutton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.personDetailsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PersonUnderACompanyButton);
            this.groupBox1.Controls.Add(this.ViewCompanybutton);
            this.groupBox1.Controls.Add(this.reportButton);
            this.groupBox1.Controls.Add(this.personDetailsButton);
            this.groupBox1.Location = new System.Drawing.Point(142, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // PersonUnderACompanyButton
            // 
            this.PersonUnderACompanyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PersonUnderACompanyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonUnderACompanyButton.ForeColor = System.Drawing.Color.Black;
            this.PersonUnderACompanyButton.Location = new System.Drawing.Point(289, 35);
            this.PersonUnderACompanyButton.Name = "PersonUnderACompanyButton";
            this.PersonUnderACompanyButton.Size = new System.Drawing.Size(134, 70);
            this.PersonUnderACompanyButton.TabIndex = 51;
            this.PersonUnderACompanyButton.Text = "Person Under A Company";
            this.PersonUnderACompanyButton.UseVisualStyleBackColor = false;
            this.PersonUnderACompanyButton.Click += new System.EventHandler(this.PersonUnderACompanyButton_Click);
            // 
            // ViewCompanybutton
            // 
            this.ViewCompanybutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ViewCompanybutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewCompanybutton.ForeColor = System.Drawing.Color.Black;
            this.ViewCompanybutton.Location = new System.Drawing.Point(53, 144);
            this.ViewCompanybutton.Name = "ViewCompanybutton";
            this.ViewCompanybutton.Size = new System.Drawing.Size(134, 70);
            this.ViewCompanybutton.TabIndex = 50;
            this.ViewCompanybutton.Text = "View And Edit Company";
            this.ViewCompanybutton.UseVisualStyleBackColor = false;
            this.ViewCompanybutton.Click += new System.EventHandler(this.ViewCompanybutton_Click);
            // 
            // reportButton
            // 
            this.reportButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportButton.ForeColor = System.Drawing.Color.Black;
            this.reportButton.Location = new System.Drawing.Point(289, 144);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(134, 70);
            this.reportButton.TabIndex = 49;
            this.reportButton.Text = "Print";
            this.reportButton.UseVisualStyleBackColor = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // personDetailsButton
            // 
            this.personDetailsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.personDetailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personDetailsButton.ForeColor = System.Drawing.Color.Black;
            this.personDetailsButton.Location = new System.Drawing.Point(53, 35);
            this.personDetailsButton.Name = "personDetailsButton";
            this.personDetailsButton.Size = new System.Drawing.Size(134, 70);
            this.personDetailsButton.TabIndex = 48;
            this.personDetailsButton.Text = "View And Edit Contact";
            this.personDetailsButton.UseVisualStyleBackColor = false;
            this.personDetailsButton.Click += new System.EventHandler(this.personDetailsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(306, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "View And Print";
            // 
            // frmViewAndReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(793, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewAndReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewAndReport";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button personDetailsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewCompanybutton;
        private System.Windows.Forms.Button PersonUnderACompanyButton;
    }
}