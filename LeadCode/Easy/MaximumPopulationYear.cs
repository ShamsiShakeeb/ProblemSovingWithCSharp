using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Easy
{
    public class MaximumPopulationYear
    {
        public int MaximumPopulation(int[][] logs)
        {
            List<log> logList = new List<log>();

            List<int> dob = new List<int>();

            for (int i = 0; i < logs.Length; i++)
            {
                for (int j = 0; j < logs[i].Length - 1; j++)
                {
                    dob.Add(logs[i][j]);

                    log l = new log()
                    {
                        birth = logs[i][j],
                        death = logs[i][j + 1]
                    };
                    logList.Add(l);
                }
            }

            List<answerSet> ansList = new List<answerSet>();

            int maxCounter = 0;

            for (int i = 0; i < dob.Count(); i++)
            {
                int counter = logList.Where(x => x.birth <= dob[i] && x.death > dob[i]).Count();
                maxCounter = Math.Max(maxCounter, counter);
                answerSet ans = new answerSet()
                {
                    birth = dob[i],
                    counter = counter
                };
                ansList.Add(ans);
            }

            return ansList.Where(x => x.counter == maxCounter).OrderBy(x => x.birth).Select(x => x.birth).FirstOrDefault();
        }
    }
}
public class log
{
    public int birth { set; get; }
    public int death { set; get; }
}

public class answerSet
{
    public int birth { set; get; }
    public int counter { set; get; }
}
