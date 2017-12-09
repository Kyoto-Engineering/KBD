namespace PhonebookApp.Reports
{
    partial class NewLOIforAutomatedTrafficLightUI
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
            this.resedentialRadioButton = new System.Windows.Forms.RadioButton();
            this.workingRadioButton = new System.Windows.Forms.RadioButton();
            this.getButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // resedentialRadioButton
            // 
            this.resedentialRadioButton.AutoSize = true;
            this.resedentialRadioButton.Location = new System.Drawing.Point(176, 136);
            this.resedentialRadioButton.Name = "resedentialRadioButton";
            this.resedentialRadioButton.Size = new System.Drawing.Size(118, 17);
            this.resedentialRadioButton.TabIndex = 21;
            this.resedentialRadioButton.TabStop = true;
            this.resedentialRadioButton.Text = "Residential Address";
            this.resedentialRadioButton.UseVisualStyleBackColor = true;
            // 
            // workingRadioButton
            // 
            this.workingRadioButton.AutoSize = true;
            this.workingRadioButton.Location = new System.Drawing.Point(176, 110);
            this.workingRadioButton.Name = "workingRadioButton";
            this.workingRadioButton.Size = new System.Drawing.Size(106, 17);
            this.workingRadioButton.TabIndex = 20;
            this.workingRadioButton.TabStop = true;
            this.workingRadioButton.Text = "Working Address";
            this.workingRadioButton.UseVisualStyleBackColor = true;
            // 
            // getButton
            // 
            this.getButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getButton.Location = new System.Drawing.Point(177, 207);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 19;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = false;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Group Name";
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(117, 69);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(292, 21);
            this.groupComboBox.TabIndex = 17;
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged_1);
            // 
            // NewLOIforAutomatedTrafficLightUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(452, 298);
            this.Controls.Add(this.resedentialRadioButton);
            this.Controls.Add(this.workingRadioButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupComboBox);
            this.Name = "NewLOIforAutomatedTrafficLightUI";
            this.Text = "NewLOIforAutomatedTrafficLightUI";
            this.Load += new System.EventHandler(this.NewLOIforAutomatedTrafficLightUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton resedentialRadioButton;
        private System.Windows.Forms.RadioButton workingRadioButton;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox groupComboBox;
    }
}