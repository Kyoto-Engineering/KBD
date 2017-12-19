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
            this.SuspendLayout();
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getButton.Location = new System.Drawing.Point(236, 197);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(74, 23);
            this.getButton.TabIndex = 0;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = false;
            this.getButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Batch Id   :";
            // 
            // batchIdCombobox
            // 
            this.batchIdCombobox.FormattingEnabled = true;
            this.batchIdCombobox.Location = new System.Drawing.Point(192, 41);
            this.batchIdCombobox.Name = "batchIdCombobox";
            this.batchIdCombobox.Size = new System.Drawing.Size(194, 21);
            this.batchIdCombobox.TabIndex = 2;
            this.batchIdCombobox.SelectedIndexChanged += new System.EventHandler(this.batchIdCombobox_SelectedIndexChanged);
            // 
            // BatchReportforSuccessfulLetter
            // 
            this.BatchReportforSuccessfulLetter.AutoSize = true;
            this.BatchReportforSuccessfulLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchReportforSuccessfulLetter.Location = new System.Drawing.Point(173, 83);
            this.BatchReportforSuccessfulLetter.Name = "BatchReportforSuccessfulLetter";
            this.BatchReportforSuccessfulLetter.Size = new System.Drawing.Size(226, 20);
            this.BatchReportforSuccessfulLetter.TabIndex = 3;
            this.BatchReportforSuccessfulLetter.TabStop = true;
            this.BatchReportforSuccessfulLetter.Text = "Batch Report for Successful Letter";
            this.BatchReportforSuccessfulLetter.UseVisualStyleBackColor = true;
            this.BatchReportforSuccessfulLetter.CheckedChanged += new System.EventHandler(this.PortraitRadioButton_CheckedChanged);
            // 
            // LandscapeRadioButton
            // 
            this.LandscapeRadioButton.AutoSize = true;
            this.LandscapeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandscapeRadioButton.Location = new System.Drawing.Point(173, 116);
            this.LandscapeRadioButton.Name = "LandscapeRadioButton";
            this.LandscapeRadioButton.Size = new System.Drawing.Size(241, 20);
            this.LandscapeRadioButton.TabIndex = 4;
            this.LandscapeRadioButton.TabStop = true;
            this.LandscapeRadioButton.Text = "Batch Report for Unsuccessful Letter";
            this.LandscapeRadioButton.UseVisualStyleBackColor = true;
            // 
            // missingradioButton
            // 
            this.missingradioButton.AutoSize = true;
            this.missingradioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingradioButton.Location = new System.Drawing.Point(173, 151);
            this.missingradioButton.Name = "missingradioButton";
            this.missingradioButton.Size = new System.Drawing.Size(207, 20);
            this.missingradioButton.TabIndex = 5;
            this.missingradioButton.TabStop = true;
            this.missingradioButton.Text = "Batch Report for Missing Letter";
            this.missingradioButton.UseVisualStyleBackColor = true;
            this.missingradioButton.CheckedChanged += new System.EventHandler(this.missingradioButton_CheckedChanged);
            this.missingradioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.missingradioButton_MouseClick);
            // 
            // ReportByBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(544, 284);
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
    }
}