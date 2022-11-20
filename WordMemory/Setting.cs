using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory
{
    public enum eViewMode
    {
        SHOW_ONLY_REMEMBER,
        SHOW_ONLY_NOT_REMEMBER,
        SHOW_MIXED
    };
    public enum eRefreshMode
    {
        MANUAL,
        TIMER,
    };

    public static class Setting
    {
        public static eViewMode ViewMode {get; set; }
        public static eRefreshMode RefreshMode { get; set; }
        public static Int32 RefreshTime { get; set; }

        private static Int32 NumOfWord;


        public static void Initialize()
        {

        }


        public static Int32 GetWordCount()
        {
	        return NumOfWord;
        }
        public static void IncreaseWordCount()
        {
	        ++NumOfWord;
        }
        public static void DecreaseWordCount()
        {
	        --NumOfWord;
        }
        public static void SetWordCount(Int32 numOfWord)
        {
            Debug.Assert(numOfWord >= 0, "numOfWord은 음수가 될 수 없습니다.");
	        NumOfWord = numOfWord;
        }
    }
}
