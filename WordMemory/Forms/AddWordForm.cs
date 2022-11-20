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

namespace WordMemory
{
 
    public partial class AddWordForm : Form
    {

        //public const WordClassData[] WordClassTypes = new WordClassData[8] {
        //WordClassData(eWordClass.NOUN, "명사" ),
        //WordClassData(eWordClass.VERB, "동사" ),
        //WordClassData(eWordClass.ADJECTIVE, "형용사" ),
        //WordClassData(eWordClass.PREPOSITION, "전치사" ),
        //WordClassData(eWordClass.CONJUNCTION, "접속사" ),
        //WordClassData(eWordClass.PRONOUN, "대명사" ),
        //WordClassData(eWordClass.INTERJECTION, "감탄사" )
        //};
        private WordClassData mSelectedWorldClass;

        public AddWordForm()
        {
            InitializeComponent();
        }

        private void AddWordForm_Load(object sender, EventArgs e)
        {
            // 초기 세팅 
            // 메세지나 그런 안내문자 그리고 기본 값 세팅

            // 콤보 박스 데이터 바인드
            WordClassCombo.DataSource = WordClassData.DataList;
            WordClassCombo.DisplayMember = "WordClassName";
            WordClassCombo.ValueMember = "WordClassName";

            // 리스트 뷰 초기화 
            // 빈 데이터가 하나 들어있는 상태이기 때문에 나중에 일일이 처리해줄바에
            // 비우는게 좋음.
            MeanListView.Items.Clear();
        }

        private void btnAddMean_Click(object sender, EventArgs e)
        {
            string inputMean = InputMean.Text;
            if(String.IsNullOrEmpty(inputMean) || String.IsNullOrWhiteSpace(inputMean))
            {
                MessageBox.Text = "뜻을 입력해주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if(mSelectedWorldClass.WordClassType == eWordClass.NULL)
            {
                MessageBox.Text = "품사를 설정해주세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (MeanListView.Items.Count > WordManager.MEAN_COUNT_LIMIT)
            {
	            MessageBox.Text = $"뜻 등록은 최대 {WordManager.MEAN_COUNT_LIMIT}개 입니다.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            if (inputMean.Length > WordManager.MEAN_STRING_LENGTH_LIMIT)
            {
	            MessageBox.Text = $"뜻 최대 입력 길이는 {WordManager.MEAN_STRING_LENGTH_LIMIT}자입니다. 현{inputMean.Length}자";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }



            MeanListView.BeginUpdate();

            string meanString = $"({mSelectedWorldClass.WordClassName[0]}){inputMean}";
            MeanListView.Items.Add(meanString);

            MeanListView.EndUpdate();

            mSelectedWorldClass = null;
            InputMean.Text = string.Empty;
            WordClassCombo.SelectedIndex = 0;

            MessageBox.Text = "잘못 추가했다면 리스트 항목을 더블클릭하여 제거할 수 있습니다.";
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

        private void WordClassCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox wordClass = sender as ComboBox;
            // eWordClass와 같은 정수 값과 매칭되도록 ComboBox를 설정.
            if(wordClass.SelectedIndex == -1)
            {
                MessageBox.Text = "품사가 선택되지 않았습니다.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 선택한 품사 데이터를 저장해서 뜻 추가할 때 문자열로 만들 것.
            mSelectedWorldClass = WordClassData.DataList[wordClass.SelectedIndex];
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            // 입력 값 체크
            // 단어 입력 검사
            if(string.IsNullOrWhiteSpace(Word.Text) || Word.Text == string.Empty)
            {
                MessageBox.Text = "단어를 입력하세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (Word.Text.Length > WordManager.WORD_STRING_LENGTH_LIMIT)
            {
	            MessageBox.Text = $"입력 가능한 단어 길이는 {WordManager.WORD_STRING_LENGTH_LIMIT}자 입니다. 현 {Word.Text.Length}자";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            // 영어인지 체크. 정규식
            if(true)
            {

            }

            // 뜻 체크
            if(MeanListView.Items.Count <= 0)
            {
                MessageBox.Text = "뜻을 하나 이상 등록하세요.";
                MessageBox.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 메모 길이 체크
            if (Memo.Text.Length > WordManager.MEMO_STRING_LENGTH_LIMIT)
            {
	            MessageBox.Text = $"메모 입력 가능 길이는 최대 {WordManager.MEMO_STRING_LENGTH_LIMIT}자 입니다. 현{Memo.Text.Length}자.";
	            MessageBox.ForeColor = System.Drawing.Color.Red;
	            return;
            }

            List<string> meanList = new List<string>(16);
            foreach (string mean in MeanListView.Items)
            {
                meanList.Add(mean);
            }
            WordManager.AddWordData(Word.Text.ToLower(), meanList, Memo.Text);
            meanList = null;

            // 등록 후, 후처리
            Word.Text = string.Empty;
            InputMean.Text = string.Empty;
            WordClassCombo.SelectedIndex = 0;
            Memo.Text = string.Empty;
            MeanListView.BeginUpdate();

            MeanListView.Items.Clear();

            MeanListView.EndUpdate();

            MessageBox.Text = $"추가 완료 {Word.Text.ToLower()}";
            MessageBox.ForeColor = System.Drawing.Color.Green;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            return;
        }

        private void MeanListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MeanListView.SelectedItems.Count <= 0)
            {
                return;
            }

            string selectedData = $"제거됨 : {MeanListView.SelectedItems[0].Text}.";

            MeanListView.BeginUpdate();

            MeanListView.SelectedItems[0].Remove();

            MeanListView.EndUpdate();

            MessageBox.Text = selectedData;
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
    }
}
