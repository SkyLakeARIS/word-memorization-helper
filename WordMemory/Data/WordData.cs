using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory.Data
{
    public enum eRememberType
    {
        NOT_REMEMBER,
        REMEMBER
    }

    public class WordData
    {
        public WordData(Int32 hash, Word word, eRememberType rememberType, string memo)
        {
            mHash = hash;
            mWord = word;
            mRememberType = rememberType;
            mMemo = memo;
        }

        //public WordData(Word word, string memo)
        //    : this(/*hash해시 함수에서 할당.,*/ word, eRememberType.NOT_REMEMBER, memo)
        //{ }

        public WordData(Int32 hash, Word word, string memo)
            : this(hash, word, eRememberType.NOT_REMEMBER, memo)
        { }

        public WordData(Int32 hash, string wordName, List<string> meanList, string memo)
            : this(hash, new Word(wordName, meanList), eRememberType.NOT_REMEMBER, memo)
        { }



        private Int32 mHash { get; }
        private Word mWord { get; }
        private eRememberType mRememberType { get; set; }
        private string mMemo { get; set; }

        private bool mbModified { get; }
    }

}
