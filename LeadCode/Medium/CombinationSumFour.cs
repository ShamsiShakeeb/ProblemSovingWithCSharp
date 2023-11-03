using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class CombinationSumFour
    {
        public CombinationSumFour()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int ans = Answer(dict, new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 10);
            Console.WriteLine(ans);
        }
        //public int Answer(Dictionary<int, int> dict, int[] nums, int target)
        //{
        //    if (target == 0)
        //    {
        //        return 1;
        //    }
        //    else if (target < 0) return 0;
        //    int value;

        //    if (dict.TryGetValue(target, out value)) return value;

        //    int ans = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        ans += Answer(dict, nums, target - nums[i]);
        //    }
        //    dict[target] = ans;
        //    return ans;
        //}

        //public int Answer(Dictionary<int, int> dict, int[] nums, int target , int sum=0)
        //{
        //    if (sum == target) return 1;
        //    else if (sum > target) return 0;
        //    int ans = 0;
        //    int value;
        //    if (dict.TryGetValue(sum, out value)) return dict[sum];
        //    for (int i = 0; i < nums.Length; i++)
        //        ans += Answer(dict, nums,target,sum + nums[i]);
        //    dict[sum] = ans;
        //    return dict[sum];
        //}
        //public int Answer(Dictionary<int, int> dict, int[] nums, int target, int sum = 0)
        //{
        //    if (sum == target) return 1;
        //    else if (sum > target) return 0;
        //    int ans = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //        ans += Answer(dict, nums, target, sum + nums[i]);
        //    return ans;
        //}

        //this recursive approach indicates ans+= recursion() means  all the recursion addition that returns from basecase
        public int Answer(Dictionary<int, int> dict, int[] nums, int target)
        {
            if (target == 0) return 1;
            else if (target < 0) return 0;
            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
                ans += Answer(dict, nums, target - nums[i]);
            return ans;
        }
    }
}
