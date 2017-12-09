namespace PhonebookApp.UI
{
    partial class ForeignPersonSelectionUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForeignPersonSelectionUI));
            this.label1 = new System.Windows.Forms.Label();
            this.SearchPersonNametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SearchByPersonIdtextBox = new System.Windows.Forms.TextBox();
            this.CompanySelectiongroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(222, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = " List  of Overseas Person  Information";
            // 
            // SearchPersonNametextBox
            // 
            this.SearchPersonNametextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPersonNametextBox.Location = new System.Drawing.Point(37, 107);
            this.SearchPersonNametextBox.Name = "SearchPersonNametextBox";
            this.SearchPersonNametextBox.Size = new System.Drawing.Size(221, 26);
            this.SearchPersonNametextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search By Overseas Person Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SearchByPersonIdtextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(398, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 59);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search By Overseas Person Id";
            // 
            // SearchByPersonIdtextBox
            // 
            this.SearchByPersonIdtextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByPersonIdtextBox.Location = new System.Drawing.Point(10, 20);
            this.SearchByPersonIdtextBox.Name = "SearchByPersonIdtextBox";
            this.SearchByPersonIdtextBox.Size = new System.Drawing.Size(216, 29);
            this.SearchByPersonIdtextBox.TabIndex = 0;
            // 
            // CompanySelectiongroupBox
            // 
            this.CompanySelectiongroupBox.ForeColor = System.Drawing.Color.Black;
            this.CompanySelectiongroupBox.Location = new System.Drawing.Point(25, 194);
            this.CompanySelectiongroupBox.Name = "CompanySelectiongroupBox";
            this.CompanySelectiongroupBox.Size = new System.Drawing.Size(910, 256);
            this.CompanySelectiongroupBox.TabIndex = 9;
            this.CompanySelectiongroupBox.TabStop = false;
            this.CompanySelectiongroupBox.Text = "Overseas Person Selection (Existing Person)";
            // 
            // ForeignPersonSelectionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(958, 474);
            this.Controls.Add(this.CompanySelectiongroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SearchPersonNametextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForeignPersonSelectionUI";
            this.Text = "ForeignPersonSelectionUI";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchPersonNametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox SearchByPersonIdtextBox;
        private System.Windows.Forms.GroupBox CompanySelectiongroupBox;
    }
}