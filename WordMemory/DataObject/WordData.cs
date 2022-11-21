﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemory.Data;

namespace WordMemory.Data
{
    public enum ERememberType
    {
        NOT_REMEMBER,
        REMEMBER
    }

    public class WordData
    {
	    public Int32 Hash { get; }
	    public string WordName { get; }

        public List<string> MeanList { get; set; }

	    public ERememberType RememberType { get; set; }

	    public string Memo { get; set; }

	    public bool IsModified { get; private set; }



        public WordData(Int32 hash, string wordName, List<string> meanList, ERememberType rememberType, string memo)
        {
	        Hash = hash;
	        WordName = wordName;
            MeanList = meanList;
	        RememberType = rememberType;
	        Memo = memo;
            // 처음 생성되면 저장되어야 하므로, 체크해야 한다.
	        IsModified = true;
        }

        //public WordData(string wordName, List<string> meanList, string memo)
	       // : this(/*해시 계산 후 반환*/, wordName, meanList, ERememberType.NOT_REMEMBER, memo)
        //{ }

        public WordData(Int32 hash, string wordName, List<string> meanList, string memo)
            : this(hash, wordName, meanList, ERememberType.NOT_REMEMBER, memo)
        { }

        //public string GetWordName()
        //{
	       // return mWordName;
        //}


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

        //public bool IsModified()
        //{
        //    return IsModified;
        //}

    }

}
