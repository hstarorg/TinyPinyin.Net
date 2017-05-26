# TinyPinyin.Net
适用于.Net平台的快速、低内存占用的汉字转拼音库。核心算法来自TinyPinyin(https://github.com/promeG/TinyPinyin)

# 特性

1. 生成的拼音不包含声调，均为大写
2. 执行效率高
3. 低内存占用
4. 支持获取简码（拼音首字母）

# 使用 

只提供足够简洁的API，简单易用。

```csharp
/// <summary>
/// 获取单个字符的拼音
/// </summary>
/// <param name="c"></param>
/// <returns></returns>
string PinyinHelper.GetPinyin(char c)

/// <summary>
/// 获取文本字符串的拼音，允许设定拼音分割符
/// </summary>
/// <param name="text">要获取拼音的文本</param>
/// <param name="separator">拼音分割符，默认空格</param>
/// <returns></returns>
string PinyinHelper.GetPinyin(string text, string separator = " ")

/// <summary>
/// 判断单个字符是否是中文
/// </summary>
/// <param name="c"></param>
/// <returns></returns>
bool IsChinese(char c)
```

# 感谢

感谢 [@promeG](https://github.com/promeG) 提供的 [Java版本](https://github.com/promeG/TinyPinyin)。