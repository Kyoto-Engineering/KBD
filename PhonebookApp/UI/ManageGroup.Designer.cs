namespace PhonebookApp.UI
{
    partial class ManageGroup
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
            this.ManageGroupsbutton = new System.Windows.Forms.Button();
            this.MemberAddedToGroupbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManageGroupsbutton
            // 
            this.ManageGroupsbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ManageGroupsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageGroupsbutton.ForeColor = System.Drawing.Color.Black;
            this.ManageGroupsbutton.Location = new System.Drawing.Point(274, 82);
            this.ManageGroupsbutton.Name = "ManageGroupsbutton";
            this.ManageGroupsbutton.Size = new System.Drawing.Size(152, 73);
            this.ManageGroupsbutton.TabIndex = 49;
            this.ManageGroupsbutton.Text = "Manage Groups";
            this.ManageGroupsbutton.UseVisualStyleBackColor = false;
            this.ManageGroupsbutton.Click += new System.EventHandler(this.ManageGroupsbutton_Click);
            // 
            // MemberAddedToGroupbutton
            // 
            this.MemberAddedToGroupbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MemberAddedToGroupbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberAddedToGroupbutton.ForeColor = System.Drawing.Color.Black;
            this.MemberAddedToGroupbutton.Location = new System.Drawing.Point(63, 82);
            this.MemberAddedToGroupbutton.Name = "MemberAddedToGroupbutton";
            this.MemberAddedToGroupbutton.Size = new System.Drawing.Size(154, 73);
            this.MemberAddedToGroupbutton.TabIndex = 48;
            this.MemberAddedToGroupbutton.Text = "Member Grouping";
            this.MemberAddedToGroupbutton.UseVisualStyleBackColor = false;
            this.MemberAddedToGroupbutton.Click += new System.EventHandler(this.MemberAddedToGroupbutton_Click);
            // 
            // ManageGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(519, 253);
            this.Controls.Add(this.ManageGroupsbutton);
            this.Controls.Add(this.MemberAddedToGroupbutton);
            this.Name = "ManageGroup";
            this.Text = "ManageGroup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ManageGroupsbutton;
        private System.Windows.Forms.Button MemberAddedToGroupbutton;
    }
}