namespace PhonebookApp.UI
{
    partial class BatchPrint
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
            this.batchlist = new System.Windows.Forms.Button();
            this.statusPrint = new System.Windows.Forms.Button();
            this.missingButtonutton = new System.Windows.Forms.Button();
            this.UnsuccessfulButton = new System.Windows.Forms.Button();
            this.successfulButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Deliverystatusbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // batchlist
            // 
            this.batchlist.BackColor = System.Drawing.Color.WhiteSmoke;
            this.batchlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batchlist.Location = new System.Drawing.Point(61, 92);
            this.batchlist.Name = "batchlist";
            this.batchlist.Size = new System.Drawing.Size(198, 54);
            this.batchlist.TabIndex = 0;
            this.batchlist.Text = "Batch List";
            this.batchlist.UseVisualStyleBackColor = false;
            this.batchlist.Click += new System.EventHandler(this.batchlist_Click);
            // 
            // statusPrint
            // 
            this.statusPrint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPrint.Location = new System.Drawing.Point(12, 12);
            this.statusPrint.Name = "statusPrint";
            this.statusPrint.Size = new System.Drawing.Size(18, 13);
            this.statusPrint.TabIndex = 1;
            this.statusPrint.Text = "Status Print";
            this.statusPrint.UseVisualStyleBackColor = false;
            this.statusPrint.Visible = false;
            this.statusPrint.Click += new System.EventHandler(this.statusPrint_Click);
            // 
            // missingButtonutton
            // 
            this.missingButtonutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.missingButtonutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingButtonutton.Location = new System.Drawing.Point(363, 182);
            this.missingButtonutton.Name = "missingButtonutton";
            this.missingButtonutton.Size = new System.Drawing.Size(130, 58);
            this.missingButtonutton.TabIndex = 11;
            this.missingButtonutton.Text = "Missing Letters";
            this.missingButtonutton.UseVisualStyleBackColor = false;
            this.missingButtonutton.Click += new System.EventHandler(this.missingButtonutton_Click);
            // 
            // UnsuccessfulButton
            // 
            this.UnsuccessfulButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UnsuccessfulButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnsuccessfulButton.Location = new System.Drawing.Point(205, 182);
            this.UnsuccessfulButton.Name = "UnsuccessfulButton";
            this.UnsuccessfulButton.Size = new System.Drawing.Size(141, 60);
            this.UnsuccessfulButton.TabIndex = 10;
            this.UnsuccessfulButton.Text = "Unsuccessful Letters";
            this.UnsuccessfulButton.UseVisualStyleBackColor = false;
            this.UnsuccessfulButton.Click += new System.EventHandler(this.UnsuccessfulButton_Click);
            // 
            // successfulButton
            // 
            this.successfulButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.successfulButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successfulButton.Location = new System.Drawing.Point(61, 182);
            this.successfulButton.Name = "successfulButton";
            this.successfulButton.Size = new System.Drawing.Size(120, 58);
            this.successfulButton.TabIndex = 9;
            this.successfulButton.Text = "Successful Letters";
            this.successfulButton.UseVisualStyleBackColor = false;
            this.successfulButton.Click += new System.EventHandler(this.successfulButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(231, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "PRINT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Deliverystatusbutton
            // 
            this.Deliverystatusbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Deliverystatusbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deliverystatusbutton.Location = new System.Drawing.Point(296, 92);
            this.Deliverystatusbutton.Name = "Deliverystatusbutton";
            this.Deliverystatusbutton.Size = new System.Drawing.Size(197, 54);
            this.Deliverystatusbutton.TabIndex = 13;
            this.Deliverystatusbutton.Text = "Delivery Status\r\n";
            this.Deliverystatusbutton.UseVisualStyleBackColor = false;
            this.Deliverystatusbutton.Click += new System.EventHandler(this.Deliverystatusbutton_Click);
            // 
            // BatchPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(569, 314);
            this.Controls.Add(this.Deliverystatusbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.missingButtonutton);
            this.Controls.Add(this.UnsuccessfulButton);
            this.Controls.Add(this.successfulButton);
            this.Controls.Add(this.statusPrint);
            this.Controls.Add(this.batchlist);
            this.Name = "BatchPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BatchPrint";
            this.Load += new System.EventHandler(this.BatchPrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button batchlist;
        private System.Windows.Forms.Button statusPrint;
        private System.Windows.Forms.Button missingButtonutton;
        private System.Windows.Forms.Button UnsuccessfulButton;
        private System.Windows.Forms.Button successfulButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Deliverystatusbutton;
    }
}