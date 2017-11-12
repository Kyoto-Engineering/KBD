namespace PhonebookApp.UI
{
    partial class ForeignCompanySelectionGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForeignCompanySelectionGrid));
            this.ForeignCompanySelectionForm = new System.Windows.Forms.Label();
            this.SearchByCompanyNameGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NewComCreationButton = new System.Windows.Forms.Button();
            this.CompanySelectiongroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchByCompanyNameGroupBox.SuspendLayout();
            this.CompanySelectiongroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ForeignCompanySelectionForm
            // 
            this.ForeignCompanySelectionForm.AutoSize = true;
            this.ForeignCompanySelectionForm.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeignCompanySelectionForm.Location = new System.Drawing.Point(167, 28);
            this.ForeignCompanySelectionForm.Name = "ForeignCompanySelectionForm";
            this.ForeignCompanySelectionForm.Size = new System.Drawing.Size(403, 31);
            this.ForeignCompanySelectionForm.TabIndex = 3;
            this.ForeignCompanySelectionForm.Text = "Foreign Company Selection Form";
            // 
            // SearchByCompanyNameGroupBox
            // 
            this.SearchByCompanyNameGroupBox.Controls.Add(this.textBox1);
            this.SearchByCompanyNameGroupBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByCompanyNameGroupBox.ForeColor = System.Drawing.Color.OrangeRed;
            this.SearchByCompanyNameGroupBox.Location = new System.Drawing.Point(17, 100);
            this.SearchByCompanyNameGroupBox.Name = "SearchByCompanyNameGroupBox";
            this.SearchByCompanyNameGroupBox.Size = new System.Drawing.Size(369, 63);
            this.SearchByCompanyNameGroupBox.TabIndex = 4;
            this.SearchByCompanyNameGroupBox.TabStop = false;
            this.SearchByCompanyNameGroupBox.Text = "Search By Company Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // NewComCreationButton
            // 
            this.NewComCreationButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.NewComCreationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewComCreationButton.Location = new System.Drawing.Point(567, 109);
            this.NewComCreationButton.Name = "NewComCreationButton";
            this.NewComCreationButton.Size = new System.Drawing.Size(123, 52);
            this.NewComCreationButton.TabIndex = 5;
            this.NewComCreationButton.Text = "New Company Creation";
            this.NewComCreationButton.UseVisualStyleBackColor = false;
            this.NewComCreationButton.Click += new System.EventHandler(this.NewComCreationButton_Click);
            // 
            // CompanySelectiongroupBox
            // 
            this.CompanySelectiongroupBox.Controls.Add(this.dataGridView1);
            this.CompanySelectiongroupBox.Location = new System.Drawing.Point(5, 202);
            this.CompanySelectiongroupBox.Name = "CompanySelectiongroupBox";
            this.CompanySelectiongroupBox.Size = new System.Drawing.Size(775, 260);
            this.CompanySelectiongroupBox.TabIndex = 6;
            this.CompanySelectiongroupBox.TabStop = false;
            this.CompanySelectiongroupBox.Text = "Company Selection (Existing Companies)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.GridColor = System.Drawing.Color.CornflowerBlue;
            this.dataGridView1.Location = new System.Drawing.Point(31, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(694, 182);
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
            // ForeignCompanySelectionGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(813, 474);
            this.Controls.Add(this.CompanySelectiongroupBox);
            this.Controls.Add(this.NewComCreationButton);
            this.Controls.Add(this.SearchByCompanyNameGroupBox);
            this.Controls.Add(this.ForeignCompanySelectionForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForeignCompanySelectionGrid";
            this.Text = "ForeignCompanySelectionGrid";
            this.Load += new System.EventHandler(this.ForeignCompanySelectionGrid_Load);
            this.SearchByCompanyNameGroupBox.ResumeLayout(false);
            this.SearchByCompanyNameGroupBox.PerformLayout();
            this.CompanySelectiongroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ForeignCompanySelectionForm;
        private System.Windows.Forms.GroupBox SearchByCompanyNameGroupBox;
        private System.Windows.Forms.Button NewComCreationButton;
        private System.Windows.Forms.GroupBox CompanySelectiongroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox textBox1;
    }
}