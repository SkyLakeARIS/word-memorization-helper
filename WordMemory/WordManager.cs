using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemory.Data;
using WordMemory.Forms;

namespace WordMemory
{
    public static class WordManager
    {
	    public static readonly Int32 MEAN_COUNT_LIMIT = 16;
	    public static readonly Int32 MEAN_STRING_LENGTH_LIMIT = 16;

	    // 사전에 등록된 단어중 가장 긴 단어가 45자.
	    // 다만, 현실적으로 외울 수 있는 범위의 단어를 등록하는 것이
	    // 좋을 수 있기 때문에 나중에 수정 가능성 있음.
	    public static readonly Int32 WORD_STRING_LENGTH_LIMIT = 46;
	    public static readonly Int32 MEMO_STRING_LENGTH_LIMIT = 64;

        // UI에 단어를 보여주기 위해서 미/암기 데이터 리스트로 저장.
        // 데이터를 통채로 들고있기는 해시 테이블의 의미가 많이 사라지니, 해시값으로만.
        private static List<Int32> rememberList;
	    private static List<Int32> notRememberList;

        private static Int32 numOfWord;

        private static EImportOption importOption;
        // 해시가 겹치는 애들은 따로 카운트로 관리하던가?
        // 아니면 다른 방안을 더 생각해보기.

        public static void Initialize()
	    {
		    rememberList = new List<Int32>(2048);
		    notRememberList = new List<Int32>(2048);

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
						rememberList.Add(wordData.Hash);
					}
					else
					{
						notRememberList.Add(wordData.Hash);
					}

					++numOfWord;

				}
			}
	    }

	    public static void Release()
	    {
			rememberList.Clear();
			notRememberList.Clear();
			// 해시 클리어.
	    }

	    public static void SetImportOption(EImportOption newOption)
	    {
		    importOption = newOption;
	    }

        public static void ShowWordToUI() // get으로 바꿔야 할 듯. UI에서 받아가도록.
	    {
			
	    }

	    public static bool AddWordData(string wordName, List<string> meanList, string memo)
	    {
		    WordData wordData = null;
		    if (WordTable.InsertWordData(wordName, meanList, memo, out wordData))
		    {
			    notRememberList.Add(wordData.Hash);
                string dataString = MyConverter.WordDataToHexString(wordData);
				FileManager.SaveWordDataToFile(wordName, dataString);
			    FileManager.DataFileNameList.Add(wordName);
                ++numOfWord;

			    wordData = null;
				return true;
		    }

		    return false;
	    }

	    public static bool RemoveWordData(WordData wordData)
	    {
		    if (WordTable.RemoveWordData(wordData))
		    {
			    if (wordData.RememberType == ERememberType.REMEMBER)
			    {
				    rememberList.Remove(wordData.Hash);
			    }
			    else
			    {
				    notRememberList.Remove(wordData.Hash);
			    }
			    --numOfWord;
				FileManager.RemoveDataFile(wordData.WordName);
				FileManager.DataFileNameList.Remove(wordData.WordName);
				return true;
            }

		    return false;
	    }

	    public static bool FindWordData(string wordName, out WordData wordData)
	    {
		    return WordTable.FindWordData(wordName, out wordData);
	    }

	    public static void UpdateWordData(WordData wordData)
	    {
            //return WordTable.UpdateWordData(wordData);
            string dataString = MyConverter.WordDataToHexString(wordData);

            FileManager.SaveWordDataToFile(wordData.WordName, dataString);
	    }

        public static void ExportWordData()
        {
	        WordData word = null;
            StringBuilder exportHexString = new StringBuilder(2048);
            for (Int32 countFile = 0; countFile < FileManager.DataFileNameList.Count; ++countFile)
            {
		        if (FindWordData(FileManager.DataFileNameList[countFile], out word))
		        {
					// 1. 해시 변환
			        exportHexString.Append(MyConverter.Int32ToHexX4(word.Hash));
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

	    public static void ImportWordData()
	    {
		    string importedDataString = string.Empty;
			List<WordData> wordDataList = new List<WordData>(1024);
			if (!FileManager.LoadImportDataOrEmpty(out importedDataString))
			{
				return;
			}

			// 1. 파서로 워드 데이터 리스트를 가져온다.
			DataParser.ParseImportData(importedDataString, ref wordDataList);

            if (wordDataList.Count <= 0)
            {
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
					
					checkImportDataSetting.ShowDialog();

					switch (importOption)
					{
					case EImportOption.USE_ORIGINAL_DATA:
						// do nothing
						break;
					case EImportOption.USE_IMPORTED_DATA:
						if (WordTable.FindWordData(wordDataList[wordCount].WordName, out foundDataOriginal))
						{
							foundDataOriginal.UpdateMeanData(wordDataList[wordCount].MeanList);
							foundDataOriginal.UpdateMemo(wordDataList[wordCount].Memo);
							foundDataOriginal.UpdateRememberType(wordDataList[wordCount].RememberType);
							foundDataOriginal = null;
                        }

						break;
					case EImportOption.USE_MERGED_DATA:

						if (WordTable.FindWordData(wordDataList[wordCount].WordName, out foundDataOriginal))
						{
							mergeWordData(ref foundDataOriginal, wordDataList[wordCount]);
							foundDataOriginal = null;
						}
                        break;
					default:
						Debug.Assert(false, $"EImportOption 값이 잘못 전달되었습니다. {(Int32)importOption}");
						break;
					}
                }
                else // 새로운 데이터 추가
                {
					// 추가되지 않은 데이터이므로 추가합니다.
					// 추가로 임포트한(외부) 데이터이므로 외우지 않았다고 가정합니다.
					AddWordData(wordDataList[wordCount].WordName, wordDataList[wordCount].MeanList, wordDataList[wordCount].Memo);

                }
				// for end
            }
			// if end
				
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
    }
}
