namespace PhonebookApp.UI
{
    partial class Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Group));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupNamelabel = new System.Windows.Forms.Label();
            this.addbutton = new System.Windows.Forms.Button();
            this.submitbutton = new System.Windows.Forms.Button();
            this.GroupNamecomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PersonSearchtextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CompanySearchtextBox = new System.Windows.Forms.TextBox();
            this.EidGreetingGroupAddressbutton = new System.Windows.Forms.Button();
            this.EnvelopesizeGroupAddressbutton = new System.Windows.Forms.Button();
            this.A4SizeGroupAddressbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LOIforK8DSbutton = new System.Windows.Forms.Button();
            this.LOIforKBDbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dataGridView.Location = new System.Drawing.Point(421, 121);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(846, 257);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PersonId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Person Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Email";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Company Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Job Title";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Specialization";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Profession";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Education Level";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Age Group";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Date Of Birth";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Religion";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Marital Status";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Marriage Anniversary Date";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "CompanyId";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(421, 456);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(846, 231);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Person Id";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Person Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Company Id";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Company Name";
            this.columnHeader4.Width = 270;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Group Id";
            // 
            // groupNamelabel
            // 
            this.groupNamelabel.AutoSize = true;
            this.groupNamelabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNamelabel.ForeColor = System.Drawing.Color.Black;
            this.groupNamelabel.Location = new System.Drawing.Point(620, 405);
            this.groupNamelabel.Name = "groupNamelabel";
            this.groupNamelabel.Size = new System.Drawing.Size(116, 22);
            this.groupNamelabel.TabIndex = 5;
            this.groupNamelabel.Text = "Group Name";
            // 
            // addbutton
            // 
            this.addbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.ForeColor = System.Drawing.Color.Black;
            this.addbutton.Location = new System.Drawing.Point(421, 386);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(113, 57);
            this.addbutton.TabIndex = 6;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // submitbutton
            // 
            this.submitbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.submitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitbutton.ForeColor = System.Drawing.Color.Black;
            this.submitbutton.Location = new System.Drawing.Point(1166, 384);
            this.submitbutton.Name = "submitbutton";
            this.submitbutton.Size = new System.Drawing.Size(101, 53);
            this.submitbutton.TabIndex = 7;
            this.submitbutton.Text = "Submit";
            this.submitbutton.UseVisualStyleBackColor = false;
            this.submitbutton.Click += new System.EventHandler(this.submitbutton_Click);
            // 
            // GroupNamecomboBox
            // 
            this.GroupNamecomboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupNamecomboBox.FormattingEnabled = true;
            this.GroupNamecomboBox.Location = new System.Drawing.Point(742, 402);
            this.GroupNamecomboBox.Name = "GroupNamecomboBox";
            this.GroupNamecomboBox.Size = new System.Drawing.Size(257, 27);
            this.GroupNamecomboBox.TabIndex = 8;
            this.GroupNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.GroupNamecomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Contact Added to Group";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(421, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 49);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(30, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 130);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Residential Address";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(310, 93);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(26, 404);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 120);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Corporate Address";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(17, 19);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(327, 95);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.ForeColor = System.Drawing.Color.Black;
            this.removeButton.Location = new System.Drawing.Point(288, 575);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(105, 53);
            this.removeButton.TabIndex = 13;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PersonSearchtextBox);
            this.groupBox4.Location = new System.Drawing.Point(421, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(334, 57);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search By Person Name";
            // 
            // PersonSearchtextBox
            // 
            this.PersonSearchtextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonSearchtextBox.Location = new System.Drawing.Point(14, 20);
            this.PersonSearchtextBox.Name = "PersonSearchtextBox";
            this.PersonSearchtextBox.Size = new System.Drawing.Size(265, 26);
            this.PersonSearchtextBox.TabIndex = 0;
            this.PersonSearchtextBox.TextChanged += new System.EventHandler(this.PersonSearchtextBox_TextChanged);
            this.PersonSearchtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PersonSearchtextBox_KeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CompanySearchtextBox);
            this.groupBox5.Location = new System.Drawing.Point(813, 58);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(344, 57);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search By Company Name";
            // 
            // CompanySearchtextBox
            // 
            this.CompanySearchtextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanySearchtextBox.Location = new System.Drawing.Point(12, 20);
            this.CompanySearchtextBox.Name = "CompanySearchtextBox";
            this.CompanySearchtextBox.Size = new System.Drawing.Size(283, 26);
            this.CompanySearchtextBox.TabIndex = 1;
            this.CompanySearchtextBox.TextChanged += new System.EventHandler(this.CompanySearchtextBox_TextChanged);
            this.CompanySearchtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanySearchtextBox_KeyDown);
            // 
            // EidGreetingGroupAddressbutton
            // 
            this.EidGreetingGroupAddressbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EidGreetingGroupAddressbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EidGreetingGroupAddressbutton.ForeColor = System.Drawing.Color.Black;
            this.EidGreetingGroupAddressbutton.Location = new System.Drawing.Point(261, 78);
            this.EidGreetingGroupAddressbutton.Name = "EidGreetingGroupAddressbutton";
            this.EidGreetingGroupAddressbutton.Size = new System.Drawing.Size(110, 65);
            this.EidGreetingGroupAddressbutton.TabIndex = 16;
            this.EidGreetingGroupAddressbutton.Text = "Eid Greeting Group Address";
            this.EidGreetingGroupAddressbutton.UseVisualStyleBackColor = false;
            this.EidGreetingGroupAddressbutton.Click += new System.EventHandler(this.EidGreetingGroupAddressbutton_Click);
            // 
            // EnvelopesizeGroupAddressbutton
            // 
            this.EnvelopesizeGroupAddressbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EnvelopesizeGroupAddressbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvelopesizeGroupAddressbutton.ForeColor = System.Drawing.Color.Black;
            this.EnvelopesizeGroupAddressbutton.Location = new System.Drawing.Point(137, 78);
            this.EnvelopesizeGroupAddressbutton.Name = "EnvelopesizeGroupAddressbutton";
            this.EnvelopesizeGroupAddressbutton.Size = new System.Drawing.Size(106, 65);
            this.EnvelopesizeGroupAddressbutton.TabIndex = 17;
            this.EnvelopesizeGroupAddressbutton.Text = "Envelope size Group Address";
            this.EnvelopesizeGroupAddressbutton.UseVisualStyleBackColor = false;
            this.EnvelopesizeGroupAddressbutton.Click += new System.EventHandler(this.EnvelopesizeGroupAddressbutton_Click);
            // 
            // A4SizeGroupAddressbutton
            // 
            this.A4SizeGroupAddressbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.A4SizeGroupAddressbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4SizeGroupAddressbutton.ForeColor = System.Drawing.Color.Black;
            this.A4SizeGroupAddressbutton.Location = new System.Drawing.Point(29, 78);
            this.A4SizeGroupAddressbutton.Name = "A4SizeGroupAddressbutton";
            this.A4SizeGroupAddressbutton.Size = new System.Drawing.Size(102, 65);
            this.A4SizeGroupAddressbutton.TabIndex = 18;
            this.A4SizeGroupAddressbutton.Text = "A4 Size Group Address";
            this.A4SizeGroupAddressbutton.UseVisualStyleBackColor = false;
            this.A4SizeGroupAddressbutton.Click += new System.EventHandler(this.A4SizeGroupAddressbutton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(137, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 65);
            this.button1.TabIndex = 22;
            this.button1.Text = "LOI for Automated Traffic Light";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LOIforK8DSbutton
            // 
            this.LOIforK8DSbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LOIforK8DSbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOIforK8DSbutton.ForeColor = System.Drawing.Color.Black;
            this.LOIforK8DSbutton.Location = new System.Drawing.Point(29, 149);
            this.LOIforK8DSbutton.Name = "LOIforK8DSbutton";
            this.LOIforK8DSbutton.Size = new System.Drawing.Size(102, 65);
            this.LOIforK8DSbutton.TabIndex = 21;
            this.LOIforK8DSbutton.Text = "LOI for K8DS";
            this.LOIforK8DSbutton.UseVisualStyleBackColor = false;
            this.LOIforK8DSbutton.Visible = false;
            this.LOIforK8DSbutton.Click += new System.EventHandler(this.LOIforK8DSbutton_Click);
            // 
            // LOIforKBDbutton
            // 
            this.LOIforKBDbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LOIforKBDbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOIforKBDbutton.ForeColor = System.Drawing.Color.Black;
            this.LOIforKBDbutton.Location = new System.Drawing.Point(261, 149);
            this.LOIforKBDbutton.Name = "LOIforKBDbutton";
            this.LOIforKBDbutton.Size = new System.Drawing.Size(110, 65);
            this.LOIforKBDbutton.TabIndex = 23;
            this.LOIforKBDbutton.Text = "LOI for KBD";
            this.LOIforKBDbutton.UseVisualStyleBackColor = false;
            this.LOIforKBDbutton.Visible = false;
            this.LOIforKBDbutton.Click += new System.EventHandler(this.LOIforKBDbutton_Click);
            // 
            // Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1279, 703);
            this.Controls.Add(this.LOIforKBDbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LOIforK8DSbutton);
            this.Controls.Add(this.A4SizeGroupAddressbutton);
            this.Controls.Add(this.EnvelopesizeGroupAddressbutton);
            this.Controls.Add(this.EidGreetingGroupAddressbutton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupNamecomboBox);
            this.Controls.Add(this.submitbutton);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.groupNamelabel);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label groupNamelabel;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button submitbutton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox GroupNamecomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox PersonSearchtextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox CompanySearchtextBox;
        private System.Windows.Forms.Button EidGreetingGroupAddressbutton;
        private System.Windows.Forms.Button EnvelopesizeGroupAddressbutton;
        private System.Windows.Forms.Button A4SizeGroupAddressbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LOIforK8DSbutton;
        private System.Windows.Forms.Button LOIforKBDbutton;
    }
}