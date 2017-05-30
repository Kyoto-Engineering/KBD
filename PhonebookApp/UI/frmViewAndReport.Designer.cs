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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ViewCompanybutton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.personDetailsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ViewCompanybutton);
            this.groupBox1.Controls.Add(this.reportButton);
            this.groupBox1.Controls.Add(this.personDetailsButton);
            this.groupBox1.Location = new System.Drawing.Point(142, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 269);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ViewCompanybutton
            // 
            this.ViewCompanybutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ViewCompanybutton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewCompanybutton.ForeColor = System.Drawing.Color.Blue;
            this.ViewCompanybutton.Location = new System.Drawing.Point(33, 144);
            this.ViewCompanybutton.Name = "ViewCompanybutton";
            this.ViewCompanybutton.Size = new System.Drawing.Size(134, 70);
            this.ViewCompanybutton.TabIndex = 50;
            this.ViewCompanybutton.Text = "View And Edit Company";
            this.ViewCompanybutton.UseVisualStyleBackColor = false;
            this.ViewCompanybutton.Click += new System.EventHandler(this.ViewCompanybutton_Click);
            // 
            // reportButton
            // 
            this.reportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.reportButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportButton.ForeColor = System.Drawing.Color.Blue;
            this.reportButton.Location = new System.Drawing.Point(214, 35);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(134, 70);
            this.reportButton.TabIndex = 49;
            this.reportButton.Text = "Report";
            this.reportButton.UseVisualStyleBackColor = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // personDetailsButton
            // 
            this.personDetailsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.personDetailsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personDetailsButton.ForeColor = System.Drawing.Color.Blue;
            this.personDetailsButton.Location = new System.Drawing.Point(33, 35);
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
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(232, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "View And Report";
            // 
            // frmViewAndReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(687, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmViewAndReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewAndReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViewAndReport_FormClosed);
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
    }
}