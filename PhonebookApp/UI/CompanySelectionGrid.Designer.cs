namespace PhonebookApp.UI
{
    partial class CompanySelectionGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CompanySelectiongroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchByCompanyNameGroupBox = new System.Windows.Forms.GroupBox();
            this.companyNameSearchtextBox = new System.Windows.Forms.TextBox();
            this.CompanySelectiongroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SearchByCompanyNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompanySelectiongroupBox
            // 
            this.CompanySelectiongroupBox.Controls.Add(this.dataGridView1);
            this.CompanySelectiongroupBox.Location = new System.Drawing.Point(33, 87);
            this.CompanySelectiongroupBox.Name = "CompanySelectiongroupBox";
            this.CompanySelectiongroupBox.Size = new System.Drawing.Size(726, 340);
            this.CompanySelectiongroupBox.TabIndex = 0;
            this.CompanySelectiongroupBox.TabStop = false;
            this.CompanySelectiongroupBox.Text = "Company Selection";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(17, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(695, 291);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Company Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Address";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Company Id";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // SearchByCompanyNameGroupBox
            // 
            this.SearchByCompanyNameGroupBox.Controls.Add(this.companyNameSearchtextBox);
            this.SearchByCompanyNameGroupBox.Location = new System.Drawing.Point(94, 13);
            this.SearchByCompanyNameGroupBox.Name = "SearchByCompanyNameGroupBox";
            this.SearchByCompanyNameGroupBox.Size = new System.Drawing.Size(369, 63);
            this.SearchByCompanyNameGroupBox.TabIndex = 1;
            this.SearchByCompanyNameGroupBox.TabStop = false;
            this.SearchByCompanyNameGroupBox.Text = "Search By Company Name";
            // 
            // companyNameSearchtextBox
            // 
            this.companyNameSearchtextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameSearchtextBox.Location = new System.Drawing.Point(26, 23);
            this.companyNameSearchtextBox.Name = "companyNameSearchtextBox";
            this.companyNameSearchtextBox.Size = new System.Drawing.Size(323, 29);
            this.companyNameSearchtextBox.TabIndex = 0;
            this.companyNameSearchtextBox.TextChanged += new System.EventHandler(this.companyNameSearchtextBox_TextChanged);
            // 
            // CompanySelectionGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 439);
            this.Controls.Add(this.SearchByCompanyNameGroupBox);
            this.Controls.Add(this.CompanySelectiongroupBox);
            this.Name = "CompanySelectionGrid";
            this.Text = "CompanySelectionGrid";
            this.Load += new System.EventHandler(this.CompanySelectionGrid_Load);
            this.CompanySelectiongroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.SearchByCompanyNameGroupBox.ResumeLayout(false);
            this.SearchByCompanyNameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CompanySelectiongroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox SearchByCompanyNameGroupBox;
        private System.Windows.Forms.TextBox companyNameSearchtextBox;
    }
}