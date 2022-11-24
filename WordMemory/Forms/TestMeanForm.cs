using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WordMemory.Data;

namespace WordMemory
{
    public partial class TestMeanForm : Form
    {
	    private WordData mWordData = null;
        // 처음 시작한 단어를 저장하고, 한 사이클을 돌았는지 확인합니다.
	    private string mStartWord;
        public TestMeanForm()
        {
            InitializeComponent();
        }

        private void TestMeanForm_Load(object sender, EventArgs e)
        {
	        ColumnHeader header1 = new ColumnHeader();
	        header1.Text = "";
	        header1.Name = "Mean";
	        header1.Width = WordManager.MEAN_STRING_LENGTH_LIMIT;

            MeanListView.View = View.Details;
	        MeanListView.Columns.Add(header1);
	        MeanListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            MeanListView.Items.Clear();

            MessageBox.Text = "품사를 제외한 뜻만 입력하여 등록합니다.\n 체점 기준은 등록된 뜻과 '정확한' 뜻을 입력해야 합니다.\n 입력한 뜻 전부 혹은 과반수 이상 정답시 정답입니다. ";
            MessageBox.ForeColor = System.Drawing.Color.Red;

            updataWordData();
            // 시작점 데이터 저장.
            if (mWordData != null)
            {
	            mStartWord = mWordData.WordName;
            }
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
	        if (InputMean.Text.Length <= 0)
	        {
		        MessageBox.Text = "뜻을 입력하세요.";
		        MessageBox.ForeColor = System.Drawing.Color.Red;
		        return;
	        }
            // 뜻 추가
            MeanListView.BeginUpdate();

            MeanListView.Items.Add(InputMean.Text);

            MeanListView.EndUpdate();

            InputMean.Text = string.Empty;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(MeanListView.Items.Count <= 0)
            {
                MessageBox.Text = "뜻을 하나 이상 등록하세요.\n 기억이 안나면 아무거나 입력 후 제출합니다.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            List<string> meanListWithoutWordClass = new List<string>(16);

            foreach (string mean in mWordData.MeanList)
            {
                // 품사 부분을 떼어내고 뜻 부분만 추출.
                string[] splited = mean.Split(')');
                meanListWithoutWordClass.Add(splited[1]);
            }

            Int32 correctCount = 0;

            for (Int32 myAnwerIndex = 0; myAnwerIndex < MeanListView.Items.Count; ++myAnwerIndex)
            {
	            for (Int32 correctIndex = 0; correctIndex < meanListWithoutWordClass.Count; ++correctIndex)
	            {
		            if (MeanListView.Items[myAnwerIndex].Text.Equals(meanListWithoutWordClass[correctIndex]))
		            {
			            ++correctCount;
                        // 정답시 다음 제출 답안을 검사합니다.
                        goto NEXT_LOOP;
		            }
	            }
                NEXT_LOOP:
                // 왜 구문이 하나는 있어야 goto가 작동하는가..
                correctCount = correctCount;
            }

            if (MeanListView.Items.Count == correctCount || correctCount >= (meanListWithoutWordClass.Count/2))
            {
	            MessageBox.Text = $"정답입니다. \n제출한 {MeanListView.Items.Count}중 {correctCount}개 정답(총{meanListWithoutWordClass.Count}개)";
	            MessageBox.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
	            MessageBox.Text = $"오답입니다. 미암기로 분류됩니다.\n제출한 {MeanListView.Items.Count}중 {correctCount}개 정답(총{meanListWithoutWordClass.Count}개)";
	            MessageBox.ForeColor = System.Drawing.Color.Green;
                
	            mWordData.UpdateRememberType(ERememberType.NOT_REMEMBER);
            }
            InputMean.Text = string.Empty;

            mWordData = null;

            // 다음 문제
            updataWordData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
	        mWordData = null;
            DialogResult = DialogResult.Cancel;
        }

        private void InputMean_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnAddMean_Click(sender, e);
            }
        }

        private void MeanListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MeanListView.SelectedItems.Count <= 0)
            {
                return;
            }
            string selectedData = $"제거됨 : {MeanListView.SelectedItems[0].Text}.";

            MeanListView.BeginUpdate();

            MeanListView.Items.Remove(MeanListView.SelectedItems[0]);

            MeanListView.EndUpdate();
            MessageBox.Text = selectedData;
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

        private void updataWordData()
        {
            // 암기된 단어리스트에서 데이터를 하나 가져옵니다.
	        mWordData = WordManager.GetWodDataOrNullBy(ERememberType.REMEMBER);

	        // 추가된 데이터가 없을 경우. (혹은 표시할 데이터가 없을 경우.)
            if (mWordData == null)
            {
				// 더이상 데이터가 없습니다.
				MessageBox.Text = "암기된 데이터가 없습니다.";
                MessageBox.ForeColor = Color.Red;
                return;
            }

            if (mWordData.WordName.Equals(mStartWord))
            {
	            MessageBox.Text = "더이상 테스트할 데이터가 없습니다.";
	            MessageBox.ForeColor = Color.Red;
	            return;
            }

            // UI로 데이터 갱신
            Word.Text = mWordData.WordName;
        }
    }
}
