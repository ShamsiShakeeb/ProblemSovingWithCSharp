using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public static class LengthOfLongestCommonSubstringSolution
    {
        public static int LengthOfLongestSubstring(this string s)
        {
            char[] a = s.ToCharArray();
            var dict = new Dictionary<char, int?>();
            int count = 0;
            int max = 0;
            for (int i = 0, j = 0; i < a.Length; i++)
            {
                int? value;
                dict.TryGetValue(a[i], out value);
                if (value == null)
                    dict[a[i]] = 1;
                else
                    dict[a[i]]++;

                if (dict[a[i]] > 1)
                {
                    count--;
                    dict[a[i]]--;
                    dict[a[j]]--;
                    i--;
                    j++;
                    max = Math.Max(count, max);
                }
                else
                {
                    count++;
                    max = Math.Max(count, max);
                }
            }
            return max;
        }
    }
}
