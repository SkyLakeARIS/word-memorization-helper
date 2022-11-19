using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WordMemory.Data;

namespace WordMemory
{
    public static class WordDataParser
    {
        private static char dataSeparator = '#';
        private static char meanDataSeparator = '\n';

        public static bool ParseData(string wordData, out WordData word)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordData) || wordData != ""), "wordName은 단어 이름이어야 합니다.");

            // 마지막에 붙는 #가 오른쪽을 공백으로 넣어버릴지 의문.
            string[] splitedData = wordData.Split(dataSeparator);

            Debug.Assert((splitedData.Length == 4 || splitedData.Length == 5), "개체를 만드는데 필요한 데이터가 모자랍니다. 파일을 확인하세요.");
            if(splitedData.Length < 4)
            {
                word = null;
                return false;
            }
            // 1. 해시 값 추출
            Int32 hash = MyConverter.HexToInt32(splitedData[0]);

            // 2. 암기 여부 추출 % 열거형으로 변환 필요.
            eRememberType rememberType = (eRememberType)MyConverter.HexToInt32(splitedData[1]);            

            // 3. 단어 이름 추출
            string wordName = MyConverter.HexToString(splitedData[2]);

            // 4. 단어 뜻 추출
            string[] SplitedMean = splitedData[3].Split(meanDataSeparator);
            Debug.Assert(SplitedMean.Length >= 1, "개체를 만드는데 필요한 데이터가 모자랍니다.(뜻이 최소 하나 이상이어야 합니다.) 파일을 확인하세요.");
            if(SplitedMean.Length <= 0)
            {
                word = null;
                return false;
            }
            List<string> meanList = new List<string>(16);

            for(int count = 0; count < SplitedMean.Length; ++count)
            {
                meanList.Add(MyConverter.HexToString(SplitedMean[count]));
            }

            // 5. 메모 내용 추출 % 없을 수도 있음.
            string memo = string.Empty;
            if (splitedData.Length == 5)
            {
                memo = MyConverter.HexToString(splitedData[4]);
            }

            // 6. 개체 조립 후 반환
            word = new WordData(hash, new Word(wordName, meanList), rememberType, memo);
            return true;
        }

        public static void ParseDataFromFile(string wordNameToLoad, out WordData word/* 단어 개체 반환*/)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != ""), "wordName은 단어 이름이어야 합니다.");
            string wordDataString = string.Empty;
            FileManager.LoadWordDataFromFile(wordNameToLoad, out wordDataString);
            ParseData(wordDataString, out word);
        }
    }
}
