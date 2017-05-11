namespace PhonebookApp.UI
{
    partial class frmCompany
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
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IndustryCategorycomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompanytype = new System.Windows.Forms.ComboBox();
            this.btnSaveCompany = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWABlock = new System.Windows.Forms.TextBox();
            this.cmbWAPost = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.cmbWADivision = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.cmbWAThana = new System.Windows.Forms.ComboBox();
            this.txtWAContactNo = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.cmbWADistrict = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtWAPostCode = new System.Windows.Forms.TextBox();
            this.txtWAArea = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.txtWARoadNo = new System.Windows.Forms.TextBox();
            this.txtWAHouseName = new System.Windows.Forms.TextBox();
            this.txtWAFlatName = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(17, 25);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(141, 22);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(188, 22);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(318, 29);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.IndustryCategorycomboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCompanytype);
            this.groupBox1.Controls.Add(this.lblCategoryName);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(183, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Industry Category";
            // 
            // IndustryCategorycomboBox
            // 
            this.IndustryCategorycomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.IndustryCategorycomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.IndustryCategorycomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IndustryCategorycomboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IndustryCategorycomboBox.FormattingEnabled = true;
            this.IndustryCategorycomboBox.Location = new System.Drawing.Point(188, 103);
            this.IndustryCategorycomboBox.Name = "IndustryCategorycomboBox";
            this.IndustryCategorycomboBox.Size = new System.Drawing.Size(318, 30);
            this.IndustryCategorycomboBox.TabIndex = 9;
            this.IndustryCategorycomboBox.SelectedIndexChanged += new System.EventHandler(this.IndustryCategorycomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Company Type";
            // 
            // cmbCompanytype
            // 
            this.cmbCompanytype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompanytype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompanytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanytype.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompanytype.FormattingEnabled = true;
            this.cmbCompanytype.Location = new System.Drawing.Point(188, 62);
            this.cmbCompanytype.Name = "cmbCompanytype";
            this.cmbCompanytype.Size = new System.Drawing.Size(318, 30);
            this.cmbCompanytype.TabIndex = 7;
            this.cmbCompanytype.SelectedIndexChanged += new System.EventHandler(this.cmbCompanytype_SelectedIndexChanged);
            // 
            // btnSaveCompany
            // 
            this.btnSaveCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSaveCompany.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCompany.ForeColor = System.Drawing.Color.White;
            this.btnSaveCompany.Location = new System.Drawing.Point(641, 495);
            this.btnSaveCompany.Name = "btnSaveCompany";
            this.btnSaveCompany.Size = new System.Drawing.Size(124, 70);
            this.btnSaveCompany.TabIndex = 1;
            this.btnSaveCompany.Text = "Save ";
            this.btnSaveCompany.UseVisualStyleBackColor = false;
            this.btnSaveCompany.Click += new System.EventHandler(this.btnSaveCompany_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(125, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 253);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Address";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtWABlock);
            this.groupBox4.Controls.Add(this.cmbWAPost);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.cmbWADivision);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.label45);
            this.groupBox4.Controls.Add(this.cmbWAThana);
            this.groupBox4.Controls.Add(this.txtWAContactNo);
            this.groupBox4.Controls.Add(this.label46);
            this.groupBox4.Controls.Add(this.cmbWADistrict);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.txtWAPostCode);
            this.groupBox4.Controls.Add(this.txtWAArea);
            this.groupBox4.Controls.Add(this.label48);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Controls.Add(this.txtWARoadNo);
            this.groupBox4.Controls.Add(this.txtWAHouseName);
            this.groupBox4.Controls.Add(this.txtWAFlatName);
            this.groupBox4.Controls.Add(this.label51);
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.label53);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox4.Location = new System.Drawing.Point(13, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(672, 203);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // txtWABlock
            // 
            this.txtWABlock.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWABlock.Location = new System.Drawing.Point(158, 108);
            this.txtWABlock.Name = "txtWABlock";
            this.txtWABlock.Size = new System.Drawing.Size(172, 26);
            this.txtWABlock.TabIndex = 4;
            // 
            // cmbWAPost
            // 
            this.cmbWAPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWAPost.FormattingEnabled = true;
            this.cmbWAPost.Location = new System.Drawing.Point(452, 122);
            this.cmbWAPost.Name = "cmbWAPost";
            this.cmbWAPost.Size = new System.Drawing.Size(198, 30);
            this.cmbWAPost.TabIndex = 10;
            this.cmbWAPost.SelectedIndexChanged += new System.EventHandler(this.cmbWAPost_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.Red;
            this.label35.Location = new System.Drawing.Point(427, 127);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(20, 22);
            this.label35.TabIndex = 81;
            this.label35.Text = "*";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(336, 127);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(96, 22);
            this.label36.TabIndex = 80;
            this.label36.Text = "Post         :";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.Red;
            this.label37.Location = new System.Drawing.Point(425, 25);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(20, 22);
            this.label37.TabIndex = 79;
            this.label37.Text = "*";
            // 
            // cmbWADivision
            // 
            this.cmbWADivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWADivision.FormattingEnabled = true;
            this.cmbWADivision.Location = new System.Drawing.Point(452, 20);
            this.cmbWADivision.Name = "cmbWADivision";
            this.cmbWADivision.Size = new System.Drawing.Size(198, 30);
            this.cmbWADivision.TabIndex = 7;
            this.cmbWADivision.SelectedIndexChanged += new System.EventHandler(this.cmbWADivision_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(336, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(96, 22);
            this.label38.TabIndex = 77;
            this.label38.Text = "Division   :";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.Red;
            this.label39.Location = new System.Drawing.Point(427, 160);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(20, 22);
            this.label39.TabIndex = 75;
            this.label39.Text = "*";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Red;
            this.label40.Location = new System.Drawing.Point(426, 54);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(20, 22);
            this.label40.TabIndex = 74;
            this.label40.Text = "*";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.Red;
            this.label45.Location = new System.Drawing.Point(427, 89);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(20, 22);
            this.label45.TabIndex = 73;
            this.label45.Text = "*";
            // 
            // cmbWAThana
            // 
            this.cmbWAThana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWAThana.FormattingEnabled = true;
            this.cmbWAThana.Location = new System.Drawing.Point(452, 85);
            this.cmbWAThana.Name = "cmbWAThana";
            this.cmbWAThana.Size = new System.Drawing.Size(198, 30);
            this.cmbWAThana.TabIndex = 9;
            this.cmbWAThana.SelectedIndexChanged += new System.EventHandler(this.cmbWAThana_SelectedIndexChanged);
            // 
            // txtWAContactNo
            // 
            this.txtWAContactNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWAContactNo.Location = new System.Drawing.Point(158, 167);
            this.txtWAContactNo.MaxLength = 11;
            this.txtWAContactNo.Name = "txtWAContactNo";
            this.txtWAContactNo.Size = new System.Drawing.Size(171, 26);
            this.txtWAContactNo.TabIndex = 6;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(10, 170);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(150, 19);
            this.label46.TabIndex = 40;
            this.label46.Text = "Contact No               :";
            // 
            // cmbWADistrict
            // 
            this.cmbWADistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWADistrict.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWADistrict.FormattingEnabled = true;
            this.cmbWADistrict.Location = new System.Drawing.Point(451, 54);
            this.cmbWADistrict.Name = "cmbWADistrict";
            this.cmbWADistrict.Size = new System.Drawing.Size(199, 27);
            this.cmbWADistrict.TabIndex = 8;
            this.cmbWADistrict.SelectedIndexChanged += new System.EventHandler(this.cmbWADistrict_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(336, 55);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(96, 22);
            this.label47.TabIndex = 18;
            this.label47.Text = "District    :";
            // 
            // txtWAPostCode
            // 
            this.txtWAPostCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWAPostCode.Location = new System.Drawing.Point(452, 157);
            this.txtWAPostCode.Name = "txtWAPostCode";
            this.txtWAPostCode.ReadOnly = true;
            this.txtWAPostCode.Size = new System.Drawing.Size(198, 29);
            this.txtWAPostCode.TabIndex = 11;
            // 
            // txtWAArea
            // 
            this.txtWAArea.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWAArea.Location = new System.Drawing.Point(158, 138);
            this.txtWAArea.Name = "txtWAArea";
            this.txtWAArea.Size = new System.Drawing.Size(171, 26);
            this.txtWAArea.TabIndex = 5;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(10, 141);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(151, 19);
            this.label48.TabIndex = 14;
            this.label48.Text = "Area                          :";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(331, 158);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(104, 22);
            this.label49.TabIndex = 13;
            this.label49.Text = "Post Code :";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(336, 88);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(98, 22);
            this.label50.TabIndex = 12;
            this.label50.Text = "Thana      :";
            // 
            // txtWARoadNo
            // 
            this.txtWARoadNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWARoadNo.Location = new System.Drawing.Point(158, 78);
            this.txtWARoadNo.Name = "txtWARoadNo";
            this.txtWARoadNo.Size = new System.Drawing.Size(172, 26);
            this.txtWARoadNo.TabIndex = 3;
            // 
            // txtWAHouseName
            // 
            this.txtWAHouseName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWAHouseName.Location = new System.Drawing.Point(158, 49);
            this.txtWAHouseName.Name = "txtWAHouseName";
            this.txtWAHouseName.Size = new System.Drawing.Size(172, 26);
            this.txtWAHouseName.TabIndex = 2;
            // 
            // txtWAFlatName
            // 
            this.txtWAFlatName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWAFlatName.Location = new System.Drawing.Point(158, 20);
            this.txtWAFlatName.Name = "txtWAFlatName";
            this.txtWAFlatName.Size = new System.Drawing.Size(172, 26);
            this.txtWAFlatName.TabIndex = 1;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(10, 111);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(149, 19);
            this.label51.TabIndex = 7;
            this.label51.Text = "Block                        :";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(8, 81);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(150, 19);
            this.label52.TabIndex = 6;
            this.label52.Text = "Road No / Name      :";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(6, 52);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(153, 19);
            this.label53.TabIndex = 5;
            this.label53.Text = "House No / Name     :";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(6, 23);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(156, 19);
            this.label54.TabIndex = 4;
            this.label54.Text = "Flat No / Name          :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(366, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 33);
            this.label3.TabIndex = 22;
            this.label3.Text = "Company Creation";
            // 
            // frmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(922, 618);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveCompany);
            this.MaximizeBox = false;
            this.Name = "frmCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCompany";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCompany_FormClosed);
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveCompany;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWABlock;
        private System.Windows.Forms.ComboBox cmbWAPost;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cmbWADivision;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cmbWAThana;
        private System.Windows.Forms.TextBox txtWAContactNo;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox cmbWADistrict;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtWAPostCode;
        private System.Windows.Forms.TextBox txtWAArea;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtWARoadNo;
        private System.Windows.Forms.TextBox txtWAHouseName;
        private System.Windows.Forms.TextBox txtWAFlatName;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox IndustryCategorycomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompanytype;
        private System.Windows.Forms.Label label3;
    }
}