namespace SwarmEquationSolver
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
            this.btnSolveBySwarm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnParallelSwarms = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSolveBySwarm
            // 
            this.btnSolveBySwarm.Location = new System.Drawing.Point(26, 52);
            this.btnSolveBySwarm.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolveBySwarm.Name = "btnSolveBySwarm";
            this.btnSolveBySwarm.Size = new System.Drawing.Size(109, 23);
            this.btnSolveBySwarm.TabIndex = 0;
            this.btnSolveBySwarm.Text = "Sequential Swarm";
            this.btnSolveBySwarm.UseVisualStyleBackColor = true;
            this.btnSolveBySwarm.Click += new System.EventHandler(this.btnSolveBySwarm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(26, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnParallelSwarms
            // 
            this.btnParallelSwarms.Location = new System.Drawing.Point(26, 90);
            this.btnParallelSwarms.Name = "btnParallelSwarms";
            this.btnParallelSwarms.Size = new System.Drawing.Size(109, 23);
            this.btnParallelSwarms.TabIndex = 6;
            this.btnParallelSwarms.Text = "Parallel Swarm";
            this.btnParallelSwarms.UseVisualStyleBackColor = true;
            this.btnParallelSwarms.Click += new System.EventHandler(this.btnParallelSwarms_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(152, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(568, 190);
            this.dataGridView1.TabIndex = 7;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(149, 57);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(43, 13);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "Result?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 292);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnParallelSwarms);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSolveBySwarm);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Swarm Intelligence Equation Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolveBySwarm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnParallelSwarms;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblResult;
    }
}

