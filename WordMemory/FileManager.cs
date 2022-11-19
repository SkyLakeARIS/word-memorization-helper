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
        public static List<string> DataFileList = null;

        private static readonly string FILE_EXTENSTION = ".wmd";
        private static readonly string SETTING_FILE_NAME = "setting";
        private static readonly string SETTING_FILE_EXTENSTION = ".wmsetting";

        private static string wordDataFilePath;
        private static string programSettingPath;
        private static string writeBuffer = string.Empty;

        public static void Initialize()
        {
            wordDataFilePath = "//Data//";
            programSettingPath = String.Empty;
            DataFileList = new List<string>(1024);
        }
        public static void Release()
        {
            DataFileList = null;

        }

        public static void SaveProgramSettingToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

        }

        public static void LoadProgramSettingFromFile(out string settingString)
        {
            string filePath = $"{SETTING_FILE_NAME}{SETTING_FILE_EXTENSTION}";
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
            string filePath = $"{wordDataFilePath}{SETTING_FILE_NAME}{SETTING_FILE_EXTENSTION}";
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

        // 단어 이름으로 로드
        public static void LoadWordDataFromFile(string wordNameToLoad, out string wordDataString)
        {
            Debug.Assert((!string.IsNullOrWhiteSpace(wordNameToLoad) || wordNameToLoad != ""), "WordNameToLoad 단어 이름이어야 합니다.");

            string filePath = $"{wordDataFilePath}{wordNameToLoad}{FILE_EXTENSTION}";
            FileStream file = new FileStream(filePath, FileMode.Open);

            StreamReader reader = new StreamReader(file);
            wordDataString = reader.ReadToEnd();

            // 데이터가 덮어 써지는지 확인하고 안덮어지면 수정.
            file.Close();
            reader.Close();
            file = null;
            reader = null;
        }

        public static void ExportWordData()
        {
            // 할 수 있다면 여기에서 file manager 오픈
            // 원하는 경로로 지정.
            SaveFileDialog saveFileDialog = new SaveFileDialog();

        }

        public static void ImportWordData()
        {
            // 원하는 경로에서 읽기.
            // 파일 오픈

            // 확장자가 맞는지.

            // 데이터 로드하여 파일 생성


            // 다 끝나면 데이터 파일 다시 로드
        }

        public static void WriteHexStringAddWhiteSpace(string hexString)
        {
            writeBuffer += $" {hexString}";
        }

        public static void WriteHexString(string hexString)
        {
            writeBuffer += hexString;
        }

        public static void LoadFileListFromDataDir()
        {

        }
    }
}
