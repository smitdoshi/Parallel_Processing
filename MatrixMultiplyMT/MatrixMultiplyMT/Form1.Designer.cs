namespace MatrixMultiplyMT
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
            this.btnTestMarix = new System.Windows.Forms.Button();
            this.btnMatrixMultiplyLarge = new System.Windows.Forms.Button();
            this.btnMatrixMultiplyJagged = new System.Windows.Forms.Button();
            this.btnBlockMatrixMultiply = new System.Windows.Forms.Button();
            this.btnBlockMatrixMultiplyLarge = new System.Windows.Forms.Button();
            this.btnTaskContinuation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestMarix
            // 
            this.btnTestMarix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestMarix.Location = new System.Drawing.Point(141, 36);
            this.btnTestMarix.Margin = new System.Windows.Forms.Padding(2);
            this.btnTestMarix.Name = "btnTestMarix";
            this.btnTestMarix.Size = new System.Drawing.Size(146, 29);
            this.btnTestMarix.TabIndex = 0;
            this.btnTestMarix.Text = "Test Matrix";
            this.btnTestMarix.UseVisualStyleBackColor = true;
            this.btnTestMarix.Click += new System.EventHandler(this.btnTestMarix_Click);
            // 
            // btnMatrixMultiplyLarge
            // 
            this.btnMatrixMultiplyLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatrixMultiplyLarge.Location = new System.Drawing.Point(141, 88);
            this.btnMatrixMultiplyLarge.Margin = new System.Windows.Forms.Padding(2);
            this.btnMatrixMultiplyLarge.Name = "btnMatrixMultiplyLarge";
            this.btnMatrixMultiplyLarge.Size = new System.Drawing.Size(146, 33);
            this.btnMatrixMultiplyLarge.TabIndex = 1;
            this.btnMatrixMultiplyLarge.Text = "Matrix Multiply Large";
            this.btnMatrixMultiplyLarge.UseVisualStyleBackColor = true;
            this.btnMatrixMultiplyLarge.Click += new System.EventHandler(this.btnMatrixMultiplyLarge_Click);
            // 
            // btnMatrixMultiplyJagged
            // 
            this.btnMatrixMultiplyJagged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatrixMultiplyJagged.Location = new System.Drawing.Point(136, 144);
            this.btnMatrixMultiplyJagged.Margin = new System.Windows.Forms.Padding(2);
            this.btnMatrixMultiplyJagged.Name = "btnMatrixMultiplyJagged";
            this.btnMatrixMultiplyJagged.Size = new System.Drawing.Size(151, 32);
            this.btnMatrixMultiplyJagged.TabIndex = 2;
            this.btnMatrixMultiplyJagged.Text = "Matrix Multiply Jagged";
            this.btnMatrixMultiplyJagged.UseVisualStyleBackColor = true;
            this.btnMatrixMultiplyJagged.Click += new System.EventHandler(this.btnMatrixMultiplyJagged_Click);
            // 
            // btnBlockMatrixMultiply
            // 
            this.btnBlockMatrixMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlockMatrixMultiply.Location = new System.Drawing.Point(136, 198);
            this.btnBlockMatrixMultiply.Margin = new System.Windows.Forms.Padding(2);
            this.btnBlockMatrixMultiply.Name = "btnBlockMatrixMultiply";
            this.btnBlockMatrixMultiply.Size = new System.Drawing.Size(151, 31);
            this.btnBlockMatrixMultiply.TabIndex = 3;
            this.btnBlockMatrixMultiply.Text = "Block Matrix Multiply";
            this.btnBlockMatrixMultiply.UseVisualStyleBackColor = true;
            this.btnBlockMatrixMultiply.Click += new System.EventHandler(this.btnBlockMatrixMultiply_Click);
            // 
            // btnBlockMatrixMultiplyLarge
            // 
            this.btnBlockMatrixMultiplyLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlockMatrixMultiplyLarge.Location = new System.Drawing.Point(136, 251);
            this.btnBlockMatrixMultiplyLarge.Margin = new System.Windows.Forms.Padding(2);
            this.btnBlockMatrixMultiplyLarge.Name = "btnBlockMatrixMultiplyLarge";
            this.btnBlockMatrixMultiplyLarge.Size = new System.Drawing.Size(151, 32);
            this.btnBlockMatrixMultiplyLarge.TabIndex = 4;
            this.btnBlockMatrixMultiplyLarge.Text = "Block Matrix Multiply Large";
            this.btnBlockMatrixMultiplyLarge.UseVisualStyleBackColor = true;
            this.btnBlockMatrixMultiplyLarge.Click += new System.EventHandler(this.btnBlockMatrixMultiplyLarge_Click);
            // 
            // btnTaskContinuation
            // 
            this.btnTaskContinuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskContinuation.Location = new System.Drawing.Point(136, 303);
            this.btnTaskContinuation.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaskContinuation.Name = "btnTaskContinuation";
            this.btnTaskContinuation.Size = new System.Drawing.Size(151, 35);
            this.btnTaskContinuation.TabIndex = 5;
            this.btnTaskContinuation.Text = "Task Continuation";
            this.btnTaskContinuation.UseVisualStyleBackColor = true;
            this.btnTaskContinuation.Click += new System.EventHandler(this.btnTaskContinuation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTaskContinuation);
            this.groupBox1.Controls.Add(this.btnMatrixMultiplyLarge);
            this.groupBox1.Controls.Add(this.btnTestMarix);
            this.groupBox1.Controls.Add(this.btnBlockMatrixMultiply);
            this.groupBox1.Controls.Add(this.btnMatrixMultiplyJagged);
            this.groupBox1.Controls.Add(this.btnBlockMatrixMultiplyLarge);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(96, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 389);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matrix Multiplication";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 433);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Matrix Multiplication";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestMarix;
        private System.Windows.Forms.Button btnMatrixMultiplyLarge;
        private System.Windows.Forms.Button btnMatrixMultiplyJagged;
        private System.Windows.Forms.Button btnBlockMatrixMultiply;
        private System.Windows.Forms.Button btnBlockMatrixMultiplyLarge;
        private System.Windows.Forms.Button btnTaskContinuation;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

