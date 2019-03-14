using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class ProcessMatrix
    {
        public static int[][] createMatrixOnes(int n)
        {
            int[][] matr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matr[i][j] = 1;
                }
            }
            return matr;
        }

        public static void swapRow(ref int[][] matrix, int n, int a, int b)
        {
            for (int i = 0; i < n; i++) { int temp = matrix[a][i]; matrix[a][i] = matrix[b][i]; matrix[b][i] = temp; }
        }

        public static void swapColumn(ref int[][] matrix, int n, int a, int b)
        {
            for (int i = 0; i < n; i++) { int temp = matrix[i][a]; matrix[i][a] = matrix[i][a]; matrix[i][b] = temp; }
        }

        public static int det2(int a, int b, int c, int d)
        {
            return a * d - b * c;
        }

        public static bool hasZeroMiddle(int[][] matrix, int size, int tryNumb)
        {
            int n = 0, m = 0;
            for (int i = 1; i < size - 1; i++)
                for (int j = 1; j < size - 1; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        n = i; m = j;
                    }
                }
            if ((n == 0) && (m == 0)) return true;
            if (tryNumb % 2 == 0) { swapColumn(ref matrix, size, n, 0); swapRow(ref matrix, size, m, 0); }
            return hasZeroMiddle(matrix, size, tryNumb + 1);
        }

        public static bool hasZeros(int[][] matr, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (matr[i][j] == 0) return true;
            return false;
        }

        public static string printMatrixSet(int[][] bigMatrix, int[][] smallMatrix, int bigSize)
        {
            string res = string.Empty;
            int n = 2 * bigSize - 1;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 1)
                {
                    res += " ";
                    for (int j = 0; j < bigSize - 1; j++)
                        res += smallMatrix[j][i/2].ToString() + " ";
                }
                else
                {
                    for (int j = 0; j < bigSize; j++)
                        res += bigMatrix[j][i/2].ToString() + " ";
                }
                res += "\n";
            }
            res += "\n";
            return res;
        }

        public static int[][] stepMatrix(int[][] bigMatrix, int[][] smallMatrix, int bigSize, ref string log)
        {
            log += printMatrixSet(bigMatrix, smallMatrix, bigSize);
            int smallSize = bigSize - 1;
            if (bigSize == 1) return bigMatrix;

            if (hasZeros(smallMatrix, smallSize) == true) { log += "Конец"; return null; }
                int[][] cutMatrix = new int[bigSize - 2][];

            for (int i = 0; i < bigSize - 1; i++)
                for (int j = 0; j < bigSize - 1; j++)
                {
                    smallMatrix[i][j] = det2(bigMatrix[i][j],bigMatrix[i+1][j],bigMatrix[i][j+1],bigMatrix[i+1][j+1])/ smallMatrix[i][j];
                }

                for (int i = 0; i < bigSize - 2; i++)
                {
                    cutMatrix[i] = new int[bigSize - 2];
                    for (int j = 0; j < bigSize - 2; j++)
                    {
                        cutMatrix[i][j] = bigMatrix[i + 1][j + 1];
                    }
                }

            log += printMatrixSet(bigMatrix, smallMatrix, bigSize);
            return stepMatrix(smallMatrix,cutMatrix, smallSize, ref log);
            
        }
    }
}
