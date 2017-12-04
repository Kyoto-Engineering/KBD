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
            this.NewGroupCreationbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManageGroupsbutton
            // 
            this.ManageGroupsbutton.BackColor = System.Drawing.SystemColors.Control;
            this.ManageGroupsbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageGroupsbutton.ForeColor = System.Drawing.Color.Black;
            this.ManageGroupsbutton.Location = new System.Drawing.Point(329, 206);
            this.ManageGroupsbutton.Name = "ManageGroupsbutton";
            this.ManageGroupsbutton.Size = new System.Drawing.Size(247, 73);
            this.ManageGroupsbutton.TabIndex = 49;
            this.ManageGroupsbutton.Text = "Remove Member from Group";
            this.ManageGroupsbutton.UseVisualStyleBackColor = false;
            this.ManageGroupsbutton.Click += new System.EventHandler(this.ManageGroupsbutton_Click);
            // 
            // MemberAddedToGroupbutton
            // 
            this.MemberAddedToGroupbutton.BackColor = System.Drawing.SystemColors.Control;
            this.MemberAddedToGroupbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberAddedToGroupbutton.ForeColor = System.Drawing.Color.Black;
            this.MemberAddedToGroupbutton.Location = new System.Drawing.Point(41, 206);
            this.MemberAddedToGroupbutton.Name = "MemberAddedToGroupbutton";
            this.MemberAddedToGroupbutton.Size = new System.Drawing.Size(247, 73);
            this.MemberAddedToGroupbutton.TabIndex = 48;
            this.MemberAddedToGroupbutton.Text = "Add Member to Group";
            this.MemberAddedToGroupbutton.UseVisualStyleBackColor = false;
            this.MemberAddedToGroupbutton.Click += new System.EventHandler(this.MemberAddedToGroupbutton_Click);
            // 
            // NewGroupCreationbutton
            // 
            this.NewGroupCreationbutton.BackColor = System.Drawing.SystemColors.Control;
            this.NewGroupCreationbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGroupCreationbutton.ForeColor = System.Drawing.Color.Black;
            this.NewGroupCreationbutton.Location = new System.Drawing.Point(164, 84);
            this.NewGroupCreationbutton.Name = "NewGroupCreationbutton";
            this.NewGroupCreationbutton.Size = new System.Drawing.Size(300, 68);
            this.NewGroupCreationbutton.TabIndex = 50;
            this.NewGroupCreationbutton.Text = "New Group Creation";
            this.NewGroupCreationbutton.UseVisualStyleBackColor = false;
            this.NewGroupCreationbutton.Click += new System.EventHandler(this.NewGroupCreationbutton_Click);
            // 
            // ManageGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(627, 367);
            this.Controls.Add(this.NewGroupCreationbutton);
            this.Controls.Add(this.ManageGroupsbutton);
            this.Controls.Add(this.MemberAddedToGroupbutton);
            this.Name = "ManageGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageGroup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ManageGroupsbutton;
        private System.Windows.Forms.Button MemberAddedToGroupbutton;
        private System.Windows.Forms.Button NewGroupCreationbutton;
    }
}