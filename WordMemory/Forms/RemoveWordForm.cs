using System;
using System.Windows.Forms;
using WordMemory.Data;

namespace WordMemory
{
    public partial class RemoveWordForm : Form
    {
	    private WordData mfoundData;
	    private bool mIsRemoveWord;

        public RemoveWordForm()
        {
            InitializeComponent();
        }

        private void RemoveWordForm_Load(object sender, EventArgs e)
        {
            // 초기 설정
            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "";
            header1.Name = "Mean";
            header1.Width = WordManager.MEAN_STRING_LENGTH_LIMIT;

            MeanListView.View = View.Details;
            MeanListView.Columns.Add(header1);
            MeanListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            MeanListView.Items.Clear();

            mIsRemoveWord = false;
        }

        private void btnFindWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Word.Text) || Word.Text == string.Empty)
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (Word.Text.Length > WordManager.WORD_STRING_LENGTH_LIMIT)
            {
	            MessageBox.Text = $"입력 가능한 단어 길이는 {WordManager.WORD_STRING_LENGTH_LIMIT}자 입니다. 현 {Word.Text.Length}자";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            // 검색 후, 결과 표시
            if (WordManager.FindWordDataOrNull(Word.Text.ToLower(), out mfoundData))
            {
	            Word.Text = mfoundData.WordName;

	            MeanListView.BeginUpdate();

	            MeanListView.Items.Clear();
	            foreach (string mean in mfoundData.MeanList)
	            {
		            MeanListView.Items.Add(mean);
	            }

	            MeanListView.EndUpdate();

	            Memo.Text = mfoundData.Memo;

	            // 안내 메세지
	            MessageBox.Text = "이제 삭제할 수 있습니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
	            // 안내 메세지
	            MessageBox.Text = "검색 결과가 없습니다. 단어를 확인하세요.(대소문자를 구분하지 않습니다.)";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            // 삭제
            if (string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if(mfoundData == null)
            {
	            MessageBox.Text = "먼저 단어를 검색해 주세요.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }
            // 확인 버튼이 설정되어 있는지(실수 방지용으로 확인 용 라디오버튼)
            
            if (WordManager.RemoveWordData(mfoundData))
            {
	            MessageBox.Text = $"삭제 완료. {Word.Text}";
	            MessageBox.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
	            MessageBox.Text = $"삭제 실패. {Word.Text}";
                MessageBox.ForeColor = System.Drawing.Color.Red;
            }


            // 후처리
            Word.Text = string.Empty;

            MeanListView.BeginUpdate();

            MeanListView.Items.Clear();

            MeanListView.EndUpdate();

            Memo.Text = string.Empty;
            mfoundData = null;
            mIsRemoveWord = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
	        mfoundData = null;
	        if (mIsRemoveWord)
	        {
		        DialogResult = DialogResult.OK;
	        }
	        else
	        {
		        DialogResult = DialogResult.Cancel;
	        }
        }

        private void Word_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnFindWord_Click(sender, e);
            }
        }

    }
}
