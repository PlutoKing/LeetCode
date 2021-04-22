# LeetCode 1. 两数之和

给定一个整数数组`nums`和一个目标值`target`，请你在该数组中找出和为目标值的那**两个**整数，并返回他们的数组下标。

你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

## 示例

```
给定 nums = [2, 7, 11, 15], target = 9

因为 nums[*0*] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]
```

## 结果

代码 | 来源 | 执行时间 | 内存消耗 | 说明
---|---|---|---|---
TowSum | Mine | 496 | 29.7MB | 暴力循环
TowSum2 | Web | 288 | 30.4MB | 一遍Dictionary
TowSum3 | Web | 296 | 31.1MB | 一遍Hash表


## 求解

### 方法一、暴力解法
&emsp;&emsp;暴力法很简单，遍历每个元素$x$，并查找是否存在一个值与$target-x$相等的目标元素。

```csharp
public int[] TwoSum(int[] nums, int target)
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
    return new int[] { -1, -1 };
}
```

&emsp;&emsp;**复杂度分析：**

- 时间复杂度：$O(n^2)$
- 空间复杂度：$O(1)$

### 方法二、两遍Hash表
&emsp;&emsp;为了对运行时间复杂度进行优化，我们需要一种更有效的方法来检查数组中是否存在目标元素。如果存在，我们需要找出它的索引。<font color=blue>保持数组中的每个元素与其索引相互对应</font>的最好方法是什么？<font face color=blue>**哈希表**</font>。

&emsp;&emsp;通过以空间换取速度的方式，我们可以将查找时间从$O(n)$降低到$O(1)$。哈希表正是为此目的而构建的，它支持以**近似**恒定的时间进行快速查找。我用“近似”来描述，是因为一旦出现冲突，查找用时可能会退化到  。但只要你仔细地挑选哈希函数，在哈希表中进行查找的用时应当被摊销为$O(1)$。

&emsp;&emsp;一个简单的实现使用了两次迭代。在第一次迭代中，我们将每个元素的值和它的索引添加到表中。然后，在第二次迭代中，我们将检查每个元素所对应的目标元素$(target-nums[i])$是否存在于表中。注意，该目标元素不能是$nums[i]$本身！

```csharp
public int[] TwoSum(int[] nums, int target)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        dict.Add(nums[i], i);
    }
    for(int i = 0; i < nums.Length; i++)
    {
        int newTarget = target - nums[i];
        int index;
        dict.TryGetValue(newTarget, out index);
        if (dict.ContainsKey(newTarget) && index != i)
        {
            return new int[] { i, index };
        }
    }
    return new int[] { -1, -1 };
}
```

&emsp;&emsp;**复杂度分析**

- 时间复杂度：$O(n)$
- 空间复杂度：$O(n)$

### 方法三、一遍Hash表

&emsp;&emsp;事实证明，我们可以一次完成。在进行迭代并将元素插入到表中的同时，我们还会回过头来检查表中是否已经存在当前元素所对应的目标元素。如果它存在，那我们已经找到了对应解，并立即将其返回。

```csharp
public int[] TwoSum2(int [] nums,int target)
{
    Dictionary<int, int> contain = new Dictionary<int, int>();
    for(int i = 0; i < nums.Length; i++)
    {
        if (contain.ContainsKey(target - nums[i]))
            return new int[] { contain[target - nums[i]], i };
        else if (!contain.ContainsKey(nums[i]))
            contain.Add(nums[i], i);

       
    }
    return new int[] { -1, -1 };
}

```

&emsp;&emsp;**复杂度分析**

- 时间复杂度：$O(n)$
- 空间复杂度：$O(n)$
