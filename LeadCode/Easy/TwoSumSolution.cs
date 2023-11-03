using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Easy
{
    public class TwoSumSolution
    {
        public class data
        {
            public int index { set; get; }
            public int value { set; get; }
        }
        public int[] TwoSum(int[] nums, int target)
        {
            int[] ans = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        ans[0] = i;
                        ans[1] = j;
                        return ans;

                    }
                }

            }
            return ans;
        }
    }
}
