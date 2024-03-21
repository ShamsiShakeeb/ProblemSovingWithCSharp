using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEular
{
    public class Euler30
    {
        bool equalPower(long value, int power)
        {
            char[] a = value.ToString().ToCharArray();

            long sum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                sum += (long)Math.Pow(Convert.ToInt64(a[i] + ""), power);
            }

            return sum == value;
        }

        public void Solution()
        {
            int power = 5;
            long start = (long)Math.Pow(10, 1);
            long end = (long)Math.Pow(10, 6);
            long ans = 0;
            for (long i = start; i < end; i++)
            {
                if (equalPower(i, power))
                {
                    ans += i;
                }
            }
            Console.WriteLine(ans);
        }
    }
}
