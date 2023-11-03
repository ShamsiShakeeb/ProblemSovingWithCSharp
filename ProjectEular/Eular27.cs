using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEular
{
    public class Eular27
    {
        #region QuadraticPrimes

        public static bool isPrime(long n)
        {
            n = Math.Abs(n);

            long squrt = (long)Math.Pow(n, 0.5);

            for (int i = 2; i <= squrt; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static int QuadraticPrimes(int a, int b)
        {
            int count = 0;

            for (int n = 0; ; n++)
            {
                long form = (n * n) + (a * n) + (b);

                if (isPrime(form))
                {
                    count++;
                }
                else break;
            }
            return count;
        }
        public static long Euler27()
        {
            int max = 0;
            int product = 0;

            for (int a = -999; a <= 999; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    int count = QuadraticPrimes(a, b);

                    if (max < count)
                    {
                        max = count;
                        product = a * b;
                    }

                }
            }

            return product;
        }

        #endregion
    }
}
