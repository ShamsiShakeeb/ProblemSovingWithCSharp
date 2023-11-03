using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DP
{
    public class SubsetFinder
    {
        public IList<IList<int>> Subsets(int[] arr, string error="TLE")
        {
            List<int> indecis = new List<int>();
            for(int i = 0; i < arr.Length; i++)
            {
                indecis.Add(i);
            }

            int[] brr = indecis.ToArray();

            if (arr.Length == 1)
            {
                var res = new List<IList<int>>();
                res.Add(new List<int>() { arr[0]});
                res.Add(new List<int>());
                return (IList<IList<int>>)res;
            }

            for (int i = 0; i < brr.Length; i++)
            {
                List<int> pattern = new List<int>();

                for (int j = 0; j < brr.Length; j++)
                {
                    if (i != j) pattern.Add(brr[j]);
                }

                Subset(brr[i].ToString(), pattern.ToArray(), brr.Length,i);
            }

            List<string> temp = new List<string>(ans);
            ans = new List<string>();

            var answer = new List<IList<int>>();

            for(int i = 0; i < temp.Count; i++)
            {
                var split = temp[i].Split(' ');
                List<int> sub = new List<int>();
                foreach(var x in split)
                {
                    sub.Add(arr[Convert.ToInt32(x)]);
                }
                answer.Add(sub);
            }
            answer.Add(new List<int>());
            return (IList<IList<int>>) answer;

        }
        private static List<string> ans = new List<string>();
        private static void Subset(string value, int[] pattern, int size , int index)
        {
            if (value.Split(' ').Length >= size) return;
           
            var data = value.ToString().Split(' ');
            Array.Sort(data);

            if (!ans.Contains(string.Join(" ", data)))
                ans.Add(string.Join(" ", data));

            for (int i = index; i < pattern.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(value + " ");
                if (!sb.ToString().Contains(pattern[i].ToString()))
                {
                    sb.Append(pattern[i]);
                    data = sb.ToString().Split(' ');
                    Array.Sort(data);
                    if (!ans.Contains(string.Join(" ", data)))
                        ans.Add(string.Join(" ", data));
                    Subset(string.Join(" ", data), pattern, size,i);
                }

            }
        }
    }
}
