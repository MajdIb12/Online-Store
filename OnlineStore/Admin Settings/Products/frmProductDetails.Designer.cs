namespace OnlineStore.Admin_Settings.Products
{
    partial class frmProductDetails
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
            this.ctrlProductDetails1 = new OnlineStore.Order_Procces.Controls.ctrlProductDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlProductDetails1
            // 
            this.ctrlProductDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ctrlProductDetails1.Location = new System.Drawing.Point(3, 3);
            this.ctrlProductDetails1.Name = "ctrlProductDetails1";
            this.ctrlProductDetails1.Size = new System.Drawing.Size(329, 583);
            this.ctrlProductDetails1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(154, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 70);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 662);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlProductDetails1);
            this.Name = "frmProductDetails";
            this.Text = "frmProductDetails";
            this.Load += new System.EventHandler(this.frmProductDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Order_Procces.Controls.ctrlProductDetails ctrlProductDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}