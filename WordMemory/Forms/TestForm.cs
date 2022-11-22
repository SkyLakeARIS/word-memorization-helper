using System;
using System.Windows.Forms;

namespace WordMemory
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // 초기설정
        }

        private void btnStartWordTest_Click(object sender, EventArgs e)
        {
            // 단어 맞추기 모드 시작
            TestWordForm testWordForm = new TestWordForm();
            if (DialogResult.Cancel == testWordForm.ShowDialog() || DialogResult.OK == testWordForm.ShowDialog())
            {
                testWordForm.Close();
            }
        }

        private void btnStartMeanTest_Click(object sender, EventArgs e)
        {
            // 뜻 맞추기 모드 시작
            TestMeanForm testMeanForm = new TestMeanForm();
            if (DialogResult.Cancel == testMeanForm.ShowDialog() || DialogResult.OK == testMeanForm.ShowDialog())
            {
                testMeanForm.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 닫기
            DialogResult = DialogResult.Cancel;
        }
    }
}
