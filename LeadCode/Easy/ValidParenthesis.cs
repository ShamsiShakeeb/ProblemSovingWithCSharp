using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Easy
{
    public static class ValidParenthesis
    {
        public static bool IsValid(this string s)
        {
            char[] a = s.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict['('] = 1; dict[')'] = -1; dict['{'] = 2; dict['}'] = -2; dict['['] = 3; dict[']'] = -3;
            List<int> pos = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (dict[a[i]] > 0)
                {
                    pos.Add(dict[a[i]]);
                }
                else
                {
                    if (pos.Count == 0) return false;

                    var p = pos[pos.Count - 1];
                    if (p == (dict[a[i]] * -1))
                    {
                        pos.RemoveAt(pos.Count - 1);
                    }
                    else return false;
                }
            }

            return pos.Count() == 0;
        }
    }
}
