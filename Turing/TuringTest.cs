using System;
using System.Collections.Generic;
using System.Linq;

namespace Turing
{
    public class TuringTest
    {
        public static string ReverseOnlyLetters(string s)
        {
            char[] a = s.ToCharArray();
            string[] b = new string[a.Length];
            List<int> value = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                bool svr = false;
                if ((a[i] >= 'a') && (a[i] <= 'z'))
                {
                    svr = true;
                }
                else if ((a[i] >= 'A') && (a[i] <= 'Z'))
                {
                    svr = true;
                }
                if (!svr)
                {
                    b[i] = a[i] + "";
                }
                else
                {
                    value.Add(i);
                }
            }
            value = value.OrderByDescending(x => x).ToList();
            int j = 0;
            foreach (int x in value)
            {
                for (; ; )
                {
                    if (b[j] == null) break;
                    j++;
                }
                b[j] = a[x] + "";
                j++;
            }


            return string.Join("", b);
        }
    }
}
