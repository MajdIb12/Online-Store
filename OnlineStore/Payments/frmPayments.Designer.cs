namespace OnlineStore.Paymenets
{
    partial class frmPayments
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
            this.lblCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbCreditCard = new System.Windows.Forms.RadioButton();
            this.rbPaybal = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.rdNone = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(212, 618);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(60, 25);
            this.lblCount.TabIndex = 22;
            this.lblCount.Text = "******";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(735, 590);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 70);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 614);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 29);
            this.label4.TabIndex = 20;
            this.label4.Text = "Row Count:";
            // 
            // rbCreditCard
            // 
            this.rbCreditCard.AutoSize = true;
            this.rbCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCreditCard.Location = new System.Drawing.Point(369, 85);
            this.rbCreditCard.Name = "rbCreditCard";
            this.rbCreditCard.Size = new System.Drawing.Size(127, 24);
            this.rbCreditCard.TabIndex = 18;
            this.rbCreditCard.Text = "Credit Card";
            this.rbCreditCard.UseVisualStyleBackColor = true;
            // 
            // rbPaybal
            // 
            this.rbPaybal.AutoSize = true;
            this.rbPaybal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPaybal.Location = new System.Drawing.Point(250, 85);
            this.rbPaybal.Name = "rbPaybal";
            this.rbPaybal.Size = new System.Drawing.Size(86, 24);
            this.rbPaybal.TabIndex = 17;
            this.rbPaybal.Text = "Paybal";
            this.rbPaybal.UseVisualStyleBackColor = true;
            this.rbPaybal.CheckedChanged += new System.EventHandler(this.rbPaybal_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "Filter:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(348, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Payments";
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AllowUserToOrderColumns = true;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPayments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Location = new System.Drawing.Point(4, 142);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersWidth = 51;
            this.dgvPayments.RowTemplate.Height = 24;
            this.dgvPayments.Size = new System.Drawing.Size(909, 442);
            this.dgvPayments.TabIndex = 13;
            // 
            // rdNone
            // 
            this.rdNone.AutoSize = true;
            this.rdNone.Checked = true;
            this.rdNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNone.Location = new System.Drawing.Point(131, 85);
            this.rdNone.Name = "rdNone";
            this.rdNone.Size = new System.Drawing.Size(73, 24);
            this.rdNone.TabIndex = 23;
            this.rdNone.TabStop = true;
            this.rdNone.Text = "None";
            this.rdNone.UseVisualStyleBackColor = true;
            this.rdNone.CheckedChanged += new System.EventHandler(this.rdNone_CheckedChanged);
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 686);
            this.Controls.Add(this.rdNone);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbCreditCard);
            this.Controls.Add(this.rbPaybal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paymenets";
            this.Load += new System.EventHandler(this.frmPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbCreditCard;
        private System.Windows.Forms.RadioButton rbPaybal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.RadioButton rdNone;
    }
}