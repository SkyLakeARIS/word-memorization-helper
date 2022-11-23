using System;
using System.Collections.Generic;
using System.Diagnostics;
using WordMemory.Data;

namespace WordMemory
{
	/*
	 *  hex string을 지정한 용도에 맞게 읽어서 변환하는 클래스입니다.
	 */
    public static class DataParser
    {
        public static readonly char DATA_SEPARATOR = '#';
        public static readonly char MEAN_DATA_SEPARATOR = '\n';
        public static readonly char WORD_SEPARATOR = '@';

        /*
		 *  넘겨받은 hex string을 단어 데이터로 변환하여 반환합니다.
         *  성공하면 단어 데이터를 out 및 true 반환 그렇지 않으면 null out 및 false 반환.
		 */
        public static bool ParseData(string wordData, out WordData word)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordData) || wordData != ""), "wordName은 단어 이름이어야 합니다.");

            word = null;
            if (string.IsNullOrWhiteSpace(wordData) || wordData == "")
            {
	            word = null;
	            return false;
            }

            // 마지막에 붙는 #가 오른쪽을 공백으로 넣어버릴지 의문.
            string[] splitedData = wordData.Split(DATA_SEPARATOR);

            Debug.Assert((splitedData.Length == 4 || splitedData.Length == 5), "개체를 만드는데 필요한 데이터가 모자랍니다. 파일을 확인하세요.");
            if(splitedData.Length != 4 && splitedData.Length != 5)
            {
                return false;
            }
            // 1. 해시 값 추출
            UInt32 hash = MyConverter.HexToUInt32(splitedData[0]);

            // 2. 암기 여부 추출 % 열거형으로 변환 필요.
            ERememberType rememberType = (ERememberType)MyConverter.HexToInt32(splitedData[1]);

            // 3. 단어 이름 추출
            string wordName = MyConverter.HexToString(splitedData[2]);

            // 4. 단어 뜻 추출
            string[] SplitedMean = splitedData[3].Split(MEAN_DATA_SEPARATOR);
            Debug.Assert(SplitedMean.Length >= 1, "개체를 만드는데 필요한 데이터가 모자랍니다.(뜻이 최소 하나 이상이어야 합니다.) 파일을 확인하세요.");
            if(SplitedMean.Length <= 0)
            {
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
            word = new WordData((UInt32)hash, wordName, meanList, rememberType, memo);
            return true;
        }

        /*
		 *  지정한 단어 데이터 이름을 통해 바로 파일에서 읽어와 단어 데이터로 변환합니다.
         *  성공하면 단어 데이터 out 그렇지 않으면 null out.
         *  사용 보류.
		 */
        //public static void ParseDataFromFile(string wordNameToLoad, out WordData word)
        //{
        //    Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != ""), "wordName은 단어 이름이어야 합니다.");
        //    word = null;
        //    if (string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != "")
        //    {
        //     return;
        //    }

        //    string wordDataString = string.Empty;
        //    FileManager.LoadWordDataFromFile(wordNameToLoad, out wordDataString);
        //    if (!ParseData(wordDataString, out word))
        //    {
        //     Debug.Assert(false, "데이터를 파싱하는데 문제가 발생했습니다. ParseDataFromFile");
        //    }
        //}

        /*
		 *  전달받은 hex string을 통해 단어 데이터들을 변환하여 리스트로 반환합니다.
         *  성공한 데이터들은 리스트에 추가되어 반환됩니다.
		 */
        public static void ParseImportData(string importedData, ref List<WordData> outWordDataList)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(importedData) || importedData != ""), "importedData에 데이터가 없습니다.");
            if (string.IsNullOrWhiteSpace(importedData) || importedData == "")
            {
	            return;
            }

            // 1. 단어 데이터들 분리.
            string[] splitedWordData = importedData.Split(WORD_SEPARATOR);
            Debug.Assert(splitedWordData.Length > 0, "임포트할 데이터가 없습니다.");
            if (splitedWordData.Length <= 0)
            {
	            return;
            }

            WordData wordData;
            // 2. 분리한 단어 데이터 내부 데이터 파싱.
            foreach(string wordDataString in splitedWordData)
            {
                if(ParseData(wordDataString, out wordData))
                {
                    outWordDataList.Add(wordData);
                }
            }
            wordData = null;
        }

        /*
		 *  전달받은 hex string을 통해 프로그램 환경설정으로 변환해 설정값을 세팅합니다.
		 */
        public static void ParseProgramSettingDataAndSet(string settingData)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(settingData) || settingData != ""), "settingData에 데이터가 없습니다.");
	        if (string.IsNullOrWhiteSpace(settingData) || settingData == "")
	        {
		        return;
	        }

            string[] splitedData = settingData.Split(DATA_SEPARATOR);
            Debug.Assert(splitedData.Length == 4, $"데이터에 이상이 있습니다. 데이터 구조 개수는 3개여야 하는데 {splitedData.Length}개 입니다.");
            if (splitedData.Length != 4)
            {
	            return;
            }

            // 1. 보기모드 데이터 추출
            Setting.ViewMode = (EViewMode)MyConverter.HexToInt32(splitedData[0]);

            // 2. 갱신 모드 데이터 추출
            Setting.RefreshMode = (ERefreshMode) MyConverter.HexToInt32(splitedData[1]);

            // 3. 타이머 설정 값 추출
            Setting.RefreshTimeMilliseconds = MyConverter.HexToInt32(splitedData[2]);

            // 4. 윈도우 실행시 자동시작 여부 값 추출
            Setting.AutoStart = (EAutoStart)MyConverter.HexToInt32(splitedData[3]);

        }
    }
}
