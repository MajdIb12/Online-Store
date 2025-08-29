namespace OnlineStore.Order_Procces
{
    partial class frmProductMain
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
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.ctrlProductDetails1 = new OnlineStore.Order_Procces.Controls.ctrlProductDetails();
            this.ctrlProductDetails2 = new OnlineStore.Order_Procces.Controls.ctrlProductDetails();
            this.ctrlProductDetails3 = new OnlineStore.Order_Procces.Controls.ctrlProductDetails();
            this.npdPage = new System.Windows.Forms.NumericUpDown();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.npdPage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.AutoSize = true;
            this.lblProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblProductCategory.Location = new System.Drawing.Point(507, 31);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(201, 32);
            this.lblProductCategory.TabIndex = 0;
            this.lblProductCategory.Text = "???????????";
            // 
            // ctrlProductDetails1
            // 
            this.ctrlProductDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ctrlProductDetails1.Location = new System.Drawing.Point(12, 93);
            this.ctrlProductDetails1.Name = "ctrlProductDetails1";
            this.ctrlProductDetails1.Size = new System.Drawing.Size(329, 583);
            this.ctrlProductDetails1.TabIndex = 1;
            // 
            // ctrlProductDetails2
            // 
            this.ctrlProductDetails2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ctrlProductDetails2.Location = new System.Drawing.Point(455, 96);
            this.ctrlProductDetails2.Name = "ctrlProductDetails2";
            this.ctrlProductDetails2.Size = new System.Drawing.Size(329, 583);
            this.ctrlProductDetails2.TabIndex = 2;
            // 
            // ctrlProductDetails3
            // 
            this.ctrlProductDetails3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ctrlProductDetails3.Location = new System.Drawing.Point(898, 96);
            this.ctrlProductDetails3.Name = "ctrlProductDetails3";
            this.ctrlProductDetails3.Size = new System.Drawing.Size(329, 583);
            this.ctrlProductDetails3.TabIndex = 3;
            // 
            // npdPage
            // 
            this.npdPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npdPage.Location = new System.Drawing.Point(1022, 35);
            this.npdPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npdPage.Name = "npdPage";
            this.npdPage.Size = new System.Drawing.Size(205, 30);
            this.npdPage.TabIndex = 4;
            this.npdPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npdPage.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(1001, 703);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(226, 70);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(751, 703);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(226, 70);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 775);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.npdPage);
            this.Controls.Add(this.ctrlProductDetails3);
            this.Controls.Add(this.ctrlProductDetails2);
            this.Controls.Add(this.ctrlProductDetails1);
            this.Controls.Add(this.lblProductCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmProductMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.frmProductMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.npdPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductCategory;
        private Controls.ctrlProductDetails ctrlProductDetails1;
        private Controls.ctrlProductDetails ctrlProductDetails2;
        private Controls.ctrlProductDetails ctrlProductDetails3;
        private System.Windows.Forms.NumericUpDown npdPage;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnClose;
    }
}