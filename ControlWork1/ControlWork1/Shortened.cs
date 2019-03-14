using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWork1
{
    class Shortened
    {
        private static long pow(int p)
        {
            long numb = 1;
            for (int i = 0; i < p; i++)
                numb *= 10;
            return numb;
        }

        private static int[] Digits(string str)
        {
            int[] res = str.Select(c => c - '0').ToArray();
            return res;
        }

        private static string toDigitString(int n)
        {
            return (((n < 10) || (n > -10)) ? ("0" + n.ToString()) : (n.ToString()));
        }

        public static string ShortMultiplication(string A, string B, ref string log)
        {
            string A_reserve = A;
            string B_reserve = B;

            log = A + " * " + B + " = \n_______________________________________\n";
            //Swap strings if b is longer then a
            if (B.Length > A.Length) { string temp = A; A = B; B = temp; }

            //Add zeros to biger string
            string zeros = string.Empty;
            for (int i = 0; i < A.Length - B.Length; i++) zeros += "0";
            B = zeros + B;

            log += A + "\n" + B + "\n";

            // Represent strings as digits arrays
            int[] a = Digits(A);
            int[] b = Digits(B);

            //CALCULATIONS
            ulong result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result *= 100;
                result += (ulong)a[i] * (ulong)b[i];
            }

            string r = result.ToString();
            while (r.Length < 2 * a.Length) { r = "0" + r; }
            log += r + "\n";

            for (int i = 1; i < a.Length; i++)
            {
                ulong sum = 0;
                for (int j = 0; j < b.Length - i; j++)
                {
                    ulong t11 = (ulong)Convert.ToInt64(a[j + i]);
                    ulong t12 = (ulong)Convert.ToInt64(b[j]);
                    ulong t21 = (ulong)Convert.ToInt64(b[j + i]);
                    ulong t22 = (ulong)Convert.ToInt64(a[j]);
                    ulong rt = t11 * t12 + t21 * t22;
                    sum *= 100;
                    sum += rt;
                }
                string tr = sum.ToString();
                while (tr.Length < (2 * a.Length - i)) { tr = "0" + tr; }
                log += tr + "\n";

                result += sum * (ulong)pow(i);
            }
            log += "\n" + A_reserve + " * " + B_reserve + " = " + result + "\n";
            return (result).ToString();
        }
    }
}
