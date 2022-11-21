using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WordMemory.Data;

namespace WordMemory
{
    public static class FileManager
    {
        public static List<string> DataFileNameList = null;

        public static readonly string FILE_EXTENSTION = "wmd";
        public static readonly string EXPORT_WORDATA_FILE_EXTENSTION = "expwmd";
        public static readonly string SETTING_FILE_NAME = "setting";
        public static readonly string SETTING_FILE_EXTENSTION = "wmsetting";
        public static readonly string WORDDATA_DIRECTORY_PATH = "Data";
        //public static readonly string PROGRAM_PATH = "";

        public static void Initialize()
        {
	        DataFileNameList = new List<string>(2048);
	        loadFileListFromDataDir();
        }
        public static void Release()
        {
	        DataFileNameList.Clear();
	        DataFileNameList = null;
        }

        public static void SaveProgramSettingToFile(string dataToSave)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(dataToSave) || dataToSave != ""), "저장할 데이터가 존재하지 않습니다.");

	        string filePath = $"{SETTING_FILE_NAME}.{SETTING_FILE_EXTENSTION}";
	        // 기존 모든 내용을 무시하고 덮어쓰기.
	        StreamWriter writer = new StreamWriter(filePath, false);

	        writer.Write(dataToSave);

	        writer.Close();
	        writer = null;
        }

        public static void LoadProgramSettingFromFile(out string settingString)
        {
            string filePath = $"{SETTING_FILE_NAME}.{SETTING_FILE_EXTENSTION}";
            //FileStream file = new FileStream(filePath, FileMode.Open);

            StreamReader reader = new StreamReader(filePath);
            // 데이터를 처음부터 끝까지 읽어옴.
            settingString = reader.ReadToEnd();

            // 데이터가 덮어 써지는지 확인하고 안덮어지면 수정.
            reader.Close();
            //file.Close();
 
            //file = null;
            reader = null;
        }

        public static void SaveWordDataToFile(string wordName, string dataToSave)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordName) || wordName != ""), "wordName은 단어 이름이어야 합니다.");
            Debug.Assert((!string.IsNullOrWhiteSpace(dataToSave) || dataToSave != ""), "저장할 데이터가 없습니다.");

            string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordName}.{FILE_EXTENSTION}";
            // 기존 모든 내용을 무시하고 덮어쓰기.
            StreamWriter writer = new StreamWriter(filePath, false);

            writer.Write(dataToSave);

            writer.Close();
            writer = null;
        }

        // 단어 이름으로 로드
        public static void LoadWordDataFromFile(string wordNameToLoad, out string wordDataString)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != ""), "WordNameToLoad 단어 이름이어야 합니다.");

            string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordNameToLoad}.{FILE_EXTENSTION}";
            //FileStream file = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(filePath);
            wordDataString = reader.ReadToEnd();

            // 데이터가 덮어 써지는지 확인하고 안덮어지면 수정.
            reader.Close();
            //file.Close();

            //file = null;
            reader = null;
        }

        public static void RemoveDataFile(string wordNameToRemove)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToRemove) || wordNameToRemove != ""), "wordNameToRemove 단어 이름이어야 합니다.");

	        string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordNameToRemove}.{FILE_EXTENSTION}";
            File.Delete(filePath);
        }

        public static bool SaveExportData(string dataToSave)
        {
	        Debug.Assert((!string.IsNullOrWhiteSpace(dataToSave) || dataToSave != ""), "저장할 데이터가 없습니다.");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // 확장자는 프로그램에서 고정시킴.
            saveFileDialog.DefaultExt = EXPORT_WORDATA_FILE_EXTENSTION;
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

        public static bool LoadImportDataOrEmpty(out string dataHexString)
        {
	        OpenFileDialog openFileDialog = new OpenFileDialog();
            // 확장자는 프로그램에서 고정시킴.
            openFileDialog.DefaultExt = EXPORT_WORDATA_FILE_EXTENSTION;
            openFileDialog.Filter = $"*.{EXPORT_WORDATA_FILE_EXTENSTION}";

            dataHexString = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
	        {
		        if (string.IsNullOrWhiteSpace(openFileDialog.FileName) || openFileDialog.FileName == string.Empty)
		        {
			        return false;
		        }

		        //Stream stream = openFileDialog.OpenFile();
		        StreamReader reader = new StreamReader(openFileDialog.FileName);

		        dataHexString = reader.ReadToEnd();

		       // stream.Close();
		        reader.Close();
	        }
	        else
	        {
		        return false;
	        }

            return true;
        }

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
