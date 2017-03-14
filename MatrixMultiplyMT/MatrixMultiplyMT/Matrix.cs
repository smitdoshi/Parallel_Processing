using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixMultiplyMT
{
    class Matrix  
    {
        int m;
        public int M
        {
            get { return m; }
        }
        int n;
        public int N
        {
            get { return n; }
        }

        double[,] data = null; 
        public double this[int i, int j]
        {
            get { return data[i,j]; }
            set { data[i,j] = value; }
        }
        public double[,] Data
        {
            get { return data; }
        }


        public Matrix(int m1, int n1)
        {
            data = new double[m1, n1];
            m = m1;
            n = n1;
        }

        
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix mres = new Matrix(A.m, B.n);
            Thread[] thArr = new Thread[A.m];
            // Using Parallel Tasking
            Parallel.For(0, A.m, i =>
            {
                for (int j = 0; j < B.n; j++)
                    for (int k = 0; k < A.n; k++)
                        mres.data[i, j] += A.data[i, k] * B.data[k, j];
                MatrixMultiplyRow mm = new MatrixMultiplyRow();
                mm.M1 = A;
                mm.M2 = B;
                mm.Mress = mres;
                mm.Iter = i;

                mm.ComputeRow();
                thArr[i] = new Thread(new ThreadStart(mm.ComputeRow));

                thArr[i].Start(); // starting new thread

            });

            for (int p = 0; p < A.m; p++)
            {
                thArr[p].Join();  // wait for all threads to finish
            }

            return mres;

        }

        public static Matrix BlockMultiply(Matrix A, Matrix B, int numBlocks)
        {
            Matrix mres = new Matrix(A.m, B.n);
             int blockSize = A.m / numBlocks;
            for (int i = 0; i < A.m / blockSize; i++)
            {
                for (int j = 0; j < B.n / blockSize; j++)
                {
                    for (int k = 0; k < A.n / blockSize; k++)
                    {
                        BlockMatrix BM1 = new BlockMatrix();
                        BM1.M = A;
                        BM1.StartRow = i*blockSize;
                        BM1.StartCol = k*blockSize;
                        BM1.RowSize = blockSize; // A.m / numBlocks;
                        BM1.ColSize = blockSize; // A.m / numBlocks;

                        BlockMatrix BM2 = new BlockMatrix();
                        BM2.M = B;
                        BM2.StartRow = k * blockSize;
                        BM2.StartCol = j * blockSize;
                        BM2.RowSize = blockSize; // A.m / numBlocks;
                        BM2.ColSize = blockSize; // A.m / numBlocks;
                        
                        Matrix mblock = BM1 * BM2;
                        UpdateMatrixBlock(i, j, mres,mblock,blockSize);
                        mres.data[i, j] += A.data[i, k] * B.data[k, j];
                    }
                }
            }
            return mres;
        }

        static void UpdateMatrixBlock(int blockColNum, int blockRowNum, Matrix m, Matrix bm, int blockSize)
        {
            for (int i = 0; i < blockSize; i++)
                for (int j = 0; j < blockSize; j++)
                    m[i + blockColNum*blockSize, j + blockRowNum*blockSize] = 
                        m[i + blockColNum *blockSize, j + blockRowNum*blockSize] + bm[i, j];
        }


        public override string ToString()
        {
            string out1 = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    out1 += data[i, j].ToString() + " \t";
                out1 += "\n";
            }
            return out1;
        }

        class BlockMatrix  // inner class
        {
            Matrix m;  // parent matrix
            public Matrix M
            {
                get { return m; }
                set { m = value; }
            }

            int startRow;
            public int StartRow
            {
                get { return startRow; }
                set { startRow = value; }
            }

            int startCol;
            public int StartCol
            {
                get { return startCol; }
                set { startCol = value; }
            }

            int rowSize;
            public int RowSize
            {
                get { return rowSize; }
                set { rowSize = value; }
            }

            int colSize;
            public int ColSize
            {
                get { return colSize; }
                set { colSize = value; }
            }

            public static Matrix operator* (BlockMatrix A1, BlockMatrix B1)
            {
                Matrix mres = new Matrix(A1.rowSize, B1.colSize);
                for (int i = 0; i < A1.rowSize; i++)
                {
                    for (int j = 0; j < B1.colSize; j++)
                    {
                        for (int k = 0; k < A1.colSize; k++)
                        {
                            mres.data[i, j] += A1.m.data[i+A1.startRow, k+A1.startCol] * B1.m.data[k+B1.startRow, j+B1.startCol];
                        }
                    }
                }
                return mres;
            }
        }

        
        class MatrixMultiplyRow   // inner class
        {
            Matrix m1;
            public Matrix M1
            {
                get { return m1; }
                set { m1 = value; }
            }
            Matrix m2;
            public Matrix M2
            {
                get { return m2; }
                set { m2 = value; }
            }

            Matrix mress;
            public Matrix Mress
            {
                get { return mress; }
                set { mress = value; }
            }

            int iter;
            public int Iter
            {
                get { return iter; }
                set { iter = value; }
            }

            public void ComputeRow()
            {
               for (int k = 0; k < M1.n; k++)  // changing order still produces - this is faster
                for (int j = 0; j < m2.n; j++)  // correct result
//                    for (int k = 0; k < m1.n; k++)
                        mress.data[iter, j] += m1.data[iter, k] * m2.data[k, j];
            }

        }

    }
}
