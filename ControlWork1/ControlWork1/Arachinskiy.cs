using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class Arachinskiy
    {
        public static bool Ar1(long n, long p, ref string log)
        {
            log += n + " / " + p + " <=>\n";

            if ((n == p) || (n == 0)) { log += "Делится!"; return true; }
            if (n < p) { log += "Не делится!"; return false; }

            long a = n / 10;
            long b = n % 10;

            long m = p / 10;
            long k = p % 10;

            log += "|" + a + "*" + k + "-" + m + "*" + b + "|/" + p + "<=>\n";

            long next = Math.Abs(a * k - m * b);
            if (next == n) { log += "Цикл!"; return false; }

            return Ar1(next, p, ref log);
        }

        public static bool Ar2(long n, long p, long q, ref string log)
        {
            log += n + " / " + p + " <=>\n";

            if ((n == p) || (n == 0)) { log += "Делится!"; return true; }
            if (n < p) { log += "Не делится!"; return false; }

            long a = n / 10;
            long b = n % 10;

            long m = p / 10;
            long k = p % 10;

            log += "(" + a + "+" + b + "*" + q + ")/" + p + "<=>\n";

            long next = a + q * b;
            if (next == n) { log += "Цикл!"; return false; }

            return Ar2(next, p, q, ref log);
        }

        public static bool Ar3(long n, long p, long qs, ref string log)
        {
            log += n + " / " + p + " <=>\n";

            if ((n == p) || (n == 0)) { log += "Делится!"; return true; }
            if (n < p) { log += "Не делится!"; return false; }

            long a = n / 10;
            long b = n % 10;

            long m = p / 10;
            long k = p % 10;

            log += "|-" + a + "+" + b + "*" + qs + "|/" + p + "<=>\n";

            long next = Math.Abs(-a + qs * b);
            if (next == n) { log += "Цикл!"; return false; }

            return Ar3(next, p, qs, ref log);
        }
    }
}
