namespace PhonebookApp.Reports
{
    partial class LOIforKBD
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
            this.workingradioButton = new System.Windows.Forms.RadioButton();
            this.ResidentioalradioButton = new System.Windows.Forms.RadioButton();
            this.Group = new System.Windows.Forms.Label();
            this.groupcomboBox = new System.Windows.Forms.ComboBox();
            this.getbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workingradioButton
            // 
            this.workingradioButton.AutoSize = true;
            this.workingradioButton.Location = new System.Drawing.Point(194, 119);
            this.workingradioButton.Name = "workingradioButton";
            this.workingradioButton.Size = new System.Drawing.Size(106, 17);
            this.workingradioButton.TabIndex = 0;
            this.workingradioButton.TabStop = true;
            this.workingradioButton.Text = "Working Address";
            this.workingradioButton.UseVisualStyleBackColor = true;
            // 
            // ResidentioalradioButton
            // 
            this.ResidentioalradioButton.AutoSize = true;
            this.ResidentioalradioButton.Location = new System.Drawing.Point(194, 142);
            this.ResidentioalradioButton.Name = "ResidentioalradioButton";
            this.ResidentioalradioButton.Size = new System.Drawing.Size(118, 17);
            this.ResidentioalradioButton.TabIndex = 1;
            this.ResidentioalradioButton.TabStop = true;
            this.ResidentioalradioButton.Text = "Residential Address";
            this.ResidentioalradioButton.UseVisualStyleBackColor = true;
            // 
            // Group
            // 
            this.Group.AutoSize = true;
            this.Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Group.Location = new System.Drawing.Point(1, 50);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(110, 20);
            this.Group.TabIndex = 2;
            this.Group.Text = "Group Name";
            // 
            // groupcomboBox
            // 
            this.groupcomboBox.FormattingEnabled = true;
            this.groupcomboBox.Location = new System.Drawing.Point(146, 52);
            this.groupcomboBox.Name = "groupcomboBox";
            this.groupcomboBox.Size = new System.Drawing.Size(271, 21);
            this.groupcomboBox.TabIndex = 3;
            this.groupcomboBox.SelectedIndexChanged += new System.EventHandler(this.groupcomboBox_SelectedIndexChanged);
            // 
            // getbutton
            // 
            this.getbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getbutton.Location = new System.Drawing.Point(213, 199);
            this.getbutton.Name = "getbutton";
            this.getbutton.Size = new System.Drawing.Size(87, 32);
            this.getbutton.TabIndex = 4;
            this.getbutton.Text = "GET";
            this.getbutton.UseVisualStyleBackColor = false;
            this.getbutton.Click += new System.EventHandler(this.getbutton_Click);
            // 
            // LOIforKBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(504, 295);
            this.Controls.Add(this.getbutton);
            this.Controls.Add(this.groupcomboBox);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.ResidentioalradioButton);
            this.Controls.Add(this.workingradioButton);
            this.Name = "LOIforKBD";
            this.Text = "LOIforKBD";
            this.Load += new System.EventHandler(this.LOIforKBD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton workingradioButton;
        private System.Windows.Forms.RadioButton ResidentioalradioButton;
        private System.Windows.Forms.Label Group;
        private System.Windows.Forms.ComboBox groupcomboBox;
        private System.Windows.Forms.Button getbutton;
    }
}