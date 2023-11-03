using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Easy
{
    public class LongestCommonPrefixSolution
    {
        public class data
        {
            public int size { set; get; }
            public string value { set; get; }
        }
        public string LongestCommonPrefix(string[] strs)
        {
            char[] a = strs[0].ToCharArray();

            StringBuilder sb = new StringBuilder();

            List<data> list = new List<data>();

            for (int i = 0; i < a.Length; i++)
            {
                sb.Append(a[i]);
                var model = new data()
                {
                    size = sb.ToString().Length,
                    value = sb.ToString()
                };
                list.Add(model);
            }
            var l = list.OrderByDescending(x => x.size).ToList();

            for (int j = 0; j < l.Count(); j++)
            {
                bool svr = true;
                for (int i = 1; i < strs.Length; i++)
                {
                    string x = strs[i];
                    if (!x.StartsWith(l[j].value))
                    {
                        svr = false;
                        break;
                    }
                }
                if (svr)
                    return l[j].value;
            }
            return "";


        }
    }
}
