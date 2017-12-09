﻿namespace PhonebookApp.UI
{
    partial class DispatchUI
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
            this.InsertPOD = new System.Windows.Forms.Button();
            this.BatchCreation = new System.Windows.Forms.Button();
            this.CourierManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InsertPOD
            // 
            this.InsertPOD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.InsertPOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertPOD.ForeColor = System.Drawing.Color.Black;
            this.InsertPOD.Location = new System.Drawing.Point(219, 79);
            this.InsertPOD.Name = "InsertPOD";
            this.InsertPOD.Size = new System.Drawing.Size(148, 59);
            this.InsertPOD.TabIndex = 53;
            this.InsertPOD.Text = "Insert POD";
            this.InsertPOD.UseVisualStyleBackColor = false;
            this.InsertPOD.Click += new System.EventHandler(this.InsertPOD_Click);
            // 
            // BatchCreation
            // 
            this.BatchCreation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BatchCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchCreation.ForeColor = System.Drawing.Color.Black;
            this.BatchCreation.Location = new System.Drawing.Point(34, 79);
            this.BatchCreation.Name = "BatchCreation";
            this.BatchCreation.Size = new System.Drawing.Size(160, 59);
            this.BatchCreation.TabIndex = 52;
            this.BatchCreation.Text = "Batch Creation\r\n";
            this.BatchCreation.UseVisualStyleBackColor = false;
            this.BatchCreation.Click += new System.EventHandler(this.BatchCreation_Click);
            // 
            // CourierManagement
            // 
            this.CourierManagement.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CourierManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourierManagement.ForeColor = System.Drawing.Color.Black;
            this.CourierManagement.Location = new System.Drawing.Point(411, 79);
            this.CourierManagement.Name = "CourierManagement";
            this.CourierManagement.Size = new System.Drawing.Size(142, 59);
            this.CourierManagement.TabIndex = 54;
            this.CourierManagement.Text = "Courier Management";
            this.CourierManagement.UseVisualStyleBackColor = false;
            // 
            // DispatchUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(627, 235);
            this.Controls.Add(this.CourierManagement);
            this.Controls.Add(this.InsertPOD);
            this.Controls.Add(this.BatchCreation);
            this.Name = "DispatchUI";
            this.Text = "DispatchUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InsertPOD;
        private System.Windows.Forms.Button BatchCreation;
        private System.Windows.Forms.Button CourierManagement;
    }
}