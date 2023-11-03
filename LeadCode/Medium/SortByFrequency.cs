using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class SortByFrequency
    {
        public class Scanner
        {
            public string nextLine()
            {
                return Console.ReadLine();
            }
            public string next()
            {
                return Console.ReadLine().Split(' ')[0];
            }
            public int nextInt()
            {
                return Convert.ToInt32(Console.ReadLine().Split(' ')[0]);
            }
            public long nextLong()
            {
                return Convert.ToInt64(Console.ReadLine().Split(' ')[0]);
            }
            public double nextDouble()
            {
                return Convert.ToDouble(Console.ReadLine().Split(' ')[0]);
            }
            public float nextFloat()
            {
                return float.Parse(Console.ReadLine().Split(' ')[0]);
            }
            public string[] nextStringArray()
            {
                return Console.ReadLine().Split(' ');
            }
            public int[] nextIntegerArray()
            {
                return Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            }
            public double[] nextDoubleArray()
            {
                return Array.ConvertAll(Console.ReadLine().Split(' '), s => double.Parse(s));
            }
            public float[] nextFloatArray()
            {
                return Array.ConvertAll(Console.ReadLine().Split(' '), s => float.Parse(s));
            }
        }

        public class Counter
        {
            public int count { set; get; }
            public char value { set; get; }
        }
        public void ans()
        {
            Scanner inc = new Scanner();
            string s = inc.next();
            char[] a = s.ToCharArray();
            Array.Sort(a);

            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < a.Length; i++)
            {
                try
                {
                    dict[a[i]] = dict[a[i]] + 1;
                }
                catch (Exception e)
                {
                    dict[a[i]] = 1;
                }
            }

            var keySet = dict.Keys;

            List<Counter> counters = new List<Counter>();

            foreach (var k in keySet)
            {
                var m = new Counter()
                {
                    count = dict[k],
                    value = k
                };
                counters.Add(m);
            }
            var res = (from b in counters.OrderByDescending(x => x.count)
                       select new
                       {
                           b.value
                       }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var r in res)
            {
                var c = dict[r.value];
                for (int i = 0; i < c; i++)
                {
                    sb.Append(r.value);
                }
            }
            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }
    }
}
