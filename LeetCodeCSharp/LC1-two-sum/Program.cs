/*──────────────────────────────────────────────────────────────
 * FileName     : Program.cs
 * Created      : 2021-04-22 16:31:09
 * Author       : Xu Zhe
 * Description  : 
 * ──────────────────────────────────────────────────────────────*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace LC1_two_sum
{
    class Program
    {
        /// <summary>
        /// LeetCode 1. 两数之和
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] r = TwoSum4(nums, target);

            Console.WriteLine("[" + Convert.ToString(r[0]) + "," + Convert.ToString(r[1]) + "]");

            Console.ReadKey();
        }

        /// <summary>
        /// 暴力循环
        /// 时间复杂度O(n2)
        /// 空间复杂度O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return new int[2] { -1, -1 };
        }

        /// <summary>
        /// 字典
        /// 时间复杂度O(n)
        /// 空间复杂度O(n2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> contain = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (contain.ContainsKey(target - nums[i]))
                    return new int[] { contain[target - nums[i]], i };
                else if (!contain.ContainsKey(nums[i]))
                    contain.Add(nums[i], i);


            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Hash表实现
        /// 时间复杂度O(n)
        /// 空间复杂度O(n2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum3(int[] nums, int target)
        {
            Hashtable map = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { Convert.ToInt32(map[complement]), i };
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            return null;
        }

        /// <summary>
        /// 两遍Hash表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum4(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dict.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int newTarget = target - nums[i];
                int index;
                dict.TryGetValue(newTarget, out index);
                if (dict.ContainsKey(newTarget) && index != i)
                {
                    return new int[] { i, index };
                }
            }
            return null;
        }
    }

}
