﻿using System.Collections.Generic;
using Xunit;

namespace TinyPinyin.Tests
{
    public class PinyinTest
    {

        public class StringComparer : IEqualityComparer<string>
        {
            public bool Equals(string t1, string t2)
            {
                return t1.Equals(t2);
            }

            public int GetHashCode(string t)
            {
                return t.GetHashCode();
            }
        }

        public readonly StringComparer comparer = new StringComparer();

        [Fact]
        public void Test_GetPinyin_Normal()
        {
            var result = PinyinHelper.GetPinyin('中');
            Assert.Equal("ZHONG", result, this.comparer);
        }

        [Fact]
        public void Test_GetPinyin_Normal_02()
        {
            var result = PinyinHelper.GetPinyin('的');
            Assert.Equal<string>("DE", result, this.comparer);
        }

        [Fact]
        public void Test_GetPinyin_With_Separator()
        {
            var result = PinyinHelper.GetPinyin("我们都有一个家", "|");
            Assert.Equal<string>("WO|MEN|DOU|YOU|YI|GE|JIA", result, this.comparer);
        }

        [Fact]
        public void Test_GetPinyinInitials_Normal()
        {
            var result = PinyinHelper.GetPinyinInitials("成都");
            Assert.Equal<string>("CD", result, this.comparer);
        }

        [Fact]
        public void Test_GetPinyinInitials_With_Separator()
        {
            var result = PinyinHelper.GetPinyinInitials("成都", " ");
            Assert.Equal<string>("C D", result, this.comparer);
        }

        [Fact]
        public void Test_GtePinyin_LongText()
        {
            var maxims = new string[]
            {
                 "事常与人违，事总在人为",
                 "骏马是跑出来的，强兵是打出来的",
                 "驾驭命运的舵是奋斗。不抱有一丝幻想，不放弃一点机会，不停止一日努力。",
                 "如果惧怕前面跌宕的山岩，生命就永远只能是死水一潭",
                 "懦弱的人只会裹足不前，莽撞的人只能引为烧身，只有真正勇敢的人才能所向披靡"
            };
            var expected = new string[]
            {
                "shi chang yu ren wei ， shi zong zai ren wei",
                "jun ma shi pao chu lai de ， qiang bing shi da chu lai de",
                "jia yu ming yun de duo shi fen dou 。 bu bao you yi si huan xiang ， bu fang qi yi dian ji hui ， bu ting zhi yi ri nu li 。",
                "ru guo ju pa qian mian die dang de shan yan ， sheng ming jiu yong yuan zhi neng shi si shui yi tan",
                "nuo ruo de ren zhi hui guo zu bu qian ， mang zhuang de ren zhi neng yin wei shao shen ， zhi you zhen zheng yong gan de ren cai neng suo xiang pi mi"
            };
            for (var i = 0; i < maxims.Length; i++)
            {
                var result = PinyinHelper.GetPinyin(maxims[i]);
                Assert.Equal(expected[i].ToUpper(), result, this.comparer);
            }
        }

        [Fact]
        public void Test_GetPinyinInitials_HardText()
        {
            string[] medicines = new string[]
            {
                 "聚维酮碘溶液",
                 "开塞露",
                 "炉甘石洗剂",
                 "苯扎氯铵贴",
                 "鱼石脂软膏",
                 "莫匹罗星软膏",
                 "红霉素软膏",
                 "氢化可的松软膏",
                 "曲安奈德软膏",
                 "丁苯羟酸乳膏",
                 "双氯芬酸二乙胺乳膏",
                 "冻疮膏",
                 "克霉唑软膏",
                 "特比奈芬软膏",
                 "酞丁安软膏",
                 "咪康唑软膏、栓剂",
                 "甲硝唑栓",
                 "复方莪术油栓"
            };
            var expected = new string[]
            {
                "JWTDRY",
                "KSL",
                "LGSXJ",
                "BZLAT",
                "YSZRG",
                "MPLXRG",
                "HMSRG",
                "QHKDSRG",
                "QANDRG",
                "DBQSRG",
                "SLFSEYARG",
                "DCG",
                "KMZRG",
                "TBNFRG",
                "TDARG",
                "MKZRG、SJ",
                "JXZS",
                "FFESYS"
            };
            for (var i = 0; i < medicines.Length; i++)
            {
                var result = PinyinHelper.GetPinyinInitials(medicines[i]);
                Assert.Equal<string>(expected[i].ToUpper(), result, this.comparer);
            }
        }
    }
}
