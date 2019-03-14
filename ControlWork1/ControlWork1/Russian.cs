using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWork1
{
    class Russian
    {
        public static string RussianMultiplication(ulong A, ulong B, ref string log)
        {
            ulong A_reserve = A;
            ulong B_reserve = B;

            log = A + " * " + B + " = \n________________________________________\n";
            //Swap if b is bigger then a
            if (B > A) { ulong temp = A; A = B; B = temp; }


            //CALCULATIONS
            ulong sum = 0;
            while (B > 1)
            {
                log += B + " * " + A + " ";
                if (B % 2 != 0) { sum += A; --B; log += " | +" + A + "\n"; }
                else { log += "\n"; }
                B /= 2;
                A *= 2;
            }
            log += "1 * " + A + " | +" + A + "\n";
            A += sum;

            //Return string result
            log += "\n" + A_reserve + " * " + B_reserve + " = " + A + "\n";
            return A.ToString();
        }
    }
}
