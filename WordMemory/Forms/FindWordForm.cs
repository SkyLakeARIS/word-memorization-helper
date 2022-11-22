using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WordMemory.BindingData;
using WordMemory.Data;

namespace WordMemory
{
    public partial class FindWordForm : Form
    {
	    private WordData mFoundData;
	    private bool mIsModifiyWord;
        public FindWordForm()
        {
            InitializeComponent();
        }

        private void FindWordForm_Load(object sender, EventArgs e)
        {
            // 초기 세팅
            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "";
            header1.Name = "Mean";
            header1.Width = WordManager.MEAN_STRING_LENGTH_LIMIT;

            MeanListView.View = View.Details;
            MeanListView.Columns.Add(header1);
            MeanListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // 콤보 박스 데이터 바인드
            WordClassCombo.DataSource = WordClassData.DataList;
            WordClassCombo.DisplayMember = "WordClassName";
            WordClassCombo.ValueMember = "WordClassName";

            rbtnRemember.Checked = false;
            rbtnNotRemember.Checked = false;

            mFoundData = null;
            // 리스트 뷰 초기화 
            // 빈 데이터가 하나 들어있는 상태이기 때문에 나중에 일일이 처리해줄바에
            // 비우는게 좋음.
            MeanListView.Items.Clear();

            mIsModifiyWord = false;
        }

    private void btnFindWord_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Word.Text) || Word.Text == string.Empty)
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
            if (WordManager.FindWordDataOrNull(Word.Text.ToLower(), out mFoundData))
            {
	            Word.Text = mFoundData.WordName;

	            MeanListView.BeginUpdate();

	            MeanListView.Items.Clear();
                foreach (string mean in mFoundData.MeanList)
	            {
		            MeanListView.Items.Add(mean);
	            }

                MeanListView.EndUpdate();

                Memo.Text = mFoundData.Memo;

                if (mFoundData.RememberType == ERememberType.REMEMBER)
                {
	                rbtnRemember.Checked = true;
                }
                else
                {
	                rbtnNotRemember.Checked = true;
                }

                // 안내 메세지
                MessageBox.Text = "수정시 단어 이름을 제외한 나머지 내용만 반영됩니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
	            // 안내 메세지
	            MessageBox.Text = "검색 결과가 없습니다. 단어를 확인하세요.(대소문자를 구분하지 않습니다.)";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
	        mFoundData = null;
	        if (mIsModifiyWord)
	        {
		        DialogResult = DialogResult.OK;
	        }
	        else
	        {
		        DialogResult = DialogResult.Cancel;
	        }
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
	        if (mFoundData == null)
	        {
		        MessageBox.Text = "단어를 먼저 검색하여 데이터를 초기화하세요.";
		        MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
	        }

            if(string.IsNullOrWhiteSpace(InputMean.Text) || InputMean.Text == string.Empty)
            {
                MessageBox.Text = "뜻을 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            if(WordClassCombo.SelectedIndex == -1 || WordClassData.DataList[WordClassCombo.SelectedIndex].WordClassType == EWordClass.NULL)
            {
                MessageBox.Text = "품사를 선택해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (MeanListView.Items.Count >= WordManager.MEAN_COUNT_LIMIT)
            {
	            MessageBox.Text = $"뜻 등록은 최대 {WordManager.MEAN_COUNT_LIMIT}개 입니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            if (InputMean.Text.Length > WordManager.MEAN_STRING_LENGTH_LIMIT)
            {
	            MessageBox.Text = $"뜻 최대 입력 길이는 {WordManager.MEAN_STRING_LENGTH_LIMIT}자입니다. 현{InputMean.Text.Length}자";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            MeanListView.BeginUpdate();

            MeanListView.Items.Add($"({WordClassData.DataList[WordClassCombo.SelectedIndex].WordClassName[0]}){InputMean.Text}");

            MeanListView.EndUpdate();

            // 후처리
            InputMean.Text = string.Empty;
            WordClassCombo.SelectedIndex = 0;
        }

        private void Word_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int KEY_ENTER = 13;
            if (e.KeyChar == KEY_ENTER)
            {
                btnFindWord_Click(sender, e);
            }
        }

        private void btnModifyWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Word.Text) || string.IsNullOrWhiteSpace(Word.Text))
            {
                MessageBox.Text = "단어를 입력해 주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (MeanListView.Items.Count <= 0)
            {
	            MessageBox.Text = $"뜻은 최소 하나 이상 등록해야 합니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            // 단어명은 업데이트X

            // 뜻 업데이트
            List<string> meanList = new List<string>(WordManager.MEAN_COUNT_LIMIT);
            for (Int32 index = 0; index < MeanListView.Items.Count; ++index)
            {
                meanList.Add(MeanListView.Items[index].Text);
            }

            mFoundData.UpdateMeanData(meanList);
            meanList = null;

            // 메모 업데이트
            mFoundData.UpdateMemo(Memo.Text);

            // 암기 여부 업데이트
            ERememberType isRemember = ERememberType.REMEMBER;
            if (rbtnNotRemember.Checked)
            {
	            isRemember = ERememberType.NOT_REMEMBER;
            }

            if (isRemember != mFoundData.RememberType)
            {
	            mFoundData.UpdateRememberType(isRemember);
            }

            WordManager.UpdateWordData(mFoundData);

            // 후처리
            Word.Text = string.Empty;

            MeanListView.BeginUpdate();

            MeanListView.Items.Clear();

            MeanListView.EndUpdate();

            Memo.Text = string.Empty;

            WordClassCombo.SelectedIndex = 0;
            InputMean.Text = string.Empty;
            mFoundData = null;
            mIsModifiyWord = true;

            MessageBox.Text = $"수정 되었습니다.";
            MessageBox.ForeColor = System.Drawing.Color.Green;
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

        private void rbtnRememberFirst_CheckedChanged(object sender, EventArgs e)
        {
	        rbtnRemember.Checked = true;
        }

        private void rbtnNotRememberFirst_CheckedChanged(object sender, EventArgs e)
        {
	        rbtnNotRemember.Checked = true;
        }

    }
}
