using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class Strassen
    {
        private static int[][] getSquare(int[][] A, int size, int part)
        {
            int newSize = size / 2;
            int[][] C = new int[newSize][];

            for (int i = 0; i < newSize; i++)
            {
                C[i] = new int[newSize];
                for (int j = 0; j < newSize; j++)
                {
                    if (part == 11) C[i][j] = A[i][j];
                    if (part == 12) C[i][j] = A[i][j+newSize];
                    if (part == 21) C[i][j] = A[i+newSize][j];
                    if (part == 22) C[i][j] = A[i+newSize][j+newSize];
                }
            }
            return C;

        }

        public static string outputMatrix(int[][] m, int size, int step)
        {
            string movement = string.Empty;
            for (int i = 0; i < step; i++) movement += "   ";

            string res = string.Empty;
            for (int i = 0; i < size; i++)
            {
                res += movement;
                for (int j = 0; j < size; j++)
                {
                    res += m[i][j] + " ";
                }
                res += "\n";
            }
            res += "\n";
            return res;
        }

        private static int[][] gather(int[][] A11, int[][] A12, int[][] A21, int[][] A22,int s)
        {
            int size = s * 2;

            int[][] C = new int[size][];
            for (int i = 0; i < size; i++)
            {
                C[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    C[i][j] = 0;
                }
            }

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    C[i][j] = A11[i][j];
                    C[i][j+s] = A12[i][j];
                    C[i+s][j] = A21[i][j];
                    C[i+s][j+s] = A22[i][j];
                }
            }
            return C;
        }

        private static int[][] zeroMatrix(int size)
        {
            int[][] C = new int[size][];
            for (int i = 0; i < size; i++)
            {
                C[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    C[i][j] = 0;
                }
            }
            return C;
        }

        private static int[][] SUM(int[][] A, int[][] B, int size)
        {
            int[][] C = new int[size][];
            for (int i = 0; i < size; i++)
            {
                C[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    C[i][j] = A[i][j] + B[i][j];
                }
            }
            return C;
        }

        private static int[][] SUB(int[][] A, int[][] B, int size)
        {
            int[][] C = new int[size][];
            for (int i = 0; i < size; i++)
            {
                C[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    C[i][j] = A[i][j] - B[i][j];
                }
            }
            return C;
        }

        public static int[][] MUL(int[][] A, int[][] B, int size, ref string log, int step)
        {
            string movement = string.Empty;
            for (int i = 0; i < step; i++) movement += "   ";

            if (size == 1)
            {
                int[][] C = new int [1][];
                C[0] = new int[1];
                C[0][0] = A[0][0] * B[0][0];
                return C;
            }
            
            int half = size / 2;

            int[][] a11 = getSquare(A, size, 11);
            int[][] a12 = getSquare(A, size, 12);
            int[][] a21 = getSquare(A, size, 21);
            int[][] a22 = getSquare(A, size, 22);

            log+= movement + "a11=\n" + outputMatrix(a11, half, step);
            log+= movement + "a12=\n" + outputMatrix(a12, half, step);
            log+= movement + "a21=\n" + outputMatrix(a21, half, step);
            log+= movement + "a22=\n" + outputMatrix(a22, half, step);

            int[][] b11 = getSquare(B, size, 11);
            int[][] b12 = getSquare(B, size, 12);
            int[][] b21 = getSquare(B, size, 21);
            int[][] b22 = getSquare(B, size, 22);

            log += movement + "b11=\n" + outputMatrix(b11, half, step);
            log += movement + "b12=\n" + outputMatrix(b12, half, step);
            log += movement + "b21=\n" + outputMatrix(b21, half, step);
            log += movement + "b22=\n" + outputMatrix(b22, half, step);

            //Peryazev's formulas had mistakes, so I used Wikipedia formulas:)
            //Here are Peryazevs, search mistakes if you want:)
            
            /*int[][] d1 = MUL(SUM(a11, a22, half), SUM(b11, b22, half), half, ref log, step + 1);
            log += "d1=\n" + outputMatrix(d1,half) + "\n";
            int[][] d2 = MUL(SUB(a12, a22, half), SUM(b21, b22, half), half, ref log, step + 1);
            log += "d2=\n" + outputMatrix(d2, half) + "\n";
            int[][] d3 = MUL(SUB(a21, a11, half), SUM(b11, b12, half), half, ref log, step + 1);
            log += "d3=\n" + outputMatrix(d3, half) + "\n";
            int[][] d4 = MUL(SUM(a11, a12, half), b22, half, ref log, step + 1);
            log += "d4=\n" + outputMatrix(d4, half) + "\n";
            int[][] d5 = MUL(SUM(a21, a22, half), b11, half, ref log, step + 1);
            log += "d5=\n" + outputMatrix(d5, half) + "\n";
            int[][] d6 = MUL(a11, SUB(b12, b22, half), half, ref log, step + 1);
            log += "d6=\n" + outputMatrix(d6, half) + "\n";
            int[][] d7 = MUL(a22, SUB(b21, b11, half), half, ref log, step + 1);
            log += "d7=\n" + outputMatrix(d7, half) + "\n";

            int[][] c11 = SUB(SUM(d1, d2, half), SUB(d4, d7, half), half);
            int[][] c22 = SUB(SUM(d1, d3, half), SUB(d5, d6, half), half);
            int[][] c12 = SUM(d4,d6,half);
            int[][] c21 = SUM(d5,d7,half);*/

            //Wikipedia formulas

            int[][] p1 = MUL(SUM(a11, a22, half), SUM(b11, b22, half), half, ref log, step + 1);
            log += movement + "d1=(a11+a22)*(b11+b22)=\n" + outputMatrix(p1, half, step) + "\n";
            int[][] p2 = MUL(SUM(a21, a22, half), b11, half, ref log, step + 1);
            log += movement + "d2=(a21+a22)*b11=\n" + outputMatrix(p2, half, step) + "\n";
            int[][] p3 = MUL(a11, SUB(b12, b22, half), half, ref log, step + 1);
            log += movement + "d3=a11*(b12-b22)=\n" + outputMatrix(p3, half, step) + "\n";
            int[][] p4 = MUL(a22, SUB(b21, b11, half), half, ref log, step + 1);
            log += movement + "d4=a22*(b21-b11)\n" + outputMatrix(p4, half, step) + "\n";
            int[][] p5 = MUL(SUM(a11, a12, half), b22, half, ref log, step + 1);
            log += movement + "d5(a11+a12)*b22=\n" + outputMatrix(p5, half, step) + "\n";
            int[][] p6 = MUL(SUB(a21, a11, half), SUM(b11, b12, half), half, ref log, step + 1);
            log += movement + "d6=(a21-a11)*(b11+b12)=\n" + outputMatrix(p6, half, step) + "\n";
            int[][] p7 = MUL(SUB(a12, a22, half), SUM(b21, b22, half), half, ref log, step + 1);
            log += movement + "d7=(a12-a22)*(b21+b22)=\n" + outputMatrix(p7, half, step) + "\n";

            int[][] c11 = SUB(SUM(p1, p4, half), SUB(p5, p7, half), half);          
            int[][] c12 = SUM(p3, p5, half);
            int[][] c21 = SUM(p2, p4, half);
            int[][] c22 = SUB(SUM(p1, p3, half), SUB(p2, p6, half), half);

            log += movement + "c11=p1+p4-p5+p7=\n" + outputMatrix(c11, half, step);
            log += movement + "c12=p3+p5=\n" + outputMatrix(c12, half, step);
            log += movement + "c21=p2+p4=\n" + outputMatrix(c21, half, step);
            log += movement + "c22=p1-p2+p3+p6=\n" + outputMatrix(c22, half, step);

            int[][] c = gather(c11, c12, c21, c22, half);
            log += movement + "c=\n" + outputMatrix(c, size, step);
            return c;
        }

    }
}
