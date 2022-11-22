using System;
using System.Collections.Generic;
using WordMemory.Data;

namespace WordMemory
{
	/*
	 *  단어 데이터의 해시 테이블 클래스
	 */
    public static class WordTable
    {
	    // 백과사전도 아니고 개인 학습 목적의 프로그램에 이정도면 충분하다 못해 넘치는 크기일 것.
        private static List<WordData>[] wordHashTable;
	    private static readonly Int32 TABLE_SIZE = 5101;
	    private static readonly Int32 BUCKET_SIZE_DEFAULT = 4;

		/*
		 *  클래스를 초기화 합니다.
		 */
	    public static void Initialize()
	    {
			wordHashTable = new List<WordData>[TABLE_SIZE];
	    }

		/*
		 *  클래스 데이터를 해제합니다.
		 */
	    public static void Release()
	    {
		    foreach (List<WordData> word in wordHashTable)
		    {
			    if (word != null)
			    {
				    word.Clear();
			    }
            }
		    wordHashTable = null;
	    }

	    /*
		 *  해시 테이블에 이미 만들어진 단어 데이터를 삽입합니다.
	     *  주로, 데이터 임포트, 저장된 단어 데이터를 추가시 사용.
		 */
        public static bool InsertWordData(WordData wordData)
	    {
		    if (ExistsUsingWordData(wordData))
		    {
			    // 이미 존재하는 단어로 추가할 필요 없음.
			    return false;
		    }
			// 처음 할당되는 경우 리스트를 생성합니다. (기본 버켓 사이즈4)
		    if (wordHashTable[wordData.Hash] == null)
		    {
			    wordHashTable[wordData.Hash] = new List<WordData>(BUCKET_SIZE_DEFAULT);
		    }
            wordHashTable[wordData.Hash].Add(wordData);
		    return true;
	    }

        /*
		 *  해시 테이블에 단어 데이터를 생성하여 삽입합니다.
         *  주로 단어 데이터를 생성할 때 사용.
		 */
        public static bool InsertWordData(string wordName, List<string> meanList, string memo, out WordData wordData)
	    {
		    if (Exists(wordName))
		    {
                // 이미 존재하는 단어로 추가할 필요 없음.
                wordData = null;
                return false;
		    }
		    UInt32 hash = calcHashdjb2(wordName);
			// 데이터 생성
		    WordData newData = new WordData((UInt32)hash, wordName, meanList, memo);

		    if (wordHashTable[hash] == null)
		    {
			    wordHashTable[hash] = new List<WordData>(BUCKET_SIZE_DEFAULT);
		    }

            wordHashTable[hash].Add(newData);

            wordData = newData;
            newData = null;
            return true;
	    }

        /*
		 *  단어 이름으로 해시 테이블을 검색합니다.
         *  찾으면 단어 데이터를 반환하고 그렇지 않으면 null을 반환합니다.
		 */
        public static bool FindWordDataOrNull(string wordName, out WordData foundData)
	    {
		    foundData = null;
		    UInt32 hash = calcHashdjb2(wordName);
		    List<WordData> data = wordHashTable[hash];
		    if (data == null || data.Count <= 0)
		    {
			    return false;
		    }

		    foreach (WordData word in data)
		    {
			    if (word.WordName.Equals(wordName))
			    {
				    foundData = word;
				    return true;
			    }
		    }

		    return false;
        }

        /*
		 *  해시 테이블에서 단어 데이터를 제거합니다.
		 */
        public static bool RemoveWordData(WordData wordData)
	    {
		    List<WordData> data = wordHashTable[wordData.Hash];
		    if (data == null || data.Count <= 0)
		    {
			    return false;
		    }

		    for (Int32 index = 0; index < data.Count; ++index)
		    {
				// 확인해보니 내부적으로 같은 주소인지, 문자열이 같은지 검사해 줌(특이하게)
			    if (data[index].WordName.Equals(wordData.WordName))
			    {
				    data.RemoveAt(index);
				    return true;
			    }
		    }

		    return false;
	    }

        /*
		 *  단어 이름으로 해시 테이블에 데이터가 존재하는지 확인합니다.
         *  찾으면 true, 그렇지 않으면 false.
		 */
        public static bool Exists(string wordName)
	    {
		    UInt32 hash = calcHashdjb2(wordName);
			List<WordData> data = wordHashTable[hash];
			if (data == null || data.Count <= 0)
			{
				return false;
			}

			foreach (WordData word in data)
			{
				if (word.WordName.Equals(wordName))
				{
					return true;
				}
			}

		    return false;
	    }

        /*
		 *  단어 데이터로 해시 테이블에 데이터가 존재하는지 확인합니다.
         *  찾으면 true, 그렇지 않으면 false.
		 */
        public static bool ExistsUsingWordData(WordData wordData)
        {
	        List<WordData> data = wordHashTable[wordData.Hash];
	        if (data == null || data.Count <= 0)
	        {
		        return false;
	        }

            foreach (WordData word in data)
	        {
		        if (word.WordName.Equals(wordData.WordName))
		        {
			        return true;
		        }
	        }

	        return false;
        }

        /*
		 *  해시를 생성하는 해시함수입니다.
         *  단어 이름으로 해시를 생성합니다.
		 */
        private static UInt32 calcHashdjb2(string wordName)
	    {
		    UInt32 hash = 5381;

		    foreach (char ch in wordName)
		    {
			    hash = ((hash << 5) + hash) + ch; /* hash * 33 + c */
		    }

		    return hash%(UInt32)TABLE_SIZE;
	    }
    }
}
