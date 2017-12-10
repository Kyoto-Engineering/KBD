namespace PhonebookApp.Reports
{
    partial class LOIforKBDUI
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
            this.getbutton = new System.Windows.Forms.Button();
            this.groupcomboBox = new System.Windows.Forms.ComboBox();
            this.Group = new System.Windows.Forms.Label();
            this.ResidentioalradioButton = new System.Windows.Forms.RadioButton();
            this.workingradioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // getbutton
            // 
            this.getbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.getbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getbutton.Location = new System.Drawing.Point(246, 189);
            this.getbutton.Name = "getbutton";
            this.getbutton.Size = new System.Drawing.Size(87, 32);
            this.getbutton.TabIndex = 9;
            this.getbutton.Text = "GET";
            this.getbutton.UseVisualStyleBackColor = false;
            this.getbutton.Click += new System.EventHandler(this.getbutton_Click_1);
            // 
            // groupcomboBox
            // 
            this.groupcomboBox.FormattingEnabled = true;
            this.groupcomboBox.Location = new System.Drawing.Point(179, 42);
            this.groupcomboBox.Name = "groupcomboBox";
            this.groupcomboBox.Size = new System.Drawing.Size(296, 21);
            this.groupcomboBox.TabIndex = 8;
            this.groupcomboBox.SelectedIndexChanged += new System.EventHandler(this.groupcomboBox_SelectedIndexChanged_1);
            // 
            // Group
            // 
            this.Group.AutoSize = true;
            this.Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Group.Location = new System.Drawing.Point(34, 40);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(110, 20);
            this.Group.TabIndex = 7;
            this.Group.Text = "Group Name";
            // 
            // ResidentioalradioButton
            // 
            this.ResidentioalradioButton.AutoSize = true;
            this.ResidentioalradioButton.Location = new System.Drawing.Point(227, 132);
            this.ResidentioalradioButton.Name = "ResidentioalradioButton";
            this.ResidentioalradioButton.Size = new System.Drawing.Size(118, 17);
            this.ResidentioalradioButton.TabIndex = 6;
            this.ResidentioalradioButton.TabStop = true;
            this.ResidentioalradioButton.Text = "Residential Address";
            this.ResidentioalradioButton.UseVisualStyleBackColor = true;
            // 
            // workingradioButton
            // 
            this.workingradioButton.AutoSize = true;
            this.workingradioButton.Location = new System.Drawing.Point(227, 109);
            this.workingradioButton.Name = "workingradioButton";
            this.workingradioButton.Size = new System.Drawing.Size(106, 17);
            this.workingradioButton.TabIndex = 5;
            this.workingradioButton.TabStop = true;
            this.workingradioButton.Text = "Working Address";
            this.workingradioButton.UseVisualStyleBackColor = true;
            // 
            // LOIforKBDUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(566, 261);
            this.Controls.Add(this.getbutton);
            this.Controls.Add(this.groupcomboBox);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.ResidentioalradioButton);
            this.Controls.Add(this.workingradioButton);
            this.Name = "LOIforKBDUI";
            this.Text = "LOIforKBDUI";
            this.Load += new System.EventHandler(this.LOIforKBDUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getbutton;
        private System.Windows.Forms.ComboBox groupcomboBox;
        private System.Windows.Forms.Label Group;
        private System.Windows.Forms.RadioButton ResidentioalradioButton;
        private System.Windows.Forms.RadioButton workingradioButton;
    }
}