using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class CountNumberofTeams
    {
        public int NumTeams(int[] rating)
        {
            graterDatas = new List<graterData>();
            lesserDatas = new List<lesserData>();
            return NumTeam(rating);
        }
        public static List<graterData> graterDatas;
        public static List<lesserData> lesserDatas;
        public class graterData
        {
            public int root { set; get; }
            public int next { set; get; }

        }
        public class lesserData
        {
            public int root { set; get; }
            public int next { set; get; }

        }
        public int NumTeam(int[] ratings)
        {
            for (int i = 0; i < ratings.Length; i++)
            {
                for (int j = i + 1; j < ratings.Length; j++)
                {
                    if (ratings[i] < ratings[j])
                    {

                        var model = new graterData()
                        {
                            root = i,
                            next = j
                        };
                        graterDatas.Add(model);
                    }
                    else if (ratings[i] > ratings[j])
                    {
                        var model = new lesserData()
                        {
                            root = i,
                            next = j
                        };
                        lesserDatas.Add(model);
                    }
                }
            }

            int count = 0;

            foreach (var x in graterDatas)
            {
                int p = ratings[x.next];

                for (int i = x.next; i < ratings.Length - 1; i++)
                {
                    if (p < ratings[i + 1])
                    {
                        count++;
                    }
                }
            }
            foreach (var x in lesserDatas)
            {
                int p = ratings[x.next];

                for (int i = x.next; i < ratings.Length - 1; i++)
                {
                    if (p > ratings[i + 1])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
