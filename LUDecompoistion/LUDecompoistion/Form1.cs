using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LUDecomposition;

namespace LUDecompoistion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
		private void btnComputeLU_Click(object sender, EventArgs e)
		{
			double[,] L = new double[4, 4];
			double[,] U = new double[4, 4];
			Matrix m1 = new Matrix(4, 4);
			m1[0, 0] = 0.5; m1[0, 1] = 2; m1[0, 2] = 1; m1[0, 3] = 4;
			m1[1, 0] = 1.25; m1[1, 1] = 7; m1[1, 2] = 3.5; m1[1, 3] = 13;
			m1[2, 0] = 0.5; m1[2, 1] = 5; m1[2, 2] = 3.5; m1[2, 3] = 10.5;
			m1[3, 0] = 0.5; m1[3, 1] = 6; m1[3, 2] = 6; m1[3, 3] = 19;

			double err = 0;
			m1.LUDecompose(L, U, ref err);
			MessageBox.Show("Error = " + err.ToString());
			string out1 = "";
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					out1 += String.Format("{0:f2}", L[i, j]) + " ";
				}
				out1 += "\n";
			}
			MessageBox.Show(out1);

			out1 = "";
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					out1 += String.Format("{0:f2}", U[i, j]) + " ";
				}
				out1 += "\n";
			}
			MessageBox.Show(out1);
			MessageBox.Show(m1.ToString());
		}
        private void btnComputeBLU_Click(object sender, EventArgs e)
        {
            double [,] L = new double[4,4];
            double[,] U = new double[4, 4];
            Matrix m1 = new Matrix(4, 4);
            m1[0, 0] = 0.5; m1[0, 1] = 2; m1[0, 2] = 1; m1[0, 3] = 4;
            m1[1, 0] = 1.25; m1[1, 1] = 7; m1[1, 2] = 3.5; m1[1, 3] = 13;
            m1[2, 0] = 0.5; m1[2, 1] = 5; m1[2, 2] = 3.5; m1[2, 3] = 10.5;
            m1[3, 0] = 0.5; m1[3, 1] = 6; m1[3, 2] = 6; m1[3, 3] = 19;

			String s = this.txbox.Text;
			int sb = Int32.Parse(s);
            double err = 0;
            m1.BlockLUDecompose(sb, L, U, ref err);
            MessageBox.Show("Error = " + err.ToString());
            string out1 = "";
            for (int i = 0; i < 4;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    out1 += String.Format("{0:f2}",L[i,j]) + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);

            out1 = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    out1 += String.Format("{0:f2}", U[i, j]) + " ";
                }
                out1 += "\n";
            }
            MessageBox.Show(out1);
            MessageBox.Show(m1.ToString());
        }
    }
}
