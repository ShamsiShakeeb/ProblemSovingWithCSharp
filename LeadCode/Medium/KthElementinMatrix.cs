using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class KthElementinMatrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                List<int> tempList = new List<int>();

                for (int j = 0; j < matrix[0].Length; j++)
                {
                    tempList.Add(matrix[i][j]);
                }
                list.AddRange(tempList);
                list.Sort();
            }
            return list.ElementAt(k - 1);
        }
    }
}
