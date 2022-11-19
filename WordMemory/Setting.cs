using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory
{
    public enum EViewMode
    {
        SHOW_ONLY_REMEMBER,
        SHOW_ONLY_NOT_REMEMBER,
        SHOW_MIXED
    };
    public enum ERefreshMode
    {
        MANUAL,
        TIMER,
    };

    public static class Setting
    {
        public static Int32 RefreshTime { get; set; }
        public static EViewMode ViewMode { get; set; }
        public static ERefreshMode RefreshMode { get; set; }


    }
}
