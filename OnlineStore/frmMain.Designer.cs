namespace OnlineStore
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.shoppingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moblieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shippingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shoppingToolStripMenuItem,
            this.trackOrderToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.accountSettingsToolStripMenuItem,
            this.adminsSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 47);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // shoppingToolStripMenuItem
            // 
            this.shoppingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pCToolStripMenuItem,
            this.moblieToolStripMenuItem});
            this.shoppingToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold);
            this.shoppingToolStripMenuItem.Name = "shoppingToolStripMenuItem";
            this.shoppingToolStripMenuItem.Size = new System.Drawing.Size(165, 43);
            this.shoppingToolStripMenuItem.Text = "Shopping";
            // 
            // pCToolStripMenuItem
            // 
            this.pCToolStripMenuItem.Name = "pCToolStripMenuItem";
            this.pCToolStripMenuItem.Size = new System.Drawing.Size(210, 44);
            this.pCToolStripMenuItem.Text = "PC";
            this.pCToolStripMenuItem.Click += new System.EventHandler(this.pCToolStripMenuItem_Click);
            // 
            // moblieToolStripMenuItem
            // 
            this.moblieToolStripMenuItem.Name = "moblieToolStripMenuItem";
            this.moblieToolStripMenuItem.Size = new System.Drawing.Size(210, 44);
            this.moblieToolStripMenuItem.Text = "Moblie";
            this.moblieToolStripMenuItem.Click += new System.EventHandler(this.moblieToolStripMenuItem_Click);
            // 
            // trackOrderToolStripMenuItem
            // 
            this.trackOrderToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.trackOrderToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackOrderToolStripMenuItem.Name = "trackOrderToolStripMenuItem";
            this.trackOrderToolStripMenuItem.Size = new System.Drawing.Size(217, 43);
            this.trackOrderToolStripMenuItem.Text = "Track Order";
            this.trackOrderToolStripMenuItem.Click += new System.EventHandler(this.trackOrderToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold);
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(154, 43);
            this.paymentToolStripMenuItem.Text = "Payment";
            this.paymentToolStripMenuItem.Click += new System.EventHandler(this.paymentToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold);
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(162, 43);
            this.accountSettingsToolStripMenuItem.Text = "Account";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(228, 44);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(228, 44);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // adminsSettingsToolStripMenuItem
            // 
            this.adminsSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productSettingsToolStripMenuItem,
            this.shippingsToolStripMenuItem});
            this.adminsSettingsToolStripMenuItem.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Bold);
            this.adminsSettingsToolStripMenuItem.Name = "adminsSettingsToolStripMenuItem";
            this.adminsSettingsToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.adminsSettingsToolStripMenuItem.Text = "Admins Settings";
            this.adminsSettingsToolStripMenuItem.Visible = false;
            // 
            // productSettingsToolStripMenuItem
            // 
            this.productSettingsToolStripMenuItem.Name = "productSettingsToolStripMenuItem";
            this.productSettingsToolStripMenuItem.Size = new System.Drawing.Size(360, 44);
            this.productSettingsToolStripMenuItem.Text = "Product Settings";
            this.productSettingsToolStripMenuItem.Click += new System.EventHandler(this.productSettingsToolStripMenuItem_Click);
            // 
            // shippingsToolStripMenuItem
            // 
            this.shippingsToolStripMenuItem.Name = "shippingsToolStripMenuItem";
            this.shippingsToolStripMenuItem.Size = new System.Drawing.Size(360, 44);
            this.shippingsToolStripMenuItem.Text = "Shippings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OnlineStore.Properties.Resources._7917652;
            this.pictureBox1.Location = new System.Drawing.Point(0, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1052, 592);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1052, 644);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trackOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shoppingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moblieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shippingsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}