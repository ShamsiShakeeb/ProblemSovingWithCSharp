using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class MaximumSubArray
    {
        public int MaxSubArray(int[] nums)
        {
            int sum = 0;
            var y = nums.ToList().Where(x => x > 0).ToList();
            var isPos = y.Count() != 0;
            if (!isPos)
            {
                return nums.ToList().Select(x => x).OrderByDescending(x => x).FirstOrDefault();
            }
            List<int> ans = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (isPos && sum < 0)
                {
                    sum = 0;
                }
                ans.Add(sum);
            }
            return ans.Select(x => x).OrderByDescending(x => x).FirstOrDefault();

        }
    }
}
