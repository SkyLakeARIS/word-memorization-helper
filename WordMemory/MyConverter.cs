using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemory.Data;

namespace WordMemory
{
    public static class MyConverter
    {
        private static StringBuilder stringBuilder = null;

        public static void Initialize()
        {
	        stringBuilder = new StringBuilder(2048);
        }
        public static void Release()
        {
	        stringBuilder.Clear();
            stringBuilder = null;
        }

        public static string WordDataToHexString(WordData wordToConvert)
        {
            // 내용물 제거.
	        stringBuilder.Clear();

	        // 1. 해시 변환
            stringBuilder.Append(Int32ToHexX4(wordToConvert.Hash));
            stringBuilder.Append(DataParser.DATA_SEPARATOR);

            // 2. 암기 여부 변환
            stringBuilder.Append(Int32ToHexX4((Int32)wordToConvert.RememberType));
            stringBuilder.Append(DataParser.DATA_SEPARATOR);

            // 3. 단어 이름 변환
            stringBuilder.Append(StringToHex(wordToConvert.WordName));
            stringBuilder.Append(DataParser.DATA_SEPARATOR);

            // 4. 뜻 변환
            for (Int32 index = 0; index < wordToConvert.MeanList.Count; ++index)
            {
                stringBuilder.Append(StringToHex(wordToConvert.MeanList[index]));
                // 마지막 데이터는 데이터 분리문자를 붙이지 않음. (파싱 과정에서 에러 발생)
                if (index < wordToConvert.MeanList.Count - 1)
	            {
		            stringBuilder.Append(DataParser.MEAN_DATA_SEPARATOR);
	            }
            }

            // 5. 메모 변환
            if (!(string.IsNullOrWhiteSpace(wordToConvert.Memo) || string.Empty == wordToConvert.Memo))
            {
	            stringBuilder.Append(DataParser.DATA_SEPARATOR);
	            stringBuilder.Append(StringToHex(wordToConvert.Memo));
            }

            return stringBuilder.ToString();
        }

        public static string HexToString(string hexString)
        {
	        stringBuilder.Clear();

            hexString = hexString.Trim();
            string[] splited = hexString.Split(' ');
            foreach(string hex in splited)
            {
                int hexInt = Convert.ToInt32(hex, 16);
                stringBuilder.Append(char.ConvertFromUtf32(hexInt));
            }
            
            return stringBuilder.ToString();
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
	        stringBuilder.Clear();

            foreach (char ch in stringToConvert)
            {
	            stringBuilder.Append(Convert.ToString(ch, 16));
	            stringBuilder.Append(' ');
            }

            string hexString = stringBuilder.ToString();
            
            return stringBuilder.ToString();
        }
    }
}
