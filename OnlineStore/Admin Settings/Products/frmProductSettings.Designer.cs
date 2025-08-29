namespace OnlineStore.Admin_Settings
{
    partial class frmProductSettings
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
            this.components = new System.ComponentModel.Container();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateProducToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPC = new System.Windows.Forms.RadioButton();
            this.rbMobile = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvProducts.Location = new System.Drawing.Point(3, 293);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(909, 298);
            this.dgvProducts.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewProductToolStripMenuItem,
            this.updateProducToolStripMenuItem,
            this.tToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 112);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click);
            // 
            // updateProducToolStripMenuItem
            // 
            this.updateProducToolStripMenuItem.Name = "updateProducToolStripMenuItem";
            this.updateProducToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.updateProducToolStripMenuItem.Text = "Update Product";
            this.updateProducToolStripMenuItem.Click += new System.EventHandler(this.updateProducToolStripMenuItem_Click);
            // 
            // tToolStripMenuItem
            // 
            this.tToolStripMenuItem.Name = "tToolStripMenuItem";
            this.tToolStripMenuItem.Size = new System.Drawing.Size(192, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(247, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Products Settings";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(264, 138);
            this.txtFilter.MaxLength = 20;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(233, 28);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter:";
            // 
            // rbPC
            // 
            this.rbPC.AutoSize = true;
            this.rbPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPC.Location = new System.Drawing.Point(38, 122);
            this.rbPC.Name = "rbPC";
            this.rbPC.Size = new System.Drawing.Size(55, 24);
            this.rbPC.TabIndex = 5;
            this.rbPC.Text = "PC";
            this.rbPC.UseVisualStyleBackColor = true;
            this.rbPC.CheckedChanged += new System.EventHandler(this.rbPC_CheckedChanged);
            // 
            // rbMobile
            // 
            this.rbMobile.AutoSize = true;
            this.rbMobile.Checked = true;
            this.rbMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMobile.Location = new System.Drawing.Point(38, 167);
            this.rbMobile.Name = "rbMobile";
            this.rbMobile.Size = new System.Drawing.Size(85, 24);
            this.rbMobile.TabIndex = 6;
            this.rbMobile.TabStop = true;
            this.rbMobile.Text = "Mobile";
            this.rbMobile.UseVisualStyleBackColor = true;
            this.rbMobile.CheckedChanged += new System.EventHandler(this.rbPC_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 621);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Row Count:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(734, 597);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 70);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(211, 625);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(60, 25);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "******";
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(734, 209);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(178, 78);
            this.btnAddNew.TabIndex = 12;
            this.btnAddNew.Text = "Add New Product";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmProductSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 679);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbMobile);
            this.Controls.Add(this.rbPC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductSettings";
            this.Text = "Product Settings";
            this.Load += new System.EventHandler(this.frmProductSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton rbPC;
        private System.Windows.Forms.RadioButton rbMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ToolStripMenuItem updateProducToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}