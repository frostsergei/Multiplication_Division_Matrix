using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class Unnamed
    {
        private ulong[] c;
        int step = 3;

        public Unnamed(ulong n, ulong p, ref string log)
        {
            ulong[] temp = new ulong[n.ToString().Length];
            temp[0] = 1;
            log += "Вычисление делителей: \nc[0]=1\n";
            for (long i = 1; i < n.ToString().Length; i++)
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

        private long[] toLongArray(long number)
        {
            long a = number;
            List<long> l = new List<long>();
            while (a > 0)
            {
                l.Add(a % 10);
                a = a / 10;
            }
            return l.ToArray();
        }

        public bool UnnamedDiv(ulong n, ulong p, ref string log)
        {
            log += n + " / " + p + " <=>\n";

            if ((n == p) || (n == 0)) { log += "Делится!"; return true; }
            if (n < p) { log += "Не делится!"; return false; }


            log += "Шаг деления = " + step + "\n";


            ulong sum = 0;
            if ((n >= pow(step)))
            {
                ulong first = n / pow(step);
                ulong second = n - first * pow(step);

                sum = first * c[step] + second;
                log += "(" + first + "*" + c[step] + "+" + second + ")/" + p + "<=>\n";
            }
            else { step--; return UnnamedDiv(n, p, ref log); }

            ulong next = sum;
            if ((next == n) || (step == 1)) { log += "Цикл! Далее можно решать другим методом."; return false; }

            return UnnamedDiv(next, p, ref log);

        }
    }
}
