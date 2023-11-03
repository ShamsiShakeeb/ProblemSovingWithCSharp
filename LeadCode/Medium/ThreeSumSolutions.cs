using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class ThreeSumSolutions
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var arr = nums.ToList();
            arr.Sort();
            Dictionary<int, int?> track = new Dictionary<int, int?>();
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0 && count != 3)
                {
                    count++;
                }
                int? value;
                track.TryGetValue(nums[i], out value);
                if (value == null)
                {
                    track[nums[i]] = 1;
                }
                else
                {
                    track[nums[i]]++;
                }
            }

            bool svr = count == 3;
            Dictionary<string, int?> visit = new Dictionary<string, int?>();
            List<List<int>> ans = new List<List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                track[nums[i]]--;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int x = nums[i] + nums[j];
                    track[nums[j]]--;
                    int index = arr.BinarySearch(-x);
                    if (index >= 0)
                    {
                        if (nums[i] == 0 && nums[j] == 0 && !svr)
                        {

                        }
                        else if ((track[nums[i]] == 0 || track[nums[j]] == 0) && (nums[i] == arr[index] || nums[j] == arr[index]))
                        {

                        }
                        else
                        {
                            int[] temp = new int[3];
                            temp[0] = nums[i];
                            temp[1] = nums[j];
                            temp[2] = arr[index];
                            Array.Sort(temp);
                            int? value;
                            visit.TryGetValue(string.Join(",", temp), out value);
                            if (value == null)
                            {
                                ans.Add(temp.ToList());
                            }
                            visit[string.Join(",", temp)] = 1;
                        }

                    }
                    track[nums[j]]++;
                }
                track[nums[i]]++;
            }
            return (new List<IList<int>>(ans));
        }
    }
}
