using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC42_trapping_rain_water
{
    class Program
    {
        /// <summary>
        /// LeetCode 42. 接雨水
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int w = Trap2(height);
            Console.WriteLine(w.ToString());

            Console.ReadKey();
        }

        public static int Trap(int[] height)
        {
            // 初始化雨量
            int water = 0;
            // 记录水池宽度
            int w = height.Length; 
            // 遍历水池
            for (int i = 1; i < w - 1; i++)
            {
                // 左侧最大值
                int leftmax = height[0];
                for (int j = 0; j < i; j++)
                {
                    
                    if (height[j] > leftmax)
                    {
                        leftmax = height[j];
                    }
                }
                // 右侧最大值
                int rightmax = height[i + 1];
                for (int j = i+1; j < w; j++)
                {
                    
                    if (height[j] > rightmax)
                    {
                        rightmax = height[j];
                    }
                }
                // 计算水量
                if(leftmax > rightmax)
                {
                    if (rightmax > height[i])
                    {
                        water += rightmax - height[i];
                    }
                }
                else
                {
                    if(leftmax>height[i])
                    {
                        water += leftmax - height[i];
                    }
                }
            }
            return water;
        }

        /// <summary>
        /// 官网方法
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int Trap2(int[] height)
        {
            int n = height.Length;
            if (n == 0)
            {
                return 0;
            }

            int[] leftMax = new int[n];
            leftMax[0] = height[0];
            for (int i = 1; i < n; ++i)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            }

            int[] rightMax = new int[n];
            rightMax[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }

            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                ans += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }
            return ans;

        }
    }
}
