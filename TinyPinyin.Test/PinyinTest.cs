using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TinyPinyin.Core;

namespace TinyPinyin.Test
{
    [TestClass]
    public class PinyinTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = PinyinHelper.GetPinyin('中');
            Assert.AreEqual<string>("ZHONG", result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = PinyinHelper.GetPinyin('的');
            Assert.AreEqual<string>("DE", result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = PinyinHelper.GetPinyin("我们都有一个家", "|");
            Assert.AreEqual<string>("WO|MEN|DOU|YOU|YI|GE|JIA", result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var result = PinyinHelper.GetPinyinInitials("成都");
            Assert.AreEqual<string>("CD", result);
        }

        [TestMethod]
        public void TestMethod5()
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
                Assert.AreEqual<string>(expected[i].ToUpper(), result);
            }
        }

        [TestMethod]
        public void TestMethod6()
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
                Assert.AreEqual<string>(expected[i].ToUpper(), result);
            }
        }
    }
}
