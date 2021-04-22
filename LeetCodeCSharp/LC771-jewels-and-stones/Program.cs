using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LC771_jewels_and_stones
{
    class Program
    {
        /// <summary>
        /// LeetCode 771. 宝石与石头
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string J = "aA";
            string S = "aAAbbbb";
            int cnt = NumJewelsInStones(J, S);
            Console.WriteLine(cnt.ToString());

            Console.ReadKey();

        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            int cnt = 0;
            // 创建Hash表
            HashSet<char> jewelsMap = new HashSet<char>();
            // 计算字符串长度，字符串转数组
            int Lj = jewels.Length;
            int Ls = stones.Length;
            char[] jewelsArray = jewels.ToCharArray();
            char[] stonesArray = stones.ToCharArray();
            // 宝石导入Hash表
            for (int i = 0; i < Lj; i++)
            {
                jewelsMap.Add(jewelsArray[i]);
            }
            // 依次对石头进行比对
            for(int i = 0; i < Ls; i++)
            {
                char s = stonesArray[i];
                if (jewelsMap.Contains(s))
                {
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
