namespace PhonebookApp.UI
{
    partial class frmPersonUpdate
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
            this.cmbCategoryName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMobileValidation = new System.Windows.Forms.Label();
            this.lblEmailValidation = new System.Windows.Forms.Label();
            this.cmbProfession = new System.Windows.Forms.ComboBox();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.cmbAgeGroup = new System.Windows.Forms.ComboBox();
            this.cmbHighestDegree = new System.Windows.Forms.ComboBox();
            this.cmbEducationalLevel = new System.Windows.Forms.ComboBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPersonId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.h = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCategoryName
            // 
            this.cmbCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoryName.FormattingEnabled = true;
            this.cmbCategoryName.Location = new System.Drawing.Point(317, 217);
            this.cmbCategoryName.Name = "cmbCategoryName";
            this.cmbCategoryName.Size = new System.Drawing.Size(292, 30);
            this.cmbCategoryName.TabIndex = 18;
            this.cmbCategoryName.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryName_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(143, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 22);
            this.label10.TabIndex = 7;
            this.label10.Text = "Category Name:";
            // 
            // lblMobileValidation
            // 
            this.lblMobileValidation.AutoSize = true;
            this.lblMobileValidation.ForeColor = System.Drawing.Color.Red;
            this.lblMobileValidation.Location = new System.Drawing.Point(250, 159);
            this.lblMobileValidation.Name = "lblMobileValidation";
            this.lblMobileValidation.Size = new System.Drawing.Size(11, 13);
            this.lblMobileValidation.TabIndex = 5;
            this.lblMobileValidation.Text = "*";
            // 
            // lblEmailValidation
            // 
            this.lblEmailValidation.AutoSize = true;
            this.lblEmailValidation.ForeColor = System.Drawing.Color.Red;
            this.lblEmailValidation.Location = new System.Drawing.Point(247, 113);
            this.lblEmailValidation.Name = "lblEmailValidation";
            this.lblEmailValidation.Size = new System.Drawing.Size(11, 13);
            this.lblEmailValidation.TabIndex = 3;
            this.lblEmailValidation.Text = "*";
            // 
            // cmbProfession
            // 
            this.cmbProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfession.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProfession.FormattingEnabled = true;
            this.cmbProfession.Items.AddRange(new object[] {
            "Accountants",
            "Architects",
            "Engineers",
            "Linguistics",
            "Surveyors",
            "Urban Planners"});
            this.cmbProfession.Location = new System.Drawing.Point(317, 309);
            this.cmbProfession.Name = "cmbProfession";
            this.cmbProfession.Size = new System.Drawing.Size(292, 30);
            this.cmbProfession.TabIndex = 20;
            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.Items.AddRange(new object[] {
            "Software Engineer",
            "Hardware Ebgineer",
            "Sub Assistant Engineer",
            "Mechanical Engineer",
            "Eleltrical Engineer"});
            this.cmbSpecialization.Location = new System.Drawing.Point(317, 266);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(292, 27);
            this.cmbSpecialization.TabIndex = 19;
            // 
            // cmbAgeGroup
            // 
            this.cmbAgeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgeGroup.FormattingEnabled = true;
            this.cmbAgeGroup.Items.AddRange(new object[] {
            "15-20",
            "21-25",
            "26-30",
            "31-35",
            "36-40",
            "41-45",
            "46-50",
            "51-55",
            "56-60"});
            this.cmbAgeGroup.Location = new System.Drawing.Point(317, 432);
            this.cmbAgeGroup.Name = "cmbAgeGroup";
            this.cmbAgeGroup.Size = new System.Drawing.Size(292, 27);
            this.cmbAgeGroup.TabIndex = 23;
            // 
            // cmbHighestDegree
            // 
            this.cmbHighestDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHighestDegree.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHighestDegree.FormattingEnabled = true;
            this.cmbHighestDegree.Items.AddRange(new object[] {
            "No degree",
            "BSc in CSE",
            "BSc in EEE",
            "BSc In Mechanical Engineering",
            "Bachelor of Business Administration (BBA)",
            "B. Sc in Engineering (EECE)",
            "B.Sc.in Industrial & Production Engineering",
            "M.B.A",
            "Diploma in CSE",
            "Diploma in Electrical Engineering",
            "Diploma In Engineering",
            "Diploma in Civil Engineering",
            "DIPLOMA IN ENGENIARING (EEE)"});
            this.cmbHighestDegree.Location = new System.Drawing.Point(317, 387);
            this.cmbHighestDegree.Name = "cmbHighestDegree";
            this.cmbHighestDegree.Size = new System.Drawing.Size(292, 30);
            this.cmbHighestDegree.TabIndex = 22;
            // 
            // cmbEducationalLevel
            // 
            this.cmbEducationalLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducationalLevel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEducationalLevel.FormattingEnabled = true;
            this.cmbEducationalLevel.Items.AddRange(new object[] {
            "Less than high school",
            "High school diploma or equivalent",
            "Some college, no degree",
            "Postsecondary non-degree award",
            "Associate\'s degree",
            "Bachelor\'s degree",
            "Master\'s degree",
            "Doctoral or professional degree"});
            this.cmbEducationalLevel.Location = new System.Drawing.Point(317, 348);
            this.cmbEducationalLevel.Name = "cmbEducationalLevel";
            this.cmbEducationalLevel.Size = new System.Drawing.Size(292, 27);
            this.cmbEducationalLevel.TabIndex = 21;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(317, 171);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(292, 29);
            this.txtCompany.TabIndex = 17;
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(317, 128);
            this.txtMobile.MaxLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(292, 29);
            this.txtMobile.TabIndex = 16;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(317, 88);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(292, 29);
            this.txtEmail.TabIndex = 15;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonName.Location = new System.Drawing.Point(317, 49);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(292, 29);
            this.txtPersonName.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(193, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 6;
            this.label9.Text = "Company:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(171, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Age Group:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(136, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Highest Degree:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(114, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Educational Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(175, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Profession:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Specialization:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(214, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mobile:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-mail:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Name:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(745, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 58);
            this.button1.TabIndex = 24;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(745, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 60);
            this.button2.TabIndex = 25;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPersonId
            // 
            this.txtPersonId.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonId.Location = new System.Drawing.Point(317, 13);
            this.txtPersonId.Name = "txtPersonId";
            this.txtPersonId.ReadOnly = true;
            this.txtPersonId.Size = new System.Drawing.Size(292, 29);
            this.txtPersonId.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(198, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Person Id";
            // 
            // h
            // 
            this.h.AutoSize = true;
            this.h.Location = new System.Drawing.Point(2, 485);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(31, 13);
            this.h.TabIndex = 26;
            this.h.Text = "hk11";
            this.h.Visible = false;
            // 
            // frmPersonUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(955, 507);
            this.Controls.Add(this.h);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPersonId);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCategoryName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblMobileValidation);
            this.Controls.Add(this.lblEmailValidation);
            this.Controls.Add(this.cmbProfession);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.cmbAgeGroup);
            this.Controls.Add(this.cmbHighestDegree);
            this.Controls.Add(this.cmbEducationalLevel);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmPersonUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPersonUpdate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPersonUpdate_FormClosed);
            this.Load += new System.EventHandler(this.frmPersonUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.ComboBox cmbCategoryName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMobileValidation;
        private System.Windows.Forms.Label lblEmailValidation;
        public  System.Windows.Forms.ComboBox cmbProfession;
        public  System.Windows.Forms.ComboBox cmbSpecialization;
        public  System.Windows.Forms.ComboBox cmbAgeGroup;
        public  System.Windows.Forms.ComboBox cmbHighestDegree;
        public  System.Windows.Forms.ComboBox cmbEducationalLevel;
        public  System.Windows.Forms.TextBox txtCompany;
        public  System.Windows.Forms.TextBox txtMobile;
        public  System.Windows.Forms.TextBox txtEmail;
        public  System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public  System.Windows.Forms.TextBox txtPersonId;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label h;
    }
}