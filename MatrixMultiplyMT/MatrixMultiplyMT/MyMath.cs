using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplyMT
{
    class MyMath
    {
        public static Random ran = new Random(500);

        public static double[,] MatrixMultiply(double[,] A, double[,] B)
        {
            
            double [,] res = new double[A.GetLength(0),B.GetLength(1)];
           // for (int i = 0; i < A.GetLength(0); i++)
            Parallel.For(0, A.GetLength(0), i =>
            {
                for (int j = 0; j < B.GetLength(1); j++)
                    for (int k = 0; k < A.GetLength(1); k++)
                        res[i, j] += A[i, k] * B[k, j];
            });
            return res;
        }

        public static void InitMatrix(double[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    m[i, j] = ran.NextDouble() + 1.0;

        }

        public static void InitMatrixJagged(double[][] m)
        {
            int num1 = m.GetLength(0);
            int num2 = m[0].Length;

            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m[0].Length; j++)
                    m[i][j] = ran.NextDouble() + 1.0;
        }

        public static double[][] MatrixMultiplyJagged(double[][] A, double[][] B)
        {

            double[][] res = new double[A.GetLength(0)][];
            for (int i = 0; i < A.GetLength(0); i++)
                res[i] = new double[B[0].Length];
            //for (int i = 0; i < A.GetLength(0); i++)
                 Parallel.For(0, A.GetLength(0), i =>
                 {
                for (int j = 0; j < B[0].Length; j++)
                    for (int k = 0; k < A[0].Length; k++)
                        res[i][j] += A[i][k] * B[k][j];
            });
            return res;
        }

    }
}
