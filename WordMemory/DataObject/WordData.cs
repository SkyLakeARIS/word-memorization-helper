using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemory.Data;

namespace WordMemory.Data
{
    public enum eRememberType
    {
        NOT_REMEMBER,
        REMEMBER
    }

    public class WordData
    {
	    public Int32 Hash { get; }

	    private string mWordName;
	    //{
		   // get { return WordName; }
		   // set { WordName = value; } // init으로
	    //}
	    public List<string> MeanList { get; set; }

	    public eRememberType RememberType { get; set; }
	    public string Memo { get; set; }

	    public bool mbModified;

        public WordData(Int32 hash, string wordName, List<string> meanList, eRememberType rememberType, string memo)
        {
	        Hash = hash;
	        mWordName = wordName;
            MeanList = meanList;
	        RememberType = rememberType;
	        Memo = memo;
            // 처음 생성되면 저장되어야 하므로, 체크해야 한다.
	        mbModified = true;
        }

        //public WordData(string wordName, List<string> meanList, string memo)
	       // : this(/*해시 계산 후 반환*/, wordName, meanList, eRememberType.NOT_REMEMBER, memo)
        //{ }

        public WordData(Int32 hash, string wordName, List<string> meanList, string memo)
            : this(hash, wordName, meanList, eRememberType.NOT_REMEMBER, memo)
        { }

        public string GetWordName()
        {
	        return mWordName;
        }


        public void UpdateMeanData(List<string> newMeanList)
        {
            MeanList.Clear();
            MeanList = newMeanList;
            mbModified = true;
        }

        public void UpdateRememberType(eRememberType newRememberType)
        {
	        RememberType = newRememberType;
	        mbModified = true;
        }

        public void UpdateMemo(string newMemo)
        {
	        Memo = newMemo;
	        mbModified = true;
        }

        public bool IsModified()
        {
            return mbModified;
        }

    }

}
