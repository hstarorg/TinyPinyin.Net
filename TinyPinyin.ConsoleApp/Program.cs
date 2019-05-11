using System;

namespace TinyPinyin.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine($"{maxims[i]} = {result}");
            }
            Console.ReadKey();
        }
    }
}
