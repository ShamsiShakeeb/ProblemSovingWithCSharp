using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Hard
{
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            Solution s = new Solution();
            return s.MaxSlidingWindow(nums, k);
        }
    }
}
#region naive Solution

public class Solution1
{
    public int kabadi(int num, List<link> links, int[] nums, int actualIndex)
    {
        int maxIndex = links.Last().maxIndex;

        for (; ; )
        {
            if (nums[maxIndex] > num)
                return maxIndex;
            else
            {
                int newMaxIndex = links.Where(x => x.index == maxIndex).Select(x => x.maxIndex).First();
                if (newMaxIndex == maxIndex)
                {
                    if (nums[maxIndex] > num)
                        return maxIndex;
                    return actualIndex;
                }
                maxIndex = newMaxIndex;
            }
        }
    }
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        List<link> links = new List<link>();
        links.Add(new link()
        {
            index = nums.Length - 1,
            value = nums[nums.Length - 1],
            maxIndex = nums.Length - 1
        });

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                links.Add(new link()
                {
                    index = i,
                    value = nums[i],
                    maxIndex = i + 1
                });
            }
            else
            {
                int maxIndex = kabadi(nums[i], links, nums, i);
                links.Add(new link()
                {
                    index = i,
                    value = nums[i],
                    maxIndex = maxIndex
                });
            }
        }
        k = k - 1;
        List<int> ans = new List<int>();
        for (int i = 0; i < links.Count() - k; i++)
        {
            int index = i;
            for (; ; )
            {
                link model = links.Where(x => x.index == index).First();

                if (!(model.maxIndex <= (i + k)))
                    break;

                if (model.index == model.maxIndex)
                {
                    index = model.maxIndex;
                    break;
                }

                index = model.maxIndex;
            }

            ans.Add(nums[index]);
        }

        return ans.ToArray();
    }
}
public class link
{
    public int index { set; get; }
    public int value { set; get; }
    public int maxIndex { set; get; }
}

#endregion

#region naive Solution to less optimize

public class Solution2
{
    public int kabadi(int num, List<int>[] abc, int[] nums, int actualIndex)
    {
        int maxIndex = abc[actualIndex + 1][0];

        for (; ; )
        {
            if (nums[maxIndex] > num)
                return maxIndex;
            else
            {
                int newMaxIndex = abc[maxIndex][0];
                if (newMaxIndex == maxIndex)
                {
                    if (nums[maxIndex] > num)
                        return maxIndex;
                    return actualIndex;
                }
                maxIndex = newMaxIndex;
            }
        }
    }
    public int[] MaxSlidingWindow(int[] nums, int k)
    {

        List<int>[] abc = new List<int>[100000];

        abc[nums.Length - 1] = new List<int>();
        abc[nums.Length - 1].Add(nums.Length - 1);

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                abc[i] = new List<int>();
                abc[i].Add(i + 1);
            }
            else
            {
                int maxIndex = kabadi(nums[i], abc, nums, i);
                abc[i] = new List<int>();
                abc[i].Add(maxIndex);
            }
        }
        k = k - 1;
        List<int> ans = new List<int>();
        for (int i = 0; i < nums.Length - k; i++)
        {
            int index = i;

            for (; ; )
            {
                int maxIndex = abc[index][0];

                if (!(maxIndex <= (i + k)))
                    break;

                if (index == maxIndex)
                {
                    index = maxIndex;
                    break;
                }

                index = maxIndex;
            }

            ans.Add(nums[index]);
        }

        return ans.ToArray();
    }
}

#endregion

#region Optimize Solution  https://www.youtube.com/watch?v=rSf9vPtKcmI&t=220s , https://www.youtube.com/watch?v=tCVOQX3lWeI&t=356s Tutorial is not quite understand able, I analyzed it bit

public class Solution
{
    public int kabadi(int num, int[,] abc, int[] nums, int actualIndex)
    {
        int maxIndex = abc[actualIndex + 1, 0];

        for (; ; )
        {
            if (nums[maxIndex] > num)
                return maxIndex;
            else
            {
                int newMaxIndex = abc[maxIndex, 0];
                if (newMaxIndex == maxIndex)
                {
                    if (nums[maxIndex] > num)
                        return maxIndex;
                    return actualIndex;
                }
                maxIndex = newMaxIndex;
            }
        }
    }
    public int[] MaxSlidingWindow(int[] nums, int k)
    {

        int[,] abc = new int[100000, 1];

        abc[nums.Length - 1, 0] = nums.Length - 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                abc[i, 0] = i + 1;
            }
            else
            {
                int maxIndex = kabadi(nums[i], abc, nums, i);
                abc[i, 0] = maxIndex;
            }
        }
        k = k - 1;
        List<int> ans = new List<int>();
        for (int i = 0; i < nums.Length - k; i++)
        {
            int index = i;

            for (; ; )
            {
                int maxIndex = abc[index, 0];

                if (!(maxIndex <= (i + k)))
                    break;

                if (index == maxIndex)
                {
                    index = maxIndex;
                    break;
                }

                index = maxIndex;
            }

            ans.Add(nums[index]);
        }

        return ans.ToArray();
    }
}

#endregion
