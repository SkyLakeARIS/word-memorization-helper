using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
    public enum EAutoStart
    {
        UNSET_AUTO_START,
	    SET_AUTO_START
    };

    /*
	 * 프로그램 환경설정 클래스
	 */
    public static class Setting
    {
        public static EViewMode ViewMode {get; set; }
        public static ERefreshMode RefreshMode { get; set; }
        public static EAutoStart AutoStart { get; set; }
        public static Int32 RefreshTimeMilliseconds
        {
	        private get
	        {
		        return refreshTimeMilliconds;
	        }

	        set
	        {
		        refreshTimeMilliconds = value * CONVERT_TO_MINUTES_OR_MILLISEC;

	        }
        }

        public static readonly Int32 REFRESH_TIME_MINUTES_DEFAULT = 10;
        public static readonly Int32 CONVERT_TO_MINUTES_OR_MILLISEC = 60 * 1000;

        // 재귀 호출 방지 용으로 일단 생성. 옳은 방법인지 좀 더 조사 필요.
        private static Int32 refreshTimeMilliconds;

        /*
         *  클래스 데이터를 초기화합니다.
         */
        public static void Initialize()
        {
	        string filePath = $"{FileManager.SETTING_FILE_NAME}.{FileManager.SETTING_FILE_EXTENSTION}";
            if (!File.Exists(filePath))
            {
	            StreamWriter streamWriter = new StreamWriter(filePath, false);

                ViewMode = EViewMode.SHOW_ONLY_NOT_REMEMBER;
                RefreshMode = ERefreshMode.TIMER;
                RefreshTimeMilliseconds = REFRESH_TIME_MINUTES_DEFAULT;
                AutoStart = EAutoStart.SET_AUTO_START;
                streamWriter.Write(makeSettingDataToHexString());
                streamWriter.Close();

                return;
            }

            string settingData = string.Empty;
            FileManager.LoadProgramSettingFromFile(out settingData);
            DataParser.ParseProgramSettingDataAndSet(settingData);
        }

        /*
         *  타이머 갱신 값을 분단위로 반환합니다.
         */
        public static Int32 GetRefreshTimeMinutes()
        {
	        return refreshTimeMilliconds / CONVERT_TO_MINUTES_OR_MILLISEC;
        }

        /*
         *  타이머 갱신 값을 밀리초 단위로 반환합니다.
         */
        public static Int32 GetRefreshTimeMilliseconds()
        {
	        return refreshTimeMilliconds;
        }

        /*
		 *  환경설정 데이터를 파일로 내보냅니다.
		 */
        public static void SaveSettingData()
        {
	        FileManager.SaveProgramSettingToFile(makeSettingDataToHexString());
        }

        /*
          *  환경설정 데이터를 파일로 내보내기 위해서 데이터를 생성합니다.
          */
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
            // 저장시에는 분 단위로 저장한다.
            Int32 refreshTimeMinutes = GetRefreshTimeMinutes();
            stringBuilder.Append(MyConverter.Int32ToHexX4(refreshTimeMinutes));
            stringBuilder.Append(DataParser.DATA_SEPARATOR);

            // 4. 윈도우 시작시 자동실행 여부를 저장합니다.
            stringBuilder.Append(MyConverter.Int32ToHexX4((Int32)AutoStart));

            return stringBuilder.ToString();
        }
    }
}
