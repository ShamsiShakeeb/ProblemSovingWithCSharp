using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEular
{
    public class Resilience
    {
        #region eular prime seive

        static int MAX = 100001;
        static List<int> p = new List<int>();
        static List<int> np = new List<int>();
        static int[] isPrimes;
        static void sieve()
        {
            isPrimes = new int[MAX + 1];

            for (int i = 2; i <= MAX; i++)
            {
                // if prime[i] is not marked before 
                if (isPrimes[i] == 0)
                {
                    // fill vector for every newly 
                    // encountered prime 
                    p.Add(i);

                    // run this loop till square root of MAX, 
                    // mark the index i * j as not prime 
                    for (int j = 2; i * j <= MAX; j++)
                    {
                        isPrimes[i * j] = 1;
                        np.Add(i * j);
                    }
                }
            }
        }
        #endregion

        #region euler totient
        /// <summary>
        /// Both Method are fast to calculate euler totient
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long phi(long n)
        {
            long res = n;

            // this loop runs sqrt(n / ln(n)) times 
            for (int i = 0; (int)p[i] * (int)p[i] <= n; i++)
            {
                if (n % (int)p[i] == 0)
                {
                    // subtract multiples of p[i] from r 
                    res -= (res / (int)p[i]);

                    // Remove all occurrences of p[i] in n 
                    while (n % (int)p[i] == 0)
                        n /= (int)p[i];
                }
            }

            // when n has prime factor greater 
            // than sqrt(n) 
            if (n > 1)
                res -= (res / n);

            return res;
        }
        static long CalculatePhi(long d)
        {
            long phi = d;
            long maxFactor = (long)Math.Sqrt(d);
            for (int p = 2; p <= maxFactor; p++)
            {
                if (d % p == 0)
                {
                    while (d % p == 0)
                    {
                        d /= p;
                    }
                    phi -= phi / p;
                }
            }
            if (d > 1)
            {
                phi -= phi / d;
            }
            return phi;
        }

        #endregion
        /// <summary>
        /// https://blog.dreamshire.com/project-euler-243-solution/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public long projectEular243(int a, int b)
        {
            //MAX = 100001;
            //p = new List<int>();
            //np = new List<int>();
            //isPrimes = new int[MAX + 1];
            sieve();
            np = np.OrderBy(x => x).Distinct().ToList();
            double targetRatio = (double)a / (double)b;
            long product = 1;
            for (int i = 0; ; i++)
            {
                product *= p[i];
                long ph = phi(product);
                double ratio = (double)ph / (double)(product - 1);
                if (ratio < targetRatio)
                {
                    product = product / p[i];
                    for (int j = 0; ; j++)
                    {
                        product *= np[j];

                        long phs = phi(product);
                        ratio = (double)phs / (double)(product - 1);

                        if (ratio < targetRatio)
                        {
                            return product;
                            //break;
                        }
                    }
                   // break;
                }
            }
        }
    }
}
