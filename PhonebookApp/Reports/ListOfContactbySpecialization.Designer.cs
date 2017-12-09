namespace PhonebookApp.Reports
{
    partial class ListOfContactbySpecialization
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
            this.workingRadioButton = new System.Windows.Forms.RadioButton();
            this.getButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.speccombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // workingRadioButton
            // 
            this.workingRadioButton.AutoSize = true;
            this.workingRadioButton.Location = new System.Drawing.Point(219, 117);
            this.workingRadioButton.Name = "workingRadioButton";
            this.workingRadioButton.Size = new System.Drawing.Size(106, 17);
            this.workingRadioButton.TabIndex = 9;
            this.workingRadioButton.TabStop = true;
            this.workingRadioButton.Text = "Working Address";
            this.workingRadioButton.UseVisualStyleBackColor = true;
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getButton.Location = new System.Drawing.Point(234, 234);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(91, 29);
            this.getButton.TabIndex = 8;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = false;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Specialization     :";
            // 
            // speccombo
            // 
            this.speccombo.FormattingEnabled = true;
            this.speccombo.Location = new System.Drawing.Point(219, 71);
            this.speccombo.Name = "speccombo";
            this.speccombo.Size = new System.Drawing.Size(196, 21);
            this.speccombo.TabIndex = 6;
            this.speccombo.SelectedIndexChanged += new System.EventHandler(this.speccombo_SelectedIndexChanged);
            // 
            // ListOfContactbySpecialization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(525, 361);
            this.Controls.Add(this.workingRadioButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.speccombo);
            this.Name = "ListOfContactbySpecialization";
            this.Text = "ListOfContactbySpecialization";
            this.Load += new System.EventHandler(this.ListOfContactbySpecialization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton workingRadioButton;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox speccombo;
    }
}