using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WordMemory
{
    public static class FileManager
    {
        public static List<string> DataFileNameList = null;

        private static readonly string FILE_EXTENSTION = "wmd";
        private static readonly string EXPORT_WORDATA_FILE_EXTENSTION = "expwmd";
        private static readonly string SETTING_FILE_NAME = "setting";
        private static readonly string SETTING_FILE_EXTENSTION = "wmsetting";
        private static readonly string WORDDATA_DIRECTORY_PATH = "//Data";
        private static readonly string PROGRAM_PATH = "";

        private static string writeBuffer = string.Empty;

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

        public static void SaveProgramSettingToFile()
        {
	        saveFile(PROGRAM_PATH, SETTING_FILE_NAME, SETTING_FILE_EXTENSTION);
        }

        public static void LoadProgramSettingFromFile(out string settingString)
        {
            string filePath = $"{SETTING_FILE_NAME}.{SETTING_FILE_EXTENSTION}";
            FileStream file = new FileStream(filePath, FileMode.Open);

            StreamReader reader = new StreamReader(file);
            settingString = reader.ReadToEnd();

            // 데이터가 덮어 써지는지 확인하고 안덮어지면 수정.
            file.Close();
            reader.Close();
            file = null;
            reader = null;
        }

        public static void SaveWordDataToFile(string wordName)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordName) || wordName != ""), "wordName은 단어 이름이어야 합니다.");
            Debug.Assert((!string.IsNullOrWhiteSpace(writeBuffer) || writeBuffer != ""), "버퍼에 기록된 내용이 없습니다.");

            saveFile(WORDDATA_DIRECTORY_PATH, wordName, FILE_EXTENSTION);
        }

        // 단어 이름으로 로드
        public static void LoadWordDataFromFile(string wordNameToLoad, out string wordDataString)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != ""), "WordNameToLoad 단어 이름이어야 합니다.");

            string filePath = $"{WORDDATA_DIRECTORY_PATH}//{wordNameToLoad}.{FILE_EXTENSTION}";
            FileStream file = new FileStream(filePath, FileMode.Open);

            StreamReader reader = new StreamReader(file);
            wordDataString = reader.ReadToEnd();

            // 데이터가 덮어 써지는지 확인하고 안덮어지면 수정.
            file.Close();
            reader.Close();
            file = null;
            reader = null;
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

	            Stream stream = saveFileDialog.OpenFile();
                StreamWriter writer = new StreamWriter(stream);

                writer.Write(dataToSave);

                stream.Close();
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

            string result = string.Empty;
	        if (openFileDialog.ShowDialog() == DialogResult.OK)
	        {
		        if (string.IsNullOrWhiteSpace(openFileDialog.FileName) || openFileDialog.FileName == string.Empty)
		        {
			        dataHexString = string.Empty;
			        return false;
		        }

		        Stream stream = openFileDialog.OpenFile();
		        StreamReader reader = new StreamReader(stream);

		        dataHexString = reader.ReadToEnd();

		        stream.Close();
		        reader.Close();
	        }
	        else
	        {
		        dataHexString = string.Empty;
		        return false;
	        }

            return true;
        }

        public static void WriteHexStringAddWhiteSpace(string hexString)
        {
            writeBuffer += $" {hexString}";
        }

        public static void WriteHexString(string hexString)
        {
            writeBuffer += hexString;
        }

        private static void loadFileListFromDataDir()
        {
	        string[] files = Directory.GetFiles(WORDDATA_DIRECTORY_PATH);
	        foreach (string file in files)
	        {
		        DataFileNameList.Add(Path.GetFileNameWithoutExtension(file));
	        }
        }

        private static void saveFile(string path, string fileName, string extension)
        {
	        string filePath = $"{path}//{fileName}.{extension}";
	        FileStream file = new FileStream(filePath, FileMode.Open);
	        StreamWriter writer = new StreamWriter(file);
	        writer.Flush();

	        // 데이터가 덮어 써지는지 확인하고 안덮어지면 수정.
	        writer.Write(writeBuffer);

	        file.Close();
	        writer.Close();
	        file = null;
	        writer = null;
	        writeBuffer = string.Empty;
        }
    }
}
