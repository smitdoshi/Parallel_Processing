using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LUDecomposition
{
    class Matrix  // uses inner class to delegate the work to a function
    {             // for launching it as a separate thread and to
                  // pass data to it and collect results from it
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

        double[,] data = null; //indexer
        public double this[int i, int j]
        {
            get { return data[i,j]; }
            set { data[i,j] = value; }
        }


        public Matrix(int m1, int n1)
        {
            data = new double[m1, n1];
            m = m1;
            n = n1;
        }

		public void copy(Matrix B)
		{
			for (int i = 0; i < n; ++i)
				for (int j = 0; j < m; ++j)
					data[i, j] = B.data[i, j];
		}
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix mres = new Matrix(A.m, B.n);
            Thread[] thArr = new Thread[A.m];
            for (int i = 0; i < A.m; i++)
            {
                //for (int j = 0; j < B.n; j++)
                //    for (int k = 0; k < A.n; k++)
                //        mres.data[i, j] += A.data[i, k] * B.data[k, j];
                MatrixMul mm = new MatrixMul();
                mm.M1 = A;
                mm.M2 = B;
                mm.Mress = mres;
                mm.Iter = i;
                thArr[i] = new Thread(new ThreadStart(mm.ComputeRow));
                thArr[i].Start();

            }

            for (int p = 0; p < A.m; p++)
            {
                thArr[p].Join();  // wait for all threads to finish
            }

            return mres;

        }
		public static Matrix operator -(Matrix A, Matrix B)
		{
			Matrix mres = new Matrix(A.m, A.n);
			for (int i = 0; i < A.m; ++i)
				for (int j = 0; j < A.n; ++j)
					mres.data[i, j] = A.data[i, j] - B.data[i, j];
			return mres;

		}

        public void LUDecompose(double[,]L, double[,] U, ref double error)  // operates on M
        {
            if (m != n)
                throw new Exception("width and column dimensions are not the same..");

            // copy data into A matrix
            double[,] A = new double[n, n];
            A = (double [,])data.Clone();

            for (int k = 0; k < n; k++)
            {
                U[k, k] = data[k, k];
                for (int j = k+1; j < n; j++)
                {
                     U[k, j] = data[k, j];
                }
                for (int i = k; i < n; i++)
                {
                    if (i == k)
                        L[i, k] = 1;
                    else
                        L[i, k] = data[i, k] / U[k, k];
                }
                for (int i = k+1; i < n; i++)
                {
                    for (int j = k+1; j < n; j++)
                        data[i, j] = data[i, j] - L[i, k] * U[k, j];
                   
                }
                
            }

            // verify if LU decomp is correct
            double [,] res = new double[n,n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        res[i, j] += L[i, k] * U[k, j];
            error = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    error += Math.Abs(res[i, j] - A[i, j]);


        }

		public void BlockLUDecompose(int SBlock, double[,] L, double[,] U, ref double error)  // operates on M
		{
			if (m != n)
				throw new Exception("width and column dimensions are not the same..");
			if (n % SBlock != 0)
				throw new Exception("cant div matrix to " + SBlock + " block");
			int NBlock = n / SBlock;


			Matrix[,] Ablocks = new Matrix[NBlock, NBlock];
			Matrix[,] LBlocks = new Matrix[NBlock, NBlock];
			Matrix[,] UBlocks = new Matrix[NBlock, NBlock];
			for (int i = 0; i < NBlock; ++i)
				for (int j = 0; j < NBlock; ++j)
				{
					LBlocks[i,j] = new Matrix(SBlock, SBlock);
					UBlocks[i,j] = new Matrix(SBlock, SBlock);

					Ablocks[i,j] = new Matrix(SBlock, SBlock);
					for (int x = 0; x < SBlock; ++x)
						for (int y = 0; y < SBlock; ++y)
						Ablocks[i, j][x, y] = data[i*SBlock + x, j*SBlock + y];
				}

			for (int k = 0; k < NBlock; k++)
			{
				double err = 0;
				Ablocks[k, k].LUDecompose(LBlocks[k, k].data, UBlocks[k, k].data, ref err);

				Matrix invU = new Matrix(SBlock, SBlock);
				UBlocks[k, k].inverseUMatrix(ref invU);
				Matrix invL = new Matrix(SBlock, SBlock);
				LBlocks[k, k].inverseLMatrix(ref invL);

				int H = NBlock - k - 1;
				Thread[] thArr = new Thread[2*H];
				for (int i = k + 1; i < NBlock; i++)
				{
					UpdateU up1 = new UpdateU(UBlocks, Ablocks, ref invL, k, i);
					thArr[i - k - 1] = new Thread(new ThreadStart(up1.cal));
					thArr[i - k - 1].Start();
					UpdateL ul1 = new UpdateL(LBlocks, Ablocks, ref invU, k, i);
					thArr[i - k - 1 + H] = new Thread(new ThreadStart(ul1.cal));
					thArr[i - k - 1 + H].Start();
				}
				for (int i = 0; i < 2 * H; ++i)
					thArr[i].Join();
				/*
				for (int i = k + 1; i < NBlock; ++i)
				{
					UBlocks[k, i] = invL * Ablocks[k, i];
					LBlocks[i, k] = Ablocks[i, k] * invU;
				}
				*/
				for (int i = k + 1; i < NBlock; ++i)
					for (int j = k + 1; j < NBlock; ++j)
					{
						Ablocks[i, j] = Ablocks[i, j] - LBlocks[i, k] * UBlocks[k,j];
					}
			}

			for (int i = 0; i < n; ++i)
				for (int j = 0; j < n; ++j)
				{
					L[i, j] = LBlocks[i / SBlock, j / SBlock][i % SBlock, j%SBlock];
					U[i, j] = UBlocks[i / SBlock, j / SBlock][i % SBlock, j % SBlock];
				}


			// verify if LU decomp is correct
			double[,] res = new double[n, n];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					for (int k = 0; k < n; k++)
						res[i, j] += L[i, k] * U[k, j];
			error = 0;
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					error += Math.Abs(res[i, j] - data[i, j]);


		}

		public void inverseUMatrix(ref Matrix inv)
		{
			for (int i = 0; i < n; ++i)
				for (int j = 0; j < n; ++j)
					inv.data[i, j] = (i == j) ? 1 : 0;
			for (int i = n-1; i >= 0; --i)
			{
				for (int j = 0; j < n; ++j)
					inv.data[i, j] /= data[i, i];
				for (int j = i - 1; j >= 0; --j)
				{
					double rate = data[j, i];
					for (int t = 0; t < n; ++t)
						inv.data[j, t] -= rate * inv.data[i,t];
				}
			}
		}
		public void inverseLMatrix(ref Matrix inv)
		{
			for (int i = 0; i < n; ++i)
				for (int j = 0; j < n; ++j)
					inv.data[i, j] = (i == j) ? 1 : 0;
			for (int i = 0; i < n; ++i)
			{
				for (int j = 0; j < n; ++j)
					inv.data[i, j] /= data[i, i];
				for (int j = i + 1; j < n; ++j)
				{
					double rate = data[j, i];
					for (int t = 0; t < n; ++t)
						inv.data[j, t] -= rate * inv.data[i, t];
				}
			}
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

		class UpdateU
		{
			public Matrix[,] UBlock;
			public Matrix[,] ABlock;
			public Matrix inv;
			public int k;
			public int iter;
			public UpdateU(Matrix[,] U, Matrix [,] A, ref Matrix invL, int _k, int _iter)
			{
				UBlock = U;
				inv = invL;
				k = _k;
				iter = _iter;
				ABlock = A;
			}
			public void cal()
			{
				UBlock[k, iter] = inv * ABlock[k, iter]; 
			}
		}
		class UpdateL
		{
			public Matrix[,] LBlock;
			public Matrix[,] ABlock;
			public Matrix inv;
			public int k;
			public int iter;
			public UpdateL(Matrix[,] L, Matrix[,] A, ref Matrix invU, int _k, int _iter)
			{
				LBlock = L;
				inv = invU;
				k = _k;
				iter = _iter;
				ABlock = A;
			}
			public void cal()
			{
				LBlock[iter, k] = ABlock[iter, k]*inv;
			}
		}
        class MatrixMul
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
                for (int k = 0; k < M1.n; k++)  // changing order still produces
                for (int j = 0; j < M2.n; j++)  // correct result
                   // for (int k = 0; k < M1.n; k++)
                        mress.data[iter, j] += M1.data[iter, k] * M2.data[k, j];

            }

        }

    }
}
