// See https://aka.ms/new-console-template for more information
using TinyPinyin;

var lines = new string[] {
    "事常与人违，事总在人为",
    "骏马是跑出来的，强兵是打出来的",
    "驾驭命运的舵是奋斗。不抱有一丝幻想，不放弃一点机会，不停止一日努力。",
    "如果惧怕前面跌宕的山岩，生命就永远只能是死水一潭",
    "懦弱的人只会裹足不前，莽撞的人只能引为烧身，只有真正勇敢的人才能所向披靡"
};

lines.ToList().ForEach(line =>
{
    var linePinyin = PinyinHelper.GetPinyin(line);
    Console.WriteLine($"{line} = {linePinyin}");
});
Console.ReadKey();