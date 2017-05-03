namespace PhonebookApp.UI
{
    partial class ReportUI
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
            this.letterOfIntroductionButton = new System.Windows.Forms.Button();
            this.gretingsCardButton = new System.Windows.Forms.Button();
            this.addressButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // letterOfIntroductionButton
            // 
            this.letterOfIntroductionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterOfIntroductionButton.Location = new System.Drawing.Point(100, 73);
            this.letterOfIntroductionButton.Name = "letterOfIntroductionButton";
            this.letterOfIntroductionButton.Size = new System.Drawing.Size(151, 62);
            this.letterOfIntroductionButton.TabIndex = 0;
            this.letterOfIntroductionButton.Text = "Letter Of Introduction";
            this.letterOfIntroductionButton.UseVisualStyleBackColor = true;
            this.letterOfIntroductionButton.Click += new System.EventHandler(this.letterOfIntroductionButton_Click);
            // 
            // gretingsCardButton
            // 
            this.gretingsCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gretingsCardButton.Location = new System.Drawing.Point(275, 73);
            this.gretingsCardButton.Name = "gretingsCardButton";
            this.gretingsCardButton.Size = new System.Drawing.Size(149, 62);
            this.gretingsCardButton.TabIndex = 1;
            this.gretingsCardButton.Text = "Gretings Card";
            this.gretingsCardButton.UseVisualStyleBackColor = true;
            this.gretingsCardButton.Click += new System.EventHandler(this.gretingsCardButton_Click);
            // 
            // addressButton
            // 
            this.addressButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressButton.Location = new System.Drawing.Point(443, 73);
            this.addressButton.Name = "addressButton";
            this.addressButton.Size = new System.Drawing.Size(149, 62);
            this.addressButton.TabIndex = 2;
            this.addressButton.Text = "Address ";
            this.addressButton.UseVisualStyleBackColor = true;
            this.addressButton.Click += new System.EventHandler(this.addressButton_Click);
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 391);
            this.Controls.Add(this.addressButton);
            this.Controls.Add(this.gretingsCardButton);
            this.Controls.Add(this.letterOfIntroductionButton);
            this.Name = "ReportUI";
            this.Text = "ReportUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button letterOfIntroductionButton;
        private System.Windows.Forms.Button gretingsCardButton;
        private System.Windows.Forms.Button addressButton;
    }
}