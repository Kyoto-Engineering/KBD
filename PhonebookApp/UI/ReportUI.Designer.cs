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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.allAddressButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // letterOfIntroductionButton
            // 
            this.letterOfIntroductionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterOfIntroductionButton.Location = new System.Drawing.Point(27, 19);
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
            this.gretingsCardButton.Location = new System.Drawing.Point(193, 19);
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
            this.addressButton.Location = new System.Drawing.Point(364, 19);
            this.addressButton.Name = "addressButton";
            this.addressButton.Size = new System.Drawing.Size(149, 62);
            this.addressButton.TabIndex = 2;
            this.addressButton.Text = "Address Individual ";
            this.addressButton.UseVisualStyleBackColor = true;
            this.addressButton.Click += new System.EventHandler(this.addressButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TestButton);
            this.groupBox1.Controls.Add(this.allAddressButton);
            this.groupBox1.Controls.Add(this.letterOfIntroductionButton);
            this.groupBox1.Controls.Add(this.addressButton);
            this.groupBox1.Controls.Add(this.gretingsCardButton);
            this.groupBox1.Location = new System.Drawing.Point(42, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 185);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // TestButton
            // 
            this.TestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestButton.Location = new System.Drawing.Point(193, 96);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(151, 62);
            this.TestButton.TabIndex = 5;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // allAddressButton
            // 
            this.allAddressButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAddressButton.Location = new System.Drawing.Point(27, 96);
            this.allAddressButton.Name = "allAddressButton";
            this.allAddressButton.Size = new System.Drawing.Size(151, 62);
            this.allAddressButton.TabIndex = 3;
            this.allAddressButton.Text = "All Address";
            this.allAddressButton.UseVisualStyleBackColor = true;
            this.allAddressButton.Click += new System.EventHandler(this.allAddressButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(34, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 254);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 391);
            this.Controls.Add(this.groupBox2);
            this.Name = "ReportUI";
            this.Text = "ReportUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button letterOfIntroductionButton;
        private System.Windows.Forms.Button gretingsCardButton;
        private System.Windows.Forms.Button addressButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button allAddressButton;
        private System.Windows.Forms.Button TestButton;
    }
}