using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace WordMemory
{
	/*
	 *  파일과 관련된 전체적인 일을 담당합니다.
	 *  단어 데이터 저장/로드, 환경설정 파일 저장/로드, 익스포트 데이터 내보내기/불러오기, 파일리스트 관리
	 *  hex string 데이터를 받습니다.
	 */
    public static class FileManager
    {
        // 프로그램에 등록된 단어 데이터리스트를 파일(단어)이름으로 저장합니다.
        public static List<string> DataFileNameList = null;

        public static readonly string FILE_EXTENSTION = "wmd";
        public static readonly string EXPORT_WORDATA_FILE_EXTENSTION = "expwmd";
        public static readonly string SETTING_FILE_NAME = "setting";
        public static readonly string SETTING_FILE_EXTENSTION = "wmsetting";
        public static readonly string WORDDATA_DIRECTORY_PATH = "Data";
        //public static readonly string PROGRAM_PATH = "";

        /*
		 *  클래스 데이터를 초기화합니다.
		 */
        public static void Initialize()
        {
	        DataFileNameList = new List<string>(2048);
	        loadFileListFromDataDir();
        }

        /*
		 *  클래스 데이터를 반환합니다.
		 */
        public static void Release()
        {
	        DataFileNameList.Clear();
	        DataFileNameList = null;
        }

        /*
		 *  프로그램 환경설정의 hex string 데이터를 파일로 저장합니다.
         *  경로는 고정입니다.
		 */
        public static void SaveProgramSettingToFile(string dataToSave)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(dataToSave) || dataToSave != ""), "저장할 데이터가 존재하지 않습니다.");
	        if (string.IsNullOrWhiteSpace(dataToSave) || dataToSave == "")
	        {
		        return;
	        }

            string filePath = $"{SETTING_FILE_NAME}.{SETTING_FILE_EXTENSTION}";
	        // 기존 모든 내용을 무시하고 덮어쓰기.
	        StreamWriter writer = new StreamWriter(filePath, false);

	        writer.Write(dataToSave);

	        writer.Close();
	        writer = null;
        }

        /*
		 *  프로그램 환경설정의 데이터 파일을 읽어서 반환합니다.
         *  hex string을 반환합니다.
         *  경로는 고정입니다.
		 */
        public static void LoadProgramSettingFromFile(out string settingString)
        {
            string filePath = $"{SETTING_FILE_NAME}.{SETTING_FILE_EXTENSTION}";

            StreamReader reader = new StreamReader(filePath);
            // 데이터를 처음부터 끝까지 읽어옴.
            settingString = reader.ReadToEnd();

            reader.Close();

            reader = null;
        }

        /*
		 *  단어 hex string 데이터를 파일로 저장합니다.
         *  데이터 저장 경로에 데이터 이름으로 저장됩니다.
		 */
        public static void SaveWordDataToFile(string wordName, string dataToSave)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordName) || wordName != ""), "wordName은 단어 이름이어야 합니다.");
            Debug.Assert((!string.IsNullOrWhiteSpace(dataToSave) || dataToSave != ""), "저장할 데이터가 없습니다.");
            if (string.IsNullOrWhiteSpace(wordName) || wordName == "")
            {
	            return;
            }

            string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordName}.{FILE_EXTENSTION}";
            // 기존 모든 내용을 무시하고 덮어쓰기.
            StreamWriter writer = new StreamWriter(filePath, false);

            writer.Write(dataToSave);

            writer.Close();
            writer = null;
        }


        /*
		 *  단어 이름으로 단어 데이터 파일을 읽어서 hex string을 반환합니다.
		 */
        public static void LoadWordDataFromFile(string wordNameToLoad, out string wordDataString)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != ""), "WordNameToLoad 단어 이름이어야 합니다.");
            if (string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad == "")
            {
	            wordDataString = string.Empty;
	            return;
            }

            string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordNameToLoad}.{FILE_EXTENSTION}";

            StreamReader reader = new StreamReader(filePath);
            wordDataString = reader.ReadToEnd();

   
            reader.Close();

            reader = null;
        }

        /*
		 *  단어 이름을 통해 데이터 디렉토리에 존재하는 데이터 파일을 삭제합니다.
		 */
        public static void RemoveDataFile(string wordNameToRemove)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToRemove) || wordNameToRemove != ""), "wordNameToRemove 단어 이름이어야 합니다.");
	        if (string.IsNullOrWhiteSpace(wordNameToRemove) || wordNameToRemove == "")
	        {
		        return;
	        }

            string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordNameToRemove}.{FILE_EXTENSTION}";
            File.Delete(filePath);
        }

        /*
		 *  내보내기 hex string 데이터를 지정한 위치에 파일로 저장합니다.
		 */
        public static bool SaveExportData(string dataToSave)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(dataToSave) || dataToSave != ""), "저장할 데이터가 없습니다.");
	        if (string.IsNullOrWhiteSpace(dataToSave) || dataToSave == "")
	        {
		        return false;
	        }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // 확장자는 프로그램에서 고정시킴.
            saveFileDialog.DefaultExt = $".{EXPORT_WORDATA_FILE_EXTENSTION}";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
	            if (string.IsNullOrWhiteSpace(saveFileDialog.FileName) || saveFileDialog.FileName == string.Empty)
	            {
		            return false;
	            }
	            StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false);

                writer.Write(dataToSave);

                writer.Close();
            }
            else
            {
	            return false;
            }

            return true;
        }

        /*
		 *  지정한 경로에서 선택한 익스포트 데이터를 읽어서 반환합니다.
		 */
        public static bool LoadImportDataOrEmpty(out string dataHexString)
        {
	        OpenFileDialog openFileDialog = new OpenFileDialog();
            // 확장자는 프로그램에서 고정시킴.
            openFileDialog.DefaultExt = EXPORT_WORDATA_FILE_EXTENSTION;
            openFileDialog.Filter = $"|*.{EXPORT_WORDATA_FILE_EXTENSTION}";

            dataHexString = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
	        {
		        if (string.IsNullOrWhiteSpace(openFileDialog.FileName) || openFileDialog.FileName == string.Empty)
		        {
			        return false;
		        }
		        StreamReader reader = new StreamReader(openFileDialog.FileName);

		        dataHexString = reader.ReadToEnd();

		        reader.Close();
	        }
	        else
	        {
		        return false;
	        }

            return true;
        }

        /*
		 *  데이터 디렉토리에서 저장된 데이터 파일들을 전부 읽어서 리스트로 저장합니다.
		 */
        private static void loadFileListFromDataDir()
        {
            if(!Directory.Exists(WORDDATA_DIRECTORY_PATH))
            {
	            Directory.CreateDirectory(WORDDATA_DIRECTORY_PATH);
            }

	        string[] files = Directory.GetFiles(WORDDATA_DIRECTORY_PATH);
	        if (files.Length <= 0)
	        {
                // 아직 생성한 데이터가 없음.
		        return;
	        }

	        foreach (string file in files)
	        {
		        DataFileNameList.Add(Path.GetFileNameWithoutExtension(file));
	        }
        }
    }
}
