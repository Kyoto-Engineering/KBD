namespace PhonebookApp.UI
{
    partial class MainUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAgeGroup = new System.Windows.Forms.Button();
            this.buttonEducationLevel = new System.Windows.Forms.Button();
            this.buttonProfession = new System.Windows.Forms.Button();
            this.buttonSpecialization = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.personDetailsButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.buttonJobTitle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(431, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Directory";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonJobTitle);
            this.groupBox1.Controls.Add(this.buttonAgeGroup);
            this.groupBox1.Controls.Add(this.buttonEducationLevel);
            this.groupBox1.Controls.Add(this.buttonProfession);
            this.groupBox1.Controls.Add(this.buttonSpecialization);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.personDetailsButton);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 636);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonAgeGroup
            // 
            this.buttonAgeGroup.Location = new System.Drawing.Point(9, 506);
            this.buttonAgeGroup.Name = "buttonAgeGroup";
            this.buttonAgeGroup.Size = new System.Drawing.Size(130, 58);
            this.buttonAgeGroup.TabIndex = 40;
            this.buttonAgeGroup.Text = "Age Group";
            this.buttonAgeGroup.UseVisualStyleBackColor = true;
            this.buttonAgeGroup.Click += new System.EventHandler(this.buttonAgeGroup_Click);
            // 
            // buttonEducationLevel
            // 
            this.buttonEducationLevel.Location = new System.Drawing.Point(9, 312);
            this.buttonEducationLevel.Name = "buttonEducationLevel";
            this.buttonEducationLevel.Size = new System.Drawing.Size(125, 55);
            this.buttonEducationLevel.TabIndex = 39;
            this.buttonEducationLevel.Text = "Education Level";
            this.buttonEducationLevel.UseVisualStyleBackColor = true;
            this.buttonEducationLevel.Click += new System.EventHandler(this.buttonEducationLevel_Click);
            // 
            // buttonProfession
            // 
            this.buttonProfession.Location = new System.Drawing.Point(9, 373);
            this.buttonProfession.Name = "buttonProfession";
            this.buttonProfession.Size = new System.Drawing.Size(125, 48);
            this.buttonProfession.TabIndex = 38;
            this.buttonProfession.Text = "Profession";
            this.buttonProfession.UseVisualStyleBackColor = true;
            this.buttonProfession.Click += new System.EventHandler(this.buttonProfession_Click);
            // 
            // buttonSpecialization
            // 
            this.buttonSpecialization.Location = new System.Drawing.Point(9, 254);
            this.buttonSpecialization.Name = "buttonSpecialization";
            this.buttonSpecialization.Size = new System.Drawing.Size(133, 52);
            this.buttonSpecialization.TabIndex = 37;
            this.buttonSpecialization.Text = "Specialization";
            this.buttonSpecialization.UseVisualStyleBackColor = true;
            this.buttonSpecialization.Click += new System.EventHandler(this.buttonSpecialization_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 57);
            this.button4.TabIndex = 36;
            this.button4.Text = "Company Creation";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // personDetailsButton
            // 
            this.personDetailsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.personDetailsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personDetailsButton.ForeColor = System.Drawing.Color.Blue;
            this.personDetailsButton.Location = new System.Drawing.Point(15, 195);
            this.personDetailsButton.Name = "personDetailsButton";
            this.personDetailsButton.Size = new System.Drawing.Size(116, 53);
            this.personDetailsButton.TabIndex = 35;
            this.personDetailsButton.Text = "Person Details";
            this.personDetailsButton.UseVisualStyleBackColor = false;
            this.personDetailsButton.Click += new System.EventHandler(this.personDetailsButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.ForeColor = System.Drawing.Color.Yellow;
            this.button3.Location = new System.Drawing.Point(6, 570);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 60);
            this.button3.TabIndex = 2;
            this.button3.Text = "User Management";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(15, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Category";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(15, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Person Details";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.logOutButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.Blue;
            this.logOutButton.Location = new System.Drawing.Point(944, 2);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(76, 48);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "LogOut";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // buttonJobTitle
            // 
            this.buttonJobTitle.Location = new System.Drawing.Point(6, 427);
            this.buttonJobTitle.Name = "buttonJobTitle";
            this.buttonJobTitle.Size = new System.Drawing.Size(130, 58);
            this.buttonJobTitle.TabIndex = 41;
            this.buttonJobTitle.Text = "JobTitle";
            this.buttonJobTitle.UseVisualStyleBackColor = true;
            this.buttonJobTitle.Click += new System.EventHandler(this.buttonJobTitle_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1023, 660);
            this.ControlBox = false;
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUI";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button personDetailsButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonAgeGroup;
        private System.Windows.Forms.Button buttonEducationLevel;
        private System.Windows.Forms.Button buttonProfession;
        private System.Windows.Forms.Button buttonSpecialization;
        private System.Windows.Forms.Button buttonJobTitle;
    }
}