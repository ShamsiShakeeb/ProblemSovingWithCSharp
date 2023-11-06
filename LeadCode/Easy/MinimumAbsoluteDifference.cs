using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Easy
{
    public class MinimumAbsoluteDifference
    {
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            List<int> list = arr.OrderBy(x => x).ToList(); // O(n log n)

            int minDif = int.MaxValue;

            List<data> dataSet = new List<data>();

            //O(n)
            for (int i = 0; i < list.Count() - 1; i++)
            {
                int dif = Math.Abs(list[i] - list[i + 1]);
                minDif = Math.Min(dif, minDif);
                data model = new data()
                {
                    value1 = list[i],
                    value2 = list[i + 1],
                    dif = dif
                };

                dataSet.Add(model);
            }

            List<IList<int>> ans = new List<IList<int>>();

            //O(n)
            for (int i = 0; i < dataSet.Count(); i++)
            {
                List<int> answerSet = new List<int>();

                if (dataSet[i].dif == minDif)
                {
                    answerSet.Add(dataSet[i].value1);
                    answerSet.Add(dataSet[i].value2);
                    ans.Add(answerSet);
                }
            }
            //O(n log n) + O(n) + O(n) = O(n log n) + O(2n) = O(n log n) + O(n)
            return ans;
        }
    }
}
public class data
{
    public int value1 { set; get; }
    public int value2 { set; get; }

    public int dif { set; get; }
}
