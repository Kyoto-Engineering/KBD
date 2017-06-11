﻿namespace PhonebookApp.Reports
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
            this.getButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.batchIdCombobox = new System.Windows.Forms.ComboBox();
            this.PortraitRadioButton = new System.Windows.Forms.RadioButton();
            this.LandscapeRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(282, 142);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(74, 23);
            this.getButton.TabIndex = 0;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Batch Id";
            // 
            // batchIdCombobox
            // 
            this.batchIdCombobox.FormattingEnabled = true;
            this.batchIdCombobox.Location = new System.Drawing.Point(267, 23);
            this.batchIdCombobox.Name = "batchIdCombobox";
            this.batchIdCombobox.Size = new System.Drawing.Size(121, 21);
            this.batchIdCombobox.TabIndex = 2;
            // 
            // PortraitRadioButton
            // 
            this.PortraitRadioButton.AutoSize = true;
            this.PortraitRadioButton.Location = new System.Drawing.Point(267, 60);
            this.PortraitRadioButton.Name = "PortraitRadioButton";
            this.PortraitRadioButton.Size = new System.Drawing.Size(139, 17);
            this.PortraitRadioButton.TabIndex = 3;
            this.PortraitRadioButton.TabStop = true;
            this.PortraitRadioButton.Text = "Batch Report for Portrait";
            this.PortraitRadioButton.UseVisualStyleBackColor = true;
            // 
            // LandscapeRadioButton
            // 
            this.LandscapeRadioButton.AutoSize = true;
            this.LandscapeRadioButton.Location = new System.Drawing.Point(267, 93);
            this.LandscapeRadioButton.Name = "LandscapeRadioButton";
            this.LandscapeRadioButton.Size = new System.Drawing.Size(159, 17);
            this.LandscapeRadioButton.TabIndex = 4;
            this.LandscapeRadioButton.TabStop = true;
            this.LandscapeRadioButton.Text = "Batch Report for Landscape";
            this.LandscapeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ReportByBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 261);
            this.Controls.Add(this.LandscapeRadioButton);
            this.Controls.Add(this.PortraitRadioButton);
            this.Controls.Add(this.batchIdCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getButton);
            this.Name = "ReportByBatch";
            this.Text = "ReportByBatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox batchIdCombobox;
        private System.Windows.Forms.RadioButton PortraitRadioButton;
        private System.Windows.Forms.RadioButton LandscapeRadioButton;
    }
}