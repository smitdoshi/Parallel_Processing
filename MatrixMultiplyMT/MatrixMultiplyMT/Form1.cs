using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;


namespace MatrixMultiplyMT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestMarix_Click(object sender, EventArgs e)
        {
            Matrix m1 = new Matrix(4, 2);
            Matrix m2 = new Matrix(2, 4);
            m1[0,0] = 5;
            m1[0,1] = 3;
            m1[1,0] = 6;
            m1[1,1] = 7;
            m1[2,0] = 3;
            m1[2,1] = 4;
            m1[3,0] = 2;
            m1[3,1] = 5;

            m2[0, 0] = 2;
            m2[0, 1] = 5;
            m2[0, 2] = 6;
            m2[0, 3] = 4;
            m2[1, 0] = 3;
            m2[1, 1] = 4;
            m2[1, 2] = 2;
            m2[1, 3] = 5;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Matrix m3 = m1 * m2;
            sw.Stop();

            MessageBox.Show(m1.ToString() +"\n" +
                m2.ToString() + "\n" + m3.ToString() + "\n" +
                sw.ElapsedMilliseconds.ToString());
        }


        private void btnMatrixMultiplyLarge_Click(object sender, EventArgs e)
        {
            Matrix m1 = new Matrix(4, 2);
            Matrix m2 = new Matrix(2, 4);
            m1[0, 0] = 5;
            m1[0, 1] = 3;
            m1[1, 0] = 6;
            m1[1, 1] = 7;
            m1[2, 0] = 3;
            m1[2, 1] = 4;
            m1[3, 0] = 2;
            m1[3, 1] = 5;

            m2[0, 0] = 2;
            m2[0, 1] = 5;
            m2[0, 2] = 6;
            m2[0, 3] = 4;
            m2[1, 0] = 3;
            m2[1, 1] = 4;
            m2[1, 2] = 2;
            m2[1, 3] = 5;

            double[,] m11 = new double[500, 500];
            MyMath.InitMatrix(m11);
            double[,] m22= new double[500, 500];
            MyMath.InitMatrix(m22);

            Matrix mm1 = new Matrix(1000, 1000);
            MyMath.InitMatrix(mm1.Data);
            Matrix mm2 = new Matrix(1000, 1000);
            MyMath.InitMatrix(mm2.Data);


            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[,] m3 = MyMath.MatrixMultiply(m1.Data,m2.Data);
            double[,] mm3 = MyMath.MatrixMultiply(m11,m22);
            Matrix matrix = m1 * m2;
            sw.Stop();

            MessageBox.Show(m3[0,0].ToString() + "\n Execution Time=" +
                sw.ElapsedMilliseconds.ToString());
        }

        // Doing for Jagged Array

        private void btnMatrixMultiplyJagged_Click(object sender, EventArgs e)
        {
            double[][] m1 = new double[500][];
            for (int i = 0; i < m1.GetLength(0); i++)
                m1[i] = new double[500];
            MyMath.InitMatrixJagged(m1);
            double[][] m2 = new double[500][];
            for (int i = 0; i < m2.GetLength(0); i++)
                m2[i] = new double[500];
            MyMath.InitMatrixJagged(m2);

            Matrix matrix1 = new Matrix(1000, 1000);
            MyMath.InitMatrix(matrix1.Data);
            Matrix matrix2 = new Matrix(1000, 1000);
            MyMath.InitMatrix(matrix2.Data);


            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[,] m3 = MyMath.MatrixMultiply(matrix1.Data,matrix2.Data);
            double[][] mm3 = MyMath.MatrixMultiplyJagged(m1, m2);
            Matrix matrix3 = matrix1 * matrix2;
            sw.Stop();

            MessageBox.Show(mm3[0][0].ToString() + "\n" +
                sw.ElapsedMilliseconds.ToString());
        }

        private void btnBlockMatrixMultiply_Click(object sender, EventArgs e)
        {
            Matrix m1 = new Matrix(4, 2);
            Matrix m2 = new Matrix(2, 4);
            m1[0, 0] = 5;
            m1[0, 1] = 3;
            m1[1, 0] = 6;
            m1[1, 1] = 7;
            m1[2, 0] = 3;
            m1[2, 1] = 4;
            m1[3, 0] = 2;
            m1[3, 1] = 5;

            m2[0, 0] = 2;
            m2[0, 1] = 5;
            m2[0, 2] = 6;
            m2[0, 3] = 4;
            m2[1, 0] = 3;
            m2[1, 1] = 4;
            m2[1, 2] = 2;
            m2[1, 3] = 5;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Matrix m3 = Matrix.BlockMultiply(m1, m2, 2);
            sw.Stop();

            MessageBox.Show(m1.ToString() + "\n" +
                m2.ToString() + "\n" + m3.ToString() + "\n" +
                sw.ElapsedMilliseconds.ToString());
        }

        private void btnBlockMatrixMultiplyLarge_Click(object sender, EventArgs e)
        {
            Matrix m1 = new Matrix(6, 6);
            MyMath.InitMatrix(m1.Data);
            Matrix m2 = new Matrix(6, 6);
            MyMath.InitMatrix(m2.Data);


            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[,] mm3 = MyMath.MatrixMultiply(m1.Data,m2.Data);
            double[,] m4 = MyMath.MatrixMultiply(m1.Data,m2.Data);
            Matrix m3 = Matrix.BlockMultiply(m1, m2, 2);
            sw.Stop();

            MessageBox.Show(m3[0, 0].ToString() + "\n" +
                sw.ElapsedMilliseconds.ToString());
        }

        //internet pe jo page khula hay wo => for loop ki jagah pe user kerny wala hay, parallel wala kaam ho gaya hy :D :D :D 
        private void btnTaskContinuation_Click(object sender, EventArgs e)
        {
            Func<object,double> fptr = new Func<object,double>(this.ComputeAvg);
            Task<double> taskAvg = new Task<double>((object objstate) =>
                {
                    int[] data = (int[]) objstate;
                    int sum = 0;
                    foreach (int num in data)
                        sum += num;
                    return sum / (double)data.Length;
                }, new int[] {10,5,13,27});
            Task<double> taskAvg1 = new Task<double>((objstate) => fptr(objstate),10);
            taskAvg1.Start();
            taskAvg1.Wait();
            double res = taskAvg.Result;
            MessageBox.Show(res.ToString());
            Task<int> task2 = taskAvg.ContinueWith<int>((ant) =>
                { return (int)(25 + ant.Result); });
            task2.Wait();
            MessageBox.Show(task2.Result.ToString());

        }

        double ComputeAvg(object obj)
        {
            int[] data = { 5, 11, 13, 17, 19 };
            int sum = 0;
            foreach (int num in data)
                sum += num;
            return sum / (double)data.Length;
        }
       
    }
}
