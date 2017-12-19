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
            this.SuspendLayout();
            // 
            // batchlist
            // 
            this.batchlist.BackColor = System.Drawing.Color.WhiteSmoke;
            this.batchlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batchlist.Location = new System.Drawing.Point(56, 92);
            this.batchlist.Name = "batchlist";
            this.batchlist.Size = new System.Drawing.Size(135, 54);
            this.batchlist.TabIndex = 0;
            this.batchlist.Text = "Batch List";
            this.batchlist.UseVisualStyleBackColor = false;
            this.batchlist.Click += new System.EventHandler(this.batchlist_Click);
            // 
            // statusPrint
            // 
            this.statusPrint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPrint.Location = new System.Drawing.Point(274, 92);
            this.statusPrint.Name = "statusPrint";
            this.statusPrint.Size = new System.Drawing.Size(137, 54);
            this.statusPrint.TabIndex = 1;
            this.statusPrint.Text = "Status Print";
            this.statusPrint.UseVisualStyleBackColor = false;
            this.statusPrint.Click += new System.EventHandler(this.statusPrint_Click);
            // 
            // BatchPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(505, 261);
            this.Controls.Add(this.statusPrint);
            this.Controls.Add(this.batchlist);
            this.Name = "BatchPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BatchPrint";
            this.Load += new System.EventHandler(this.BatchPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button batchlist;
        private System.Windows.Forms.Button statusPrint;
    }
}