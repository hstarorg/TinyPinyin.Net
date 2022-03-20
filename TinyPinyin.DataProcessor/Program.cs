using TinyPinyin.DataProcessor.OriginalData;

namespace TinyPinyin.DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFile(ConvertToBytesArray(PinyinCode1.PINYIN_CODE_PADDING), "1_padding.txt");
            WriteFile(ConvertToBytesArray(PinyinCode1.PINYIN_CODE), "1_code.txt");
            WriteFile(ConvertToBytesArray(PinyinCode2.PINYIN_CODE_PADDING), "2_padding.txt");
            WriteFile(ConvertToBytesArray(PinyinCode2.PINYIN_CODE), "2_code.txt");
            WriteFile(ConvertToBytesArray(PinyinCode3.PINYIN_CODE_PADDING), "3_padding.txt");
            WriteFile(ConvertToBytesArray(PinyinCode3.PINYIN_CODE), "3_code.txt");
            Console.WriteLine("请按任意键退出");
            Console.ReadKey();
        }

        static void WriteFile(byte[] bytes, string filepath)
        {
            var result = String.Join(",", bytes.ToArray());
            File.WriteAllText(filepath, result);
        }

        static byte[] ConvertToBytesArray(int[] arr)
        {
            var len = arr.Length;
            var bytes = new byte[len];
            for (var i = 0; i < len; i++)
            {
                bytes[i] = IntToByte(arr[i]);
            }
            return bytes;
        }

        static byte IntToByte(int val)
        {
            if (val >= 0)
            {
                return Convert.ToByte(val);
            }
            return Convert.ToByte(0xff & val);
        }
    }
}
