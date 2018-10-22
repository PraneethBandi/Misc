using System;
using System.Collections.Generic;
using System.Text;

namespace Prep
{
    public class Math
    {
        //give x and y the x*y == GCD*LCD
        // gcd = small number which divdes both
        //lcm = big number whose multiples contains both
        public int findGCD(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            if (a == b)
                return a;

            if (a > b)
                return findGCD(a - b, b);
            return findGCD(a, b - a);

            //using modulo

            if (a == 0)
                return b;

            return findGCD(b % a, a);
        }

        public int findLCM(int a, int b)
        {
            return (a * b) / findGCD(a, b);
        }

        public int[] findPrimes(int n)
        {
            return null;
        }

        public bool IsPrime(int n)
        {
            return false;
        }
    }
}
