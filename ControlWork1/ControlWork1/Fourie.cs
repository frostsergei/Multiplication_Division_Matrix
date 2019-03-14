using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlWork1
{
    class Fourie
    {
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static long pow(int p)
        {
            long numb = 1;
            for (int i = 0; i < p; i++)
                numb *= 10;
            return numb;
        }

        private static int[] Digits(String str)
        {
            int[] res = str.Select(c => c - '0').ToArray();
            return res;
        }

        public static string FourieMultiplication(string A, string B, ref string log)
        {
            string A_reserve = A;
            string B_reserve = B;

            log = A + " * " + B + " = \n_______________________________________\n";
            //Swap strings if b is longer then a
            if (B.Length > A.Length) { string temp = A; A = B; B = temp; }

            //Add zeros to biger string
            string zeros = string.Empty;
            for (int i = 0; i < B.Length; i++) zeros += "0";
            A = zeros + A + zeros;

            //Reverse string for the required operation
            A = Reverse(A);

            log += A + "\n" + B + "\n";

            // Represent strings as digits arrays
            int[] a = Digits(A);
            int[] b = Digits(B);

            //CALCULATIONS
            ulong result = 0;
            for (int i = 1; i < a.Length - b.Length; i++)
            {
                ulong sum = 0;
                for (int j = 0; j < b.Length; j++)
                {
                    ulong t1 = (ulong)Convert.ToInt64(a[j + i]);
                    ulong t2 = (ulong)Convert.ToInt64(b[j]);
                    ulong r = t1 * t2;
                    sum += r;
                }
                result += sum * (ulong)pow(i);

                string movement = string.Empty;
                for (int k = 0; k < (a.Length - i - sum.ToString().Length); k++)
                {
                    movement += "0";
                }
                log += movement + sum + "\n";
            }
            //Return result div 10, due to addidion requirements
            log += "\n" + A_reserve + " * " + B_reserve + " = " + result / 10 + "\n";
            return (result / 10).ToString();
        }
    }
}
