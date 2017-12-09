namespace PhonebookApp.Reports
{
    partial class ReportByMultiple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportByMultiple));
            this.religionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getButton = new System.Windows.Forms.Button();
            this.workingRadioButton = new System.Windows.Forms.RadioButton();
            this.resedentialRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // religionComboBox
            // 
            this.religionComboBox.FormattingEnabled = true;
            this.religionComboBox.Location = new System.Drawing.Point(156, 30);
            this.religionComboBox.Name = "religionComboBox";
            this.religionComboBox.Size = new System.Drawing.Size(121, 21);
            this.religionComboBox.TabIndex = 1;
            this.religionComboBox.SelectedIndexChanged += new System.EventHandler(this.workingRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Religion     :";
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getButton.Location = new System.Drawing.Point(171, 193);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 4;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = false;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // workingRadioButton
            // 
            this.workingRadioButton.AutoSize = true;
            this.workingRadioButton.Location = new System.Drawing.Point(156, 77);
            this.workingRadioButton.Name = "workingRadioButton";
            this.workingRadioButton.Size = new System.Drawing.Size(106, 17);
            this.workingRadioButton.TabIndex = 5;
            this.workingRadioButton.TabStop = true;
            this.workingRadioButton.Text = "Working Address";
            this.workingRadioButton.UseVisualStyleBackColor = true;
            this.workingRadioButton.CheckedChanged += new System.EventHandler(this.workingRadioButton_CheckedChanged);
            // 
            // resedentialRadioButton
            // 
            this.resedentialRadioButton.AutoSize = true;
            this.resedentialRadioButton.Location = new System.Drawing.Point(156, 110);
            this.resedentialRadioButton.Name = "resedentialRadioButton";
            this.resedentialRadioButton.Size = new System.Drawing.Size(118, 17);
            this.resedentialRadioButton.TabIndex = 6;
            this.resedentialRadioButton.TabStop = true;
            this.resedentialRadioButton.Text = "Residential Address";
            this.resedentialRadioButton.UseVisualStyleBackColor = true;
            // 
            // ReportByMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(456, 289);
            this.Controls.Add(this.resedentialRadioButton);
            this.Controls.Add(this.workingRadioButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.religionComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportByMultiple";
            this.Text = "ReportByMultiple";
            this.Load += new System.EventHandler(this.ReportByMultiple_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox religionComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.RadioButton workingRadioButton;
        private System.Windows.Forms.RadioButton resedentialRadioButton;
    }
}