using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class MinimumMoves
    {
        public int[] MinOperations(string boxes)
        {
            List<int> answer = new List<int>();

            char[] a = boxes.ToCharArray();

            List<int> track = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '1')
                {
                    track.Add(i);
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                int sum = 0;

                for (int j = 0; j < track.Count(); j++)
                {
                    sum += Math.Abs(i - track[j]);
                }
                answer.Add(sum);
            }
            return answer.ToArray();
        }
    }
}
