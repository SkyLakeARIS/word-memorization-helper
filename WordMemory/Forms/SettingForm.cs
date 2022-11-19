using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordMemory
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // 설정 load

            // 설정에 따라서 ui들 초기화
            string fileContent = "hello world!";
            fileContent = string.Format("{0:X2}", fileContent);
            fileContent = 153151.ToString("X2");
            MessageBox.Text = fileContent;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // 설정값 검증 후 저장
   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnExportWordData_Click(object sender, EventArgs e)
        {
            // export 데이터를 만들어서  지정 경로에 파일로 저장.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

            
            string fileName = "C:\\Users\\KMS-LT\\Desktop\\binary.wmd";
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            string fileContent = "hello, this is converter test.";

            string result = MyConverter.StringToHex(fileContent);
            MessageBox.Text = result;
            //writer.Write(result);
            var a = Encoding.UTF8.GetBytes(result);
            fs.Write(a, 0, a.Length);
            // writer.Close();
            fs.Close();
        }

        private void btnImportWordData_Click(object sender, EventArgs e)
        {
            // export 데이터를 로드해서 데이터 파일로 분리 저장 후, 데이터 파일 재로드

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            if(string.IsNullOrEmpty(openFileDialog.FileName) || string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                return;
            }
            Stream file =  openFileDialog.OpenFile();

            StreamReader reader = new StreamReader(file);

            string line = MyConverter.HexToString(reader.ReadLine());

            MessageBox.Text = line;

            file.Close();
            reader.Close();
        }

    }
}
