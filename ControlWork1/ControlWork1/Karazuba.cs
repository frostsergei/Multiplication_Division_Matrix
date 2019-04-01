using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class Karazuba
    {
        private static ulong pow(int p)
        {
            ulong numb = 1;
            for (int i = 0; i < p; i++)
                numb *= 10;
            return numb;
        }

        public static ulong KarazubaMultiplication(ulong A, ulong B, ref string log, int step)
        {
            string movement = string.Empty;
            for (int i = 0; i < step; i++) movement += "   ";

            log += movement + A + "*" + B + "\n";
            if ((A.ToString().Length == 1) || (B.ToString().Length == 1)) return A * B;

            int lengthX = A.ToString().Length;
            int lengthY = B.ToString().Length;

            int length = (lengthX<lengthY) ? (lengthX) : (lengthY);
            length /= 2;

            ulong a = A / pow(length);
            ulong b = A % pow(length);
            ulong c = B / pow(length);
            ulong d = B % pow(length);

            log += movement + "A=" + a + "*10^" + length + "+" + b + "\n";
            log += movement + "B=" + c + "*10^" + length + "+" + d + "\n";

            log += movement + "=" + b + "*" + d + "+((" + "(" + a + "+" + b + ")(" + c + "+" + d + ")" + "-" + a + "*" + c + "-" + b + "*" + d + ")*10^" + length + ")+" + a + "*" + c + "*10^" + 2 * length + "\n";

            ulong ac = KarazubaMultiplication((ulong)a, (ulong)c, ref log, step + 1);
            ulong bd = KarazubaMultiplication((ulong)b, (ulong)d, ref log, step + 1);
            ulong abcd = KarazubaMultiplication((ulong)(a+b), (ulong)(c+d), ref log, step + 1);

            ulong res = bd + ((abcd - ac - bd) * pow(length)) + (ac * pow(2*length));
            log += movement + "=" + bd + "+((" + abcd + "-" + ac + "-" + bd + ")*10^" + length + ")+" + ac + "*10^" + 2 * length + "\n";
            log += movement + "=" + res+"\n";

            return res;
        }
    }
}
