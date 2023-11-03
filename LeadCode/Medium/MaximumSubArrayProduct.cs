using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class MaximumSubArrayProduct
    {
        public int MaxProduct(int[] nums)
        {
            int prod = 1;
            int ansL = int.MinValue;
            int ansR = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                prod *= nums[i];
                ansL = Math.Max(ansL, prod);
                if (prod == 0) prod = 1;
            }

            prod = 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                prod *= nums[i];
                ansR = Math.Max(ansR, prod);
                if (prod == 0) prod = 1;
            }
            return Math.Max(ansR, ansL);
        }
    }
}
