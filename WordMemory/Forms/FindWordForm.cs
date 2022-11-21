using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemory.BindingData;
using WordMemory.Data;

namespace WordMemory
{
    public partial class FindWordForm : Form
    {
	    private WordData foundData;
        public FindWordForm()
        {
            InitializeComponent();
        }

        private void FindWordForm_Load(object sender, EventArgs e)
        {
            // 초기 세팅
            // 콤보 박스 데이터 바인드
            WordClassCombo.DataSource = WordClassData.DataList;
            WordClassCombo.DisplayMember = "WordClassName";
            WordClassCombo.ValueMember = "WordClassName";

            foundData = null;
            // 리스트 뷰 초기화 
            // 빈 데이터가 하나 들어있는 상태이기 때문에 나중에 일일이 처리해줄바에
            // 비우는게 좋음.
            MeanListView.Items.Clear();

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
            if (WordManager.FindWordData(Word.Text.ToLower(), out foundData))
            {
	            Word.Text = foundData.WordName;

	            MeanListView.BeginUpdate();

	            MeanListView.Items.Clear();
                foreach (string mean in foundData.MeanList)
	            {
		            MeanListView.Items.Add(mean);
	            }

                MeanListView.EndUpdate();

                Memo.Text = foundData.Memo;

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
	        foundData = null;
            DialogResult = DialogResult.Cancel;
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
	        if (foundData == null)
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

            // 데이터가 변경된 것이 있는지 체크. 

            // 단어명은 체크하지 않는다. (그렇다면 입력되서 변경된 단어 이름을 따로 알아낼 방법 고려)

            // 변경되었으면 더티비트 체크

            // 해시에서 가져온 워드 데이터이면, 왠지 foundData도 같은 메모리를 가질 것 같음.
            // 따라서 테스트에서 update 메서드만 호출해서 반영되는지 확인 필요하고 되면, 워드 매니저, 테이블에서 업데이트 함수 제거
            // 또, 된다는 가정하에, 입력 데이터가 바뀌면 이벤트 호출을 통해서 어느 부분이 변경되었는지 체크 후, 그 부분만 업데이트.

            // 뜻 업데이트
            List<string> meanList = new List<string>(WordManager.MEAN_COUNT_LIMIT);
            for (Int32 index = 0; index < MeanListView.Items.Count; ++index)
            {
                meanList.Add(MeanListView.Items[index].Text);
            }

            foundData.UpdateMeanData(meanList);
            meanList = null;


            // 암기 여부도 수정할 수 있도록 제공.

            // 암기 여부 업데이트
            //foundData.UpdateRememberType(foundData.RememberType);

            // 메모 업데이트
            foundData.UpdateMemo(Memo.Text);

            WordManager.UpdateWordData(foundData);

            // 후처리
            Word.Text = string.Empty;

            MeanListView.BeginUpdate();

            MeanListView.Items.Clear();

            MeanListView.EndUpdate();

            Memo.Text = string.Empty;

            WordClassCombo.SelectedIndex = 0;
            InputMean.Text = string.Empty;
            foundData = null;

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

    }
}
