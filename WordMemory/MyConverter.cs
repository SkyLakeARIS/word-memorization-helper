using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory
{
    public static class MyConverter
    {
        private static StringBuilder StringBuilder;

        public static void Initialize()
        {
            StringBuilder = new StringBuilder(1024);
        }
        public static void Release()
        {
            StringBuilder = null;
        }
        public static string HexToString(string hexString)
        {
            StringBuilder.Clear();

            hexString = hexString.Trim();
            string[] splited = hexString.Split(' ');
            foreach(string hex in splited)
            {
                int hexInt = Convert.ToInt32(hex, 16);
                StringBuilder.Append(char.ConvertFromUtf32(hexInt));
            }
            
            return StringBuilder.ToString();
        }

        public static Int32 HexToInt32(string hexString)
        {
            return Convert.ToInt32(hexString, 16);
        }

        public static string StringToHex(string stringToConvert)
        {
            return stringToHex(stringToConvert).Trim();
        }

        public static string StringToHexAddLength(string stringToConvert)
        {
            string result = stringToHex(stringToConvert.Trim());

            return $"{result.Length.ToString("X4")} {result}";
        }


        public static string Int32ToHexX4(Int32 intToConvert)
        {
            return intToConvert.ToString("X4");
        }
        // 코드 중복 제거
        private static string stringToHex(string stringToConvert)
        {
            StringBuilder.Clear();

            foreach (char ch in stringToConvert)
            {
                StringBuilder.Append(Convert.ToString(ch, 16));
                StringBuilder.Append(' ');
            }
            return StringBuilder.ToString();
        }
    }
}
