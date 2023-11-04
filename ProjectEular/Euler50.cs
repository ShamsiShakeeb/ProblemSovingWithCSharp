using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEular
{
    public class Euler50
    {
        #region bruteForce
        public List<long> seive()
        {
            int max = (int)Math.Pow(10, 6);

            Dictionary<long, long> isPrime = new Dictionary<long, long>();

            long sumPrime = 0;

            List<long> prime = new List<long>();

            for (long i = 2; i <= max; i++)
            {
                long value;

                bool exist = isPrime.TryGetValue(i, out value);

                if (!exist)
                {
                    sumPrime += i;

                    prime.Add(i);

                    for (long j = 2; i * j <= max; j++)
                    {
                        isPrime[i * j] = 1;
                    }
                }
            }

            return prime;
        }

        public bool isPrime(long n)
        {
            long squrt = (long)Math.Pow(n, 0.5) + 1;

            for (long i = 2; i <= squrt; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public long ProjectEuler50(long limit)
        {
            var primeList = seive();

            int maxCount = 0;

            long maxSum = 0;

            for (int i = 0; i < primeList.Count(); i++)
            {
                int count = 0;

                long sum = 0;

                if (limit < primeList[i])
                    break;

                for (int j = i; j < primeList.Count(); j++)
                {
                    sum += primeList[j];

                    if (sum > limit)
                        break;

                    if (isPrime(sum))
                    {
                        count = (j - i) + 1;

                        if (maxCount < count)
                        {
                            maxCount = count;
                            maxSum = sum;
                        }
                    }
                }
            }
            Console.WriteLine(maxCount);
            return maxSum;
        }
        #endregion
    }
}
