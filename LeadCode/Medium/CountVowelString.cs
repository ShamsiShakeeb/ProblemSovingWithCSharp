using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class CountVowelString
    {
        static int ans = 0;
        public static int CountVowelStrings(int n, string error = "Time Limit Exit")
        {
            char[] v = { 'a', 'e', 'i', 'o', 'u' };
            foreach (var e in v)
            {
                vowalCount(e.ToString(), n);
            }
            return ans;
        }
        static int vowalCount(string x, int n)
        {
            if (n == 1) { ans = 5; return 5; }

            if (x.Length == n)
            {
                ans += 1;
                return 1;
            }

            char[] v = { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < v.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(x.ToString());
                sb.Append(v[i].ToString());
                if (x.ElementAt(x.Length - 1) <= v[i])
                    vowalCount(sb.ToString(), n);
            }
            return ans;
        }
        public int CountVowelStrings(int n)
        {
            if (n == 1) return 5;
            if (n == 2) return 15;
            List<int> pattern = new List<int>() { 5, 4, 3, 2, 1 };

            int ans = 0;

            for (int k = 2; k < n; k++)
            {

                List<int> Temppattern = new List<int>();

                for (int i = 0; i < pattern.Count; i++)
                {
                    int sum = 0;

                    for (int j = i; j < pattern.Count; j++)
                    {
                        sum += pattern[j];
                    }

                    Temppattern.Add(sum);
                }
                pattern = Temppattern;
                ans = 0;

                foreach (var e in Temppattern)
                {
                    ans += e;
                }

                Temppattern = new List<int>();
            }

            return ans;
        }
    }
}
