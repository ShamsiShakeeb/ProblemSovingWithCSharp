using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEular
{
    public class SmallestMultiple
    {
        public void Answer()
        {
            long mul = 1;

            List<int> track = new List<int>();

            for (int i = 2; i <= 20; i++)
            {
                if (isPrime(i))
                {
                    mul *= i;
                    track.Add(i);
                }
                else if (mul % i != 0)
                {
                    var divisor = primeDivisor(i);
                    var uniqueDivisor = primeDivisor(i).Distinct();

                    foreach (var e in uniqueDivisor)
                    {
                        var divisorCount = divisor.Where(x => x == e).ToList().Count();
                        var trackDivisorCount = track.Where(x => x == e).ToList().Count();

                        for (int j = 0; j < (divisorCount - trackDivisorCount); j++)
                        {
                            mul *= e;
                            track.Add(e);
                        }
                    }

                }
                Console.WriteLine("K = {0} where N= {1} ", i, mul);
            }
        }
        static bool isPrime(int value)
        {
            if (value == 1) return false;
            if (value == 2) return true;

            int range = (int)Math.Pow(value, 0.5) + 1;

            for (int i = 2; i <= range; i++)
            {
                if (value % i == 0) return false;
            }
            return true;
        }
        static List<int> primeDivisor(int value)
        {
            int range = (int)Math.Pow(value, 0.5) + 1;

            List<int> divisor = new List<int>();

            for (int i = 2; i <= range;)
            {
                if (isPrime(i))
                {
                    if (value % i == 0)
                    {
                        value = value / i;
                        divisor.Add(i);
                        range = (int)Math.Pow(value, 0.5) + 1;
                    }
                    else i++;
                }
                else i++;
            }
            if (value > 1) divisor.Add(value);
            return divisor;
        }
    }
}
