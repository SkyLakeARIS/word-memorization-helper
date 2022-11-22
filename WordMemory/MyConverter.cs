using System;
using System.Diagnostics;
using System.Text;
using WordMemory.Data;

namespace WordMemory
{
	 /*
	  *  hex string <-> Int32, string 변환
	  *  단어 데이터를 hex string으로 변환하는 클래스
	  */
    public static class MyConverter
    {
		/*
		*  단어 데이터를 파일로 내보내기 위해 hex string으로 변환합니다.
		*/
        public static string WordDataToHexString(WordData wordToConvert)
        {
	        StringBuilder stringBuilder = new StringBuilder(2048);
	        // 1. 해시 변환
            stringBuilder.Append(UInt32ToHexX4(wordToConvert.Hash));
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

        /*
		*  받은 hex string을 일반 string 데이터로 변환하여 반환합니다.
		*/
        public static string HexToString(string hexString)
        {
	        StringBuilder stringBuilder = new StringBuilder(256);

            hexString = hexString.Trim();
            string[] splited = hexString.Split(' ');
            foreach(string hex in splited)
            {
                int hexInt = Convert.ToInt32(hex, 16);
                stringBuilder.Append(char.ConvertFromUtf32(hexInt));
            }
            
            return stringBuilder.ToString();
        }

        /*
		*  받은 hex string을 일반 Int32 데이터로 변환하여 반환합니다.
		*/
        public static Int32 HexToInt32(string hexString)
        {
            return Convert.ToInt32(hexString, 16);
        }

        /*
		*  받은 hex string을 일반 UInt32 데이터로 변환하여 반환합니다.
		*/
        public static UInt32 HexToUInt32(string hexString)
        {
	        return Convert.ToUInt32(hexString, 16);
        }
        /*
		*  받은 string을 hex string 데이터로 변환하여 반환합니다.
		*/
        public static string StringToHex(string stringToConvert)
        {
            return stringToHex(stringToConvert).Trim();
        }

        /*
		*  받은 string을 hex string 데이터로 변환하여 반환합니다.
        *  변환한 데이터 앞에 변환된 데이터의 길이가 hex로 변환되어 덧붙여집니다.
		*/
        public static string StringToHexAddLength(string stringToConvert)
        {
            Debug.Assert(false, "해당 프로그램에서 사용하지 않는 파일 형식의 동작입니다. 한번 더 확인하세요.");
            string result = stringToHex(stringToConvert.Trim());

            return $"{result.Length.ToString("X4")} {result}";
        }

        /*
		*  받은 Int32를 hex string 데이터로 변환하여 반환합니다.
        *  4자리 hex로 변환됩니다.
		*/
        public static string Int32ToHexX4(Int32 intToConvert)
        {
            return intToConvert.ToString("X4");
        }

        /*
		*  받은 UInt32를 hex string 데이터로 변환하여 반환합니다.
        *  4자리 hex로 변환됩니다.
		*/
        public static string UInt32ToHexX4(UInt32 intToConvert)
        {
	        return intToConvert.ToString("X4");
        }
        /*
		 *  받은 string을 hex string 데이터로 변환하여 반환합니다.
         *  내부에서 코드 중복 제거용으로 사용
		 */
        private static string stringToHex(string stringToConvert)
        {
	        StringBuilder stringBuilder = new StringBuilder(256);

            foreach (char ch in stringToConvert)
            {
	            stringBuilder.Append(Convert.ToString(ch, 16));
	            stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}
