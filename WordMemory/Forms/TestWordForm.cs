using System;
using System.Drawing;
using System.Windows.Forms;
using WordMemory.Data;

namespace WordMemory
{
    public partial class TestWordForm : Form
    {
	    private WordData mWordData;
	    private string mStartWord;

        public TestWordForm()
        {
            InitializeComponent();
        }

        private void TestWordForm_Load(object sender, EventArgs e)
        {
	        ColumnHeader header1 = new ColumnHeader();
	        header1.Text = "";
	        header1.Name = "Mean";
	        header1.Width = WordManager.MEAN_STRING_LENGTH_LIMIT;
            
            MeanListView.View = View.Details;
	        MeanListView.Columns.Add(header1);
	        MeanListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

	        MessageBox.Text = "뜻에 맞는 단어를 입력합니다..\n 체점 기준은 등록된 단어와 '정확한' 단어를 입력해야 합니다.";
	        MessageBox.ForeColor = System.Drawing.Color.Red;

            MeanListView.Items.Clear();

			updataWordData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
	        if(string.IsNullOrWhiteSpace(Word.Text) || Word.Text == string.Empty)
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (Word.Text.Length >= WordManager.WORD_STRING_LENGTH_LIMIT)
            {
	            MessageBox.Text = $"{WordManager.WORD_STRING_LENGTH_LIMIT}자 이내로 입력해 주세요.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            Word.Text = Word.Text.ToLower();

            if (mWordData.WordName.Equals(Word.Text))
            {
	            MessageBox.Text = "정답입니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
	            MessageBox.Text = "오답입니다. 미암기로 분류됩니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
                mWordData.UpdateRememberType(ERememberType.NOT_REMEMBER);
                WordManager.MoveWordDataToNotRememberList(mWordData.WordName);
            }

            Word.Text = string.Empty;
            mWordData = null;
            MeanListView.Items.Clear();

            // 정답시 타이머로 2-3초 딜레이를 준 다음 다음문제로 넘어가도록 하는 것도 좋을 듯.
            updataWordData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
	        mWordData = null;
            DialogResult = DialogResult.Cancel;
        }

        private void Word_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if(e.KeyChar == KEY_ENTER)
            {
                btnSubmit_Click(sender, e);
            }
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
	        MeanListView.BeginUpdate();
	        foreach (string mean in mWordData.MeanList)
	        {
		        MeanListView.Items.Add(mean);
	        }
	        MeanListView.EndUpdate();
        }
    }
}
