namespace PhonebookApp.UI
{
    partial class Profession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profession));
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtProfessionName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveProfession = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(36, 32);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(145, 20);
            this.lblCategoryName.TabIndex = 4;
            this.lblCategoryName.Text = "Profession Name";
            // 
            // txtProfessionName
            // 
            this.txtProfessionName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfessionName.Location = new System.Drawing.Point(22, 31);
            this.txtProfessionName.MaxLength = 90;
            this.txtProfessionName.Name = "txtProfessionName";
            this.txtProfessionName.Size = new System.Drawing.Size(445, 29);
            this.txtProfessionName.TabIndex = 1;
            this.txtProfessionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProfessionName_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProfessionName);
            this.groupBox1.Location = new System.Drawing.Point(31, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveProfession
            // 
            this.btnSaveProfession.BackColor = System.Drawing.Color.White;
            this.btnSaveProfession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProfession.ForeColor = System.Drawing.Color.Black;
            this.btnSaveProfession.Location = new System.Drawing.Point(397, 189);
            this.btnSaveProfession.Name = "btnSaveProfession";
            this.btnSaveProfession.Size = new System.Drawing.Size(101, 36);
            this.btnSaveProfession.TabIndex = 1;
            this.btnSaveProfession.Text = "Save ";
            this.btnSaveProfession.UseVisualStyleBackColor = false;
            this.btnSaveProfession.Click += new System.EventHandler(this.btnSaveProfession_Click);
            // 
            // Profession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(574, 290);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveProfession);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Profession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profession";
            this.Load += new System.EventHandler(this.Profession_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtProfessionName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveProfession;
    }
}