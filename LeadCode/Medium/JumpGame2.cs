using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class JumpGame2
    {
        public static int Jump(int[] nums)
        {
            int[] memo = new int[nums.Length];
            bool[] visit = new bool[nums.Length];
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int indices = nums[i] + i;

                    for (int j = i + 1; j <= indices; j++)
                    {
                        if (!visit[j])
                        {
                            memo[j] = memo[i] + 1;
                            visit[j] = true;
                        }
                        if (visit[nums.Length - 1])
                        {
                            return memo[j];
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return memo[nums.Length - 1];
        }
    }
}
