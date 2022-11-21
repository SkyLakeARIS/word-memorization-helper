using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory
{
    public enum EViewMode
    {
	    SHOW_ONLY_NOT_REMEMBER,
        SHOW_ONLY_REMEMBER,
        SHOW_MIXED
    };
    public enum ERefreshMode
    {
        MANUAL,
        TIMER,
    };

    public static class Setting
    {
        public static EViewMode ViewMode {get; set; }
        public static ERefreshMode RefreshMode { get; set; }
        public static Int32 RefreshTime { get; set; }

        public static readonly Int32 REFRESH_TIME_DEFAULT = 300;

        public static void Initialize()
        {
	        string filePath = $"{FileManager.SETTING_FILE_NAME}.{FileManager.SETTING_FILE_EXTENSTION}";
            if (!File.Exists(filePath))
            {
	            StreamWriter streamWriter = new StreamWriter(filePath, false);

                ViewMode = EViewMode.SHOW_ONLY_NOT_REMEMBER;
                RefreshMode = ERefreshMode.TIMER;
                RefreshTime = REFRESH_TIME_DEFAULT;
                streamWriter.Write(makeSettingDataToHexString());
                streamWriter.Close();
                return;
            }

            string settingData = string.Empty;
            FileManager.LoadProgramSettingFromFile(out settingData);
            DataParser.ParseProgramSettingDataAndSet(settingData);
        }

        public static void SaveSettingData()
        {
	        FileManager.SaveProgramSettingToFile(makeSettingDataToHexString());
        }

        private static string makeSettingDataToHexString()
        {
	        StringBuilder stringBuilder = new StringBuilder(128);

            // 1. 보기모드 변환
	        stringBuilder.Append(MyConverter.Int32ToHexX4((Int32) ViewMode));
	        stringBuilder.Append(DataParser.DATA_SEPARATOR);

            // 2. 갱신모드 변환
	        stringBuilder.Append(MyConverter.Int32ToHexX4((Int32)RefreshMode));
	        stringBuilder.Append(DataParser.DATA_SEPARATOR);

            // 3. 타이머 설정 변환
	        stringBuilder.Append(MyConverter.Int32ToHexX4(RefreshTime));

	        return stringBuilder.ToString();
        }
    }
}
