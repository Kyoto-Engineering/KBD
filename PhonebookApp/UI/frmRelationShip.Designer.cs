namespace PhonebookApp.UI
{
    partial class frmRelationShip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelationShip));
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtRelationship = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveRelationship = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.ForeColor = System.Drawing.Color.Black;
            this.lblCategoryName.Location = new System.Drawing.Point(21, 16);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(112, 22);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Relationship";
            // 
            // txtRelationship
            // 
            this.txtRelationship.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelationship.Location = new System.Drawing.Point(22, 31);
            this.txtRelationship.MaxLength = 90;
            this.txtRelationship.Name = "txtRelationship";
            this.txtRelationship.Size = new System.Drawing.Size(367, 29);
            this.txtRelationship.TabIndex = 1;
            this.txtRelationship.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRelationship_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRelationship);
            this.groupBox1.Location = new System.Drawing.Point(16, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveRelationship
            // 
            this.btnSaveRelationship.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSaveRelationship.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRelationship.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveRelationship.Location = new System.Drawing.Point(281, 171);
            this.btnSaveRelationship.Name = "btnSaveRelationship";
            this.btnSaveRelationship.Size = new System.Drawing.Size(124, 70);
            this.btnSaveRelationship.TabIndex = 1;
            this.btnSaveRelationship.Text = "Save ";
            this.btnSaveRelationship.UseVisualStyleBackColor = false;
            this.btnSaveRelationship.Click += new System.EventHandler(this.btnSaveRelationship_Click);
            // 
            // frmRelationShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(468, 292);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveRelationship);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelationShip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRelationShip";
            this.Load += new System.EventHandler(this.frmRelationShip_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtRelationship;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveRelationship;
    }
}