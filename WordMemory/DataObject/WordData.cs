using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordMemory.Data
{
    public enum ERememberType
    {
        NOT_REMEMBER,
        REMEMBER
    }

    public class WordData
    {
	    public UInt32 Hash { get; }
	    public string WordName { get; }

        public List<string> MeanList { get; set; }

	    public ERememberType RememberType { get; set; }

	    public string Memo { get; set; }

        // 추후에 오토세이브 기능시 사용될 예정.
	    public bool IsModified { get; private set; }



        public WordData(UInt32 hash, string wordName, List<string> meanList, ERememberType rememberType, string memo)
        {
	        Hash = hash;
	        WordName = wordName;
            MeanList = meanList;
	        RememberType = rememberType;
	        Memo = memo;
            // 처음 생성되면 저장되어야 하므로, 체크해야 한다.
	        IsModified = true;
        }

   
        public WordData(UInt32 hash, string wordName, List<string> meanList, string memo)
            : this(hash, wordName, meanList, ERememberType.NOT_REMEMBER, memo)
        { }



        public void UpdateMeanData(List<string> newMeanList)
        {
            MeanList.Clear();
            MeanList = newMeanList;
            IsModified = true;
        }

        public void UpdateRememberType(ERememberType newRememberType)
        {
	        RememberType = newRememberType;
	        IsModified = true;
        }

        public void UpdateMemo(string newMemo)
        {
	        Memo = newMemo;
	        IsModified = true;
        }

        // 오토세이브 기능이 사용될 때 사용.
        public void Saved()
        {
            Debug.Assert(false, "현재 사용되지 않는 기능이 호출되었습니다.");
	        IsModified = false;
        }


    }

}
