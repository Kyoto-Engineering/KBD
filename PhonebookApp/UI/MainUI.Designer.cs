namespace PhonebookApp.UI
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DispatchButton = new System.Windows.Forms.Button();
            this.Managebutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ViewAndReportbutton = new System.Windows.Forms.Button();
            this.NewEntrybutton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(404, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Directory Enterprise";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DispatchButton);
            this.groupBox1.Controls.Add(this.Managebutton);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ViewAndReportbutton);
            this.groupBox1.Controls.Add(this.NewEntrybutton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DispatchButton
            // 
            this.DispatchButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DispatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DispatchButton.ForeColor = System.Drawing.Color.Black;
            this.DispatchButton.Location = new System.Drawing.Point(22, 213);
            this.DispatchButton.Name = "DispatchButton";
            this.DispatchButton.Size = new System.Drawing.Size(134, 66);
            this.DispatchButton.TabIndex = 4;
            this.DispatchButton.Text = "Dispatch\r\n";
            this.DispatchButton.UseVisualStyleBackColor = false;
            this.DispatchButton.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Managebutton
            // 
            this.Managebutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Managebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Managebutton.ForeColor = System.Drawing.Color.Black;
            this.Managebutton.Location = new System.Drawing.Point(192, 38);
            this.Managebutton.Name = "Managebutton";
            this.Managebutton.Size = new System.Drawing.Size(134, 66);
            this.Managebutton.TabIndex = 1;
            this.Managebutton.Text = "Groups";
            this.Managebutton.UseVisualStyleBackColor = false;
            this.Managebutton.Click += new System.EventHandler(this.Managebutton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(22, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 69);
            this.button2.TabIndex = 2;
            this.button2.Text = "Manage";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ViewAndReportbutton
            // 
            this.ViewAndReportbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ViewAndReportbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewAndReportbutton.ForeColor = System.Drawing.Color.Black;
            this.ViewAndReportbutton.Location = new System.Drawing.Point(192, 123);
            this.ViewAndReportbutton.Name = "ViewAndReportbutton";
            this.ViewAndReportbutton.Size = new System.Drawing.Size(134, 68);
            this.ViewAndReportbutton.TabIndex = 3;
            this.ViewAndReportbutton.Text = "View And Print";
            this.ViewAndReportbutton.UseVisualStyleBackColor = false;
            this.ViewAndReportbutton.Click += new System.EventHandler(this.ViewAndReportbutton_Click);
            // 
            // NewEntrybutton
            // 
            this.NewEntrybutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NewEntrybutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewEntrybutton.ForeColor = System.Drawing.Color.Black;
            this.NewEntrybutton.Location = new System.Drawing.Point(21, 38);
            this.NewEntrybutton.Name = "NewEntrybutton";
            this.NewEntrybutton.Size = new System.Drawing.Size(134, 66);
            this.NewEntrybutton.TabIndex = 0;
            this.NewEntrybutton.Text = "New Entry";
            this.NewEntrybutton.UseVisualStyleBackColor = false;
            this.NewEntrybutton.Click += new System.EventHandler(this.NewEntrybutton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.Gainsboro;
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.Black;
            this.logOutButton.Location = new System.Drawing.Point(917, 2);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(103, 38);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::PhonebookApp.Properties.Resources.BusinessDirectory;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1038, 641);
            this.ControlBox = false;
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUI";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button NewEntrybutton;
        private System.Windows.Forms.Button ViewAndReportbutton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Managebutton;
        private System.Windows.Forms.Button DispatchButton;
    }
}