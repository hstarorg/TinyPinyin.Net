using System.Linq;

namespace TinyPinyin
{
    public static class PinyinHelper
    {
        /// <summary>
        /// 判断给定字符是否是中文
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsChinese(char c)
        {
            return Engine.IsChinese(c);
        }

        /// <summary>
        /// 获取单个字符的拼音
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetPinyin(char c)
        {
            return Engine.GetPinyinByChar(c);
        }

        /// <summary>
        /// 获取文本的拼音
        /// </summary>
        /// <param name="str">要获取拼音的文本</param>
        /// <param name="separator">单个拼音分隔符</param>
        /// <returns></returns>
        public static string GetPinyin(string str, string separator = " ")
        {
            return Engine.ToPinyin(str, null, null, separator);
        }

        /// <summary>
        /// 获取拼音首字母
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator">拼音分割符，默认空字符串（不分割）</param>
        /// <returns></returns>
        public static string GetPinyinInitials(string str, string separator = "")
        {
            var result = GetPinyin(str, "|");
            // 修复：获取首字母时字符串中含有|字符会报超出索引范围，https://github.com/hstarorg/TinyPinyin.Net/issues/5
            return string.Join(separator, result.Split('|').Select(x => !string.IsNullOrWhiteSpace(x) && x.Length > 0 ? x.Substring(0, 1) : x).ToArray());
        }
    }
}
