using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEular
{
    public class Euler29
    {
        public void Solution()
        {
            BigInteger l = 2, h = 100;
            int exl = 2, exh = 100;

            List<BigInteger> values = new List<BigInteger>();

            for (BigInteger i = l; i <= h; i++)
            {
                for (int j = exl; j <= exh; j++)
                {
                    BigInteger val = BigInteger.Pow(i, j);
                    values.Add(val);
                }
            }

            int ans = values.Distinct().Count();
            Console.WriteLine(ans);
        }
    }
}
