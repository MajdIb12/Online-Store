namespace OnlineStore.Order_Procces.Controls
{
    partial class ctrlProductDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pbImage1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.npdQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(16, 266);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(98, 32);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "*******";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(3, 472);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(323, 108);
            this.txtDescription.TabIndex = 3;
            // 
            // pbImage1
            // 
            this.pbImage1.ErrorImage = global::OnlineStore.Properties.Resources.Male_512;
            this.pbImage1.ImageLocation = "";
            this.pbImage1.Location = new System.Drawing.Point(3, 3);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(323, 241);
            this.pbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage1.TabIndex = 1;
            this.pbImage1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Description:";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(163, 315);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(150, 45);
            this.btnAddToCart.TabIndex = 5;
            this.btnAddToCart.Text = "Add to cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.button1_AddToCart);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantity:";
            // 
            // npdQuantity
            // 
            this.npdQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npdQuantity.Location = new System.Drawing.Point(163, 366);
            this.npdQuantity.Name = "npdQuantity";
            this.npdQuantity.Size = new System.Drawing.Size(120, 30);
            this.npdQuantity.TabIndex = 7;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(251, 203);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 41);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = ">>>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(3, 203);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(70, 41);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "<<<";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ctrlProductDetails
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.npdQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImage1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblName);
            this.Name = "ctrlProductDetails";
            this.Size = new System.Drawing.Size(329, 583);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npdQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.PictureBox pbImage1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown npdQuantity;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
    }
}
