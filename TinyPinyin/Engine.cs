using System;
using System.Collections.Generic;
using System.Text;
using TinyPinyin.Data;

namespace TinyPinyin
{
    public static class Engine
    {
        public static string[] PinyinFromDict(string wordInDict, List<IPinyinDict> pinyinDictSet)
        {
            if (pinyinDictSet != null)
            {
                foreach (IPinyinDict dict in pinyinDictSet)
                {
                    if (dict != null && dict.Words() != null && dict.Words().Contains(wordInDict))
                    {
                        return dict.ToPinyin(wordInDict);
                    }
                }
            }
            throw new ArgumentException("No pinyin dict contains word: " + wordInDict);
        }

        /// <summary>
        /// 获取给定的字符串的拼音
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="trie"></param>
        /// <param name="pinyinDictList"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToPinyin(string inputStr, string trie, List<IPinyinDict> pinyinDictList, string separator)
        {
            if (inputStr == null || inputStr.Length == 0)
            {
                return inputStr;
            }


            if (trie == null)
            {
                // 没有提供字典或选择器，按单字符转换输出
                var builder1 = new StringBuilder();
                for (int i = 0; i < inputStr.Length; i++)
                {
                    builder1.Append(GetPinyinByChar(inputStr[i]));
                    if (i != inputStr.Length - 1)
                    {
                        builder1.Append(separator);
                    }
                }
                return builder1.ToString();
            }
            return null;

            //List<Emit> selectedEmits = selector.select(trie.parseText(inputStr));

            //Collections.sort(selectedEmits, EMIT_COMPARATOR);

            //StringBuffer resultPinyinStrBuf = new StringBuffer();

            //int nextHitIndex = 0;

            //for (int i = 0; i < inputStr.length();)
            //{
            //    // 首先确认是否有以第i个字符作为begin的hit
            //    if (nextHitIndex < selectedEmits.size() && i == selectedEmits.get(nextHitIndex).getStart())
            //    {
            //        // 有以第i个字符作为begin的hit
            //        String[] fromDicts = pinyinFromDict(selectedEmits.get(nextHitIndex).getKeyword(), pinyinDictList);
            //        for (int j = 0; j < fromDicts.length; j++)
            //        {
            //            resultPinyinStrBuf.append(fromDicts[j].toUpperCase());
            //            if (j != fromDicts.length - 1)
            //            {
            //                resultPinyinStrBuf.append(separator);
            //            }
            //        }

            //        i = i + selectedEmits.get(nextHitIndex).size();
            //        nextHitIndex++;
            //    }
            //    else
            //    {
            //        // 将第i个字符转为拼音
            //        resultPinyinStrBuf.append(Pinyin.toPinyin(inputStr.charAt(i)));
            //        i++;
            //    }

            //    if (i != inputStr.length())
            //    {
            //        resultPinyinStrBuf.append(separator);
            //    }
            //}

            //return resultPinyinStrBuf.toString();
        }

        private static int GetPinyinCode(char c)
        {
            int offset = c - PinyinData.MIN_VALUE;
            if (0 <= offset && offset < PinyinData.PINYIN_CODE_1_OFFSET)
            {
                // 前 7000 个汉字
                return decodeIndex(PinyinCode1.PINYIN_CODE_PADDING, PinyinCode1.PINYIN_CODE, offset);
            }
            else if (PinyinData.PINYIN_CODE_1_OFFSET <= offset && offset < PinyinData.PINYIN_CODE_2_OFFSET)
            {
                // 7000 ~ 14000 个汉字
                return decodeIndex(PinyinCode2.PINYIN_CODE_PADDING, PinyinCode2.PINYIN_CODE, offset - PinyinData.PINYIN_CODE_1_OFFSET);
            }
            else
            {
                // 14000 之后的汉字
                return decodeIndex(PinyinCode3.PINYIN_CODE_PADDING, PinyinCode3.PINYIN_CODE, offset - PinyinData.PINYIN_CODE_2_OFFSET);
            }
        }

        private static short decodeIndex(byte[] paddings, byte[] indexes, int offset)
        {
            //CHECKSTYLE:OFF
            int index1 = offset / 8;
            int index2 = offset % 8;
            short realIndex;
            realIndex = (short)(indexes[offset] & 0xff);
            //CHECKSTYLE:ON
            if ((paddings[index1] & PinyinData.BIT_MASKS[index2]) != 0)
            {
                realIndex = (short)(realIndex | PinyinData.PADDING_MASK);
            }
            return realIndex;
        }

        /// <summary>
        /// 判断是否是汉字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsChinese(char c)
        {
            return (PinyinData.MIN_VALUE <= c && c <= PinyinData.MAX_VALUE && GetPinyinCode(c) > 0) || PinyinData.CHAR_12295 == c;
        }

        /// <summary>
        /// 获取单个汉字的完整拼音
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetPinyinByChar(char c)
        {
            if (IsChinese(c))
            {
                if (c == PinyinData.CHAR_12295)
                {
                    return PinyinData.PINYIN_12295;
                }
                else
                {
                    return PinyinData.PINYIN_TABLE[GetPinyinCode(c)];
                }
            }
            else
            {
                return c.ToString();
            }
        }
    }
}
