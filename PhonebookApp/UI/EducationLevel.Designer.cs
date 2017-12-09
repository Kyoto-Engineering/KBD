namespace PhonebookApp.UI
{
    partial class EducationLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EducationLevel));
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtEducationLevel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveEducationLevel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(40, 28);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(188, 20);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Education Level Name";
            // 
            // txtEducationLevel
            // 
            this.txtEducationLevel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEducationLevel.Location = new System.Drawing.Point(22, 31);
            this.txtEducationLevel.MaxLength = 90;
            this.txtEducationLevel.Name = "txtEducationLevel";
            this.txtEducationLevel.Size = new System.Drawing.Size(367, 29);
            this.txtEducationLevel.TabIndex = 1;
            this.txtEducationLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEducationLevel_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEducationLevel);
            this.groupBox1.Location = new System.Drawing.Point(35, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveEducationLevel
            // 
            this.btnSaveEducationLevel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveEducationLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEducationLevel.ForeColor = System.Drawing.Color.Black;
            this.btnSaveEducationLevel.Location = new System.Drawing.Point(346, 177);
            this.btnSaveEducationLevel.Name = "btnSaveEducationLevel";
            this.btnSaveEducationLevel.Size = new System.Drawing.Size(97, 30);
            this.btnSaveEducationLevel.TabIndex = 1;
            this.btnSaveEducationLevel.Text = "Save ";
            this.btnSaveEducationLevel.UseVisualStyleBackColor = false;
            this.btnSaveEducationLevel.Click += new System.EventHandler(this.btnSaveEducationLevel_Click);
            // 
            // EducationLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(487, 245);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveEducationLevel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EducationLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EducationLevel";
            this.Load += new System.EventHandler(this.EducationLevel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtEducationLevel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveEducationLevel;
    }
}