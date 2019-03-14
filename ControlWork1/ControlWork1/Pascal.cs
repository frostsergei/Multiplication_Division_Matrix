using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class Pascal
    {
        private ulong[] c;

        public Pascal(ulong n, ulong p, ref string log)
        {
            ulong[] temp = new ulong[n.ToString().Length];
            temp[0] = 1;
            log += "Вычисление делителей: \nc[0]=1\n";
            for (int i = 1; i < n.ToString().Length; i++)
            {
                temp[i] = pow(i) % p;
                log += "c[" + i + "]=" + temp[i] + "\n";
            }
            log += "\n";
            c = temp;
        }

        private ulong pow(long n)
        {
            ulong res = 1;
            for (long i = 0; i < n; i++)
                res *= 10;
            return res;
        }

        private ulong[] toLongArray(ulong number)
        {
            ulong a = number;
            List<ulong> l = new List<ulong>();
            while (a > 0)
            {
                l.Add(a % 10);
                a = a / 10;
            }
            return l.ToArray();
        }

        public bool PascalDiv(ulong n, ulong p, ref string log)
        {
            log += n + " / " + p + " <=>\n";

            if ((n == p) || (n == 0)) { log += "Делится!"; return true; }
            if (n < p) { log += "Не делится!"; return false; }

            ulong[] digits = toLongArray(n);

            ulong sum = 0;
            log += "(";
            for (int i = 0; i < n.ToString().Length; i++)
            {
                log += digits[i] + "*" + c[i];
                if (i < n.ToString().Length - 1) log += "+";
                sum += (ulong)digits[i] * c[i];
            }
            log += ")/" + p + "<=>\n";

            ulong next = sum;
            if (next == n) { log += "Цикл! Далее можно решать другим методом."; return false; }

            return PascalDiv(next, p, ref log);

        }
    }
}
