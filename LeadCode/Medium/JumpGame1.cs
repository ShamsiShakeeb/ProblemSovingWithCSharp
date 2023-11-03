using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class JumpGame1
    {
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1) return true;
            int max = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                int reach = i + nums[i];
                max = Math.Max(max, reach);
                if (max == i && nums[i] == 0 && max != nums.Length - 1) return false;
            }
            return true;
        }
    }
}
