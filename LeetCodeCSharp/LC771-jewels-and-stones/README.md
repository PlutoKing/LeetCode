# LeetCode 771. 宝石与石头

 给定字符串`J`代表石头中宝石的类型，和字符串`S`代表你拥有的石头。`S`中每个字符代表了一种你拥有的石头的类型，你想知道你拥有的石头中有多少是宝石。

`J` 中的字母不重复，`J`和`S`中的所有字符都是字母。字母区分大小写，因此`"a"`和`"A"`是不同类型的石头。


## 示例

### 示例1
```
输入: J = "aA", S = "aAAbbbb"
输出: 3
```

### 示例2
```
输入: J = "z", S = "ZZ"
输出: 0
```

### 注意

- `S`和`J`最多含有50个字母。
- `J`中的字符不重复。


## 结果

代码 | 来源 | 执行时间 | 内存消耗 | 说明
---|---|---|---|---
NumJewelsInStones | Mine | 88ms | 23.6MB | Hash表


## 求解

### 方法

&emsp;&emsp;采用Hash表存储J中的字符，将S中的字符进行比对。

```csharp
public static int NumJewelsInStones(string jewels, string stones)
{
    // 初始化计数器，作为返回值
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
    for (int i = 0; i < Ls; i++)
    {
        char s = stonesArray[i];
        if (jewelsMap.Contains(s))
        {
            cnt++;
        }
    }
    // 返回结果
    return cnt;
}
```

&emsp;&emsp;**复杂度分析**

- 时间复杂度：$O(m+n)$,其中$m$是字符串`jewels`的长度，$n$是字符串`stones`的长度。遍历字符串`jewels`将其中的字符存储到哈希集合中，时间复杂度是$O(m)$，然后遍历字符串`stones`，对于`stones`中的每个字符在$O(1)$的时间内判断当前字符是否是宝石，时间复杂度是$O(n)$，因此总时间复杂度是$O(m+n)$。
- 空间复杂度：$O(m)$,其中$m$是字符串`jewels`的长度。使用哈希集合存储字符串`jewels`中的字符。
