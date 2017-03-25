﻿namespace PhonebookApp.UI
{
    partial class GroupCreation
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
            this.groupNamelabel = new System.Windows.Forms.Label();
            this.groupNametextBox = new System.Windows.Forms.TextBox();
            this.savebutton = new System.Windows.Forms.Button();
            this.definitionlabel = new System.Windows.Forms.Label();
            this.purposelabel = new System.Windows.Forms.Label();
            this.definitionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.purposetextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // groupNamelabel
            // 
            this.groupNamelabel.AutoSize = true;
            this.groupNamelabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNamelabel.Location = new System.Drawing.Point(163, 77);
            this.groupNamelabel.Name = "groupNamelabel";
            this.groupNamelabel.Size = new System.Drawing.Size(116, 22);
            this.groupNamelabel.TabIndex = 7;
            this.groupNamelabel.Text = "Group Name";
            // 
            // groupNametextBox
            // 
            this.groupNametextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNametextBox.Location = new System.Drawing.Point(302, 77);
            this.groupNametextBox.Name = "groupNametextBox";
            this.groupNametextBox.Size = new System.Drawing.Size(311, 29);
            this.groupNametextBox.TabIndex = 6;
            // 
            // savebutton
            // 
            this.savebutton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebutton.Location = new System.Drawing.Point(413, 363);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(101, 59);
            this.savebutton.TabIndex = 8;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // definitionlabel
            // 
            this.definitionlabel.AutoSize = true;
            this.definitionlabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.definitionlabel.Location = new System.Drawing.Point(189, 139);
            this.definitionlabel.Name = "definitionlabel";
            this.definitionlabel.Size = new System.Drawing.Size(90, 22);
            this.definitionlabel.TabIndex = 10;
            this.definitionlabel.Text = "Definition";
            // 
            // purposelabel
            // 
            this.purposelabel.AutoSize = true;
            this.purposelabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purposelabel.Location = new System.Drawing.Point(202, 297);
            this.purposelabel.Name = "purposelabel";
            this.purposelabel.Size = new System.Drawing.Size(77, 22);
            this.purposelabel.TabIndex = 12;
            this.purposelabel.Text = "Purpose";
            // 
            // definitionrichTextBox
            // 
            this.definitionrichTextBox.Location = new System.Drawing.Point(302, 139);
            this.definitionrichTextBox.Name = "definitionrichTextBox";
            this.definitionrichTextBox.Size = new System.Drawing.Size(311, 121);
            this.definitionrichTextBox.TabIndex = 13;
            this.definitionrichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Group Creation";
            // 
            // purposetextBox
            // 
            this.purposetextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purposetextBox.Location = new System.Drawing.Point(302, 297);
            this.purposetextBox.Name = "purposetextBox";
            this.purposetextBox.Size = new System.Drawing.Size(311, 29);
            this.purposetextBox.TabIndex = 16;
            // 
            // GroupCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 491);
            this.Controls.Add(this.purposetextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.definitionrichTextBox);
            this.Controls.Add(this.purposelabel);
            this.Controls.Add(this.definitionlabel);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.groupNamelabel);
            this.Controls.Add(this.groupNametextBox);
            this.Name = "GroupCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupCreation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GroupCreation_FormClosed);
            this.Load += new System.EventHandler(this.GroupCreation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label groupNamelabel;
        private System.Windows.Forms.TextBox groupNametextBox;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.Label definitionlabel;
        private System.Windows.Forms.Label purposelabel;
        private System.Windows.Forms.RichTextBox definitionrichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox purposetextBox;
    }
}