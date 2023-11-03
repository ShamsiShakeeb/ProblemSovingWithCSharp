

///TLE
















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class RankByTeams
    {
        public int NumTeams(int[] rating)
        {
            datas = new List<data>();

            for (int i = 0; i < rating.Length; i++)
            {
                var model = new data()
                {
                    index = i,
                    value = rating[i]
                };
                datas.Add(model);
            }
            return NumTeam(rating);
        }
        public static List<data> datas;
        public class data
        {
            public int index { set; get; }
            public int value { set; get; }
        }
        public int NumTeam(int[] ratings)
        {
            int count = 0;

            for (int i = 0; i < ratings.Length; i++)
            {
                for (int j = i + 1; j < ratings.Length; j++)
                {
                    if (ratings[i] < ratings[j])
                    {
                        var subCount = datas.Where(x => x.index > j && x.value > ratings[j]).Select(x => x.index).Count();
                        count += subCount;
                    }

                    if (ratings[i] > ratings[j])
                    {
                        var subCount = datas.Where(x => x.index > j && x.value < ratings[j]).Select(x => x.index).Count();
                        count += subCount;
                    }
                }
            }
            return count;
        }
    }
}
