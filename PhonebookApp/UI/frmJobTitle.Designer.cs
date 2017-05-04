namespace PhonebookApp.UI
{
    partial class frmJobTitle
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
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveJobTitle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.ForeColor = System.Drawing.Color.Blue;
            this.lblCategoryName.Location = new System.Drawing.Point(31, 22);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(185, 22);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Job Title/Designation";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobTitle.Location = new System.Drawing.Point(22, 31);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(367, 29);
            this.txtJobTitle.TabIndex = 1;
            this.txtJobTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobTitle_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtJobTitle);
            this.groupBox1.Location = new System.Drawing.Point(26, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveJobTitle
            // 
            this.btnSaveJobTitle.BackColor = System.Drawing.Color.Lime;
            this.btnSaveJobTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveJobTitle.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveJobTitle.Location = new System.Drawing.Point(310, 168);
            this.btnSaveJobTitle.Name = "btnSaveJobTitle";
            this.btnSaveJobTitle.Size = new System.Drawing.Size(124, 70);
            this.btnSaveJobTitle.TabIndex = 1;
            this.btnSaveJobTitle.Text = "Save ";
            this.btnSaveJobTitle.UseVisualStyleBackColor = false;
            this.btnSaveJobTitle.Click += new System.EventHandler(this.btnSaveJobTitle_Click);
            // 
            // frmJobTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(506, 276);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveJobTitle);
            this.MaximizeBox = false;
            this.Name = "frmJobTitle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJobTitle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmJobTitle_FormClosed);
            this.Load += new System.EventHandler(this.frmJobTitle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveJobTitle;
    }
}