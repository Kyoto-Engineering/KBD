namespace PhonebookApp.Reports
{
    partial class ReportByBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportByBatch));
            this.getButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.batchIdCombobox = new System.Windows.Forms.ComboBox();
            this.BatchReportforSuccessfulLetter = new System.Windows.Forms.RadioButton();
            this.LandscapeRadioButton = new System.Windows.Forms.RadioButton();
            this.missingradioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getButton.Location = new System.Drawing.Point(184, 264);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(11, 23);
            this.getButton.TabIndex = 0;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = false;
            this.getButton.Visible = false;
            this.getButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Batch Id   :";
            this.label1.Visible = false;
            // 
            // batchIdCombobox
            // 
            this.batchIdCombobox.FormattingEnabled = true;
            this.batchIdCombobox.Location = new System.Drawing.Point(496, 239);
            this.batchIdCombobox.Name = "batchIdCombobox";
            this.batchIdCombobox.Size = new System.Drawing.Size(17, 21);
            this.batchIdCombobox.TabIndex = 2;
            this.batchIdCombobox.Visible = false;
            this.batchIdCombobox.SelectedIndexChanged += new System.EventHandler(this.batchIdCombobox_SelectedIndexChanged);
            // 
            // BatchReportforSuccessfulLetter
            // 
            this.BatchReportforSuccessfulLetter.AutoSize = true;
            this.BatchReportforSuccessfulLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchReportforSuccessfulLetter.Location = new System.Drawing.Point(407, 277);
            this.BatchReportforSuccessfulLetter.Name = "BatchReportforSuccessfulLetter";
            this.BatchReportforSuccessfulLetter.Size = new System.Drawing.Size(188, 17);
            this.BatchReportforSuccessfulLetter.TabIndex = 3;
            this.BatchReportforSuccessfulLetter.TabStop = true;
            this.BatchReportforSuccessfulLetter.Text = "Batch Report for Successful Letter";
            this.BatchReportforSuccessfulLetter.UseVisualStyleBackColor = true;
            this.BatchReportforSuccessfulLetter.Visible = false;
            this.BatchReportforSuccessfulLetter.CheckedChanged += new System.EventHandler(this.PortraitRadioButton_CheckedChanged);
            // 
            // LandscapeRadioButton
            // 
            this.LandscapeRadioButton.AutoSize = true;
            this.LandscapeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandscapeRadioButton.Location = new System.Drawing.Point(201, 274);
            this.LandscapeRadioButton.Name = "LandscapeRadioButton";
            this.LandscapeRadioButton.Size = new System.Drawing.Size(200, 17);
            this.LandscapeRadioButton.TabIndex = 4;
            this.LandscapeRadioButton.TabStop = true;
            this.LandscapeRadioButton.Text = "Batch Report for Unsuccessful Letter";
            this.LandscapeRadioButton.UseVisualStyleBackColor = true;
            this.LandscapeRadioButton.Visible = false;
            // 
            // missingradioButton
            // 
            this.missingradioButton.AutoSize = true;
            this.missingradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingradioButton.Location = new System.Drawing.Point(12, 271);
            this.missingradioButton.Name = "missingradioButton";
            this.missingradioButton.Size = new System.Drawing.Size(171, 17);
            this.missingradioButton.TabIndex = 5;
            this.missingradioButton.TabStop = true;
            this.missingradioButton.Text = "Batch Report for Missing Letter";
            this.missingradioButton.UseVisualStyleBackColor = true;
            this.missingradioButton.Visible = false;
            this.missingradioButton.CheckedChanged += new System.EventHandler(this.missingradioButton_CheckedChanged);
            this.missingradioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.missingradioButton_MouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(67, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 60);
            this.button1.TabIndex = 6;
            this.button1.Text = "Successful Letters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(326, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 60);
            this.button2.TabIndex = 7;
            this.button2.Text = "Unsuccessful Letters";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(563, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 60);
            this.button3.TabIndex = 8;
            this.button3.Text = "Missing Letters";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ReportByBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(784, 345);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.missingradioButton);
            this.Controls.Add(this.LandscapeRadioButton);
            this.Controls.Add(this.BatchReportforSuccessfulLetter);
            this.Controls.Add(this.batchIdCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportByBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportByBatch";
            this.Load += new System.EventHandler(this.ReportByBatch_Load);
            this.Click += new System.EventHandler(this.ReportByBatch_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox batchIdCombobox;
        private System.Windows.Forms.RadioButton BatchReportforSuccessfulLetter;
        private System.Windows.Forms.RadioButton LandscapeRadioButton;
        private System.Windows.Forms.RadioButton missingradioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}