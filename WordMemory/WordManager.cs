using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WordMemory.Data;

namespace WordMemory
{
    public static class WordManager
    {
        // UI에 단어를 보여주기 위해서 미/암기 데이터 리스트로 저장.
        // 데이터를 통채로 들고있기는 해시 테이블의 의미가 많이 사라지니, 해시값으로만.
        private static List<Int32> rememberList;
	    private static List<Int32> notRememberList;

	    public static readonly Int32 MEAN_COUNT_LIMIT = 16;
	    public static readonly Int32 MEAN_STRING_LENGTH_LIMIT = 16;

		// 사전에 등록된 단어중 가장 긴 단어가 45자.
		// 다만, 현실적으로 외울 수 있는 범위의 단어를 등록하는 것이
		// 좋을 수 있기 때문에 나중에 수정 가능성 있음.
        public static readonly Int32 WORD_STRING_LENGTH_LIMIT = 46;
        public static readonly Int32 MEMO_STRING_LENGTH_LIMIT = 64;


        // 해시가 겹치는 애들은 따로 카운트로 관리하던가?
        // 아니면 다른 방안을 더 생각해보기.

        public static void Initialize()
	    {
		    WordTable.Initialize();

			// 파일을 로드해서 해시테이블과 리스트를 동시에 초기화.
			if (FileManager.DataFileNameList.Count <= 0)
			{
				return;
			}
		    string wordHexString = string.Empty;
		    WordData wordData;

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

					if (wordData.RememberType == eRememberType.REMEMBER)
					{
						rememberList.Add(wordData.Hash);
					}
					else
					{
						notRememberList.Add(wordData.Hash);
					}
				}
			}
	    }

	    public static void Release()
	    {
			rememberList.Clear();
			notRememberList.Clear();
			// 해시 클리어.
	    }

	    public static void ShowWordToUI() // get으로 바꿔야 할 듯. UI에서 받아가도록.
	    {
			
	    }

	    public static void AddWordData(string wordName, List<string> meanList, string memo)
	    {
		    Int32 hash = 0;
		    if (WordTable.InsertWordData(wordName, meanList, memo, out hash))
		    {
			    notRememberList.Add(hash);
			    Setting.IncreaseWordCount();
			    FileManager.DataFileNameList.Add(wordName);
		    }
        }

	    public static void RemoveWordData(WordData wordData)
	    {
		    Int32 hash = 0;
		    if (WordTable.RemoveWordData(wordData))
		    {
			    if (wordData.RememberType == eRememberType.REMEMBER)
			    {
				    rememberList.Remove(wordData.Hash);
			    }
			    else
			    {
				    notRememberList.Remove(wordData.Hash);
			    }
				Setting.DecreaseWordCount();
				FileManager.DataFileNameList.Remove(wordData.GetWordName());
		    }
	    }

	    public static bool FindWordData(string wordName, out WordData wordData)
	    {
		    return WordTable.FindWordData(wordName, out wordData);
	    }

	    public static bool UpdateWordData(WordData wordData)
	    {
		    return WordTable.UpdateWordData(wordData);
	    }

        public static void ExportWordData()
        {
	        const char DATA_SEPARATOR = '#';
	        const char WORD_SEPARATOR = '@';
	        const char MEAN_SEPARATOR = '\n';


            WordData word = null;
            StringBuilder exportHexString = new StringBuilder(2048);
	        foreach (string fileName in FileManager.DataFileNameList)
	        {
		        if (FindWordData(fileName, out word))
		        {
					// 1. 해시 변환
			        exportHexString.Append(MyConverter.Int32ToHexX4(word.Hash));
                    exportHexString.Append(DATA_SEPARATOR);

                    // 2. 암기 여부 변환
                    exportHexString.Append(MyConverter.Int32ToHexX4((Int32)word.RememberType));
                    exportHexString.Append(DATA_SEPARATOR);

                    // 3. 단어 명 변환
                    exportHexString.Append(MyConverter.StringToHex(word.GetWordName()));
                    exportHexString.Append(DATA_SEPARATOR);

                    // 4. 뜻 리스트 변환
                    foreach (string mean in word.MeanList)
                    {
	                    exportHexString.Append(MyConverter.StringToHex(mean));
	                    exportHexString.Append(MEAN_SEPARATOR);
                    }
                    exportHexString.Append(DATA_SEPARATOR);

                    // 5. 메모 내용 변환 % 없을 수도 있음.
                    if (!(string.IsNullOrWhiteSpace(word.Memo) || word.Memo == string.Empty))
                    {
	                    exportHexString.Append(MyConverter.StringToHex(word.Memo));
	                    exportHexString.Append(DATA_SEPARATOR);
                    }

                    // 6. 변환 완료. 분리자(@) 붙임.
                    exportHexString.Append(WORD_SEPARATOR);
		        }
            }

			// 7. 파일로 내보내기.
	        FileManager.SaveExportData(exportHexString.ToString());
        }

	    public static void ImportWordData()
	    {
		    string importedDataString;
			List<WordData> wordDataList = new List<WordData>(1024);
		    if (FileManager.LoadImportDataOrEmpty(out importedDataString))
		    {
				DataParser.ParseImportData(importedDataString, ref wordDataList);
				if (wordDataList.Count > 0)
				{
					// 기존 데이터들과 임포트된 데이터를 합병한다.
					// 겹치는 데이터가 존재하면 사용자에게 어떤 버전을 사용할 것인지 확인한다.(기존꺼 사용, 새로운 데이터 사용, (위험)그냥 합치기)
					// 겹치지 않는 데이터는 그냥 추가.

					// 새로운 데이터이면,

					// 해시에 삽입

					// 워드 매니저 리스트 업데이트

					// 파일 목록에 추가

					// 충돌한 데이터이면,

					// 사용자 확인에 따라 동작.
					// -1. 기존 데이터 사용 (임포트 안함) : 건너뛰기
					// -2. 새로운 데이터 사용 : Update()
					// -3. 합병 : 뜻 최대한 추가, 메모 내용 합치기 (<imported> 접두로 붙음.)

					// 갱신된 데이터들 파일 저장.
				}
		    }

	    }

    }
}
