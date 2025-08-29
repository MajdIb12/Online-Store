namespace OnlineStore.Order_Procces.Track_Order
{
    partial class frmTrackOrder
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
            this.ctrlShippingStatus1 = new OnlineStore.Admin_Settings.Shippings.Controls.ctrlShippingStatus();
            this.ctrlAdminTracking1 = new OnlineStore.Order_Procces.Controls.ctrlAdminTracking();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShippingStatus1
            // 
            this.ctrlShippingStatus1.Location = new System.Drawing.Point(2, 2);
            this.ctrlShippingStatus1.Name = "ctrlShippingStatus1";
            this.ctrlShippingStatus1.Size = new System.Drawing.Size(726, 438);
            this.ctrlShippingStatus1.TabIndex = 0;
            // 
            // ctrlAdminTracking1
            // 
            this.ctrlAdminTracking1.Location = new System.Drawing.Point(2, 2);
            this.ctrlAdminTracking1.Name = "ctrlAdminTracking1";
            this.ctrlAdminTracking1.Size = new System.Drawing.Size(919, 658);
            this.ctrlAdminTracking1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(743, 693);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 70);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTrackOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 764);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlAdminTracking1);
            this.Controls.Add(this.ctrlShippingStatus1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTrackOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrackOrder";
            this.ResumeLayout(false);

        }

        #endregion

        private Admin_Settings.Shippings.Controls.ctrlShippingStatus ctrlShippingStatus1;
        private Controls.ctrlAdminTracking ctrlAdminTracking1;
        private System.Windows.Forms.Button btnClose;
    }
}