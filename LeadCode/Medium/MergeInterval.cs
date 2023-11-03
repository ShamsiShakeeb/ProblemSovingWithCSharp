using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class MergeInterval
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=44H3cEC2fFM&t=203s
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int[][] Merge(int[][] intervals)
        {
            List<ovLap> ovLaps = new List<ovLap>();
            for (int i = 0; i < intervals.GetLength(0); i++)
            {
                ovLap model = new ovLap();
                model.start = intervals[i][0];
                model.end = intervals[i][1];
                ovLaps.Add(model);
            }
            ovLaps = ovLaps.OrderBy(x => x.start).ToList();
            for (int i = 0; i < ovLaps.Count - 1; i++)
            {
                if (ovLaps[i].end >= ovLaps[i + 1].start)
                {
                    ovLap model = new ovLap();
                    model.start = ovLaps[i].start;
                    model.end = Math.Max(ovLaps[i + 1].end, ovLaps[i].end);
                    ovLaps.RemoveAt(i);
                    ovLaps.RemoveAt(i);
                    ovLaps.Insert(i, model);
                    i--;
                }
            }

            List<int[]> ans = new List<int[]>();

            for (int i = 0; i < ovLaps.Count; i++)
            {
                int[] a = new int[2];
                a[0] = ovLaps[i].start;
                a[1] = ovLaps[i].end;
                ans.Add(a);
            }
            return ans.ToArray();
        }
    }
}
public class ovLap
{
    public int start { set; get; }
    public int end { set; get; }
}
