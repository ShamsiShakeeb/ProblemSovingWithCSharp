using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class LargestPalindromicSubArray
    {

        #region TLE
        class data
        {
            public int length { set; get; }
            public string value { set; get; }
        }
        public static string LongestPalindrome(string s)
        {
            char[] a = s.ToCharArray();
            List<data> list = new List<data>();
            for (int i = 0; i < a.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(a[i]);
                var model = new data()
                {
                    length = sb.ToString().Length,
                    value = sb.ToString()
                };
                list.Add(model);

                for (int j = i + 1; j < a.Length; j++)
                {
                    sb.Append(a[j]);
                    if (isPalindrome(sb.ToString()))
                    {
                        model = new data()
                        {
                            length = sb.ToString().Length,
                            value = sb.ToString()
                        };
                        list.Add(model);
                    }
                }
            }
            var ans = list.OrderByDescending(x => x.length).Select(x => x.value).FirstOrDefault();


            return ans;
        }
        public static bool isPalindrome(string x)
        {
            char[] a = x.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != a[a.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Accepted Sliding Window https://www.youtube.com/watch?v=pVs1RjhmHwU&t=286s

        public string LongestPalindromeAccepted(string s)
        {
            char[] a = s.ToCharArray();
            int max = 1;
            string ans = "";

            for (int i = 0; i < a.Length; i++)
            {
                StringBuilder build = new StringBuilder();
                StringBuilder builder = new StringBuilder();

                bool first = true;
                bool odd = true, even = true;

                for (int j = i, k = i - 1, x = i; j < a.Length; j++)
                {
                    //odd
                    if (first)
                    {
                        build.Append(a[j]);
                        first = false;
                    }
                    if (k >= 0 && j + 1 < a.Length && a[k] == a[j + 1] && odd)
                    {
                        build.Insert(0, a[k]);
                        build.Append(a[j + 1]);
                        k--;
                        if (max < build.Length)
                        {
                            max = build.Length;
                            ans = build.ToString();
                        }
                    }
                    else
                    {
                        odd = false;
                        build = new StringBuilder(); first = true;

                    }
                    ///even
                    if (x >= 0 && j + 1 < a.Length && a[x] == a[j + 1] && even)
                    {
                        builder.Insert(0, a[x]);
                        builder.Append(a[j + 1]);
                        x--;
                        if (max < builder.Length)
                        {
                            max = builder.Length;
                            ans = builder.ToString();
                        }
                    }
                    else
                    {
                        even = false;
                    }

                    if (!even && !odd) break;
                }
            }
            return max == 1 ? a[0] + "" : ans;
        }

        #endregion
    }
}
