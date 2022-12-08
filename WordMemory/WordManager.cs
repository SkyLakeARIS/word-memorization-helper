using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using WordMemory.Data;
using WordMemory.Forms;

namespace WordMemory
{
	/*
	 *  단어 데이터를 관리하는 클래스
	 *  주로 UI에서 받은 명령을 통해 다른 클래스들과 상호작용합니다.
	 */
    public static class WordManager
    {
	    public static readonly Int32 MEAN_COUNT_LIMIT = 16;
	    public static readonly Int32 MEAN_STRING_LENGTH_LIMIT = 16;

	    // 사전에 등록된 단어중 가장 긴 단어가 45자.
	    // 현실적으로 외울 수 있는 범위의 단어 길이는 아니기 때문에 넘치는 길이.
	    public static readonly Int32 WORD_STRING_LENGTH_LIMIT = 46;
	    public static readonly Int32 MEMO_STRING_LENGTH_LIMIT = 64;

        // UI에 단어를 보여주기 위해서 미/암기 데이터 리스트로 저장.
        // -> 해시 값을 가지면 중복된 해시에 대해서 처리가 까다로우므로, 단어명을 들고 있는 것으로 변경.
        private static List<string> rememberList;
	    private static List<string> notRememberList;

		// 메인 폼, 테스트 폼에서 단어 데이터를 요청할 때 사용하기 위해 인덱스를 저장.
		// 테스트 용의 인덱스를 따로 관리하는 것이 더 좋을 것으로 판단됨.
	    private static Int32 currentRememberListIndex;
		private static Int32 currentNotRememberListIndex;

	    // 좀 더 보류 후 삭제 여부 결정.
        private static Int32 numOfWord;

		// 임포트시 중복 데이터에 대한 처리 옵션.
        private static EImportOption importOption;

        /*
		 *  클래스 데이터를 초기화합니다.
		 */
        public static void Initialize()
	    {
		    rememberList = new List<string>(2048);
		    notRememberList = new List<string>(2048);

		    // 파일을 로드해서 해시테이블과 리스트를 동시에 초기화.
            if (FileManager.DataFileNameList.Count <= 0)
			{
				return;
			}
		    string wordHexString = string.Empty;
		    WordData wordData = null;

		    foreach (string wordName in FileManager.DataFileNameList)
			{
				// 1. 파일 이름으로 데이터 파일 로드
				FileManager.LoadWordDataFromFile(wordName, out wordHexString);
				
				// 2. 로드한 파일 데이터 추출
				DataParser.ParseData(wordHexString, out wordData);
				if (wordData != null)
				{
					// 3. 추출에 성공하면 해시테이블에 할당 및 리스트에 추가.
					WordTable.InsertWordData(wordData);

					if (wordData.RememberType == ERememberType.REMEMBER)
					{
						rememberList.Add(wordData.WordName);
					}
					else
					{
						notRememberList.Add(wordData.WordName);
					}

					++numOfWord;
				}
			}

			// 랜덤으로 시작 인덱스를 결정합니다.
			// 단순히 매 실행마다 같은 순서를 가지는 것을 약간 피하기 위함.
		    Random rand = new Random();
		    currentRememberListIndex = rand.Next(rememberList.Count);
		    currentNotRememberListIndex = rand.Next(notRememberList.Count);


		    MessageBox.Show($"감지된 단어 {FileManager.DataFileNameList.Count}중 {(notRememberList.Count + rememberList.Count)}개가 로드 되었습니다.", "워드 매니저", MessageBoxButtons.OK, MessageBoxIcon.Information);
	    }

        /*
		 *  클래스 데이터를 해제합니다.
		 */
        public static void Release()
	    {
		    saveWordData();

            rememberList.Clear();
			notRememberList.Clear();
	    }

        /*
		 *  setter, 데이터 임포트 과정에서 중복 데이터에 대한 처리 옵션 설정입니다.
		 */
        public static void SetImportOption(EImportOption newOption)
	    {
		    importOption = newOption;
	    }

        /*
		 *  ERememberType으로 지정한 열거형에 맞는 리스트에서
         *  데이터를 해시테이블에서 찾아 반환합니다.
         *  주로 테스트, 메인 폼에서 사용.
		 */
        public static WordData GetWodDataOrNullBy(ERememberType typeToGet)
        {
	        WordData returnData = null;

	        switch (typeToGet)
		    {
				// 미암기된 단어 리스트에서 반환.
				case ERememberType.NOT_REMEMBER:
					if (notRememberList.Count <= 0)
					{
						return returnData;
					}

                    WordTable.FindWordDataOrNull(notRememberList[currentNotRememberListIndex++], out returnData);
					if (currentNotRememberListIndex >= notRememberList.Count)
					{
						currentNotRememberListIndex = 0;
					}
					break;
				// 암기된 단어 리스트에서 반환.
				case ERememberType.REMEMBER:
					if (rememberList.Count <= 0)
					{
						return returnData;
					}
                    WordTable.FindWordDataOrNull(rememberList[currentRememberListIndex++], out returnData);
					if (currentRememberListIndex >= rememberList.Count)
					{
						currentRememberListIndex = 0;
					}
                    break;
				default:
					Debug.Assert(false, $"잘못된 ERememberType 데이터가 넘어왔습니다. {typeToGet}");
					break;
		    }

		    return returnData;

        }

        /*
		 *  AddWordForm에서 입력한 데이터를 통해서 단어 데이터를 생성합니다.
		 */
        public static bool AddWordData(string wordName, List<string> meanList, string memo)
	    {
		    WordData wordData = null;
		    if (WordTable.InsertWordData(wordName, meanList, memo, out wordData))
		    {
				// 처음 추가하는 단어는 무조건 암기되지 않았다고 가정합니다.
			    notRememberList.Add(wordData.WordName);

				// 바로 저장합니다.
                string dataString = MyConverter.WordDataToHexString(wordData);

				FileManager.SaveWordDataToFile(wordName, dataString);
			    FileManager.DataFileNameList.Add(wordName);

                ++numOfWord;

			    wordData = null;
				return true;
		    }

		    return false;
	    }

        /*
		 *  단어 데이터를 통해서 단어를 제거합니다.
         *  (제거는 단어 추가가 전제이기 때문에, 단어 데이터를 인자로 받음.)
		 */
        public static bool RemoveWordData(WordData wordData)
	    {
		    if (WordTable.RemoveWordData(wordData))
		    {
			    if (wordData.RememberType == ERememberType.REMEMBER)
			    {
				    rememberList.Remove(wordData.WordName);
			    }
			    else
			    {
				    notRememberList.Remove(wordData.WordName);
			    }
			    --numOfWord;
				FileManager.RemoveDataFile(wordData.WordName);
				FileManager.DataFileNameList.Remove(wordData.WordName);
				return true;
            }

		    return false;
	    }

        /*
		 *  단어 이름으로 해시 테이블에서 검색하여 결과를 반환합니다.
         *  찾으면 단어 데이터 out 및 true 반환, 그렇지 않으면 null out 및 false 반환.
		 */
        public static bool FindWordDataOrNull(string wordName, out WordData wordData)
	    {
		    return WordTable.FindWordDataOrNull(wordName, out wordData);
	    }

        /*
         *  내용이 수정된 단어 데이터를 파일로 내보냅니다.
         */
        public static void UpdateWordData(WordData wordData)
	    {
            //return WordTable.UpdateWordData(wordData);
            string dataString = MyConverter.WordDataToHexString(wordData);

            FileManager.SaveWordDataToFile(wordData.WordName, dataString);
	    }

        /*
		 *  프로그램에 등록된 모든 단어 데이터를 내보내기하기 위해
         *  데이터를 생성하여 지정 위치에 저장합니다.
		 */
        public static void ExportWordData()
        {
	        WordData word = null;
            StringBuilder exportHexString = new StringBuilder(2048);
            for (Int32 countFile = 0; countFile < FileManager.DataFileNameList.Count; ++countFile)
            {
		        if (FindWordDataOrNull(FileManager.DataFileNameList[countFile], out word))
		        {
					// 1. 해시 변환
			        exportHexString.Append(MyConverter.UInt32ToHexX4(word.Hash));
                    exportHexString.Append(DataParser.DATA_SEPARATOR);

                    // 2. 암기 여부 변환
                    exportHexString.Append(MyConverter.Int32ToHexX4((Int32)word.RememberType));
                    exportHexString.Append(DataParser.DATA_SEPARATOR);

                    // 3. 단어 명 변환
                    exportHexString.Append(MyConverter.StringToHex(word.WordName));
                    exportHexString.Append(DataParser.DATA_SEPARATOR);

                    // 4. 뜻 리스트 변환
					// 마지막 데이터는 데이터 분리문자를 붙이지 않음. (파싱 과정에서 에러 발생)
                    for (Int32 countMean = 0; countMean < word.MeanList.Count; ++countMean)
                    {
	                    exportHexString.Append(MyConverter.StringToHex(word.MeanList[countMean]));
	                    if (countMean < word.MeanList.Count - 1)
	                    {
		                    exportHexString.Append(DataParser.MEAN_DATA_SEPARATOR);
	                    }
                    }

                    // 5. 메모 내용 변환 % 없을 수도 있음.
                    if (!(string.IsNullOrWhiteSpace(word.Memo) || word.Memo == string.Empty))
                    {
	                    exportHexString.Append(DataParser.DATA_SEPARATOR);
	                    exportHexString.Append(MyConverter.StringToHex(word.Memo));
                    }

                    // 6. 변환 완료. 분리자(@) 붙임.
                    // 마지막 데이터는 데이터 분리문자를 붙이지 않음. (파싱 과정에서 에러 발생)
                    if (countFile < FileManager.DataFileNameList.Count - 1)
                    {
	                    exportHexString.Append(DataParser.WORD_SEPARATOR);
                    }
                }
            }

			// 7. 파일로 내보내기.
	        FileManager.SaveExportData(exportHexString.ToString());
        }

        /*
		 * 외부에서 내보내기한 데이터를 불러와 프로그램에 등록합니다.
         * 자동으로 저장됩니다.
		 */
        public static void ImportWordData()
        {
	        Int32 addedWordCount = 0;
	        Int32 modifiedWordCount = 0;
		    string importedDataString = string.Empty;
			List<WordData> wordDataList = new List<WordData>(1024);
			if (!FileManager.LoadImportDataOrEmpty(out importedDataString))
			{
				Debug.Assert(false, "데이터 임포트 실패");
				return;
			}

			// 1. 파서로 워드 데이터 리스트를 가져온다.
			DataParser.ParseImportData(importedDataString, ref wordDataList);

            if (wordDataList.Count <= 0)
            {
	            Debug.Assert(false, "단어 데이터 파싱 실패");
	            return;
            }

            // 2. 데이터 합병을 한다.
            // 2-1. USE_ORIGINAL_DATA : 기존 데이터 사용 (임포트 안함), 건너뛰기
            // 2-2. USE_IMPORTED_DATA : 새로운(임포트한) 데이터 사용 : Update~~()
            // 2-3. USE_MERGED_DATA : 암기여부 제외 합병, 뜻 최대한 추가(16개), 메모 내용 합치기 (<imported> 접두로 붙음.)
            WordData foundDataOriginal = null;
            for (Int32 wordCount = 0; wordCount < wordDataList.Count; ++wordCount)
            {
				// 중복된 데이터의 경우 임포트 옵션을 설정.
                if(WordTable.ExistsUsingWordData(wordDataList[wordCount]))
                {
					CheckImportDataSetting checkImportDataSetting = new CheckImportDataSetting();

					checkImportDataSetting.WordName = wordDataList[wordCount].WordName;

                    checkImportDataSetting.ShowDialog();

					switch (importOption)
					{
					case EImportOption.USE_ORIGINAL_DATA:
						// do nothing
						goto NEXT_LOOP;
					case EImportOption.USE_IMPORTED_DATA:
						if (WordTable.FindWordDataOrNull(wordDataList[wordCount].WordName, out foundDataOriginal))
						{
							foundDataOriginal.UpdateMeanData(wordDataList[wordCount].MeanList);
							foundDataOriginal.UpdateMemo(wordDataList[wordCount].Memo);
							foundDataOriginal.UpdateRememberType(wordDataList[wordCount].RememberType);
							++modifiedWordCount;
						}

						break;
					case EImportOption.USE_MERGED_DATA:

						if (WordTable.FindWordDataOrNull(wordDataList[wordCount].WordName, out foundDataOriginal))
						{
							mergeWordData(ref foundDataOriginal, wordDataList[wordCount]);
							++modifiedWordCount;
						}
                        break;
					default:
						Debug.Assert(false, $"EImportOption 값이 잘못 전달되었습니다. {(Int32)importOption}");
						break;
					}

					// 작업한 데이터를 저장합니다.
					string dataString = MyConverter.WordDataToHexString(foundDataOriginal);
					FileManager.SaveWordDataToFile(foundDataOriginal.WordName, dataString);

                }
                else // 새로운 데이터 추가
                {
					// 추가되지 않은 데이터이므로 추가합니다.
					// 추가로 임포트한(외부) 데이터이므로 외우지 않았다고 가정합니다.
					AddWordData(wordDataList[wordCount].WordName, wordDataList[wordCount].MeanList, wordDataList[wordCount].Memo);
					++addedWordCount;
                }

                NEXT_LOOP:
                foundDataOriginal = null;
                // for end
            }
            // if end
            MessageBox.Show($"임포트된 단어 {wordDataList.Count}개 중 {(addedWordCount)}개가 추가, {modifiedWordCount}개가 수정 되었습니다.", "워드 매니저", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

		/*
		 * 단어 데이터를 미암기 단어 리스트에서 암기 단어 리스트로 이동합니다.
		 * 사용자가 암기했다고 체크했을 때.
		 */
		public static void MoveWordDataToRememberList(string wordName)
		{
			// 미암기->암기로 이동전에 미암기에 속하는 데이터인지 확인합니다.
			if (!notRememberList.Contains(wordName))
			{
				Debug.Assert(false, $"존재하지 않는 데이터를 옮기려고 합니다. : {wordName}");

                return;
			}

			Debug.Assert(!rememberList.Contains(wordName), "이미 암기된 데이터를 암기리스트에 추가하려 합니다.");

			notRememberList.Remove(wordName);
			rememberList.Add(wordName);

            // 옮겨진 리스트의 개수가 줄었으므로, 미암기 리스트의 인덱스 위치 변수를 재계산.
            if (notRememberList.Count > 0)
            {
	            currentNotRememberListIndex = currentNotRememberListIndex % notRememberList.Count;
            }
            else
            {
	            currentNotRememberListIndex = 0;
            }
        }

		/*
		 * 단어 데이터를 암기 단어 리스트에서 미암기 단어 리스트로 이동합니다.
		 * 사용자가 암기하지 못 했다고 체크했을 때.
		 */
		public static void MoveWordDataToNotRememberList(string wordName)
		{
			// 암기->미암기로 이동전에 암기에 속하는 데이터인지 확인합니다.
			if (!rememberList.Contains(wordName))
			{
				Debug.Assert(false, $"존재하지 않는 데이터를 옮기려고 합니다. : {wordName}");

				return;
			}

			Debug.Assert(!notRememberList.Contains(wordName), "이미 암기된 데이터를 암기리스트에 추가하려 합니다.");

			rememberList.Remove(wordName);
			notRememberList.Add(wordName);
			
			// 옮겨진 리스트의 개수가 줄었으므로, 암기 리스트의 인덱스 위치 변수를 재계산.
			if (rememberList.Count > 0)
			{
				currentRememberListIndex = currentRememberListIndex % rememberList.Count;
			}
			else
			{
				currentRememberListIndex = 0;
			}
        }

        // 임포트된 데이터를 기존 데이터에 추가합니다.
        // 뜻은 최대 16개까지 추가되고, 메모는 '<imported>'접두를 붙여 덧붙입니다.
        // 이때의 경우, 최대 글자 제한은 무시합니다.
        // 암기 여부는 포함되지 않습니다.
        private static void mergeWordData(ref WordData originalData, WordData importedData)
	    {

            // 원본을 이어받으므로 별도 작업은 필요없을 것.
			// 하지만 따로 setter를 만들어야 할 듯. 혹은 getter는 copy
            List<string> meanListOriginal = originalData.MeanList;
			if (meanListOriginal.Count < MEAN_COUNT_LIMIT)
			{
				goto COMPLETE_MERGE_MEAN;
			}


			bool bIsDuplicate = false;
			foreach (string mean in importedData.MeanList)
			{
				bIsDuplicate = false;
				// 중복검사
				foreach (string meanOriginal in meanListOriginal)
				{
					if (meanOriginal.Equals(mean))
					{
						bIsDuplicate = true;
					}
				}
				
				// 중복된 뜻은 추가하지 않습니다.
				if (bIsDuplicate == false)
				{
					meanListOriginal.Add(mean);
				}

				if (meanListOriginal.Count < MEAN_COUNT_LIMIT)
				{
					break;
				}
			}

			originalData.UpdateMeanData(meanListOriginal);
            meanListOriginal = null;

			COMPLETE_MERGE_MEAN:

			originalData.UpdateMemo($"{originalData.Memo} <imported>{importedData.Memo}");
	    }

	    /*
	     *  프로그램에 등록된 모든 단어 데이터들을 파일로 내보냅니다.
		 *  프로그램을 종료하기전에 실행합니다.
		 */
        private static void saveWordData()
	    {
		    WordData wordData = null;
		    string wordDataString = string.Empty;
		    foreach (string wordName in FileManager.DataFileNameList)
		    {
			    if (WordTable.FindWordDataOrNull(wordName, out wordData))
			    {
				    wordDataString = MyConverter.WordDataToHexString(wordData);
				    FileManager.SaveWordDataToFile(wordName, wordDataString);
			    }
		    }
	    }

        // 추후에 오토 세이브 기능시 더 제대로 사용될 듯.
        //private static void saveWordDataIfModified()
        //{
        //	WordData wordData = null;
        //	foreach (string wordName in FileManager.DataFileNameList)
        //	{
        //		if (WordTable.FindWordDataOrNull(wordName, out wordData))
        //		{
        //			if (wordData.IsModified)
        //			{
        //				string wordDataString = MyConverter.WordDataToHexString(wordData);
        //				FileManager.SaveWordDataToFile(wordName, wordDataString);
        //			}
        //		}
        //	}
        //}
    }
}
