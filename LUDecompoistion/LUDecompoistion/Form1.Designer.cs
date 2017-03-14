namespace LUDecompoistion
{
    partial class Form1
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
            this.btnComputeLU = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnComputeLU
            // 
            this.btnComputeLU.Location = new System.Drawing.Point(65, 24);
            this.btnComputeLU.Name = "btnComputeLU";
            this.btnComputeLU.Size = new System.Drawing.Size(122, 23);
            this.btnComputeLU.TabIndex = 0;
            this.btnComputeLU.Text = "Compute LU";
            this.btnComputeLU.UseVisualStyleBackColor = true;
            this.btnComputeLU.Click += new System.EventHandler(this.btnComputeLU_Click);

			this.btnComputeBLU = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnComputeLU
			// 
			this.btnComputeBLU.Location = new System.Drawing.Point(65, 140);
			this.btnComputeBLU.Name = "btnComputeBLU";
			this.btnComputeBLU.Size = new System.Drawing.Size(122, 23);
			this.btnComputeBLU.TabIndex = 0;
			this.btnComputeBLU.Text = "Compute Block LU";
			this.btnComputeBLU.UseVisualStyleBackColor = true;
			this.btnComputeBLU.Click += new System.EventHandler(this.btnComputeBLU_Click);

			this.txbox = new System.Windows.Forms.TextBox();
			this.txbox.Location = new System.Drawing.Point(80, 100);
			this.txbox.Size = new System.Drawing.Size(60, 23);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 267);
            this.Controls.Add(this.btnComputeLU);
			this.Controls.Add(this.btnComputeBLU);
			this.Controls.Add(this.txbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComputeLU;
		private System.Windows.Forms.Button btnComputeBLU;
		public System.Windows.Forms.TextBox txbox;
    }
}

