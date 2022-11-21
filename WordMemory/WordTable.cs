using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemory.Data;

namespace WordMemory
{
    public static class WordTable
    {
	    // 백과사전도 아니고 개인 학습 목적의 프로그램에 이정도면 충분하다 못해 넘치는 크기일 것.
        private static List<WordData>[] wordHashTable;
	    private static readonly Int32 TABLE_SIZE = 5101;
	    private static readonly Int32 BUCKET_SIZE_DEFAULT = 4;


        public static void Initialize()
	    {
			wordHashTable = new List<WordData>[TABLE_SIZE];
	    }
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

	    public static bool InsertWordData(WordData wordData)
	    {
		    if (ExistsUsingWordData(wordData))
		    {
			    // 이미 존재하는 단어로 추가할 필요 없음.
			    return false;
		    }
		    if (wordHashTable[wordData.Hash] == null)
		    {
			    wordHashTable[wordData.Hash] = new List<WordData>(BUCKET_SIZE_DEFAULT);
		    }
            wordHashTable[wordData.Hash].Add(wordData);
		    return true;
	    }

        public static bool InsertWordData(string wordName, List<string> meanList, string memo, out WordData wordData)
	    {
		    if (Exists(wordName))
		    {
                // 이미 존재하는 단어로 추가할 필요 없음.
                wordData = null;
                return false;
		    }
		    Int32 hash = calcHashdjb2(wordName);
		    WordData newData = new WordData(hash, wordName, meanList, memo);
		    if (wordHashTable[hash] == null)
		    {
			    wordHashTable[hash] = new List<WordData>(BUCKET_SIZE_DEFAULT);
		    }
            wordHashTable[hash].Add(newData);
            wordData = newData;
            newData = null;
            return true;
	    }

	   // public static bool UpdateWordData(WordData wordData)
	   // {
		  //  if (!ExistsUsingWordData(wordData))
		  //  {
			 //   // 존재하지 않는 데이터는 에러.
				//Debug.Assert(false, "존재하지 않는 데이터가 업데이트 시도되었습니다. 새 데이터는 Insert입니다.");
			 //   return false;
		  //  }

		  //  List<WordData> wordList = wordHashTable[wordData.Hash];
		  //  if (wordList == null)
		  //  {
			 //   return false;
		  //  }
		  //  for (Int32 index = 0; index < wordList.Count; ++index)
		  //  {
			 //   if (wordList[index].WordName.Equals(wordData.WordName))
			 //   {
				//	wordList[index] = wordData;
				//	wordData = null;
				//	return true;
			 //   }
		  //  }

		  //  Debug.Assert(false, "이상 동작, 같은 단어를 찾지 못했습니다.");

    //        return false;
	   // }

	    public static bool FindWordData(string wordName, out WordData foundData)
	    {
		    foundData = null;
		    Int32 hash = calcHashdjb2(wordName);
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

	    public static bool RemoveWordData(WordData wordData)
	    {
		    List<WordData> data = wordHashTable[wordData.Hash];
		    if (data == null || data.Count <= 0)
		    {
			    return false;
		    }

			// 추후 wordData를 비교 함수를 오버라이드 해서 단어 명으로 비교할 수 있도록 수정.

		    for (Int32 index = 0; index < data.Count; ++index)
		    {
			    if (data[index].WordName.Equals(wordData.WordName))
			    {
				    data.RemoveAt(index);
				    return true;
			    }
		    }

		    return false;
	    }

        public static bool Exists(string wordName)
	    {
		    Int32 hash = calcHashdjb2(wordName);
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
        private static Int32 calcHashdjb2(string wordName)
	    {
		    Int32 hash = 5381;

		    foreach (char ch in wordName)
		    {
			    hash = ((hash << 5) + hash) + ch; /* hash * 33 + c */
		    }

		    return hash%TABLE_SIZE;
	    }
    }
}
